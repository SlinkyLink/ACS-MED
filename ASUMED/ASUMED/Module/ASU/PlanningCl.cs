namespace ASUMED
{
    public class PlanningCl : DBTable
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

        public override string GetDATA()
        {
            return @$"|->{ClientID}<-|->{PlanID}<-|";
        }

        public override string cmdAddDB()
        {
            VARIBLE = $"({ClientID}, '{PlanID}')";
            return base.cmdAddDB();
        }

        public override string cmdDellDB(string Value)
        {
            return ErrorExceptrionSTR;
        }

        public override string cmdDellDB(int Value)
        {
            string temp;
            if(Value == ClientID) temp = "ClientID";
            else if(Value == PlanID) temp = "PlanID";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
    }
}