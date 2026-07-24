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
        }

        /// <summary>Banner / toast notification Border styles.</summary>
        public static class Banner
        {
            public const string Default = "OS2.Banner.Default";
            public const string Info    = "OS2.Banner.Info";
            public const string Warning = "OS2.Banner.Warning";
            public const string Danger  = "OS2.Banner.Danger";
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
