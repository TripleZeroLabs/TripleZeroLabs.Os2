using System.Windows;

namespace TripleZeroLabs.Os2
{
    /// <summary>
    /// Drop-in replacement for WPF's <see cref="MessageBox"/> with OS2 styling.
    ///
    /// Find-replace <c>MessageBox</c> → <c>Os2MessageBox</c>.
    /// All overloads and return types match the original exactly.
    ///
    ///     Os2MessageBox.Show("Settings saved.");
    ///
    ///     var r = Os2MessageBox.Show("Delete this item?", "Confirm",
    ///                 MessageBoxButton.OKCancel, MessageBoxImage.Warning);
    ///     if (r == MessageBoxResult.OK) { /* proceed */ }
    /// </summary>
    public static class Os2MessageBox
    {
        // ── one-argument overloads ────────────────────────────────────────────────

        public static MessageBoxResult Show(string messageBoxText)
            => Core(null, messageBoxText, string.Empty, MessageBoxButton.OK, MessageBoxImage.None);

        public static MessageBoxResult Show(Window owner, string messageBoxText)
            => Core(owner, messageBoxText, string.Empty, MessageBoxButton.OK, MessageBoxImage.None);

        // ── two-argument overloads ────────────────────────────────────────────────

        public static MessageBoxResult Show(string messageBoxText, string caption)
            => Core(null, messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.None);

        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption)
            => Core(owner, messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.None);

        // ── three-argument overloads ──────────────────────────────────────────────

        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button)
            => Core(null, messageBoxText, caption, button, MessageBoxImage.None);

        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button)
            => Core(owner, messageBoxText, caption, button, MessageBoxImage.None);

        // ── four-argument overloads (full signature) ──────────────────────────────

        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
            => Core(null, messageBoxText, caption, button, icon);

        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
            => Core(owner, messageBoxText, caption, button, icon);

        // ── implementation ────────────────────────────────────────────────────────

        private static MessageBoxResult Core(
            Window owner,
            string message,
            string caption,
            MessageBoxButton button,
            MessageBoxImage icon)
        {
            var dialog = new Os2MessageBoxWindow(message, caption, button, icon)
            {
                Owner = owner ?? Application.Current?.MainWindow
            };
            dialog.ShowDialog();
            return dialog.Result;
        }
    }
}
