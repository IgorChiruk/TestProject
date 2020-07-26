using System;
using System.Windows;
using System.Windows.Controls;
using TaskTexode.Models;


namespace TaskTexode
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {        
            InitializeComponent();
            DataContext = new ApplicationViewModel();        
        }

      

        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplicationViewModel a = this.DataContext as ApplicationViewModel;
            ListView list = (ListView)this.MainGrid.Children[0];
            a.SetUserViewColor(Convert.ToInt32(a.SelectedUser.AverageNumberOfSteps));
            list.Items.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                ApplicationViewModel appView = this.DataContext as ApplicationViewModel;
                var selecteduser = appView.SelectedUser;
                DefaultDialogService service = new DefaultDialogService();
                service.SaveFileDialog();
                if (service.FilePath == null) { return; }
                string extension = System.IO.Path.GetExtension(service.FilePath);              
                if (extension == ".json")
                {
                    //ApplicationViewModel appView = this.DataContext as ApplicationViewModel;
                    //var selecteduser = appView.SelectedUser;
                    if (selecteduser != null)
                    {
                        JsonSave save = new JsonSave(appView, selecteduser, service.FilePath);                     
                    }
                }
                else if (extension == ".xml")
                {
                    //ApplicationViewModel a = this.DataContext as ApplicationViewModel;
                    //var selecteduser = a.SelectedUser;
                    if (selecteduser != null)
                    {                    
                        XMLSave save = new XMLSave(selecteduser,service.FilePath);
                    }
                }
                else if (extension == ".csv")
                {
                    //ApplicationViewModel a = this.DataContext as ApplicationViewModel;
                    //var selecteduser = a.SelectedUser;
                    if (selecteduser != null)
                    {                
                        CSVSave save = new CSVSave(selecteduser, service.FilePath);
                    }
                }

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DefaultDialogService service = new DefaultDialogService();
            service.OpenFileDialog();
            if (service.FilePath != null)
            {
                LoadTestData loadData = new LoadTestData(service.FilePath);
                UpdateListView();
            }
        }

        public void UpdateListView()
        {
            this.DataContext = new ApplicationViewModel();         
        }
    }
}
