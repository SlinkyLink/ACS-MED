using System;
using System.Diagnostics;
namespace ASUMED
{
    public class ClientPills : DBTable
    {
        public int ClientID { get; set; }
        public int PillID { get; set; }
        public int Amount { get; set; }

        public ClientPills() { }
        public override bool HaveData(string varible, object value)
        {
            if (varible == "ClientID")
                if (Convert.ToInt32(value) == ClientID) return true;
            if (varible == "PillID")
                if (Convert.ToInt32(value) == PillID) return true;
            if (varible == "Amount")
                if (Convert.ToInt32(value) == Amount) return true;
            return false;
        }
        public override string cmdAddDB()
        {
            VARIBLE = $"({ClientID}, {PillID}, {Amount} )";

            return base.cmdAddDB();
        }
        public override string cmdDellDB(string Value)
        {
            return ErrorExceptrionSTR;
        }
        public override string cmdDellDB(int Value)
        {
            string temp;
            if (Value == ClientID) temp = "ClientID";
            else if (Value == PillID) temp = "PillID";
            else if (Value == Amount) temp = "Amount";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
    }
}