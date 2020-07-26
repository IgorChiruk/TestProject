using System.Collections.Generic;
using System.IO;
using TaskTexode.Models;
using System.Web.Script.Serialization;


namespace TaskTexode
{
    class JsonSave
    {
        public JsonSave(ApplicationViewModel appView, UserView selecteduser, string FilePath)
        {
            SaveToFile(appView, selecteduser, FilePath);
        }

        private void SaveToFile(ApplicationViewModel appView, UserView selecteduser, string FilePath)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var user = context.FindUserByName(selecteduser.Name);
                Dictionary<string, string> valuePairs = new Dictionary<string, string>();
                valuePairs.Add("Name", appView.SelectedUser.Name);
                var json = new JavaScriptSerializer().Serialize(valuePairs);
                File.AppendAllText(FilePath, json);
                foreach (UserRecord record in user.UserRecords)
                {
                    context.Entry(record).Reference("Day").Load();
                    context.Entry(record).Reference("UserStatus").Load();                   
                    WriterecordToFile(record,FilePath);
                }
            }
        }

        private void WriterecordToFile(UserRecord record,string FilePath)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Dictionary<string, string> valuePairs2 = new Dictionary<string, string>();               
                valuePairs2.Add("Day", record.Day.Id.ToString());
                valuePairs2.Add("Rank", record.Rank);
                valuePairs2.Add("Steps", record.Steps);
                valuePairs2.Add("Status", record.UserStatus.Description);
                var json2 = new JavaScriptSerializer().Serialize(valuePairs2);
                File.AppendAllText(FilePath, json2);
            }
        }
    }
}
