using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TripleZeroLabs.Os2
{
    public sealed partial class Os2MessageBoxWindow : Window
    {
        public MessageBoxResult Result { get; private set; } = MessageBoxResult.None;

        internal Os2MessageBoxWindow(
            string message,
            string caption,
            MessageBoxButton button,
            MessageBoxImage image)
        {
            InitializeComponent();

            Title             = caption;
            PART_Message.Text = message;

            bool hasCaption = !string.IsNullOrEmpty(caption);
            bool hasIcon    = image != MessageBoxImage.None;

            if (!hasCaption && !hasIcon)
            {
                PART_Header.Visibility = Visibility.Collapsed;
            }
            else
            {
                PART_Title.Text = caption;
                if (!hasCaption)
                    PART_Title.Visibility = Visibility.Collapsed;
                ApplyIcon(image);
            }

            BuildButtons(button, image);
        }

        private void ApplyIcon(MessageBoxImage image)
        {
            string symbol;
            string brushKey;

            switch (image)
            {
                case MessageBoxImage.Error:       // covers Hand (16) and Stop (16)
                    symbol   = "✕";
                    brushKey = Os2ResourceKey.Brush.Danger;
                    break;
                case MessageBoxImage.Warning:     // covers Exclamation (48)
                    symbol   = "!";
                    brushKey = Os2ResourceKey.Brush.Warning;
                    break;
                case MessageBoxImage.Question:
                    symbol   = "?";
                    brushKey = Os2ResourceKey.Brush.Primary;
                    break;
                case MessageBoxImage.Information: // covers Asterisk (64)
                    symbol   = "i";
                    brushKey = Os2ResourceKey.Brush.Primary;
                    break;
                default:
                    PART_IconBorder.Visibility = Visibility.Collapsed;
                    return;
            }

            PART_IconText.Text         = symbol;
            PART_IconBorder.Background = (Brush)FindResource(brushKey);
        }

        private void BuildButtons(MessageBoxButton buttons, MessageBoxImage image)
        {
            // Error dialogs promote the confirm button to DangerSolid — the action is destructive
            bool destructive = image == MessageBoxImage.Error;

            switch (buttons)
            {
                case MessageBoxButton.OK:
                    Add("OK",     MessageBoxResult.OK,     primary: true,  danger: false,       isDefault: true,        isCancel: false);
                    break;

                case MessageBoxButton.OKCancel:
                    Add("Cancel", MessageBoxResult.Cancel, primary: false, danger: false,       isDefault: false,       isCancel: true);
                    Add("OK",     MessageBoxResult.OK,     primary: true,  danger: false,       isDefault: true,        isCancel: false);
                    break;

                case MessageBoxButton.YesNo:
                    Add("No",     MessageBoxResult.No,     primary: false, danger: false,       isDefault: false,       isCancel: false);
                    Add("Yes",    MessageBoxResult.Yes,    primary: true,  danger: destructive, isDefault: !destructive, isCancel: false);
                    break;

                case MessageBoxButton.YesNoCancel:
                    Add("Cancel", MessageBoxResult.Cancel, primary: false, danger: false,       isDefault: false,       isCancel: true);
                    Add("No",     MessageBoxResult.No,     primary: false, danger: false,       isDefault: false,       isCancel: false);
                    Add("Yes",    MessageBoxResult.Yes,    primary: true,  danger: destructive, isDefault: !destructive, isCancel: false);
                    break;
            }
        }

        private void Add(string label, MessageBoxResult result,
                         bool primary, bool danger, bool isDefault, bool isCancel)
        {
            var btn = new Button
            {
                Content   = label,
                IsDefault = isDefault,
                IsCancel  = isCancel,
                Margin    = new Thickness(8, 0, 0, 0),
            };

            if (danger)
                btn.Style = (Style)FindResource(Os2ResourceKey.Button.DangerSolid);
            else if (!primary)
                btn.Style = (Style)FindResource(Os2ResourceKey.Button.Flat);
            // primary && !danger → inherits the implicit primary-blue Button style

            var capture = result;
            btn.Click += (s, e) => Commit(capture);

            PART_Buttons.Children.Add(btn);
        }

        private void Commit(MessageBoxResult result)
        {
            Result       = result;
            DialogResult = true;
        }
    }
}
