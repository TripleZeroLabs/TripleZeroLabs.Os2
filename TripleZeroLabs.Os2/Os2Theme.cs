using System;
using System.Linq;
using System.Windows;

namespace TripleZeroLabs.Os2
{
    /// <summary>
    /// Applies or removes the OS2 theme at runtime without requiring XAML merge statements.
    ///
    /// Standalone WPF app — call once in App.xaml.cs:
    ///     Os2Theme.Apply(this);
    ///
    /// Plugin / add-in — apply per-window so the host app's resources are untouched:
    ///     Os2Theme.Apply(myWindow);
    /// </summary>
    public static class Os2Theme
    {
        private const string ThemeUri =
            "pack://application:,,,/TripleZeroLabs.Os2;component/Themes/Theme.xaml";

        public static void Apply(Application app)       => Merge(app.Resources);
        public static void Apply(FrameworkElement el)   => Merge(el.Resources);

        public static void Remove(Application app)      => Unmerge(app.Resources);
        public static void Remove(FrameworkElement el)  => Unmerge(el.Resources);

        public static bool IsApplied(Application app)      => IsPresent(app.Resources);
        public static bool IsApplied(FrameworkElement el)  => IsPresent(el.Resources);

        private static void Merge(ResourceDictionary target)
        {
            if (IsPresent(target)) return;
            target.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri(ThemeUri) });
        }

        private static void Unmerge(ResourceDictionary target)
        {
            var entry = target.MergedDictionaries
                .FirstOrDefault(d => string.Equals(
                    d.Source?.OriginalString, ThemeUri, StringComparison.Ordinal));
            if (entry != null)
                target.MergedDictionaries.Remove(entry);
        }

        private static bool IsPresent(ResourceDictionary target)
            => target.MergedDictionaries.Any(d =>
                string.Equals(d.Source?.OriginalString, ThemeUri, StringComparison.Ordinal));
    }
}
