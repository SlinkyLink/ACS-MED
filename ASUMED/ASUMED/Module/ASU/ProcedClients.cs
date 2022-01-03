using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASUMED
{
    internal class ProcedClients : DBTable
    {
        public int ProcedureID { get; set; }
        public int ClientID { get; set; }
        public int DocID { get; set; } //DATE
        public string Time { get; set; }
        public ProcedClients() { }
        public override bool HaveData(string varible, object value)
        {
            if (varible == "ProcedureID")
                if (Convert.ToInt32(value) == ProcedureID) return true;
            if (varible == "ClientID")
                if (Convert.ToInt32(value) == ClientID) return true;
            if (varible == "DocID")
                if (Convert.ToInt32(value) == DocID) return true;
            if (varible == "Time")
                if (value == Time) return true;
            return false;
        }
        public override string cmdAddDB()
        {

            VARIBLE = $"({ProcedureID}, {ClientID}, {DocID}, '{Time}')";
            return base.cmdAddDB();
        }
        public override string cmdDellDB(string Value)
        {
            string temp;
            if (Time == Value) temp = "Time";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = '{Value}'";
            return base.cmdDellDB(Value);
        }
        public override string cmdDellDB(int Value)
        {
            string temp;
            if (Value == ProcedureID) temp = "ProcedureID";
            else if (Value == ClientID) temp = "ClientID";
            else if (Value == DocID) temp = "DocID";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
    }
}

