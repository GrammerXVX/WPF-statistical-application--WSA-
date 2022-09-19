using System.Windows;
using System.Windows.Controls;

namespace WSA
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
        private void MyDataGrid_LoadingRow(object sender, DataGridRowEventArgs e) =>
            ApplicationViewModel.ColorRow(sender, e);

        private void BtnOpenFile_Click(object sender, RoutedEventArgs e) =>
            ApplicationViewModel.RefreshDataGridView(ref DataGrid);

        private void BtnSaveData_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
