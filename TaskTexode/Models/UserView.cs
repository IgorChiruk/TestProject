using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace TaskTexode
{
    class UserView
    {
        public UserView(){}

        public UserView(string name,string average, string best,string worst)
        {          
            using (ApplicationContext context = new ApplicationContext())
            {
                this.name = name;
                this.averageNumberOfSteps = average;
                this.bestNumberOfSteps = best;
                this.worstNumberOfSteps = worst;

                ApplicationUser user = context.FindUserByName(this.name);           

                foreach (UserRecord record in user.UserRecords)
                {
                    GraphData data = new GraphData() { Day = record.DayId, Steps = Convert.ToInt32(record.Steps) };
                    Graph.Add(data);
                }
            }
        }
        private string name { get; set; }
        private string averageNumberOfSteps { get; set; }
        private string bestNumberOfSteps { get; set; }
        private string worstNumberOfSteps { get; set; }

        private ObservableCollection<GraphData> graph = new ObservableCollection<GraphData>();

        private Color backgroundColor = Colors.White;


        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                backgroundColor = value;
                OnPropertyChanged("BackgroundColor");
            }
        }

        public string AverageNumberOfSteps
        {
            get { return averageNumberOfSteps; }
            set
            {
                averageNumberOfSteps = value;
                OnPropertyChanged("AverageNumberOfStepse");
            }
        }
        public string BestNumberOfSteps
        {
            get { return bestNumberOfSteps; }
            set
            {
                bestNumberOfSteps = value;
                OnPropertyChanged("BestNumberOfSteps");
            }
        }
        public string WorstNumberOfSteps
        {
            get { return worstNumberOfSteps; }
            set
            {
                worstNumberOfSteps = value;
                OnPropertyChanged("WorstNumberOfSteps");
            }
        }

        public ObservableCollection<GraphData> Graph
        {
            get { return graph; }
            set 
            { 
                graph = value;
                OnPropertyChanged("SelectedPhone");
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
