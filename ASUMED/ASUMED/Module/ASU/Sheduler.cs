using System;

namespace ASUMED
{
    public class Sheduler : DBTable
    {
        public int ID {get; set;}
        public int ClientID {get; set;}
        public int DoctorID {get; set;}
        public string DateTime {get; set;} //DATE
        public int DrugID {get; set;}
        public int ActionID {get; set;}
        public Sheduler() {}
        public override bool HaveData(string varible, object value)
        {
            if (varible == "ID")
                if (Convert.ToInt32(value) == ID) return true;
            if (varible == "ClientID")
                if (Convert.ToInt32(value) == ClientID) return true;
            if (varible == "DoctorID")
                if (Convert.ToInt32(value) == DoctorID) return true;
            if (varible == "DateTime")
                if ((string)value == DateTime) return true;
            if (varible == "DrugID")
                if (Convert.ToInt32(value) == DrugID) return true;
            if (varible == "ActionID")
                if (Convert.ToInt32(value) == ActionID) return true;
            return false;
        }
        public override string cmdAddDB()
        {

            VARIBLE = $"({ID},{ClientID}, {DoctorID}, {DateTime}, {DrugID}, {ActionID})";

            return base.cmdAddDB();
        }
        public override string cmdDellDB(string Value)
        {
            string temp;
            if(DateTime == Value) temp = "DateTime";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = '{Value}'";
            return base.cmdDellDB(Value);
        }
        public override string cmdDellDB(int Value)
        {
            string temp;
            if(Value == ID) temp = "ID";
            else if (Value == ClientID) temp = "ClientID";
            else if(Value == DoctorID) temp = "DoctorID";
            else if(Value == DrugID) temp = "DrugID";
            else if(Value == ActionID) temp = "ActionID";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
    }
}