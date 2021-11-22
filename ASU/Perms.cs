namespace ASU
{
    public class Perms
    {
        public int ID {get; private set;}
        public string CreatedBy {get; private set;}
        public string CreatedAt {get; private set;} //DATE
        public string Key {get; private set;}
        public string Desc {get; private set;}

        private Perms() {}
        
        public Perms( int ID, 
                      string CreatedBy, 
                      string CreatedAt, 
                      string Key,
                      string Desc) 
        {
            this.ID = ID;
            this.CreatedBy = CreatedBy;
            this.CreatedAt = CreatedAt;
            this.Key = Key;
            this.Desc = Desc;
        }
    }
}