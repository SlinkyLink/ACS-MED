using System;
namespace ASUMED
{
    public class AccActions : DBTable
    {
        public int ID { get; set; }
        public string CreatedBy {get; set;}
        public string CreatedAt {get; set;} //DATE
        public string Action { get; set; }
        public AccActions() {}
        public override bool HaveData(string varible, object value)
        {
            if(varible == "ID")
                if(Convert.ToInt32(value) == ID) return true;
            if (varible == "CreatedAt")
                if ((string)value == CreatedAt) return true;
            if (varible == "CreatedBy")
                if ((string)value == CreatedBy) return true;
            if (varible == "Action")
                if ((string)value == Action) return true;
            return false;
        }
        public override string cmdAddDB()
        {

            VARIBLE = $"({ID}, '{CreatedBy}', {CreatedAt}, '{Action}')";
            return base.cmdAddDB();
        }
        public override string cmdDellDB(string Value)
        {
            string temp;
            if(CreatedBy == Value) temp = "CreatedBy";
            else if(CreatedAt == Value) temp = "CreatedAt";
            else if(Action == Value) temp = "Action";
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