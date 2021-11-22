namespace ASU
{
    public class RankGroups
    {
        public int ID {get; private set;}
        public string CreatedBy {get; private set;}
        public string CreatedAt {get; private set;} //DATE
        public string Name {get; private set;}
        public string ShortName {get; private set;}

        private RankGroups() {}

        public RankGroups( int ID,
                          string CreatedBy, 
                          string CreatedAt, 
                          string Name, 
                          string ShortName )
        {
            this.ID = ID;
            this.CreatedBy = CreatedBy;
            this.CreatedAt = CreatedAt;
            this.Name = Name;
            this.ShortName = ShortName;
        }
    }
}