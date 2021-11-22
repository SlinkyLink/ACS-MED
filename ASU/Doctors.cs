namespace ASU
{
    public class Doctors
    {
        public int ID {get; private set;}
        public string Username {get; private set;}
        public string CreatedAt {get; private set;}
        public string CreatedBy {get; private set;}

        private Doctors() {}

        public Doctors( int ID, 
                        string Username, 
                        string CreatedAt, 
                        string CreatedBy)
        {
            this.ID = ID;
            this.Username = Username;
            this.CreatedAt = CreatedAt;
            this.CreatedBy = CreatedBy;
        }
    }
}