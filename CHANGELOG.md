# Changelog

All notable changes to **TripleZeroLabs.Os2** are documented here.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project follows [Semantic Versioning](https://semver.org/spec/v2.0.0.html).
While the version is below 1.0, minor releases may include visual changes to existing controls.

## [Unreleased]

## [0.2.1] - 2026-11-19

### Fixed

- `Os2MessageBox` no longer crashes inside host applications such as Revit. It used to set `Owner` to
  `Application.Current.MainWindow`, a window the host never shows, so WPF threw
  `InvalidOperationException` ("Cannot set Owner property to a Window that has not been shown previously").
  A window, including one you pass in, now owns the box only when it is loaded and visible on the same
  UI thread; otherwise the box is centred on the screen. Inside a host app, pass your own visible window
  as `owner`.

## [0.2.0] - 2026-11-18

### Added

- Implicit styles for ten more controls — no `Style=` needed:
  - **DatePicker** and **Calendar** — TextBox look with a calendar icon button; rounded day cells,
    today outlined, selected day solid primary. Year/decade views are styled too.
  - **ProgressBar** — slim 6 px rounded bar. The fill follows `Foreground`, so
    `Foreground="{DynamicResource OS2.Brush.Success}"` recolours it. Indeterminate mode animates a sweep.
  - **Hyperlink** — primary blue, underlined on hover; disabled links stay underlined in grey.
  - **ScrollViewer / ScrollBar** — slim arrow-less scrollbars with a rounded thumb and a transparent corner.
  - **Expander** — bordered card with a SemiBold header and a chevron that flips when open.
  - **ToggleButton** — a sliding switch: dark grey when off, primary blue when on, with an animated knob.
    `Content` is the "on" label and `Tag` the "off" label (omit `Tag` to show `Content` in both positions).
    Three-state toggles park the knob mid-track.
  - **TreeView / TreeViewItem** — rotating chevrons, rounded hover rows, RowHighlight selection.
  - **GridSplitter** — 1 px grey line that turns primary blue on hover and drag.
  - **ToolTip** — dark toolbar-coloured bubble with white text and a soft shadow.
- New keyed styles and resources:
  - `OS2.ToggleButton.Segment` — button-shaped toggle for segmented pickers (Day / Week / Month).
  - `OS2.Button.Icon` — square, transparent, glyph-only button.
  - `OS2.Calendar` and `OS2.Calendar.Popup` — calendar, without and with the floating shadow.
  - `OS2.Geometry.ChevronDown`, `ChevronRight`, `ChevronLeft`, `Calendar` — stroked glyph geometries.
  - `OS2.Path.Glyph` — Path style whose stroke follows the parent control's `Foreground`.
  - `OS2.Effect.PopupShadow` — shared drop shadow for floating surfaces.
  - `OS2.ButtonBase` — shared font, size, padding and cursor setters for button-like controls.
- `Os2ResourceKey` constants for the new keys, plus `Button.Subtle`, which was missing.
- Gallery sections for every new control.

### Changed

- **All scrollbars in a themed window now use the slim OS2 style**, including those inside ListBox,
  DataGrid and ComboBox drop-downs.
- All `Button` styles now inherit their shared setters from `OS2.ButtonBase`. Their appearance is unchanged.
- ComboBox drop-downs and context menus now use the shared `OS2.Effect.PopupShadow`. The shadow is
  marginally softer than before.

## [0.1.0] - 2026-09-19

### Added

- First release of the dependency-free WPF theme for `net48`, `net8.0-windows` and `net10.0-windows`.
- Single entry point (`Themes/Theme.xaml`) and `Os2Theme.Apply(...)` for application-wide or per-window use.
  Per-window use is safe in plugin hosts.
- Implicit styles for Window, TextBlock, Label, Button, TextBox, PasswordBox, ComboBox, ComboBoxItem,
  CheckBox, ListBox, DataGrid (column header, row, cell), TabControl, TabItem, ContextMenu and MenuItem.
- Keyed styles: button variants (`Secondary`, `Danger`, `DangerSolid`, `Flat`, `Subtle`, `Success`,
  `SuccessSecondary`), text (`Heading`, `Caption`), banners (`Default`, `Info`, `Warning`, `Danger`),
  `OS2.Dialog`, and sidebar navigation (`OS2.Nav.ListBox`, `OS2.Nav.ListBoxItem`).
- Colour palette and brushes (`OS2.Color.*`, `OS2.Brush.*`) and shared metrics.
- `Os2MessageBox` — styled drop-in replacement for `MessageBox.Show`.
- `Os2ContextMenu` — fluent builder for themed context menus.
- `Os2ResourceKey` — typed constants for every resource key.
- Gallery app and an AI-assistant skill (`os2-wpf-theme/`).

[Unreleased]: https://github.com/TripleZeroLabs/TripleZeroLabs.Os2/compare/v0.2.1...HEAD
[0.2.1]: https://github.com/TripleZeroLabs/TripleZeroLabs.Os2/compare/v0.2.0...v0.2.1
[0.2.0]: https://github.com/TripleZeroLabs/TripleZeroLabs.Os2/compare/v0.1.0...v0.2.0
[0.1.0]: https://github.com/TripleZeroLabs/TripleZeroLabs.Os2/releases/tag/v0.1.0
