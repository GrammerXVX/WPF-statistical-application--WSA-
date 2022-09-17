using OxyPlot;
using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media;

namespace TZ
{
    internal class ApplicationViewModel
    {
        private Person selectedPerson;
        private readonly DataModel DataModel;
        private PersonModel PersonModel;
        public ObservableCollection<Person> Persons { get; private set; }

        public PlotModel MyModel { private set; get; }
        private RelayCommand HandlingCommand;
        public RelayCommand CommandProcFileBtn
        {
            get
            {
                HandlingCommand = null;
                return HandlingCommand ??
                  (HandlingCommand = new RelayCommand(obj =>
                  {
                      ProcessingButton();
                      DataGrid.Items.Refresh();
                      
                  }));
            }
        }
        public RelayCommand CommandSaveDataBtn
        {
            get
            {
                HandlingCommand = null;
                return HandlingCommand ??
                  (HandlingCommand = new RelayCommand(obj =>
                  {
                      SaveDataButton();
                  }));
            }
        }
       
        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                selectedPerson = value;
                OnPropertyChanged("SelectedPerson");
            }
        }
        public ApplicationViewModel()
        {
            
            DataModel = new DataModel();
            MyModel = DataModel.MyModel;
            
        }
        public static void ColorRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                Person Person = (Person)e.Row.DataContext;
                double StepsBestPercent = (((double)Person.StepsBest - (double)Person.StepsAverage) / (double)Person.StepsAverage * 100);
                double StepsWorstPercent = (((double)Person.StepsAverage - (double)Person.StepsWorst) / (double)Person.StepsAverage * 100);
                if (StepsBestPercent> 20 || StepsWorstPercent > 20)
                    e.Row.Background = new SolidColorBrush(Colors.BlueViolet);
                else
                    e.Row.Background = new SolidColorBrush(Colors.White);
            }
            catch (Exception)
            {
                return;
            }
        }
        public void ProcessingButton()
        {
            Persons = new ObservableCollection<Person>();
            PersonModel = null;

            FilesProcessingModel filesProcessingModel = new FilesProcessingModel();
            PersonModel= new PersonModel(filesProcessingModel.GetFiles());
            Persons = PersonModel.HandlingData();
            DataGrid.ItemsSource = Persons;
        }
        public void SaveDataButton()=>
            SerializeData.SerializeJSON(SelectedPerson);
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if(SelectedPerson != null)
                MyModel = DataModel.DataViewModel(SelectedPerson);
        }
        private static DataGrid DataGrid;
        public static void RefreshDataGridView(ref DataGrid dataGrid)=>
            DataGrid = dataGrid;

    }
    
}
