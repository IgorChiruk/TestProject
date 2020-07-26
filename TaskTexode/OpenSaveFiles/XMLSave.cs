using System.Linq;
using System.Xml.Linq;

namespace TaskTexode
{
    class XMLSave
    {
        public XMLSave(UserView selecteduser, string FilePath) 
        {
            SaveToFile(selecteduser, FilePath);
        }

        private void SaveToFile(UserView selecteduser, string FilePath)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                XDocument xdoc = new XDocument();
                XElement user = new XElement("user");
                XAttribute name = new XAttribute("name", selecteduser.Name);
                XElement average = new XElement("average", selecteduser.AverageNumberOfSteps);
                XElement best = new XElement("best", selecteduser.BestNumberOfSteps);
                XElement worst = new XElement("worst", selecteduser.WorstNumberOfSteps);
                user.Add(average);
                user.Add(best);
                user.Add(worst);
                user.Add(name);

                var thisuser = context.ApplicationUsers.Where(x => x.Name == selecteduser.Name).FirstOrDefault();
                context.Entry(thisuser).Collection("UserRecords").Load();
                XElement records = new XElement("records");
                foreach (UserRecord userRecord in thisuser.UserRecords)
                {
                    context.Entry(userRecord).Reference("Day").Load();
                    context.Entry(userRecord).Reference("UserStatus").Load();
                    XElement record = new XElement("record");
                    XElement day = new XElement("day", userRecord.DayId);
                    XElement rank = new XElement("rank", userRecord.Rank);
                    XElement steps = new XElement("steps", userRecord.Steps);
                    XElement status = new XElement("status", userRecord.UserStatus.Description);

                    record.Add(day);
                    record.Add(rank);
                    record.Add(steps);
                    record.Add(status);
                    records.Add(record);
                }
                user.Add(records);
                xdoc.Add(user);
                xdoc.Save(FilePath);
            }
        }

    }
}
