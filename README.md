# TripleZeroLabs.Os2

> **Building with AI?** This repo ships an [Agent Skill](os2-wpf-theme/SKILL.md) that teaches your
> AI coding assistant — Claude Code, Cursor, GitHub Copilot, ChatGPT, Gemini, or any agent that
> supports the [Agent Skills](https://agentskills.io) spec — exactly how to apply this theme
> correctly. Your agent learns every resource key, which controls are auto-styled, and all the
> common gotchas, without you having to explain any of it. See
> [§ Onboarding Your AI Assistant](#onboarding-your-ai-assistant) below.

A dependency-free WPF theme. No MaterialDesign, no MahApps — plain `ResourceDictionary` files
that compile to BAML. Targets `net48`, `net8.0-windows`, and `net10.0-windows` so it works across
standalone desktop apps, plugin hosts, and embedded tool windows alike.

| Project | Purpose |
|---|---|
| `TripleZeroLabs.Os2` | The theme library. This is what you reference. |
| `TripleZeroLabs.Os2.Gallery` | Runnable WPF app showing every control and its states. |

---

## Getting Started

### 1. Clone and build the theme

Clone the repository and build it alongside your project. The output is a single `.dll` you
reference directly — no NuGet package required.

```bash
git clone https://github.com/TripleZeroLabs/TripleZeroLabs.Os2.git
cd TripleZeroLabs.Os2
dotnet build
```

To verify everything is working, run the gallery app — it opens a live window showing every
styled control:

```bash
cd TripleZeroLabs.Os2.Gallery
dotnet run
```

### 2. Add a reference to your project

Add a `ProjectReference` from your WPF project to the theme library:

```xml
<ProjectReference Include="..\TripleZeroLabs.Os2\TripleZeroLabs.Os2.csproj" />
```

If you placed the repo in a different location, adjust the path to match. The theme library
targets `net48`, `net8.0-windows`, and `net10.0-windows` — it resolves to the correct runtime
automatically based on your project's `TargetFramework`.

### 3. Apply the theme

**XAML — merge in `App.xaml`** (recommended for standalone apps)

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/TripleZeroLabs.Os2;component/Themes/Theme.xaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

**C# — call `Os2Theme.Apply` in `App.xaml.cs`**

```csharp
using TripleZeroLabs.Os2;

protected override void OnStartup(StartupEventArgs e)
{
    base.OnStartup(e);
    Os2Theme.Apply(this);
}
```

**Plugin / add-in — apply per window to avoid affecting the host app**

When embedding in a host application (VS extensions, CAD add-ins, Office plugins, or any other
process you don't own), apply the theme to individual windows rather than `Application.Current`
so the host app's resource dictionary stays untouched.

```csharp
Os2Theme.Apply(myWindow);
```

Once applied, all standard WPF controls pick up OS2 implicit styles automatically — no extra
attributes needed on individual controls.

### 4. Point your AI assistant at the skill

If you're using an AI coding assistant, copy the included skill into your project so your agent
understands the theme without needing to be explained it on every prompt. See
[§ Onboarding Your AI Assistant](#onboarding-your-ai-assistant) for provider-specific setup.

---

## Onboarding Your AI Assistant

This repo includes an [Agent Skill](os2-wpf-theme/SKILL.md) — a structured context file that
teaches any compatible AI coding assistant how to apply the OS2 theme correctly. Once set up,
your agent knows every resource key, which controls are auto-styled vs. opt-in, the right
patterns for DataGrids, banners, dialogs, and nav sidebars, and the gotchas that silently break
the theme. You can then prompt it naturally — "add a settings panel with a sidebar and a danger
button" — and get correct, theme-consistent XAML on the first try.

Copy the skill folder into your project first:

```bash
# From your project root
cp -r path/to/TripleZeroLabs.Os2/os2-wpf-theme ./os2-wpf-theme
```

Then follow the setup for your AI tool below.

---

### Claude Code / Claude (Anthropic)

Claude Code has native skill support. Drop the folder into `.claude/skills/`:

```bash
mkdir -p .claude/skills
cp -r os2-wpf-theme .claude/skills/os2-wpf-theme
```

Claude Code automatically indexes `SKILL.md` metadata on startup and loads the full skill body
when you start working on XAML or ask about the theme. No further configuration needed.

For the **Claude.ai web interface**, paste the contents of
[`os2-wpf-theme/SKILL.md`](os2-wpf-theme/SKILL.md) into a Project Knowledge document so it's
available in every conversation in that project.

---

### Cursor

Cursor picks up context from files in the `.cursor/rules/` directory. Convert the skill to a
Cursor rule:

```bash
mkdir -p .cursor/rules
cp os2-wpf-theme/SKILL.md .cursor/rules/os2-wpf-theme.mdc
```

You can also include the full key catalog as a second rule file:

```bash
cp os2-wpf-theme/references/resource-keys.md .cursor/rules/os2-resource-keys.mdc
```

Once in place, Cursor will reference these rules when you work on `.xaml` or `.cs` files. For
more targeted activation, open the rule file and add a front-matter `globs` pattern:

```
---
globs: ["**/*.xaml", "**/*.cs"]
---
```

---

### GitHub Copilot (VS Code / Visual Studio)

Copilot reads context files placed in `.github/copilot-instructions.md` (workspace-level) or
any file referenced via the `#file:` syntax in chat. The quickest setup:

```bash
# Workspace-level instructions (applies to all Copilot interactions in this repo)
cat os2-wpf-theme/SKILL.md >> .github/copilot-instructions.md
```

In Copilot Chat, you can also attach the file on demand:

```
@workspace #file:os2-wpf-theme/SKILL.md  Add a settings window with sidebar nav and a danger button
```

---

### ChatGPT (OpenAI)

ChatGPT doesn't have a project-level skill directory, but you have two good options:

**Custom GPT** — if you have ChatGPT Plus or a Teams account, create a Custom GPT and paste the
contents of [`os2-wpf-theme/SKILL.md`](os2-wpf-theme/SKILL.md) into the GPT's system
instructions. This makes the theme knowledge permanent across all conversations with that GPT.

**Per-conversation** — upload [`os2-wpf-theme/SKILL.md`](os2-wpf-theme/SKILL.md) as a file
attachment at the start of any conversation, then ask your question. ChatGPT will read it before
responding.

---

### Gemini (Google)

**Gemini for Google Workspace / Gemini Advanced** — paste the contents of
[`os2-wpf-theme/SKILL.md`](os2-wpf-theme/SKILL.md) into a Google Doc, then share that doc with
your Gemini workspace context or reference it in a Gem (custom AI agent) system prompt.

**Gemini in VS Code (via the Gemini Code Assist extension)** — add the skill content to your
workspace's `.gemini/context.md` file:

```bash
mkdir -p .gemini
cat os2-wpf-theme/SKILL.md >> .gemini/context.md
```

---

### JetBrains AI Assistant

In any JetBrains IDE with the AI Assistant plugin, open **Settings → AI Assistant → Prompt
Library** and add a new entry. Paste the contents of
[`os2-wpf-theme/SKILL.md`](os2-wpf-theme/SKILL.md) as the prompt body. Name it "OS2 Theme" and
set its scope to the project. The assistant will include it as context whenever it generates code
in that project.

---

### General approach (any other agent)

If your tool isn't listed above, look for one of these extension points:

| Mechanism | Where to look |
|---|---|
| System prompt / instructions | Paste `SKILL.md` content here |
| Knowledge base / context files | Upload `SKILL.md` + `references/resource-keys.md` |
| `.context` or rules directory | Drop the `os2-wpf-theme/` folder there |
| `@file` / `#file` attachment | Reference `os2-wpf-theme/SKILL.md` inline in chat |

The skill follows the open [Agent Skills spec](https://agentskills.io/specification) — any
agent built to that standard will pick it up automatically from `.claude/skills/` or the
equivalent directory your tool uses.

---

## Buttons

The default `Button` style is the solid **primary** button. Named styles cover every other variant.

| Style key | Appearance | Use for |
|---|---|---|
| *(default)* | Solid blue | Primary / confirming action |
| `OS2.Button.Secondary` | Outlined blue | Secondary action |
| `OS2.Button.Danger` | Outlined red | Initiating a destructive action |
| `OS2.Button.DangerSolid` | Solid red | Confirming a destructive action |
| `OS2.Button.Flat` | Text only | Low-emphasis action (e.g. Cancel) |
| `OS2.Button.Success` | Solid green | Confirming a safe / positive action |
| `OS2.Button.SuccessSecondary` | Outlined green | Secondary positive action |

```xml
<!-- Primary — no style attribute needed -->
<Button Content="Save" />

<!-- Secondary -->
<Button Style="{StaticResource OS2.Button.Secondary}" Content="Export" />

<!-- Danger (outlined) — opens a confirmation dialog -->
<Button Style="{StaticResource OS2.Button.Danger}" Content="Delete Collection" />

<!-- Danger (solid) — the confirm button inside that dialog -->
<Button Style="{StaticResource OS2.Button.DangerSolid}" Content="Yes, delete permanently" />

<!-- Flat -->
<Button Style="{StaticResource OS2.Button.Flat}" Content="Cancel" />
```

All button styles handle hover, pressed, and disabled states automatically.

---

## DataGrid

The implicit `DataGrid` style removes outer borders and vertical grid lines, shows subtle
horizontal row dividers, and adds generous cell padding. Row hover and selection are handled
automatically — no extra style attributes needed.

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

**Selected row colours**

Selected rows use `OS2.Brush.Primary` (blue) as the background with `OS2.Brush.TextOnPrimary`
(white) for text. If a cell template contains secondary text, switch its foreground on selection
so it stays readable:

```xml
<DataGridTemplateColumn Header="Name" Width="*">
    <DataGridTemplateColumn.CellTemplate>
        <DataTemplate>
            <StackPanel Margin="0,4">
                <TextBlock Text="{Binding Name}" FontWeight="SemiBold" />
                <TextBlock Text="{Binding Subtitle}">
                    <TextBlock.Style>
                        <Style TargetType="TextBlock">
                            <Setter Property="Foreground"
                                    Value="{DynamicResource OS2.Brush.TextSecondary}" />
                            <Style.Triggers>
                                <DataTrigger Value="True"
                                             Binding="{Binding IsSelected,
                                                 RelativeSource={RelativeSource AncestorType={x:Type DataGridRow}}}">
                                    <Setter Property="Foreground"
                                            Value="{DynamicResource OS2.Brush.TextOnPrimarySubtle}" />
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </TextBlock.Style>
                </TextBlock>
            </StackPanel>
        </DataTemplate>
    </DataGridTemplateColumn.CellTemplate>
</DataGridTemplateColumn>
```

---

**Highlight rows where a boolean property is true**

Apply a `RowStyle` to the DataGrid that uses a `DataTrigger` bound to the relevant property.
`BasedOn` preserves the implicit row style's hover behaviour.

```xml
<DataGrid ...>
    <DataGrid.RowStyle>
        <Style TargetType="{x:Type DataGridRow}" BasedOn="{StaticResource {x:Type DataGridRow}}">
            <Style.Triggers>
                <DataTrigger Binding="{Binding Active}" Value="True">
                    <Setter Property="Background" Value="{DynamicResource OS2.Brush.RowHighlight}" />
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </DataGrid.RowStyle>
    ...
</DataGrid>
```

`OS2.Brush.RowHighlight` is a light blue tint (`#EBF2FF`). When the row is selected, the
cell-level Primary blue background takes over automatically — no extra triggers needed.

---

## Banners

Apply a banner style to any `Border` to get a toast-style notification with a coloured left accent bar.

| Style key | Appearance | Use for |
|---|---|---|
| `OS2.Banner.Default` | Grey accent / grey bg | Neutral status or informational note |
| `OS2.Banner.Info` | Blue accent / blue-tint bg | Helpful tip or completed action |
| `OS2.Banner.Warning` | Amber accent / yellow-tint bg | Needs attention before continuing |
| `OS2.Banner.Danger` | Red accent / pink-tint bg | Error or destructive action pending |

```xml
<Border Style="{StaticResource OS2.Banner.Info}">
    <StackPanel>
        <TextBlock Text="Changes saved." FontWeight="SemiBold"
                   Foreground="{DynamicResource OS2.Brush.Primary}"/>
        <TextBlock Text="Your changes have been saved and are ready to publish."/>
    </StackPanel>
</Border>
```

---

## Dialog cards

Apply `OS2.Dialog` to a `Border` to create a floating modal card — white background, rounded corners, and a soft shadow.

```xml
<Border Style="{StaticResource OS2.Dialog}" MaxWidth="420">
    <StackPanel>
        <TextBlock Text="Delete item?" Style="{StaticResource OS2.Text.Heading}" Margin="0,0,0,8"/>
        <TextBlock Text="This will permanently remove the item. This action cannot be undone."
                   Margin="0,0,0,20"/>
        <StackPanel Orientation="Horizontal" HorizontalAlignment="Right">
            <Button Style="{StaticResource OS2.Button.Flat}" Content="Cancel" Margin="0,0,8,0"/>
            <Button Style="{StaticResource OS2.Button.DangerSolid}" Content="Yes, delete"/>
        </StackPanel>
    </StackPanel>
</Border>
```

---

## Context menus

Use `Os2ContextMenu` in code-behind to build a styled context menu with one line. The result picks up the implicit `ContextMenu` and `MenuItem` styles automatically.

```csharp
using TripleZeroLabs.Os2;

element.ContextMenu = Os2ContextMenu.Create()
    .Item("Copy", () => Clipboard.SetText(value))
    .Separator()
    .Item("Open in browser", () => Process.Start(url))
    .Build();
```

---

## Resource reference

### Brushes (`OS2.Brush.*`)

| Key | Purpose |
|---|---|
| `Primary` | Brand blue — buttons, links, active indicators |
| `PrimaryHover` | Hover state for primary controls |
| `PrimaryPressed` | Pressed state for primary controls |
| `Accent` | Purple — secondary highlights |
| `Background` | Window / page background |
| `Surface` | Slightly off-white — cards, tab strip |
| `SurfaceAlt` | Row hover, alternate fills |
| `Card` | Card / panel background |
| `Overlay` | Semi-transparent modal scrim |
| `Border` | Default control border |
| `BorderFocus` | Focus ring (matches Primary) |
| `Toolbar` | Dark toolbar / chrome background |
| `ToolbarForeground` | White — text on dark toolbar |
| `TextPrimary` | Main body text |
| `TextSecondary` | Subdued / caption text |
| `TextOnPrimary` | White — text on solid-Primary surfaces |
| `TextOnPrimarySubtle` | Light blue — secondary text on selected rows |
| `TextDisabled` | Disabled control text |
| `Success` | Green status |
| `SuccessHover` | Darker green for success hover |
| `SuccessPressed` | Pressed state for success controls |
| `SuccessSurface` | Faint green wash — outlined success hover fill |
| `Warning` | Amber status |
| `Danger` | Red — destructive / error |
| `DangerHover` | Darker red for danger hover |
| `DangerSurface` | Faint red wash — outlined danger hover fill |
| `RowHighlight` | Light blue tint for highlighted DataGrid rows |
| `BannerInfoBackground` | Light blue tint for info banners |
| `BannerWarningBackground` | Light yellow tint for warning banners |
| `BannerDangerBackground` | Light pink tint for danger banners |

### Named styles

| Key | Control | Purpose |
|---|---|---|
| `OS2.Text.Heading` | TextBlock | 20 px SemiBold heading |
| `OS2.Text.Caption` | TextBlock | 11 px subdued caption |
| `OS2.Button.Secondary` | Button | Outlined primary-colour button |
| `OS2.Button.Danger` | Button | Outlined red button |
| `OS2.Button.DangerSolid` | Button | Solid red button |
| `OS2.Button.Flat` | Button | Text-only button |
| `OS2.Button.Success` | Button | Solid green button |
| `OS2.Button.SuccessSecondary` | Button | Outlined green button |
| `OS2.Banner.Default` | Border | Neutral banner with grey accent bar |
| `OS2.Banner.Info` | Border | Blue-tinted info banner |
| `OS2.Banner.Warning` | Border | Yellow-tinted warning banner |
| `OS2.Banner.Danger` | Border | Pink-tinted danger banner |
| `OS2.Dialog` | Border | Floating dialog card with shadow |
| `OS2.Nav.ListBox` | ListBox | Vertical sidebar nav container |
| `OS2.Nav.ListBoxItem` | ListBoxItem | Nav item with left active-bar indicator |

### Typed constants (C#)

Use `Os2ResourceKey` instead of magic strings in code-behind:

```csharp
using TripleZeroLabs.Os2;

element.SetResourceReference(Control.ForegroundProperty, Os2ResourceKey.Brush.Primary);
var style = (Style)FindResource(Os2ResourceKey.Button.Success);
var bannerStyle = (Style)FindResource(Os2ResourceKey.Banner.Info);
var dialogStyle = (Style)FindResource(Os2ResourceKey.Dialog);
```

---

## Preview the gallery

```
cd TripleZeroLabs.Os2.Gallery
dotnet run
```

Opens a live window with every styled control — typography, buttons, form fields, nav,
tabs, data grid, and the full colour palette — including hover, active, and disabled states.
