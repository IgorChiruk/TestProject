using System.IO;

namespace TaskTexode
{
    class CSVSave
    {
        public CSVSave(UserView selecteduser, string FilePath) 
        {
            SaveToFile(selecteduser, FilePath);
        }

        private void SaveToFile(UserView selecteduser, string FilePath) 
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var user = context.FindUserByName(selecteduser.Name);
                string temp = "day;rank;steps;status;user;best;worst;average\r\n";
                File.AppendAllText(FilePath, temp);
                string userstring = (string)(selecteduser.Name + ";" + selecteduser.BestNumberOfSteps + ";" + selecteduser.WorstNumberOfSteps + ";" + selecteduser.AverageNumberOfSteps + "\r\n");
                foreach (UserRecord record in user.UserRecords)
                {
                    context.Entry(record).Reference("Day").Load();
                    context.Entry(record).Reference("UserStatus").Load();
                    string newrecord = (string)(record.DayId.ToString() + ";" + record.Rank + ";" + record.Steps + ";" + record.UserStatus.Description + ";" + userstring);
                    File.AppendAllText(FilePath, newrecord);
                }
            }
        }
    }
}
