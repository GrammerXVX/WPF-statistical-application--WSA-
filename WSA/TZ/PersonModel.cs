using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace WSA
{
    public class PersonModel 
    {
        public ObservableCollection<Person> PersonsData { get; private set; }
        private List<ObservableCollection<Person>> PersonsOnDay { get; set; }
        public PersonModel(List<ObservableCollection<Person>> PersonOnDay)
        {
            PersonsData = new ObservableCollection<Person>();
            if (PersonOnDay != null)
            {

                this.PersonsOnDay = PersonOnDay;

                GetData();
            }
            else
                this.PersonsOnDay = new List<ObservableCollection<Person>>();
            
        }

        public ObservableCollection<Person> HandlingData()
        {
            Person.index = PersonsOnDay.Count;
            foreach (Person p1 in PersonsData)
            {
                for (int i = 0; i < PersonsOnDay.Count; i++)
                {
                    foreach (Person p2 in PersonsOnDay[i])
                    {
                        try
                        {
                            if (p1.User == p2.User)
                            {
                                if (p2.StepsAverage != 0)
                                {
                                    PersonsData[i] =  p2;
                                    return PersonsData;
                                }
                                else
                                    p1.SpecSteps = p2.Steps;
                                continue;
                            }
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            SortDataAndRanking();
            return PersonsData;
        }
        private void SortDataAndRanking()
        {
            Person temp;
            for (int i = 0; i < PersonsData.Count- 1; i++)
            {
                for (int j = i + 1; j < PersonsData.Count; j++)
                {
                    if (PersonsData[i].StepsAverage < PersonsData[j].StepsAverage)
                    {
                        temp = PersonsData[i];
                        PersonsData[i] = PersonsData[j];
                        PersonsData[j] = temp;
                    }
                }
            }
            for (int i = 0; i < PersonsData.Count; i++)
            {
                PersonsData[i].Rank = i + 1;
            }
        }
        private void GetData()=>
            PersonsData = JsonConvert.DeserializeObject<ObservableCollection<Person>>(File.ReadAllText(@"Data\\day30.json"));
    }
}
