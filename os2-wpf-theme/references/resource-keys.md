# OS2 Resource Key Catalog

Complete reference for every resource key shipped in `TripleZeroLabs.Os2`.  
Load this file when you need a specific key name, hex value, or type.

## Table of Contents

- [Brushes — OS2.Brush.*](#brushes--os2brush)
- [Metrics](#metrics)
- [Implicit Styles (no key required)](#implicit-styles-no-key-required)
- [Keyed Styles — Buttons](#keyed-styles--buttons)
- [Keyed Styles — Typography](#keyed-styles--typography)
- [Keyed Styles — Banners](#keyed-styles--banners)
- [Keyed Styles — Dialog](#keyed-styles--dialog)
- [Keyed Styles — Navigation](#keyed-styles--navigation)
- [C# Typed Constants (Os2ResourceKey)](#c-typed-constants-os2resourcekey)

---

## Brushes — OS2.Brush.*

All values are `SolidColorBrush`. Use `{DynamicResource KEY}` in XAML.

### Brand

| Key | Hex | Purpose |
|---|---|---|
| `OS2.Brush.Primary` | `#2F6FEB` | Brand blue — primary buttons, links, active indicators |
| `OS2.Brush.PrimaryHover` | `#2257C6` | Hover state for primary controls |
| `OS2.Brush.PrimaryPressed` | `#1B46A0` | Pressed state for primary controls |
| `OS2.Brush.Accent` | `#7C4DFF` | Purple — secondary highlights |

### Surfaces

| Key | Hex | Purpose |
|---|---|---|
| `OS2.Brush.Background` | `#FFFFFF` | Window and page background |
| `OS2.Brush.Surface` | `#F4F6F9` | Cards, tab strip, slightly off-white fill |
| `OS2.Brush.SurfaceAlt` | `#ECEFF3` | Row hover, alternate fills, checkbox hover bg |
| `OS2.Brush.Card` | `#FFFFFF` | Card / panel background (alias of Background) |
| `OS2.Brush.Overlay` | `#B2000000` | Semi-transparent modal scrim (~70% opacity) |

### Borders

| Key | Hex | Purpose |
|---|---|---|
| `OS2.Brush.Border` | `#D6DBE1` | Default control border, DataGrid dividers |
| `OS2.Brush.BorderFocus` | `#2F6FEB` | Focus ring (matches Primary) |

### Toolbar / chrome

| Key | Hex | Purpose |
|---|---|---|
| `OS2.Brush.Toolbar` | `#2B3442` | Dark toolbar / top-chrome background |
| `OS2.Brush.ToolbarForeground` | `#FFFFFF` | White text on the dark toolbar |

### Text

| Key | Hex | Purpose |
|---|---|---|
| `OS2.Brush.TextPrimary` | `#1B2733` | Main body text |
| `OS2.Brush.TextSecondary` | `#5B6875` | Subdued / caption / column-header text |
| `OS2.Brush.TextOnPrimary` | `#FFFFFF` | White — text on solid-Primary surfaces (buttons, selected cells) |
| `OS2.Brush.TextOnPrimarySubtle` | `#C7DDFF` | Light blue — secondary text inside selected (blue) DataGrid cells |
| `OS2.Brush.TextDisabled` | `#A2ABB5` | Disabled control text |

### Status — Success

| Key | Hex | Purpose |
|---|---|---|
| `OS2.Brush.Success` | `#2E9E5B` | Green status color — success buttons |
| `OS2.Brush.SuccessHover` | `#27875C` | Hover state for Success button |
| `OS2.Brush.SuccessPressed` | `#1E6B49` | Pressed state for Success button |
| `OS2.Brush.SuccessSurface` | `#E8F5EE` | Faint green wash — SuccessSecondary button hover fill |

### Status — Warning

| Key | Hex | Purpose |
|---|---|---|
| `OS2.Brush.Warning` | `#E0A100` | Amber — warning indicators and banner accents |

### Status — Danger

| Key | Hex | Purpose |
|---|---|---|
| `OS2.Brush.Danger` | `#D64545` | Red — destructive / error indicators |
| `OS2.Brush.DangerHover` | `#B83A3A` | Hover state for DangerSolid button |
| `OS2.Brush.DangerSurface` | `#FBEAEA` | Faint red wash — Danger (outlined) button hover fill |

### Row highlighting

| Key | Hex | Purpose |
|---|---|---|
| `OS2.Brush.RowHighlight` | `#EBF2FF` | Light blue tint for DataGrid rows with an active/checked boolean |

### Banner backgrounds

| Key | Hex | Purpose |
|---|---|---|
| `OS2.Brush.BannerInfoBackground` | `#EBF2FF` | Tinted background for OS2.Banner.Info |
| `OS2.Brush.BannerWarningBackground` | `#FFF8E8` | Tinted background for OS2.Banner.Warning |
| `OS2.Brush.BannerDangerBackground` | `#FFF0F0` | Tinted background for OS2.Banner.Danger |

---

## Metrics

| Key | Type | Value | Purpose |
|---|---|---|---|
| `OS2.CornerRadius` | `CornerRadius` | `4` | Standard corner radius for controls |
| `OS2.Thickness.ControlPadding` | `Thickness` | `10,6` | Standard control padding |

---

## Implicit Styles (no key required)

These `TargetType`-only styles activate on all instances of the control once the theme is merged. **Do not add `Style=` — just use the control normally.**

| Control type | Key behavior |
|---|---|
| `Window` | Foreground = TextPrimary (enables text inheritance throughout the tree) |
| `TextBlock` | Segoe UI 13px, TextWrapping=Wrap; **no Foreground** (inherits from parent) |
| `Label` | Segoe UI 13px, TextPrimary foreground |
| `Button` | Solid Primary blue, CornerRadius=4, white text, hover/pressed/disabled states |
| `TextBox` | CornerRadius=4, Border focus ring (BorderFocus), disabled Surface fill |
| `PasswordBox` | Identical appearance to TextBox |
| `RichTextBox` | TextBox look (shared `OS2.TextInputBase`), MinHeight=80, vertical scrollbar Auto, Paragraph margin 0,0,0,6 |
| `ComboBox` | Gradient raised border (light-top → grey-bottom), white popup + drop shadow |
| `ComboBoxItem` | Rounded, Padding=12,9, SurfaceAlt on IsHighlighted, Primary fg when selected |
| `CheckBox` | 16×16 rounded tick box, full-row hover background (SurfaceAlt), indeterminate dash |
| `RadioButton` | 16×16 round box, same row/hover as CheckBox; checked = Primary fill + white dot |
| `Slider` | 4px Border-coloured track; fill and 16px knob ring follow Foreground (default Primary); TickPlacement and Orientation=Vertical supported |
| `RepeatButton` | Outlined neutral (Border outline, TextPrimary) via `OS2.Template.SecondaryButton`; Height 32 |
| `ListBox` | Light Border, CornerRadius=4, Padding=4 |
| `ListBoxItem` | Padding=10,7, CornerRadius=4, SurfaceAlt hover, RowHighlight + Primary fg when selected (`OS2.ListItemBase`) |
| `ListView` + `GridView` | DataGrid look: `GridViewColumnHeader` SemiBold 12px TextSecondary with 2px baseline; rows Padding=10,10 with 1px dividers, SurfaceAlt hover, Primary + TextOnPrimary when selected |
| `ListView` (no View) | Same as ListBox / ListBoxItem |
| `DataGrid` | No outer border, horizontal grid lines only, RowHeaderWidth=0, ColumnHeaderHeight=42 |
| `DataGridColumnHeader` | SemiBold 12px, TextSecondary, bottom-only 2px border, sort arrows |
| `DataGridRow` | Background=Background, SurfaceAlt on hover |
| `DataGridCell` | Padding=16,12, no focus rect; selected = Primary background + TextOnPrimary |
| `TabControl` | Surface tab strip with hairline baseline, transparent content area |
| `TabItem` | 14px SemiBold, Primary underline + foreground when selected |
| `ContextMenu` | White, CornerRadius=6, 1px border, Padding=0,4, soft drop shadow |
| `Menu` | Surface background, 1px bottom border, Padding=4,3; top-level items Padding=10,5 |
| `MenuItem` | Segoe UI 13px, Padding=12,9, SurfaceAlt on IsHighlighted / IsSubmenuOpen; icon column, Primary check mark, InputGestureText (TextSecondary 12px), ChevronRight for submenus |
| `Separator` (in menu) | 1px Border brush, Margin=12,4 (via `{x:Static MenuItem.SeparatorStyleKey}`) |
| `Separator` (elsewhere) | 1px horizontal Border-brush line, Margin=0,8 |
| `GroupBox` | 1px border, CornerRadius=6, SemiBold header row (Padding=16,10) over a hairline, content Padding=16,12 |
| `ToolBarTray` / `ToolBar` | Surface background; dotted grip (hidden when `ToolBarTray.IsLocked`); overflow chevron + popup. Items get `ToolBar.*StyleKey` styles: flat Button (based on `OS2.Button.Icon`), RowHighlight ToggleButton, 28px ComboBox/TextBox, vertical Separator |
| `StatusBar` / `StatusBarItem` | Surface, 1px top border, TextSecondary 12px; items Padding=8,4; vertical separators |
| `DatePicker` / `Calendar` | TextBox look + calendar icon; rounded day cells, today outlined, selection solid Primary |
| `ProgressBar` | 6px rounded bar; fill follows Foreground; indeterminate sweep |
| `Hyperlink` | Primary, underline on hover; disabled = TextDisabled + underline |
| `ScrollViewer` / `ScrollBar` | 10px arrow-less bars, rounded thumb, transparent corner |
| `Expander` | Bordered card, SemiBold header, chevron flips when open |
| `ToggleButton` | Sliding switch (`Content` = on label, `Tag` = off label) |
| `TreeView` / `TreeViewItem` | Rotating chevrons, rounded hover rows, RowHighlight selection |
| `GridSplitter` | 1px TextDisabled hairline, Primary on hover/drag |
| `ToolTip` | Toolbar-coloured bubble, white 12px text, soft shadow |

---

## Keyed Styles — Buttons

All applied as `Style="{StaticResource KEY}"` on a `Button`.  
Hover, pressed, and disabled states are handled automatically in all variants.

| Key | Appearance | Use for |
|---|---|---|
| *(implicit)* | Solid Primary blue, white text | Default confirming action |
| `OS2.Button.Secondary` | Outlined Primary blue | Secondary or non-destructive action |
| `OS2.Button.Danger` | Outlined red | Initiating a destructive action (opens confirm dialog) |
| `OS2.Button.DangerSolid` | Solid red, white text | Confirming a destructive action |
| `OS2.Button.Flat` | Text-only, Primary foreground | Low-emphasis action (Cancel, Skip) |
| `OS2.Button.Success` | Solid green, white text | Confirming a safe / positive action |
| `OS2.Button.SuccessSecondary` | Outlined green | Secondary positive action |

---

## Keyed Styles — Typography

Applied as `Style="{StaticResource KEY}"` on a `TextBlock`.

| Key | Size | Weight | Foreground | Use for |
|---|---|---|---|---|
| `OS2.Text.Heading` | 20px | SemiBold | TextPrimary | Section or page headings |
| `OS2.Text.Caption` | 11px | Regular | TextSecondary | Helper text, captions, metadata |

---

## Keyed Styles — Banners

Applied as `Style="{StaticResource KEY}"` on a `Border`. Put content inside the Border.  
Each style sets a 4px left accent bar (`BorderThickness="4,0,0,0"`), a tinted background, and `Padding="16,12"`.

| Key | Accent color | Background | Use for |
|---|---|---|---|
| `OS2.Banner.Default` | TextSecondary (grey) | Surface (`#F4F6F9`) | Neutral status, info with no severity |
| `OS2.Banner.Info` | Primary (blue) | BannerInfoBackground (`#EBF2FF`) | Helpful tips, completed actions |
| `OS2.Banner.Warning` | Warning (amber) | BannerWarningBackground (`#FFF8E8`) | Needs attention before continuing |
| `OS2.Banner.Danger` | Danger (red) | BannerDangerBackground (`#FFF0F0`) | Errors, destructive action pending |

---

## Keyed Styles — Dialog

Applied as `Style="{StaticResource OS2.Dialog}"` on a `Border`.  
Sets Background=white, CornerRadius=8, Padding=28, 1px border, and a reduced drop shadow (`BlurRadius=12, Opacity=0.5`).

```xml
<Border Style="{StaticResource OS2.Dialog}" MaxWidth="420">
    <!-- dialog content -->
</Border>
```

---

## Keyed Styles — Icon button & glyphs

`OS2.Button.Icon` is a square, transparent button for glyph-only actions (hover = SurfaceAlt).
Pair it with a `Path` using `OS2.Path.Glyph` and one of the shared geometries
(`OS2.Geometry.ChevronDown`, `ChevronRight`, `ChevronLeft`, `Calendar`) — the stroke follows the inherited text colour (`TextElement.Foreground`, i.e. the button's Foreground). This also works for `MenuItem.Icon` and ToolBar buttons.

```xml
<Button Style="{StaticResource OS2.Button.Icon}" ToolTip="Previous">
    <Path Data="{StaticResource OS2.Geometry.ChevronLeft}" Style="{StaticResource OS2.Path.Glyph}" />
</Button>
```

**ProgressBar colour:** the fill follows `Foreground`, e.g. `Foreground="{DynamicResource OS2.Brush.Success}"`.

**ToggleButton (switch):** `Content` is the label shown when on, `Tag` the label shown when off (omit `Tag` to show `Content` in both).
The track sizes to the longer label. For a button-shaped toggle use `Style="{StaticResource OS2.ToggleButton.Segment}"`.

```xml
<ToggleButton Content="ON" Tag="OFF" IsChecked="{Binding ShowGrid}" />
```

**GridSplitter:** give a column splitter `Width="5"`; a row splitter `Height="5" HorizontalAlignment="Stretch"`.

**Slider colour:** like the ProgressBar, the fill and knob ring follow `Foreground`.

**Menu items with icons, check marks and shortcuts:**

```xml
<Menu>
    <MenuItem Header="_File">
        <MenuItem Header="_Open..." InputGestureText="Ctrl+O">
            <MenuItem.Icon><Path Data="{StaticResource OS2.Geometry.Calendar}" Style="{StaticResource OS2.Path.Glyph}" /></MenuItem.Icon>
        </MenuItem>
        <MenuItem Header="_Auto-save" IsCheckable="True" IsChecked="True" />
        <Separator />
        <MenuItem Header="E_xit" />
    </MenuItem>
</Menu>
```

**Vertical separator** in a horizontal row: `<Separator Style="{StaticResource OS2.Separator.Vertical}" />` (ToolBar and StatusBar do this automatically).

**ListView vs DataGrid:** a `ListView` with a `GridView` already looks like the DataGrid; use it for read-only lists and the DataGrid for editing.

---

## Keyed Styles — Navigation

Both keys must be set for the sidebar to look correct.

| Key | Applied to | Purpose |
|---|---|---|
| `OS2.Nav.ListBox` | ListBox | Removes outer border, disables horizontal scroll, stretches items |
| `OS2.Nav.ListBoxItem` | ListBoxItem | Full-width rows, 3px Primary left bar when selected, SurfaceAlt hover |

```xml
<ListBox Style="{StaticResource OS2.Nav.ListBox}"
         ItemContainerStyle="{StaticResource OS2.Nav.ListBoxItem}">
    <ListBoxItem Content="Dashboard" />
</ListBox>
```

---

## C# Typed Constants (Os2ResourceKey)

`Os2ResourceKey` is a static class in the `TripleZeroLabs.Os2` namespace with nested classes matching each key category. Use these instead of magic strings.

```csharp
using TripleZeroLabs.Os2;

// Brushes
Os2ResourceKey.Brush.Primary            // "OS2.Brush.Primary"
Os2ResourceKey.Brush.TextOnPrimarySubtle // "OS2.Brush.TextOnPrimarySubtle"
Os2ResourceKey.Brush.RowHighlight       // "OS2.Brush.RowHighlight"
Os2ResourceKey.Brush.BannerInfoBackground // "OS2.Brush.BannerInfoBackground"

// Button styles
Os2ResourceKey.Button.Secondary         // "OS2.Button.Secondary"
Os2ResourceKey.Button.DangerSolid       // "OS2.Button.DangerSolid"
Os2ResourceKey.Button.Success           // "OS2.Button.Success"
Os2ResourceKey.Button.SuccessSecondary  // "OS2.Button.SuccessSecondary"

// Text styles
Os2ResourceKey.Text.Heading             // "OS2.Text.Heading"
Os2ResourceKey.Text.Caption             // "OS2.Text.Caption"

// Banner styles
Os2ResourceKey.Banner.Info              // "OS2.Banner.Info"
Os2ResourceKey.Banner.Warning           // "OS2.Banner.Warning"
Os2ResourceKey.Banner.Danger            // "OS2.Banner.Danger"

// Dialog
Os2ResourceKey.Dialog                   // "OS2.Dialog"

// Icon button + shared glyphs / effects
Os2ResourceKey.Button.Icon              // "OS2.Button.Icon"
Os2ResourceKey.Geometry.ChevronDown     // "OS2.Geometry.ChevronDown"  (also ChevronRight, ChevronLeft, Calendar)
Os2ResourceKey.GlyphPath                // "OS2.Path.Glyph"  — stroked Path whose Stroke follows the inherited text colour
Os2ResourceKey.Separator.Vertical       // "OS2.Separator.Vertical"
Os2ResourceKey.PopupShadow              // "OS2.Effect.PopupShadow" — shared by ComboBox, ContextMenu, Calendar, ToolTip
Os2ResourceKey.Calendar.Popup           // "OS2.Calendar.Popup"
Os2ResourceKey.ToggleButton.Segment     // "OS2.ToggleButton.Segment"

// Base styles to build on (BasedOn / Template)
Os2ResourceKey.Base.Button              // "OS2.ButtonBase"     (TargetType ButtonBase)
Os2ResourceKey.Base.TextInput           // "OS2.TextInputBase"  (TextBox, PasswordBox, RichTextBox)
Os2ResourceKey.Base.Choice              // "OS2.ChoiceBase"     (CheckBox, RadioButton)
Os2ResourceKey.Base.ListItem            // "OS2.ListItemBase"   (ListBoxItem, ListViewItem)
Os2ResourceKey.Base.SecondaryButtonTemplate // "OS2.Template.SecondaryButton" (ControlTemplate)

// Nav
Os2ResourceKey.Nav.ListBox              // "OS2.Nav.ListBox"
Os2ResourceKey.Nav.ListBoxItem          // "OS2.Nav.ListBoxItem"

// Metrics
Os2ResourceKey.Metric.CornerRadius      // "OS2.CornerRadius"
Os2ResourceKey.Metric.ControlPadding    // "OS2.Thickness.ControlPadding"
```
