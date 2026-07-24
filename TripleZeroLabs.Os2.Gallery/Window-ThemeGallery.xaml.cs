using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TripleZeroLabs.Os2;

namespace TripleZeroLabs.Os2.Gallery
{
    /// <summary>
    /// A living style guide for the OS2 theme: every control the theme styles,
    /// shown with sample data and its hover / active / disabled states. Kept in the theme
    /// library itself so it travels with the theme if it is ever split into its own package
    /// (and doubles as a quick visual regression check).
    /// </summary>
    public partial class Window_ThemeGallery : Window
    {
        /// <summary>Sample row for the demo DataGrid.</summary>
        public class SampleItem
        {
            public string Name { get; set; }
            public string Id { get; set; }
            public string Category { get; set; }
            public bool Active { get; set; }
        }

        public Window_ThemeGallery()
        {
            InitializeComponent();

            LoadSampleCombo();
            LoadSampleGrid();
            BuildSwatches();
        }

        private void LoadSampleCombo()
        {
            SampleCombo.ItemsSource = new List<string>
            {
                "Draft", "In Review", "Published", "Archived", "Deprecated"
            };
            SampleCombo.SelectedIndex = 2;
        }

        private void LoadSampleGrid()
        {
            var rows = new List<SampleItem>
            {
                new SampleItem { Name = "Customer Report Q1",  Id = "doc-2024-0001", Category = "Report",    Active = true  },
                new SampleItem { Name = "Product Roadmap",     Id = "doc-2024-0002", Category = "Document",  Active = true  },
                new SampleItem { Name = "Brand Guidelines",    Id = "doc-2024-0003", Category = "Document",  Active = false },
                new SampleItem { Name = "API Reference",       Id = "doc-2024-0004", Category = "Reference", Active = true  },
                new SampleItem { Name = "Release Notes 2.0",  Id = "doc-2024-0005", Category = "Release",   Active = true  },
                new SampleItem { Name = "Migration Guide",     Id = "doc-2024-0006", Category = "Reference", Active = false },
            };

            SampleGrid.ItemsSource = rows;

            // Pre-select a row so the active (selected) state is visible on open.
            SampleGrid.SelectedIndex = 1;
        }

        /// <summary>
        /// Build a swatch for each theme brush, reading the live resources so the gallery always
        /// reflects the current palette rather than a hard-coded copy.
        /// </summary>
        private void BuildSwatches()
        {
            var swatches = new (string Label, string Key)[]
            {
                ("Primary",          "OS2.Brush.Primary"),
                ("Primary Hover",    "OS2.Brush.PrimaryHover"),
                ("Primary Pressed",  "OS2.Brush.PrimaryPressed"),
                ("Accent",           "OS2.Brush.Accent"),
                ("Toolbar",          "OS2.Brush.Toolbar"),
                ("Background",       "OS2.Brush.Background"),
                ("Surface",          "OS2.Brush.Surface"),
                ("Surface Alt",      "OS2.Brush.SurfaceAlt"),
                ("Border",           "OS2.Brush.Border"),
                ("Text Primary",     "OS2.Brush.TextPrimary"),
                ("Text Secondary",   "OS2.Brush.TextSecondary"),
                ("Success",          "OS2.Brush.Success"),
                ("Success Hover",    "OS2.Brush.SuccessHover"),
                ("Success Pressed",  "OS2.Brush.SuccessPressed"),
                ("Success Surface",  "OS2.Brush.SuccessSurface"),
                ("Warning",          "OS2.Brush.Warning"),
                ("Danger",           "OS2.Brush.Danger"),
                ("Danger Hover",     "OS2.Brush.DangerHover"),
                ("Row Highlight",    "OS2.Brush.RowHighlight"),
                ("Banner Info",      "OS2.Brush.BannerInfoBackground"),
                ("Banner Warning",   "OS2.Brush.BannerWarningBackground"),
                ("Banner Danger",    "OS2.Brush.BannerDangerBackground")
            };

            var borderBrush  = TryBrush("OS2.Brush.Border")         ?? Brushes.Gray;
            var captionBrush = TryBrush("OS2.Brush.TextSecondary")   ?? Brushes.Gray;
            var codeBrush    = TryBrush("OS2.Brush.TextPrimary")     ?? Brushes.Black;

            foreach (var (label, key) in swatches)
            {
                var brush = TryBrush(key);
                if (brush == null) continue;

                var hexValue = (brush as SolidColorBrush)?.Color.ToString() ?? string.Empty;

                var hexForMenu = hexValue;
                var chip = new Border
                {
                    Height = 52,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Background = brush,
                    BorderBrush = borderBrush,
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(6),
                    ContextMenu = Os2ContextMenu.Create()
                        .Item("Copy hex", () => Clipboard.SetText(hexForMenu))
                        .Build()
                };

                var name = new TextBlock
                {
                    Text = label,
                    FontSize = 11,
                    Foreground = captionBrush,
                    Margin = new Thickness(0, 6, 0, 0),
                    TextWrapping = TextWrapping.Wrap
                };

                // Clickable hex — copies value to clipboard on click.
                var hex = new TextBlock
                {
                    Text = hexValue,
                    FontFamily = new FontFamily("Consolas"),
                    FontSize = 10,
                    Foreground = codeBrush,
                    Margin = new Thickness(0, 2, 0, 0),
                    Cursor = Cursors.Hand,
                    ToolTip = "Click to copy"
                };
                hex.MouseDown += (s, _) =>
                {
                    var tb = (TextBlock)s;
                    Clipboard.SetText(tb.Text);
                    tb.ToolTip = "Copied!";
                    var timer = new System.Windows.Threading.DispatcherTimer
                    {
                        Interval = System.TimeSpan.FromSeconds(1.5)
                    };
                    timer.Tick += (_, __) => { tb.ToolTip = "Click to copy"; timer.Stop(); };
                    timer.Start();
                };

                var cell = new StackPanel
                {
                    Width = 100,
                    Margin = new Thickness(0, 0, 16, 16)
                };
                cell.Children.Add(chip);
                cell.Children.Add(name);
                cell.Children.Add(hex);

                SwatchPanel.Children.Add(cell);
            }
        }

        private Brush TryBrush(string key)
        {
            return TryFindResource(key) as Brush;
        }
    }
}
