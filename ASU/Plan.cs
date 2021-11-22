using System.Diagnostics;
namespace ASU
{
    public class Plan
    {
        public int ID {get; private set;}
        public string Username {get; private set;}
        public string PlanAction {get; private set;} //DATE
        public string CreatedBy {get; private set;}
        public string CreatedAt {get; private set;}
        public string Desc {get; private set;}

        private Plan() {}

        public Plan( int ID, 
                     string Username, 
                     string PlanAction, 
                     string CreatedBy, 
                     string CreatedAt, 
                     string Desc )
        {
            this.ID = ID;
            this.Username = Username;
            this.PlanAction = PlanAction;
            this.CreatedBy = CreatedBy;
            this.CreatedAt = CreatedAt;
            this.Desc = Desc;
        }
    }
}