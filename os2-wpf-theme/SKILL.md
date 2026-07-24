---
name: os2-wpf-theme
description: Apply the OS2 WPF theme (TripleZeroLabs.Os2) correctly in any XAML or C# file. Activate when building or editing a WPF window, page, view, or UserControl; styling any WPF control (Button, TextBox, DataGrid, ComboBox, CheckBox, nav sidebar, tabs, dialog, banner); building a settings screen, form, dashboard, or toolbar; the user mentions OS2, Triple Zero Labs, or TripleZeroLabs.Os2; or any new Window, UserControl, or XAML file is scaffolded in a project that references TripleZeroLabs.Os2. Load this skill before writing any XAML markup or brush/style references.
license: MIT
compatibility: WPF projects targeting net48, net8.0-windows, or net10.0-windows. Requires a ProjectReference to TripleZeroLabs.Os2.
metadata:
  author: Triple Zero Labs
  version: "0.1.0"
---

## Installation

Add a project reference to `TripleZeroLabs.Os2`, then apply the theme using one of the three options below. **One entry point, one merge URI** — `Theme.xaml` wires everything internally.

### Option A — XAML merge in App.xaml (standalone apps, recommended)

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/TripleZeroLabs.Os2;component/Themes/Theme.xaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

### Option B — C# at startup (App.xaml.cs)

```csharp
using TripleZeroLabs.Os2;

protected override void OnStartup(StartupEventArgs e)
{
    base.OnStartup(e);
    Os2Theme.Apply(this);
}
```

### Option C — Per-window (plugins, add-ins, embedded tool hosts)

When your code runs inside a host process you don't own, apply to the individual window only so the host app's resource dictionary stays untouched:

```csharp
Os2Theme.Apply(myWindow);   // safe for Revit, VS extensions, Office add-ins, etc.
```

`Os2Theme` also exposes `Remove(...)` and `IsApplied(...)` with the same overloads.

---

## The Golden Rule: Implicit vs. Explicit

This is the thing agents get wrong most. There are two categories of styles.

### Implicit styles — automatic, no `Style=` attribute needed

Merging the theme is enough. Every instance of these controls is themed:

| Control | What changes |
|---|---|
| `Window` | Root `Foreground` set so all TextBlocks inherit it |
| `TextBlock` | Segoe UI 13px, `TextWrapping=Wrap` — **no Foreground setter, by design** |
| `Label` | Segoe UI 13px, TextPrimary foreground |
| `Button` | Solid primary blue, rounded, hover/pressed/disabled states |
| `TextBox` | Rounded border, focus ring, disabled tint |
| `PasswordBox` | Matches TextBox visually |
| `ComboBox` | Gradient raised border, white popup with drop shadow |
| `ComboBoxItem` | Rounded, SurfaceAlt on hover, Primary foreground when selected |
| `CheckBox` | Rounded tick box, full-row hover background |
| `ListBox` | Light border, TextPrimary foreground |
| `DataGrid` | No outer border, horizontal dividers, generous cell padding |
| `DataGridColumnHeader` | SemiBold labels, bottom baseline, sort arrows |
| `DataGridRow` | SurfaceAlt on hover |
| `DataGridCell` | 16,12 padding; blue background + white text when selected |
| `TabControl` | Surface tab strip with hairline baseline |
| `TabItem` | Underline indicator on selected, subdued when inactive |
| `ContextMenu` | White, CornerRadius 6, soft drop shadow |
| `MenuItem` | Rounded, SurfaceAlt highlight, generous padding |

### Explicit styles — must set `Style="{StaticResource KEY}"`

These keyed styles are opt-in. Nothing happens unless you reference them:

| Key | Applied to | Purpose |
|---|---|---|
| `OS2.Text.Heading` | TextBlock | 20px SemiBold heading |
| `OS2.Text.Caption` | TextBlock | 11px subdued caption |
| `OS2.Button.Secondary` | Button | Outlined primary-blue |
| `OS2.Button.Danger` | Button | Outlined red — open a confirm dialog |
| `OS2.Button.DangerSolid` | Button | Solid red — confirm the destructive action |
| `OS2.Button.Flat` | Button | Text-only, low-emphasis (Cancel, Skip) |
| `OS2.Button.Success` | Button | Solid green — positive confirming action |
| `OS2.Button.SuccessSecondary` | Button | Outlined green — secondary positive action |
| `OS2.Banner.Default` | Border | Grey accent-bar notification |
| `OS2.Banner.Info` | Border | Blue-tinted notification |
| `OS2.Banner.Warning` | Border | Amber-tinted notification |
| `OS2.Banner.Danger` | Border | Red-tinted notification |
| `OS2.Dialog` | Border | Floating card with rounded corners and shadow |
| `OS2.Nav.ListBox` | ListBox | Sidebar nav container |
| `OS2.Nav.ListBoxItem` | ListBoxItem | Nav item with left active-bar indicator |

---

## Common Patterns

### Buttons

```xml
<!-- Default (solid primary) — implicit, no attribute -->
<Button Content="Save" />

<!-- All other variants require an explicit Style -->
<Button Style="{StaticResource OS2.Button.Secondary}"      Content="Export" />
<Button Style="{StaticResource OS2.Button.Danger}"         Content="Delete" />
<Button Style="{StaticResource OS2.Button.DangerSolid}"    Content="Yes, delete permanently" />
<Button Style="{StaticResource OS2.Button.Flat}"           Content="Cancel" />
<Button Style="{StaticResource OS2.Button.Success}"        Content="Publish" />
<Button Style="{StaticResource OS2.Button.SuccessSecondary}" Content="Download" />
```

### Text

```xml
<TextBlock Text="Section Heading" Style="{StaticResource OS2.Text.Heading}" />
<TextBlock Text="Body text — no style needed, implicit gives Segoe UI 13px" />
<TextBlock Text="Helper or caption" Style="{StaticResource OS2.Text.Caption}" />
```

### Form fields

```xml
<!-- TextBox and PasswordBox are both implicit -->
<TextBox Text="{Binding Email}" />
<PasswordBox />
<!-- ComboBox is implicit -->
<ComboBox ItemsSource="{Binding Options}" SelectedItem="{Binding Selected}" />
<!-- CheckBox hover highlights the full row automatically -->
<CheckBox Content="Enable notifications" IsChecked="{Binding NotificationsEnabled}" />
```

### DataGrid (basic)

```xml
<DataGrid ItemsSource="{Binding Items}"
          AutoGenerateColumns="False"
          IsReadOnly="True"
          SelectionUnit="FullRow"
          HeadersVisibility="Column">
    <DataGrid.Columns>
        <DataGridTextColumn Header="Name"     Binding="{Binding Name}"     Width="*" />
        <DataGridTextColumn Header="Category" Binding="{Binding Category}" Width="160" />
        <DataGridCheckBoxColumn Header="Active" Binding="{Binding Active}" Width="80" />
    </DataGrid.Columns>
</DataGrid>
```

### DataGrid — secondary text that must stay readable on selection

The selected cell goes blue. Any `TextBlock` inside a `DataGridTemplateColumn` that sets its own foreground must switch it on selection:

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

### DataGrid — highlight rows where a boolean property is true

```xml
<DataGrid ...>
    <DataGrid.RowStyle>
        <!-- BasedOn is required — omitting it removes the hover state -->
        <Style TargetType="{x:Type DataGridRow}" BasedOn="{StaticResource {x:Type DataGridRow}}">
            <Style.Triggers>
                <DataTrigger Binding="{Binding Active}" Value="True">
                    <Setter Property="Background" Value="{DynamicResource OS2.Brush.RowHighlight}" />
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </DataGrid.RowStyle>
</DataGrid>
```

### Tabs

```xml
<!-- TabControl and TabItem are both implicit -->
<TabControl>
    <TabItem Header="Overview"><TextBlock Text="Overview content" Margin="16" /></TabItem>
    <TabItem Header="Details"><TextBlock Text="Details content" Margin="16" /></TabItem>
    <TabItem Header="Settings"><TextBlock Text="Settings content" Margin="16" /></TabItem>
</TabControl>
```

### Vertical nav sidebar

```xml
<!-- Both Style and ItemContainerStyle are required -->
<ListBox Style="{StaticResource OS2.Nav.ListBox}"
         ItemContainerStyle="{StaticResource OS2.Nav.ListBoxItem}"
         SelectedIndex="0">
    <ListBoxItem Content="Dashboard" />
    <ListBoxItem Content="Documents" />
    <ListBoxItem Content="Settings" />
</ListBox>
```

### Banners / toast notifications

```xml
<Border Style="{StaticResource OS2.Banner.Info}">
    <StackPanel>
        <TextBlock Text="Changes saved." FontWeight="SemiBold"
                   Foreground="{DynamicResource OS2.Brush.Primary}" />
        <TextBlock Text="Your changes are ready to publish." />
    </StackPanel>
</Border>

<!-- Swap the style for other severity levels -->
<!-- OS2.Banner.Default  — neutral grey accent bar  -->
<!-- OS2.Banner.Warning  — amber accent bar          -->
<!-- OS2.Banner.Danger   — red accent bar            -->
```

### Dialog card

```xml
<Border Style="{StaticResource OS2.Dialog}" MaxWidth="420" HorizontalAlignment="Center">
    <StackPanel>
        <TextBlock Text="Delete item?" Style="{StaticResource OS2.Text.Heading}"
                   Margin="0,0,0,8" />
        <TextBlock Text="This will permanently remove the item. This action cannot be undone."
                   Margin="0,0,0,20" />
        <StackPanel Orientation="Horizontal" HorizontalAlignment="Right">
            <Button Style="{StaticResource OS2.Button.Flat}"       Content="Cancel"      Margin="0,0,8,0" />
            <Button Style="{StaticResource OS2.Button.DangerSolid}" Content="Yes, delete" />
        </StackPanel>
    </StackPanel>
</Border>
```

### Context menus (code-behind)

```csharp
using TripleZeroLabs.Os2;

element.ContextMenu = Os2ContextMenu.Create()
    .Item("Copy", () => Clipboard.SetText(value))
    .Separator()
    .Item("Open", () => OpenItem(id))
    .Build();
// The returned ContextMenu inherits OS2's implicit ContextMenu + MenuItem styles automatically.
```

### Brushes in code-behind

```csharp
using TripleZeroLabs.Os2;

// Use typed constants — never magic strings
element.SetResourceReference(Control.ForegroundProperty, Os2ResourceKey.Brush.Primary);
var style = (Style)FindResource(Os2ResourceKey.Button.Success);
var banner = (Style)FindResource(Os2ResourceKey.Banner.Info);
```

---

## DynamicResource vs StaticResource

**Always use `{DynamicResource}` for OS2 brush and style references.** The theme wires all of its own internal references with `DynamicResource`, and consumer XAML must match:

```xml
<!-- Correct -->
<Border Background="{DynamicResource OS2.Brush.Surface}" />
<TextBlock Foreground="{DynamicResource OS2.Brush.TextSecondary}" />

<!-- Avoid — may fail if the dictionary merges after the element is constructed -->
<Border Background="{StaticResource OS2.Brush.Surface}" />
```

---

## Key Naming Convention

`OS2.{Category}.{Purpose}` — all categories are Pascal-cased:

| Prefix | Type | Example |
|---|---|---|
| `OS2.Brush.*` | SolidColorBrush | `OS2.Brush.Primary` |
| `OS2.Button.*` | Button Style | `OS2.Button.DangerSolid` |
| `OS2.Text.*` | TextBlock Style | `OS2.Text.Heading` |
| `OS2.Banner.*` | Border Style | `OS2.Banner.Warning` |
| `OS2.Nav.*` | ListBox/ListBoxItem Style | `OS2.Nav.ListBox` |
| `OS2.Dialog` | Border Style | `OS2.Dialog` |
| `OS2.CornerRadius` | CornerRadius (4) | shared metric |
| `OS2.Thickness.ControlPadding` | Thickness (10,6) | shared metric |

---

## Gotchas

1. **Never hardcode hex colors.** Use `{DynamicResource OS2.Brush.*}` keys for all coloring. Hardcoded values break visual consistency and won't update if the theme evolves.

2. **Never add `Foreground` to an implicit `TextBlock` style.** The OS2 TextBlock style omits `Foreground` on purpose — this lets parent controls (buttons, selected DataGrid cells) pass their foreground down via inheritance. Adding it there makes text on solid-color buttons go black.

3. **Secondary text in DataGrid cell templates needs its own DataTrigger.** Any `TextBlock` inside a `DataGridTemplateColumn` that explicitly sets `Foreground` (e.g. to `TextSecondary`) must also add a `DataTrigger` on `IsSelected` switching the foreground to `OS2.Brush.TextOnPrimarySubtle`. Without this, the text disappears on the selected (blue) row.

4. **`DataGrid.RowStyle` must include `BasedOn`.** Omitting `BasedOn="{StaticResource {x:Type DataGridRow}}"` strips the implicit row hover state from the new style.

5. **Nav sidebar requires both style keys.** Set both `Style="{StaticResource OS2.Nav.ListBox}"` on the `ListBox` AND `ItemContainerStyle="{StaticResource OS2.Nav.ListBoxItem}"`. Missing `ItemContainerStyle` leaves the items looking like a default unstyled ListBox.

6. **Plugin/add-in hosts: apply per-window.** Call `Os2Theme.Apply(myWindow)` — not `Os2Theme.Apply(Application.Current)`. The latter injects the theme into the host process's global resource dictionary.

---

## Full Key Reference

See [`references/resource-keys.md`](references/resource-keys.md) for the exhaustive catalog of every brush, color, metric, and style key with hex values and purpose notes.
