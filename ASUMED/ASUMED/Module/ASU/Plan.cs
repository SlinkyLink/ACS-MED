using System;
using System.Diagnostics;
namespace ASUMED
{
    public class Plan : DBTable
    {
        public int ID {get; set;}
        public string Username {get; set;}
        public string PlanSheduler {get; set;} //DATE
        public string CreatedBy {get; set;}
        public string CreatedAt {get; set;}
        public string Desc {get; set;}
        public Plan() {}
        public override bool HaveData(string varible, object value)
        {
            if (varible == "ID")
                if (Convert.ToInt32(value) == ID) return true;
            if (varible == "Username")
                if ((string)value == Username) return true;
            if (varible == "PlanSheduler")
                if ((string)value == PlanSheduler) return true;
            if (varible == "CreatedBy")
                if ((string)value == CreatedBy) return true;
            if (varible == "CreatedAt")
                if ((string)value == CreatedAt) return true;
            if (varible == "Desc")
                if ((string)value == Desc) return true;
            return false;
        }
        public override string cmdAddDB()
        {
            VARIBLE = $"({ID}, '{Username}', '{PlanSheduler}', '{CreatedBy}', {CreatedAt}, '{Desc}')";

            return base.cmdAddDB();
        }
        public override string cmdDellDB(string Value)
        {
            string temp;
            if(Username == Value) temp = "Username";
            else if(PlanSheduler == Value) temp = "PlanSheduler";
            else if(CreatedBy == Value) temp = "CreatedBy";
            else if(CreatedAt == Value) temp = "CreatedAt";
            else if(Desc == Value) temp = "Desc";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = '{Value}'";
            return base.cmdDellDB(Value);
        }
        public override string cmdDellDB(int Value)
        {
            string temp;
            if(Value == ID) temp = "ID";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
    }
}