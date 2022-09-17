using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;

namespace TZ
{
    public class SerializeData
    {
        public static void SerializeJSON(Person SerializePerson)
        {

            JsonSerializer serializer = new JsonSerializer();
            if (SerializePerson != null)
            using (StreamWriter sw = new StreamWriter($"{SerializePerson.User ?? "None"}.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                try
                {
                    if (SerializePerson != null)
                    {
                        serializer.Serialize(writer, SerializePerson);
                        MessageBox.Show($"Save {SerializePerson.User} complite to path \\TZ\\bin\\Debug\\{SerializePerson.User}.json", "Complite", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        MessageBox.Show("Data is null. Please choose file and try save data", "Not Save", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                catch (Exception e)
                {
                    MessageBox.Show("Save error. Error message: " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                MessageBox.Show("User not selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        }
    }
}
