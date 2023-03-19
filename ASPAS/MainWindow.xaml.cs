using ASPAS.Classes.Frotend.Helper;
using ASPAS.Pages;
using System.Windows;

namespace ASPAS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameNav.SetFrame(FrmMain);
            FrmMain.Navigate(new PageMain());
        }
    }
}
