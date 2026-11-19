namespace TripleZeroLabs.Os2
{
    /// <summary>
    /// Typed constants for every OS2 resource key.
    ///
    /// C# code-behind:
    ///     element.SetResourceReference(Control.ForegroundProperty, Os2ResourceKey.Brush.Primary);
    ///     var style = (Style)app.FindResource(Os2ResourceKey.Button.Secondary);
    ///
    /// XAML (rare — prefer {DynamicResource OS2.Brush.Primary} directly):
    ///     Foreground="{DynamicResource {x:Static os2:Os2ResourceKey+Brush.Primary}}"
    /// </summary>
    public static class Os2ResourceKey
    {
        /// <summary>SolidColorBrush resources for painting UI elements.</summary>
        public static class Brush
        {
            // Brand
            public const string Primary        = "OS2.Brush.Primary";
            public const string PrimaryHover   = "OS2.Brush.PrimaryHover";
            public const string PrimaryPressed = "OS2.Brush.PrimaryPressed";
            public const string Accent         = "OS2.Brush.Accent";

            // Surfaces
            public const string Background  = "OS2.Brush.Background";
            public const string Surface     = "OS2.Brush.Surface";
            public const string SurfaceAlt  = "OS2.Brush.SurfaceAlt";
            public const string Card        = "OS2.Brush.Card";
            public const string Overlay     = "OS2.Brush.Overlay";

            // Borders
            public const string Border      = "OS2.Brush.Border";
            public const string BorderFocus = "OS2.Brush.BorderFocus";

            // Toolbar / chrome
            public const string Toolbar           = "OS2.Brush.Toolbar";
            public const string ToolbarForeground = "OS2.Brush.ToolbarForeground";

            // Text
            public const string TextPrimary        = "OS2.Brush.TextPrimary";
            public const string TextSecondary      = "OS2.Brush.TextSecondary";
            public const string TextOnPrimary      = "OS2.Brush.TextOnPrimary";
            public const string TextOnPrimarySubtle = "OS2.Brush.TextOnPrimarySubtle";
            public const string TextDisabled       = "OS2.Brush.TextDisabled";

            // Status — danger
            public const string Danger        = "OS2.Brush.Danger";
            public const string DangerHover   = "OS2.Brush.DangerHover";
            public const string DangerSurface = "OS2.Brush.DangerSurface";

            // Status — success
            public const string Success        = "OS2.Brush.Success";
            public const string SuccessHover   = "OS2.Brush.SuccessHover";
            public const string SuccessPressed = "OS2.Brush.SuccessPressed";
            public const string SuccessSurface = "OS2.Brush.SuccessSurface";

            // Status — warning
            public const string Warning = "OS2.Brush.Warning";

            // Row highlight: light blue tint for DataGrid rows with a checked/active property
            public const string RowHighlight = "OS2.Brush.RowHighlight";

            // Banner / toast backgrounds
            public const string BannerInfoBackground    = "OS2.Brush.BannerInfoBackground";
            public const string BannerWarningBackground = "OS2.Brush.BannerWarningBackground";
            public const string BannerDangerBackground  = "OS2.Brush.BannerDangerBackground";
        }

        /// <summary>Named Button styles beyond the default (primary) button.</summary>
        public static class Button
        {
            public const string Secondary        = "OS2.Button.Secondary";
            public const string Danger           = "OS2.Button.Danger";
            public const string DangerSolid      = "OS2.Button.DangerSolid";
            public const string Flat             = "OS2.Button.Flat";
            public const string Success          = "OS2.Button.Success";
            public const string SuccessSecondary = "OS2.Button.SuccessSecondary";
            public const string Subtle           = "OS2.Button.Subtle";
            public const string Icon             = "OS2.Button.Icon";
        }

        /// <summary>Named ToggleButton styles beyond the default (switch) toggle.</summary>
        public static class ToggleButton
        {
            public const string Segment = "OS2.ToggleButton.Segment";
        }

        /// <summary>Banner / toast notification Border styles.</summary>
        public static class Banner
        {
            public const string Default = "OS2.Banner.Default";
            public const string Info    = "OS2.Banner.Info";
            public const string Warning = "OS2.Banner.Warning";
            public const string Danger  = "OS2.Banner.Danger";
        }

        /// <summary>Stroked glyph geometries (use with <see cref="GlyphPath"/>).</summary>
        public static class Geometry
        {
            public const string ChevronDown  = "OS2.Geometry.ChevronDown";
            public const string ChevronRight = "OS2.Geometry.ChevronRight";
            public const string ChevronLeft  = "OS2.Geometry.ChevronLeft";
            public const string Calendar     = "OS2.Geometry.Calendar";
        }

        /// <summary>Path style for stroked glyphs; Stroke follows the inherited text colour (the parent Control's Foreground).</summary>
        public const string GlyphPath = "OS2.Path.Glyph";

        /// <summary>Separator styles beyond the default horizontal hairline.</summary>
        public static class Separator
        {
            /// <summary>1 px vertical hairline for horizontal rows (toolbars, status bars, button groups).</summary>
            public const string Vertical = "OS2.Separator.Vertical";
        }

        /// <summary>Base styles and templates to build your own controls on (use with BasedOn / Template).</summary>
        public static class Base
        {
            /// <summary>Font, size and padding shared by every button-like control (TargetType ButtonBase).</summary>
            public const string Button = "OS2.ButtonBase";
            /// <summary>Setters and template shared by TextBox, PasswordBox and RichTextBox (TargetType Control).</summary>
            public const string TextInput = "OS2.TextInputBase";
            /// <summary>Setters shared by CheckBox and RadioButton (TargetType ToggleButton).</summary>
            public const string Choice = "OS2.ChoiceBase";
            /// <summary>Rounded list row shared by ListBoxItem and the plain-list ListViewItem (TargetType ListBoxItem).</summary>
            public const string ListItem = "OS2.ListItemBase";
            /// <summary>Outlined button ControlTemplate (TargetType ButtonBase) used by OS2.Button.Secondary and RepeatButton.</summary>
            public const string SecondaryButtonTemplate = "OS2.Template.SecondaryButton";
        }

        /// <summary>Shared drop shadow for floating surfaces (drop-downs, menus, tooltips).</summary>
        public const string PopupShadow = "OS2.Effect.PopupShadow";

        /// <summary>Calendar styles.</summary>
        public static class Calendar
        {
            public const string Default = "OS2.Calendar";
            public const string Popup   = "OS2.Calendar.Popup";
        }

        /// <summary>Dialog card Border style.</summary>
        public const string Dialog = "OS2.Dialog";

        /// <summary>Named TextBlock styles.</summary>
        public static class Text
        {
            public const string Heading = "OS2.Text.Heading";
            public const string Caption = "OS2.Text.Caption";
        }

        /// <summary>Vertical navigation list styles.</summary>
        public static class Nav
        {
            public const string ListBox     = "OS2.Nav.ListBox";
            public const string ListBoxItem = "OS2.Nav.ListBoxItem";
        }

        /// <summary>Shared layout metrics (CornerRadius, Thickness).</summary>
        public static class Metric
        {
            public const string CornerRadius    = "OS2.CornerRadius";
            public const string ControlPadding  = "OS2.Thickness.ControlPadding";
        }
    }
}
