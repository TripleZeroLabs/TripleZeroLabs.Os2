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
| `ComboBox` | Gradient raised border (light-top → grey-bottom), white popup + drop shadow |
| `ComboBoxItem` | Rounded, Padding=12,9, SurfaceAlt on IsHighlighted, Primary fg when selected |
| `CheckBox` | 16×16 rounded tick box, full-row hover background (SurfaceAlt), indeterminate dash |
| `ListBox` | Light Border, TextPrimary foreground |
| `DataGrid` | No outer border, horizontal grid lines only, RowHeaderWidth=0, ColumnHeaderHeight=42 |
| `DataGridColumnHeader` | SemiBold 12px, TextSecondary, bottom-only 2px border, sort arrows |
| `DataGridRow` | Background=Background, SurfaceAlt on hover |
| `DataGridCell` | Padding=16,12, no focus rect; selected = Primary background + TextOnPrimary |
| `TabControl` | Surface tab strip with hairline baseline, transparent content area |
| `TabItem` | 14px SemiBold, Primary underline + foreground when selected |
| `ContextMenu` | White, CornerRadius=6, 1px border, Padding=0,4, soft drop shadow |
| `MenuItem` | Segoe UI 13px, Padding=12,9, SurfaceAlt on IsHighlighted |
| `Separator` (in menu) | 1px Border brush, Margin=8,4 (via `{x:Static MenuItem.SeparatorStyleKey}`) |

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

// Nav
Os2ResourceKey.Nav.ListBox              // "OS2.Nav.ListBox"
Os2ResourceKey.Nav.ListBoxItem          // "OS2.Nav.ListBoxItem"

// Metrics
Os2ResourceKey.Metric.CornerRadius      // "OS2.CornerRadius"
Os2ResourceKey.Metric.ControlPadding    // "OS2.Thickness.ControlPadding"
```
