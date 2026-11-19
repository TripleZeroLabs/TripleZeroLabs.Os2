# TripleZeroLabs.Os2

A clean, modern, **dependency-free WPF theme**. Merge one resource dictionary and every standard WPF control is
styled: no MaterialDesign, no MahApps, and no third-party packages.

Targets **.NET Framework 4.8**, **.NET 8** and **.NET 10** (Windows).

## Quick start

Merge the theme in `App.xaml`:

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/TripleZeroLabs.Os2;component/Themes/Theme.xaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

Or apply it from code:

```csharp
using TripleZeroLabs.Os2;

Os2Theme.Apply(this);       // whole application (in App.OnStartup)
Os2Theme.Apply(myWindow);   // one window only: safe for plugin / add-in hosts
```

## What gets styled

**Automatically (implicit styles):** Window, TextBlock, Label, Button, RepeatButton, TextBox, PasswordBox,
RichTextBox, ComboBox, CheckBox, RadioButton, Slider, ListBox, ListView / GridView, DataGrid, TabControl,
Menu / ContextMenu / MenuItem, Separator, ToolBar / ToolBarTray, StatusBar, GroupBox, DatePicker / Calendar,
ProgressBar, Hyperlink, ScrollViewer / ScrollBar, Expander, ToggleButton (sliding switch), TreeView, GridSplitter
and ToolTip.

**Opt-in (keyed styles):**

| Key | Use |
|---|---|
| `OS2.Button.Secondary` / `Danger` / `DangerSolid` / `Flat` / `Subtle` / `Success` / `SuccessSecondary` / `Icon` | Button variants |
| `OS2.ToggleButton.Segment` | Button-shaped toggle for segmented pickers |
| `OS2.Separator.Vertical` | Vertical hairline for horizontal rows |
| `OS2.Text.Heading` / `OS2.Text.Caption` | Typography |
| `OS2.Banner.Default` / `Info` / `Warning` / `Danger` | Notification banners (on a `Border`) |
| `OS2.Dialog` | Floating dialog card (on a `Border`) |
| `OS2.Nav.ListBox` + `OS2.Nav.ListBoxItem` | Sidebar navigation |

```xml
<Button Content="Save" />                                              <!-- primary, implicit -->
<Button Style="{StaticResource OS2.Button.Secondary}" Content="Export" />
<ToggleButton Content="ON" Tag="OFF" IsChecked="{Binding ShowGrid}" /> <!-- switch with labels -->
<ProgressBar Value="40" Foreground="{DynamicResource OS2.Brush.Success}" />
<Slider Value="70" TickFrequency="10" TickPlacement="BottomRight" />
```

Use `{DynamicResource OS2.Brush.*}` for colours (`Primary`, `Surface`, `Border`, `TextPrimary`, `TextSecondary`,
`Success`, `Warning`, `Danger` and more), or the typed constants in `Os2ResourceKey` from C#.

## Extras

- **`Os2MessageBox`**: a styled drop-in for `MessageBox.Show`, with the same overloads and return values.
- **`Os2ContextMenu`**: a fluent builder for themed context menus.

## Links

- Documentation, gallery app and AI-assistant skill: https://github.com/TripleZeroLabs/TripleZeroLabs.Os2
- Release notes: https://github.com/TripleZeroLabs/TripleZeroLabs.Os2/blob/master/CHANGELOG.md
- License: see the `LICENSE` file included in this package.
