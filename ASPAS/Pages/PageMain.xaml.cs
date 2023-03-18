using ASPAS.Classes.BetaModels;
using ASPAS.Pages.Blueprints;
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

namespace ASPAS.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        #region BetaData
        private Dictionary<string, Dictionary<string, Page>> _manufactures = new Dictionary<string, Dictionary<string, Page>>();
        private Dictionary<string, Page> _blueprints = new Dictionary<string, Page>();

        private Dictionary<string, Page> _selectedBlueprints;

        private List<BetaModel> _problems = new List<BetaModel>() {
            new BetaModel() {Id = 1, Name = "Problems 1"},
            new BetaModel() {Id = 2, Name = "Problems 2"},
            new BetaModel() {Id = 3, Name = "Problems 3"},
            new BetaModel() {Id = 4, Name = "Problems 4"},
            new BetaModel() {Id = 5, Name = "Problems 5"},
            new BetaModel() {Id = 6, Name = "Problems 6"},
            new BetaModel() {Id = 7, Name = "Problems 7"},
            new BetaModel() {Id = 1, Name = "Problems 8"},
        };

        private List<BetaModel> _realTimes = new List<BetaModel>() {
            new BetaModel() {Id = 1, Name = "RealTime 1"},
            new BetaModel() {Id = 2, Name = "RealTime 2"},
            new BetaModel() {Id = 3, Name = "RealTime 3"},
            new BetaModel() {Id = 4, Name = "RealTime 4"},
            new BetaModel() {Id = 5, Name = "RealTime 5"},
            new BetaModel() {Id = 6, Name = "RealTime 6"},
            new BetaModel() {Id = 7, Name = "RealTime 7"},
            new BetaModel() {Id = 8, Name = "RealTime 8"},
        };

        private List<BetaModel> _recommendeds = new List<BetaModel>() {
            new BetaModel() {Id = 1, Name = "Recommended 1"},
            new BetaModel() {Id = 2, Name = "Recommended 2"},
            new BetaModel() {Id = 3, Name = "Recommended 3"},
            new BetaModel() {Id = 4, Name = "Recommended 4"},
            new BetaModel() {Id = 5, Name = "Recommended 5"},
            new BetaModel() {Id = 6, Name = "Recommended 6"},
            new BetaModel() {Id = 7, Name = "Recommended 7"},
            new BetaModel() {Id = 8, Name = "Recommended 8"},
        };
        #endregion

        public PageMain()
        {
            InitializeComponent();
            _blueprints.Add("Схема1", new Blueprint1());
            _blueprints.Add("Схема2", new Blueprint2());
            _manufactures.Add("Цех 1", _blueprints);
            _manufactures.Add("Цех 2", _blueprints);
            CmbBoxManufactory.ItemsSource = _manufactures.Keys;

            GridRealTimeList.ItemsSource = _realTimes;
            GridProblemsList.ItemsSource = _problems;
            GridRecomList.ItemsSource = _recommendeds;

            ProfileLogin.Visibility = Visibility.Visible;
        }

        #region Open-Close RightMenu
        private void BtnClickExitSettings(object sender, RoutedEventArgs e)
        => Settings.Visibility = Visibility.Hidden;

        private void BtnClickOpenSettings(object sender, RoutedEventArgs e) =>
            Settings.Visibility = Visibility.Visible;

        private void BtnClickOpenProfile(object sender, RoutedEventArgs e)
        {
            if (CmbBoxManufactory.IsEnabled)
                Profile.Visibility = Visibility.Visible;
            else
                ProfileLogin.Visibility = Visibility.Visible;
        }

        private void BtnClickExitProfile(object sender, RoutedEventArgs e) =>
            Profile.Visibility = Visibility.Hidden;

        private void BtnClickExitArchive(object sender, RoutedEventArgs e) =>
            Archive.Visibility = Visibility.Hidden;

        private void BtnClickOpenArchive(object sender, RoutedEventArgs e) =>
            Archive.Visibility = Visibility.Visible;
        #endregion

        private void CmbBoxSelectedUpdateTime(object sender, RoutedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            int.TryParse(comboBox.SelectedItem.ToString(), out int time);

            //backend
        }

        private void CmbBoxSelectedNotifications(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;

        }

        private void CmbBoxSelectedColorIndication(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;

        }

        private void CmbBoxChangedBlueprints(object sender, SelectionChangedEventArgs e)
        {
            var selectedBlueprint = (string)CmbBoxBlueprints.SelectedItem;
            if (selectedBlueprint == null) return;
            FrmBlueprints.Navigate(_selectedBlueprints[selectedBlueprint]);
            IndicatorsGrids.Visibility = Visibility.Visible;
        }

        private void CmbBoxChangedManufactory(object sender, SelectionChangedEventArgs e)
        {
            var manufacture = (string)CmbBoxManufactory.SelectedItem;
            _selectedBlueprints = _manufactures[manufacture];
            CmbBoxBlueprints.ItemsSource =  _selectedBlueprints.Keys;
            CmbBoxBlueprints.SelectedIndex = 0;
            CmbBoxBlueprints.IsEnabled = true;
        }


        private void BtnRealTime_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            MessageBox.Show(button.ContentStringFormat);
        }

        private void BtnRecommended_Click(object sender, RoutedEventArgs e)
        {

        }


        private void BtnProblems_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClickErrorButton(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClickLogin(object sender, RoutedEventArgs e)
        {
            //back

            CmbBoxManufactory.IsEnabled = true;
            ProfileLogin.Visibility = Visibility.Hidden;
        }

        private void BtnClickExitProfileLogin(object sender, RoutedEventArgs e) =>
            ProfileLogin.Visibility = Visibility.Hidden;


    }
}
