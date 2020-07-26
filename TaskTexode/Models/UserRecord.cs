namespace TaskTexode
{
    class UserRecord
    {
        public UserRecord() { }
        public int Id { get; set; }
        public string Rank { get; set; }
        public string Steps { get; set; }

        public int DayId { get; set; }
        public Day Day { get; set; }

        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int UserStatusId { get; set; }
        public UserStatus UserStatus { get; set; }
    }
}
