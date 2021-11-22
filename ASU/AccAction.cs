namespace ASU
{
    public class AccAction
    {
        public int ID {get; private set;}
        public string CreatedBy {get; private set;}
        public string CreatedAt {get; private set;} //DATE
        public string Action {get; private set;}

        private AccAction() {}

        public AccAction( int ID, 
                          string CreatedBy, 
                          string CreatedAt, 
                          string Action )
        {
            this.ID = ID;
            this.CreatedBy = CreatedBy;
            this.CreatedAt = CreatedAt;
            this.Action = Action;
        }
    }
}