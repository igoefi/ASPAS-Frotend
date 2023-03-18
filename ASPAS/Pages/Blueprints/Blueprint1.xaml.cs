using ASPAS.Classes;
using ASPAS.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ASPAS.Pages.Blueprints
{
    /// <summary>
    /// Логика взаимодействия для Blueprint1.xaml
    /// </summary>
    public partial class Blueprint1 : Page
    {
        private Dictionary<Button, ErrorClass> _buttons = new Dictionary<Button, ErrorClass>();

        private const string _alertIconPath = "pack://application:,,,/Resources/AlertIcon.png";
        private byte[] AlertColor { get; } = new byte[3] { 241, 143, 1 };

        private const string _errorIconPath = "pack://application:,,,/Resources/ErrorIcon.png";
        private byte[] ErrorColor { get; } = new byte[3] { 255, 37, 37 };



        public Blueprint1()
        {
            InitializeComponent();

            BetaSetup();
            SetButtons();
        }

        private void BetaSetup()
        {
            var rand = new Random();

            _buttons.Add(FirstButton, new ErrorClass { Message = rand.Next(0, 1000).ToString(), Error = Error.Alert });
            _buttons.Add(SecondButton, new ErrorClass { Message = rand.Next(0, 1000).ToString(), Error = Error.Alert });
            _buttons.Add(ThirdButton, new ErrorClass { Message = rand.Next(0, 1000).ToString(), Error = Error.None });
            _buttons.Add(ThourthButton, new ErrorClass { Message = rand.Next(0, 1000).ToString(), Error = Error.Error });
        }

        private void SetButtons()
        {
            foreach (var button in _buttons.Keys)
            {
                var error = _buttons[button];

                if (error.Error == Error.None)
                {
                    button.Visibility = Visibility.Hidden;
                    return;
                }

                var buttonImage = (Image)button.Content;

                string needPath = error.Error == Error.Alert ? _alertIconPath : _errorIconPath;
                
                buttonImage.Source  = new BitmapImage(new Uri(needPath));
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
