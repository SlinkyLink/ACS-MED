namespace ASU
{
    public class Clients
    {
        public int ID {get; private set;}
        public string Username {get; private set;}
        public string DateStart {get; private set;}
        public string DateEnd {get; private set;}
        public string CreatedAt {get; private set;} //DATE

        private Clients() {}

        public Clients( int ID, 
                        string Username, 
                        string DateStart, 
                        string DateEnd, 
                        string CreatedAt)
        {
            this.ID = ID;
            this.Username = Username;
            this.DateStart = DateStart;
            this.DateEnd = DateEnd;
            this.CreatedAt = CreatedAt;
        }
    }
}