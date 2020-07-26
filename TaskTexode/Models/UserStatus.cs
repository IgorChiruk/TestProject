using System.Collections.Generic;

namespace TaskTexode
{
    class UserStatus
    {
        public UserStatus() { }
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<UserRecord> UserRecords { get; set; }
    }
}
