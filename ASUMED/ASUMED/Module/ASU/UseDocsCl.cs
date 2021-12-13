using System;

namespace ASUMED
{
    public class UseDocsCl : DBTable
    {
        public int DocID {get; set;}
        public int ClientID {get; set;}
        public UseDocsCl() {}
        public override bool HaveData(string varible, object value)
        {
            if (varible == "DocID")
                if (Convert.ToInt32(value) == DocID) return true;
            if (varible == "ClientID")
                if (Convert.ToInt32(value) == ClientID) return true;
            return false;
        }
        public override string cmdAddDB()
        {
            VARIBLE = $"({DocID}, {ClientID})";

            return base.cmdAddDB();
        } 
        public override string cmdDellDB(string Value)
        {
            return ErrorExceptrionSTR;
        }
        public override string cmdDellDB(int Value)
        {
            string temp;
            if(Value == DocID) temp = "DocID";
            else if(Value == ClientID) temp = "ClientID";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        } 
    }
}