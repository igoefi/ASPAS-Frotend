using ASPAS.Classes;
using ASPAS.Classes.BetaModels;
using ASPAS.Classes.Enums;
using ASPAS.Pages.Blueprints;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ASPAS.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        #region BetaData
        private readonly Dictionary<string, Dictionary<string, ISetModels>> _manufactures = new Dictionary<string, Dictionary<string, ISetModels>>();
        private readonly Dictionary<string, ISetModels> _blueprints = new Dictionary<string, ISetModels>();

        private Dictionary<string, ISetModels> _selectedBlueprints;

        private readonly List<BetaModel> _realTime1 = new List<BetaModel>() 
        {
            new BetaModel() {Name = "Параметр 1", Arg = "xf", Error = new ErrorClass { Error = Error.Alert, Message = "dasd"} },
            new BetaModel() {Name = "Параметр 2", Arg = "1121f", Error = new ErrorClass { Error = Error.None, Message = "dacvsdsd"}},
            new BetaModel() {Name = "Параметр 3", Arg = "cf1f", Error = new ErrorClass { Error = Error.Error, Message = "daqwsd"}},
            new BetaModel() {Name = "Параметр 4", Arg = "2sd1f", Error = new ErrorClass { Error = Error.None, Message = "d6458asd"}}
        };

        private readonly List<BetaModel> _realTime2 = new List<BetaModel>() 
        {
            new BetaModel() {Name = "Параметр 1", Arg = "xf", Error = new ErrorClass { Error = Error.Error, Message = "dasd"} },
            new BetaModel() {Name = "Параметр 2", Arg = "1121f", Error = new ErrorClass { Error = Error.Error, Message = "dacvsdsd"}},
            new BetaModel() {Name = "Параметр 4", Arg = "cf1f", Error = new ErrorClass { Error = Error.Alert, Message = "daqwsd"}},
            new BetaModel() {Name = "Параметр 4", Arg = "2sd1f", Error = new ErrorClass { Error = Error.Error, Message = "d6458asd"}}
        };

        private readonly List<ArchiveClass> _archiveClasses = new List<ArchiveClass>
        {
            new ArchiveClass(){ Date = "12.06", Errors = new List<BetaModel>{new BetaModel() { Name = "first", Arg = "High"}, new BetaModel() { Name = "second", Arg = "medium"}}},
            new ArchiveClass(){ Date = "13.06", Errors = new List<BetaModel>{new BetaModel() { Name = "first", Arg = "High"}, new BetaModel() { Name = "second", Arg = "medium"}}},
            new ArchiveClass(){ Date = "14.06", Errors = new List<BetaModel>{new BetaModel() { Name = "first", Arg = "High"}, new BetaModel() { Name = "second", Arg = "medium"}}}
        };

        #endregion

        public PageMain()
        {
            InitializeComponent();

            _blueprints.Add("Схема1", new Blueprint1(_realTime1));
            _blueprints.Add("Схема2", new Blueprint1(_realTime2));
            _manufactures.Add("Цех 1", _blueprints);
            _manufactures.Add("Цех 2", _blueprints);
            CmbBoxManufactory.ItemsSource = _manufactures.Keys;

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
            SetIndicators();

            IndicatorsGrids.Visibility = Visibility.Visible;
        }

        private void CmbBoxChangedManufactory(object sender, SelectionChangedEventArgs e)
        {
            var manufacture = (string)CmbBoxManufactory.SelectedItem;
            _selectedBlueprints = _manufactures[manufacture];
            CmbBoxBlueprints.ItemsSource = _selectedBlueprints.Keys;
            CmbBoxBlueprints.SelectedIndex = 0;
            CmbBoxBlueprints.IsEnabled = true;
        }


        private void BtnRealTime_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            MessageBox.Show(button.Content.ToString());
        }

        private void BtnClickLogin(object sender, RoutedEventArgs e)
        {
            //back

            CmbBoxManufactory.IsEnabled = true;
            ProfileLogin.Visibility = Visibility.Hidden;
            DataGridArchive.ItemsSource = _archiveClasses;
        }

        private void BtnClickExitProfileLogin(object sender, RoutedEventArgs e) =>
            ProfileLogin.Visibility = Visibility.Hidden;

        private void SetIndicators()
        {
            var selectedBlueprint = (string)CmbBoxBlueprints.SelectedItem;
            var selectedManufacture = (string)CmbBoxManufactory.SelectedItem;

            if (selectedBlueprint == null || selectedManufacture == null) return;

            var models = _manufactures[selectedManufacture][selectedBlueprint].Models;

            GridRealTimeList.ItemsSource = models;
            GridRecomList.ItemsSource = GetTypeModels(models, Error.Alert);
            GridProblemsList.ItemsSource = GetTypeModels(models, Error.Error);
        }

        private List<BetaModel> GetTypeModels(List<BetaModel> originalModels, Error errorType)
        {
            var needModels = new List<BetaModel>();
            foreach (var model in originalModels)
                if(model.Error.Error == errorType)
                    needModels.Add(model);
            return needModels;
        }

        private void BtnClickShowErrorMessage(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var name = button.FontFamily.Source;

            var errorMessage = GetErrorMessage(name);

            if (errorMessage == null) return;

            MessageBox.Show(errorMessage);
        }

        private string GetErrorMessage(string indicatorName)
        {
            var selectedBlueprint = (string)CmbBoxBlueprints.SelectedItem;
            var selectedManufacture = (string)CmbBoxManufactory.SelectedItem;
            var models = _manufactures[selectedManufacture][selectedBlueprint].Models;

            foreach (var model in models)
                if (model.Name == indicatorName)
                    return model.Error.Message;
            return null;
        }
    }
}
