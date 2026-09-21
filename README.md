# TripleZeroLabs.Os2

A dependency-free WPF theme. No MaterialDesign, no MahApps — plain `ResourceDictionary` files
that compile to BAML. Drop it in, merge one URI, and every standard WPF control is styled.
Targets `net48`, `net8.0-windows`, and `net10.0-windows`.

---

## Installation

```
dotnet add package TripleZeroLabs.Os2
```

Or add the package reference manually:

```xml
<PackageReference Include="TripleZeroLabs.Os2" Version="0.1.0" />
```

---

## Quick Start

Merge the single theme entry point in `App.xaml`:

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/TripleZeroLabs.Os2;component/Themes/Theme.xaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

Or apply in code in `App.xaml.cs`:

```csharp
using TripleZeroLabs.Os2;

protected override void OnStartup(StartupEventArgs e)
{
    base.OnStartup(e);
    Os2Theme.Apply(this);
}
```

**Plugin / add-in hosts** — apply per-window to leave the host app's resources untouched:

```csharp
Os2Theme.Apply(myWindow);   // safe for VS extensions, CAD add-ins, Office plugins, etc.
```

Once applied, all standard WPF controls pick up OS2 styles automatically — no extra attributes needed.

---

## What's Included

### Implicit styles — automatic, no `Style=` needed

| Control | What changes |
|---|---|
| `Window` | Root `Foreground` set so TextBlocks inherit it |
| `TextBlock` | Segoe UI 13 px, `TextWrapping=Wrap` |
| `Label` | Segoe UI 13 px, TextPrimary foreground |
| `Button` | Solid primary blue, rounded, hover/pressed/disabled states |
| `TextBox` | Rounded border, focus ring, disabled tint |
| `PasswordBox` | Matches TextBox visually |
| `ComboBox` | Raised border, white popup with drop shadow |
| `ComboBoxItem` | Rounded, SurfaceAlt on hover |
| `CheckBox` | Rounded tick box, full-row hover background |
| `ListBox` | Light border, TextPrimary foreground |
| `DataGrid` | No outer border, horizontal dividers, generous cell padding |
| `DataGridColumnHeader` | SemiBold labels, sort arrows |
| `DataGridRow` | SurfaceAlt on hover |
| `DataGridCell` | 16,12 padding; blue + white when selected |
| `TabControl` | Surface tab strip with hairline baseline |
| `TabItem` | Primary underline on selected tab |
| `ContextMenu` | White, CornerRadius 6, soft drop shadow |
| `MenuItem` | Rounded, SurfaceAlt highlight, generous padding |

### Keyed styles — apply with `Style="{StaticResource KEY}"`

| Key | Control | Purpose |
|---|---|---|
| `OS2.Text.Heading` | TextBlock | 20 px SemiBold heading |
| `OS2.Text.Caption` | TextBlock | 11 px subdued caption |
| `OS2.Button.Secondary` | Button | Outlined primary-blue |
| `OS2.Button.Danger` | Button | Outlined red — open a confirm dialog |
| `OS2.Button.DangerSolid` | Button | Solid red — confirm the destructive action |
| `OS2.Button.Flat` | Button | Text-only (Cancel, Skip) |
| `OS2.Button.Success` | Button | Solid green — positive confirming action |
| `OS2.Button.SuccessSecondary` | Button | Outlined green |
| `OS2.Banner.Default` | Border | Neutral grey accent-bar notification |
| `OS2.Banner.Info` | Border | Blue-tinted notification |
| `OS2.Banner.Warning` | Border | Amber-tinted notification |
| `OS2.Banner.Danger` | Border | Red-tinted notification |
| `OS2.Dialog` | Border | Floating card with rounded corners and shadow |
| `OS2.Nav.ListBox` | ListBox | Sidebar nav container |
| `OS2.Nav.ListBoxItem` | ListBoxItem | Nav item with left active-bar indicator |

---

## Buttons

```xml
<!-- Primary (solid blue) — implicit, no style attribute -->
<Button Content="Save" />

<!-- All other variants are opt-in -->
<Button Style="{StaticResource OS2.Button.Secondary}"      Content="Export" />
<Button Style="{StaticResource OS2.Button.Danger}"         Content="Delete" />
<Button Style="{StaticResource OS2.Button.DangerSolid}"    Content="Yes, delete permanently" />
<Button Style="{StaticResource OS2.Button.Flat}"           Content="Cancel" />
<Button Style="{StaticResource OS2.Button.Success}"        Content="Publish" />
<Button Style="{StaticResource OS2.Button.SuccessSecondary}" Content="Download" />
```

---

## Os2MessageBox

A drop-in replacement for WPF's `MessageBox` with OS2 styling. Same overloads, same return type — find-replace `MessageBox` → `Os2MessageBox` and nothing else changes.

```csharp
using TripleZeroLabs.Os2;

// Simple
Os2MessageBox.Show("Settings saved.");

// With buttons and icon
var result = Os2MessageBox.Show(
    "Delete this item?", "Confirm",
    MessageBoxButton.OKCancel, MessageBoxImage.Warning);

if (result == MessageBoxResult.OK) { /* proceed */ }
```

`MessageBoxImage.Error` automatically promotes the confirm button to `OS2.Button.DangerSolid`.
`Enter` and `Escape` are wired to the appropriate buttons based on the button set.

---

## DataGrid

```xml
<DataGrid ItemsSource="{Binding Items}"
          AutoGenerateColumns="False"
          IsReadOnly="True"
          SelectionUnit="FullRow"
          HeadersVisibility="Column">
    <DataGrid.Columns>
        <DataGridTextColumn Header="Name"     Binding="{Binding Name}"     Width="*"   />
        <DataGridTextColumn Header="Category" Binding="{Binding Category}" Width="160" />
        <DataGridCheckBoxColumn Header="Active" Binding="{Binding Active}" Width="80" />
    </DataGrid.Columns>
</DataGrid>
```

**Highlight rows where a boolean is true** — `BasedOn` is required to preserve the hover state:

```xml
<DataGrid.RowStyle>
    <Style TargetType="{x:Type DataGridRow}" BasedOn="{StaticResource {x:Type DataGridRow}}">
        <Style.Triggers>
            <DataTrigger Binding="{Binding Active}" Value="True">
                <Setter Property="Background" Value="{DynamicResource OS2.Brush.RowHighlight}" />
            </DataTrigger>
        </Style.Triggers>
    </Style>
</DataGrid.RowStyle>
```

**Secondary text in template columns** — switch foreground on selection so it stays readable against the blue selected-row background:

```xml
<TextBlock Text="{Binding Subtitle}">
    <TextBlock.Style>
        <Style TargetType="TextBlock">
            <Setter Property="Foreground" Value="{DynamicResource OS2.Brush.TextSecondary}" />
            <Style.Triggers>
                <DataTrigger Value="True"
                             Binding="{Binding IsSelected, RelativeSource={RelativeSource AncestorType={x:Type DataGridRow}}}">
                    <Setter Property="Foreground" Value="{DynamicResource OS2.Brush.TextOnPrimarySubtle}" />
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </TextBlock.Style>
</TextBlock>
```

---

## Banners

```xml
<Border Style="{StaticResource OS2.Banner.Info}">
    <StackPanel>
        <TextBlock Text="Changes saved." FontWeight="SemiBold"
                   Foreground="{DynamicResource OS2.Brush.Primary}" />
        <TextBlock Text="Your changes are ready to publish." />
    </StackPanel>
</Border>

<!-- OS2.Banner.Default — neutral grey accent bar  -->
<!-- OS2.Banner.Warning — amber accent bar          -->
<!-- OS2.Banner.Danger  — red accent bar            -->
```

---

## Dialog card

```xml
<Border Style="{StaticResource OS2.Dialog}" MaxWidth="420" HorizontalAlignment="Center">
    <StackPanel>
        <TextBlock Text="Delete item?" Style="{StaticResource OS2.Text.Heading}" Margin="0,0,0,8" />
        <TextBlock Text="This will permanently remove the item. This action cannot be undone."
                   Margin="0,0,0,20" />
        <StackPanel Orientation="Horizontal" HorizontalAlignment="Right">
            <Button Style="{StaticResource OS2.Button.Flat}"       Content="Cancel"      Margin="0,0,8,0" />
            <Button Style="{StaticResource OS2.Button.DangerSolid}" Content="Yes, delete" />
        </StackPanel>
    </StackPanel>
</Border>
```

---

## Context menus

```csharp
using TripleZeroLabs.Os2;

element.ContextMenu = Os2ContextMenu.Create()
    .Item("Copy", () => Clipboard.SetText(value))
    .Separator()
    .Item("Open", () => OpenItem(id))
    .Build();
```

The returned `ContextMenu` picks up the implicit `ContextMenu` and `MenuItem` styles automatically.

---

## Resource reference

### Brushes — `{DynamicResource OS2.Brush.*}`

Always use `{DynamicResource}` (not `{StaticResource}`) for OS2 brush references.

| Key | Purpose |
|---|---|
| `OS2.Brush.Primary` | Brand blue — buttons, links, active indicators |
| `OS2.Brush.PrimaryHover` | Hover state |
| `OS2.Brush.PrimaryPressed` | Pressed state |
| `OS2.Brush.Accent` | Purple — secondary highlights |
| `OS2.Brush.Background` | Window / page background |
| `OS2.Brush.Surface` | Cards, tab strip, off-white fill |
| `OS2.Brush.SurfaceAlt` | Row hover, alternate fills |
| `OS2.Brush.Overlay` | Semi-transparent modal scrim |
| `OS2.Brush.Border` | Default control border |
| `OS2.Brush.BorderFocus` | Focus ring |
| `OS2.Brush.Toolbar` | Dark toolbar background |
| `OS2.Brush.ToolbarForeground` | White text on toolbar |
| `OS2.Brush.TextPrimary` | Main body text |
| `OS2.Brush.TextSecondary` | Subdued / caption text |
| `OS2.Brush.TextOnPrimary` | White — text on solid-Primary surfaces |
| `OS2.Brush.TextOnPrimarySubtle` | Light blue — secondary text on selected rows |
| `OS2.Brush.TextDisabled` | Disabled text |
| `OS2.Brush.Success` | Green |
| `OS2.Brush.Warning` | Amber |
| `OS2.Brush.Danger` | Red |
| `OS2.Brush.RowHighlight` | Light blue tint for highlighted DataGrid rows |

### Typed constants (C#)

Use `Os2ResourceKey` instead of magic strings:

```csharp
using TripleZeroLabs.Os2;

element.SetResourceReference(Control.ForegroundProperty, Os2ResourceKey.Brush.Primary);
var style     = (Style)FindResource(Os2ResourceKey.Button.Success);
var banner    = (Style)FindResource(Os2ResourceKey.Banner.Info);
var dialog    = (Style)FindResource(Os2ResourceKey.Dialog);
```

---

## Requirements

- Windows (WPF is Windows-only)
- One of: .NET Framework 4.8, .NET 8, or .NET 10
- No additional dependencies

---

---

## Building from source

```bash
git clone https://github.com/TripleZeroLabs/TripleZeroLabs.Os2.git
cd TripleZeroLabs.Os2
dotnet build
```

Run the gallery to see every control and state live:

```bash
cd TripleZeroLabs.Os2.Gallery
dotnet run
```

| Project | Purpose |
|---|---|
| `TripleZeroLabs.Os2` | The theme library — this is what you reference |
| `TripleZeroLabs.Os2.Gallery` | Runnable WPF app showing every control and its states |

---

## AI assistant onboarding

> This repo ships an [Agent Skill](os2-wpf-theme/SKILL.md) — a structured context file that
> teaches any compatible AI coding assistant how to apply the OS2 theme correctly. Once set up,
> your agent knows every resource key, which controls are auto-styled vs. opt-in, and the
> gotchas that silently break the theme.

Copy the skill folder into your project:

```bash
cp -r path/to/TripleZeroLabs.Os2/os2-wpf-theme ./os2-wpf-theme
```

### Claude Code

```bash
mkdir -p .claude/skills
cp -r os2-wpf-theme .claude/skills/os2-wpf-theme
```

Claude Code indexes `SKILL.md` on startup and loads the full body when you work on XAML. No further configuration needed.

### Cursor

```bash
mkdir -p .cursor/rules
cp os2-wpf-theme/SKILL.md .cursor/rules/os2-wpf-theme.mdc
cp os2-wpf-theme/references/resource-keys.md .cursor/rules/os2-resource-keys.mdc
```

### GitHub Copilot

```bash
cat os2-wpf-theme/SKILL.md >> .github/copilot-instructions.md
```

Or attach on demand in Copilot Chat: `@workspace #file:os2-wpf-theme/SKILL.md`

### ChatGPT

Upload [`os2-wpf-theme/SKILL.md`](os2-wpf-theme/SKILL.md) as a file attachment at the start of a conversation, or paste it into a Custom GPT's system instructions for permanent context.

### Gemini

```bash
mkdir -p .gemini
cat os2-wpf-theme/SKILL.md >> .gemini/context.md
```

Or paste the skill contents into a Gem system prompt.

### JetBrains AI Assistant

Open **Settings → AI Assistant → Prompt Library**, add a new entry, paste the contents of [`os2-wpf-theme/SKILL.md`](os2-wpf-theme/SKILL.md), and set its scope to the project.

### Any other agent

| Mechanism | What to use |
|---|---|
| System prompt / instructions | Paste `SKILL.md` content |
| Knowledge base / context files | Upload `SKILL.md` + `references/resource-keys.md` |
| `@file` / `#file` attachment | Reference `os2-wpf-theme/SKILL.md` inline |

The skill follows the open [Agent Skills spec](https://agentskills.io/specification) — any agent built to that standard picks it up automatically.

---

## License

MIT — free to use in commercial products. See [LICENSE](LICENSE) for the full text.
