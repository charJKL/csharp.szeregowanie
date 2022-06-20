using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.IO;
using Microsoft.Win32;

using Szeregowanie.Utility;
using Szeregowanie.Utility.Factories;
using Szeregowanie.View.Chart;
using Szeregowanie.Model;

namespace Szeregowanie.ViewModel
{
    class LobbyViewModel : Bindable
    {
        public List<TaskWrapper> Tasks
        {
            get
            {
                return _Tasks;
            }
            set
            {
                if (value == null)
                    return;
                _Tasks = value;
                RaisePropertyChanged();
            }
        }
        public Canvas Chart
        {
            get
            {
                return _Chart;
            }
            set
            {
                _Chart = value;
                RaisePropertyChanged();
            }
        }
       
        private List<TaskWrapper> _Tasks;
        private Canvas _Chart;

        public LobbyViewModel()
        {
            NumerFactory.Reset();
            Tasks = new List<TaskWrapper>();
        }
           
        public void CreateRandomData()
        {
            NumerFactory.Reset();
            Random random = new Random();
            List<TaskWrapper> randomTasks = new List<TaskWrapper>();
            int count = random.Next(2, 100);
            while (count-- > 0)
                randomTasks.Add(new TaskWrapper() { Time = new int[2] { random.Next(0, 50), random.Next(0, 50) } });
            Tasks = randomTasks;
        }

        public List<string> LoadDataFromFile()
        {
            NumerFactory.Reset();
            OpenFileDialog filePopup = new OpenFileDialog();
            filePopup.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            filePopup.FilterIndex = 1;
            filePopup.Multiselect = false;

            bool? fileSelected = filePopup.ShowDialog();

            if (fileSelected == true)
            {
                StreamReader data = new StreamReader(filePopup.FileName);
                string rawTask;
                List<TaskWrapper> readTasks = new List<TaskWrapper>();
                List<string> UnunderstoodLines = new List<string>();
                while ( (rawTask = data.ReadLine()) != null )
                {
                    var times = rawTask.Split(' ');
                    if ( times.Length < 1)
                        continue;

                    int[] time = new int[2];
                    if (!Int32.TryParse(times[0], out time[0]))
                    {
                        UnunderstoodLines.Add(rawTask+" - pominięto ");
                        continue;
                    }
                       
                    if (!Int32.TryParse(times[1], out time[1]))
                    {
                        UnunderstoodLines.Add(rawTask+ " - pominięto");
                        continue;
                    }
                        
                    if( time[0] < 0)
                    {
                        UnunderstoodLines.Add(rawTask+" - wyzerowano czas dla pierwszej maszyny.");
                        time[0] = 0;
                    }
                    if (time[1] < 0)
                    {
                        UnunderstoodLines.Add(rawTask + " - wyzerowano czas dla drugiej maszyny.");
                        time[1] = 0;
                    }

                    readTasks.Add(new TaskWrapper() { Time = new int[2] { time[0], time[1] } });
                }
                data.Close();
                Tasks = readTasks;
                return UnunderstoodLines;
            }
            return new List<string>() { "Cancel" };
        }

        public bool FindSolution()
        {
            if (!CheckData())
                return false;

            Algorithm Algorithm = new Algorithm(Tasks);
            var solution = Algorithm.FindSolution();
            var nodes = Algorithm.GetNodes();
            Chart = (new ChartBuilder(Tasks)).Draw(solution);

            return true;
        }

        private bool CheckData()
        {
            if( Tasks.Count < 1)
                return false;

            foreach (TaskWrapper task in Tasks)
                if (!task.isValid())
                    return false;
         
            return true;
        }
    }
}