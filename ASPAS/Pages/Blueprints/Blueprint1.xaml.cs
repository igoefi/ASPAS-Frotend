using ASPAS.Classes;
using ASPAS.Classes.BetaModels;
using ASPAS.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ASPAS.Pages.Blueprints
{
    /// <summary>
    /// Логика взаимодействия для Blueprint1.xaml
    /// </summary>
    public partial class Blueprint1 : Page, ISetModels
    {
        public List<BetaModel> Models { get; set; }

        private readonly Dictionary<Button, ErrorClass> _buttons = new Dictionary<Button, ErrorClass>();

        private const string _alertIconPath = "pack://application:,,,/Resources/AlertIcon.png";
        private byte[] AlertColor { get; } = new byte[3] { 241, 143, 1 };

        private const string _errorIconPath = "pack://application:,,,/Resources/ErrorIcon.png";
        private byte[] ErrorColor { get; } = new byte[3] { 255, 37, 37 };


        public Blueprint1(List<BetaModel> models)
        {
            InitializeComponent();

            Models = models;

            var errors = new List<ErrorClass>();
            foreach (var model in models)
                errors.Add(model.Error);

            BetaSetup(errors);
            SetButtons();
        }

        private void BetaSetup(List<ErrorClass> errors)
        {
            _buttons.Add(FirstButton, errors[0]);
            _buttons.Add(SecondButton, errors[1]);
            _buttons.Add(ThirdButton, errors[2]);
            _buttons.Add(ThourthButton, errors[3]);
        }

        private void SetButtons()
        {
            foreach (var button in _buttons.Keys)
            {
                var error = _buttons[button];
                if (error.Error == Error.None)
                {
                    button.Visibility = Visibility.Hidden;
                    continue;
                }

                var buttonImage = (Image)button.Content;

                string needPath = error.Error == Error.Alert ? _alertIconPath : _errorIconPath;

                buttonImage.Source = new BitmapImage(new Uri(needPath));
            }
        }

        private void BtnClickShowError(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            var error = _buttons[button];

            TxbError.Text = error.Message;

            var colorBrush = error.Error == Error.Alert ?
                new SolidColorBrush(Color.FromRgb(AlertColor[0], AlertColor[1], AlertColor[2])) :
                new SolidColorBrush(Color.FromRgb(ErrorColor[0], ErrorColor[1], ErrorColor[2]));

            ErrorTextBorder.BorderBrush = colorBrush;
            ErrorTextBorder.Visibility = Visibility.Visible;
        }

        private void BtnClickCloseTextBorder(object sender, RoutedEventArgs e) =>
            ErrorTextBorder.Visibility = Visibility.Hidden;

    }
}
