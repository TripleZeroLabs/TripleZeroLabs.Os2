#Requires -Version 5.1
<#
.SYNOPSIS
    Signs built TripleZeroLabs.Os2 DLLs and EXEs so Smart App Control / Defender trusts them.
.DESCRIPTION
    Invoked automatically from Directory.Build.targets after each build. Signs every
    TripleZeroLabs.Os2*.dll and TripleZeroLabs.Os2*.exe in the given folder with Azure
    Trusted Signing so Smart App Control trusts them by certificate rather than
    cloud reputation.

    Smart App Control blocks unsigned assemblies by cloud reputation, so a freshly-built
    DLL or EXE with no reputation gets blocked at random. Signing makes SAC trust them
    by certificate instead.

    Best-effort by design: if the Azure credentials, signtool, the dlib, or the metadata
    file are missing, it prints a warning and exits 0 so it NEVER breaks a build. Files
    that already carry a valid signature are skipped.
.PARAMETER Folder
    Folder containing the files to sign (normally the project's build output directory).
.PARAMETER Pattern
    Glob passed to Get-ChildItem -Filter. Defaults to TripleZeroLabs.Os2* (our assemblies
    only; third-party DLLs keep their own signatures).
#>
param(
    [Parameter(Mandatory)][string]$Folder,
    [string]$Pattern = 'TripleZeroLabs.Os2*'
)

$ErrorActionPreference = 'Continue'

if (-not (Test-Path $Folder)) { exit 0 }

# Sign .dll and .exe only — skip .pdb, .xml, .deps.json, etc.
$targets = @(Get-ChildItem -Path $Folder -Filter $Pattern -File -ErrorAction SilentlyContinue |
    Where-Object { $_.Extension -in '.dll', '.exe' })
if ($targets.Count -eq 0) { exit 0 }

# --- Azure Trusted Signing credentials (skip if absent) --------------------------
foreach ($v in 'AZURE_CLIENT_ID', 'AZURE_CLIENT_SECRET', 'AZURE_TENANT_ID') {
    if (-not [Environment]::GetEnvironmentVariable($v)) {
        Write-Warning "Debug signing skipped: $v is not set. Built files remain unsigned; Smart App Control may block them."
        exit 0
    }
}

# --- signing-metadata.json (repo root; this script lives in <repo>\installer) -----
$repoRoot     = Split-Path -Parent (Split-Path -Parent $MyInvocation.MyCommand.Path)
$metadataJson = Join-Path $repoRoot 'signing-metadata.json'
if (-not (Test-Path $metadataJson)) {
    Write-Warning "Debug signing skipped: signing-metadata.json not found at $metadataJson (copy signing-metadata.sample.json and fill it in)."
    exit 0
}

# --- Locate signtool.exe ----------------------------------------------------------
$signTool = $env:SIGNTOOL_PATH
if (-not $signTool) {
    $kitsRoot = (Get-ItemProperty 'HKLM:\SOFTWARE\WOW6432Node\Microsoft\Windows Kits\Installed Roots' `
                    -ErrorAction SilentlyContinue).KitsRoot10
    if ($kitsRoot) {
        $signTool = Get-ChildItem "$kitsRoot\bin" -Filter 'signtool.exe' -Recurse -ErrorAction SilentlyContinue |
            Where-Object { $_.FullName -like '*x64*' } |
            Sort-Object LastWriteTime -Descending |
            Select-Object -First 1 -ExpandProperty FullName
    }
}
if (-not $signTool) {
    Write-Warning "Debug signing skipped: signtool.exe not found (set SIGNTOOL_PATH to override)."
    exit 0
}

# --- Locate the Azure Trusted Signing DLIB (any restored version) ------------------
$nugetRoot = $env:NUGET_PACKAGES
if (-not $nugetRoot) { $nugetRoot = "$env:USERPROFILE\.nuget\packages" }
$dlibRoot = Join-Path $nugetRoot 'microsoft.trusted.signing.client'
$dlib = $null
if (Test-Path $dlibRoot) {
    $dlib = Get-ChildItem $dlibRoot -Filter 'Azure.CodeSigning.Dlib.dll' -Recurse -ErrorAction SilentlyContinue |
        Where-Object { $_.FullName -like '*\x64\*' } |
        Sort-Object FullName -Descending |
        Select-Object -First 1 -ExpandProperty FullName
}
if (-not $dlib) {
    Write-Warning "Debug signing skipped: Azure.CodeSigning.Dlib.dll not found under $dlibRoot (run 'dotnet restore')."
    exit 0
}

# --- Sign each unsigned file -------------------------------------------------------
foreach ($file in $targets) {
    if ((Get-AuthenticodeSignature $file.FullName).Status -eq 'Valid') { continue }

    & $signTool sign /fd SHA256 /tr http://timestamp.digicert.com /td SHA256 `
        /dlib $dlib /dmdf $metadataJson $file.FullName
    if ($LASTEXITCODE -ne 0) {
        Write-Warning "Debug signing: signtool failed on $($file.Name) (exit $LASTEXITCODE); it remains unsigned."
    } else {
        Write-Host "  signed $($file.Name)" -ForegroundColor DarkGreen
    }
}

exit 0
