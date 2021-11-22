namespace ASU
{
    
    public class Accounts
    {
        public int ID {get; private set;}
        public string Username {get; private set;}
        public string CreatedBy {get; private set;}
        public string CreatedAt {get; private set;} //DATE

        private Accounts() {}

        public Accounts( int ID, 
                         string Username, 
                         string CreatedBy, 
                         string CreatedAt )
        {
            this.ID = ID;
            this.Username = Username;
            this.CreatedBy = CreatedBy;
            this.CreatedAt = CreatedAt;
        }
    }
}