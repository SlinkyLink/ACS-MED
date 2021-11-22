namespace ASU
{
    public class PlanningCl
    {
        public int ClientID {get; private set;}
        public int PlanID {get; private set;}

        private PlanningCl() {}

        public PlanningCl( int ClientID, 
                           int PlanID )
        {
            this.ClientID = ClientID;
            this.PlanID = PlanID;
        }
    }
}