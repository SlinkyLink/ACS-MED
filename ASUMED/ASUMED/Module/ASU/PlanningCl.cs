using System;

namespace ASUMED
{
    public class PlanningCl : DBTable
    {
        public int ClientID {get; set;}
        public int PlanID {get; set;}
        public PlanningCl() {}
        public override bool HaveData(string varible, object value)
        {
            if (varible == "ClientID")
                if (Convert.ToInt32(value) == ClientID) return true;
            if (varible == "PlanID")
                if (Convert.ToInt32(value) == PlanID) return true;
            return false;
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