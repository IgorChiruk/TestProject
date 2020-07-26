using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using TaskTexode.Models;


namespace TaskTexode
{
    public class LoadTestData
    {
        private string directoryPath;
        public LoadTestData(string path)
        {
            this.directoryPath = path;
            Load();
        }

        private void Load()
        {
            List<string> filePaths = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories).ToList();
            foreach (string str in filePaths)
            {           
                string json = new StreamReader(str).ReadToEnd();
                List<JsonDataOfUserRecord> items = JsonConvert.DeserializeObject<List<JsonDataOfUserRecord>>(json);
                CreateRecordsFromList(items); ;
            }
        }

        private void CreateRecordsFromList(IList<JsonDataOfUserRecord> data)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Day day = new Day();
                context.Days.Add(day);
                context.SaveChanges();
                foreach (JsonDataOfUserRecord jsonData in data)
                {                  
                    CheckUserNameAndStatus(jsonData);
                    CreateRecord(jsonData, day);
                }
            }
        }

        private void CreateRecord(JsonDataOfUserRecord jsonData, Day dayyyy)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                UserRecord userRecord = new UserRecord();
                userRecord.Rank = jsonData.Rank;
                userRecord.Steps = jsonData.Steps;

                var statuses = context.UserStatuses.ToList();
                foreach (UserStatus status in statuses)
                {
                    if (status.Description == jsonData.Status)
                    {
                        userRecord.UserStatus = status;
                        break;
                    }
                }

                var users = context.ApplicationUsers.ToList();
                foreach (ApplicationUser user in users)
                {
                    if (user.Name == jsonData.User)
                    {
                        userRecord.ApplicationUser = user;
                        break;
                    }
                }

                var day = context.Days.ToList().LastOrDefault();
                userRecord.Day = day;                         
                context.UserRecords.Add(userRecord);
                context.SaveChanges();
            }
        }

        private void CheckUserNameAndStatus(JsonDataOfUserRecord jsonData)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (FindStatusByDescription(jsonData.Status) == null)
                {
                    CreateUserStatus(jsonData);
                }

                if (FindUserByName(jsonData.User) == null)
                {
                    CreateUser(jsonData);
                }
            }
        }

        private void CreateUserStatus(JsonDataOfUserRecord jsonData)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                UserStatus status = new UserStatus() { Description = jsonData.Status };
                context.UserStatuses.Add(status);
                context.SaveChanges();
            }
        }

        private void CreateUser(JsonDataOfUserRecord jsonData)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                ApplicationUser user = new ApplicationUser() { Name = jsonData.User };
                context.ApplicationUsers.Add(user);
                context.SaveChanges();
            }
        }

        private UserStatus FindStatusByDescription(string statusDescription)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var statuses = context.UserStatuses.ToList();
                foreach (UserStatus status in statuses)
                {
                    if (status.Description == statusDescription)
                    {
                        return status;
                    }
                }
                return null;
            }
        }

        private ApplicationUser FindUserByName(string userName)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var users = context.ApplicationUsers.ToList();
                foreach (ApplicationUser user in users)
                {
                    if (user.Name == userName)
                    {
                        return user;
                    }
                }
                return null;
            }
        }
    }
}
