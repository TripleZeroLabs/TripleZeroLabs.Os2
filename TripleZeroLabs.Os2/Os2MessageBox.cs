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
    /// <remarks>
    /// Owner: a window only owns the box when it is loaded and visible. Without such an owner the
    /// box is centred on the screen. Inside a host application (Revit, AutoCAD, …) pass your own
    /// visible window as <c>owner</c>; the host's Application.MainWindow is often never shown.
    /// </remarks>
    public static class Os2MessageBox
    {
        // ── one-argument overloads ────────────────────────────────────────────────

        /// <remarks>Owned by Application.MainWindow only if it is loaded and visible; otherwise centred on the screen.
        /// Inside a host app (Revit, AutoCAD) use the overload that takes your own visible window as owner.</remarks>
        public static MessageBoxResult Show(string messageBoxText)
            => Core(null, messageBoxText, string.Empty, MessageBoxButton.OK, MessageBoxImage.None);

        /// <remarks>Inside a host app (Revit, AutoCAD) pass your own visible window as <paramref name="owner"/>.
        /// If it is not loaded and visible, the box is centred on the screen instead.</remarks>
        public static MessageBoxResult Show(Window owner, string messageBoxText)
            => Core(owner, messageBoxText, string.Empty, MessageBoxButton.OK, MessageBoxImage.None);

        // ── two-argument overloads ────────────────────────────────────────────────

        /// <remarks>Owned by Application.MainWindow only if it is loaded and visible; otherwise centred on the screen.
        /// Inside a host app (Revit, AutoCAD) use the overload that takes your own visible window as owner.</remarks>
        public static MessageBoxResult Show(string messageBoxText, string caption)
            => Core(null, messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.None);

        /// <remarks>Inside a host app (Revit, AutoCAD) pass your own visible window as <paramref name="owner"/>.
        /// If it is not loaded and visible, the box is centred on the screen instead.</remarks>
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption)
            => Core(owner, messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.None);

        // ── three-argument overloads ──────────────────────────────────────────────

        /// <remarks>Owned by Application.MainWindow only if it is loaded and visible; otherwise centred on the screen.
        /// Inside a host app (Revit, AutoCAD) use the overload that takes your own visible window as owner.</remarks>
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button)
            => Core(null, messageBoxText, caption, button, MessageBoxImage.None);

        /// <remarks>Inside a host app (Revit, AutoCAD) pass your own visible window as <paramref name="owner"/>.
        /// If it is not loaded and visible, the box is centred on the screen instead.</remarks>
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button)
            => Core(owner, messageBoxText, caption, button, MessageBoxImage.None);

        // ── four-argument overloads (full signature) ──────────────────────────────

        /// <remarks>Owned by Application.MainWindow only if it is loaded and visible; otherwise centred on the screen.
        /// Inside a host app (Revit, AutoCAD) use the overload that takes your own visible window as owner.</remarks>
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
            => Core(null, messageBoxText, caption, button, icon);

        /// <remarks>Inside a host app (Revit, AutoCAD) pass your own visible window as <paramref name="owner"/>.
        /// If it is not loaded and visible, the box is centred on the screen instead.</remarks>
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
            var dialog = new Os2MessageBoxWindow(message, caption, button, icon);

            // Only let a window own the dialog if it is actually on screen. WPF throws when Owner is a
            // window that has never been shown, and host apps such as Revit have an
            // Application.MainWindow that never is. A window from another UI thread can't own it either.
            Window candidate = owner ?? Application.Current?.MainWindow;
            if (CanOwn(candidate, dialog))
                dialog.Owner = candidate;   // keeps the dialog's CenterOwner placement
            else
                dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            dialog.ShowDialog();
            return dialog.Result;
        }

        private static bool CanOwn(Window candidate, Window dialog)
            => candidate != null
            && !ReferenceEquals(candidate, dialog)
            && candidate.Dispatcher == dialog.Dispatcher
            && candidate.IsLoaded
            && candidate.IsVisible;
    }
}
