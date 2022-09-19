using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WSA
{
    public class Person
    {

        private int rank = 0;
        private string user = "None";
        private string status = "None";
        private int steps = 0;
        public static int index = 0;
        private List<int> daySteps;
        private int stepsBest = 0;
        private int stepsAverage = 0;
        private int stepsWorst = 0;
        private int specSteps = 0;
        public Person() { daySteps = new List<int>(); }

        public int Index { private get { return index; } set { index = value; } }
        public List<int> DaySteps { get { return daySteps; } set { daySteps = value; } }
        public int Rank
        {
            get { return rank; }
            set
            {
                rank = value;
                OnPropertyChanged("Rank");
            }
        }

        public string User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        public int Steps
        {
            get { return steps; }
            set
            {
                steps = value;
                OnPropertyChanged("Steps");
            }
        }

        public int SpecSteps
        {
            private get { return specSteps; }
            set
            {
                specSteps = value;
                DaySteps.Add(value);
                StepsBest = value;
                StepsAverage = value;
                StepsWorst = value;
                Index = index;

            }
        }

        public int StepsBest
        {
            get { return stepsBest; }
            set
            {
                if (value > stepsBest)
                    stepsBest = value;
                OnPropertyChanged("StepsBest");
            }
        }

        public int StepsAverage
        {
            get { return stepsAverage; }
            set
            {
                stepsAverage += value / Index;
                OnPropertyChanged("StepsAverage");
            }
        }

        public int StepsWorst
        {
            get { return stepsWorst; }
            set
            {
                if (value < stepsWorst && stepsWorst != 0)
                    stepsWorst = value;
                else if (stepsWorst == 0 && (DaySteps.Count == 1))
                    stepsWorst = value;
                OnPropertyChanged("StepsWorst");
            }
        }
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
