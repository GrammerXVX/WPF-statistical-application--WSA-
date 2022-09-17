using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace TZ
{

    class FilesProcessingModel
    {
        private readonly OpenFileDialog openFileDialog;
        public FilesProcessingModel()
        {
            openFileDialog = new OpenFileDialog
            {
                Multiselect = true
            };
        }

        public List<ObservableCollection<Person>> GetFiles()
        {
            List<ObservableCollection<Person>> PersonDataProcessing = new List<ObservableCollection<Person>>();
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            if (openFileDialog.ShowDialog().Value == true)
            {
                foreach (String file in openFileDialog.FileNames)
                    try
                    {
                        PersonDataProcessing.Add(JsonConvert.DeserializeObject<ObservableCollection<Person>>(File.ReadAllText(file)));
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error desiarilize JSON file.");
                    }
                    
                return PersonDataProcessing;
            }
            else
                return null;
           
        }
    }
}
