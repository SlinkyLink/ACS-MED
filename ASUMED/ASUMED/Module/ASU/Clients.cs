using System;

namespace ASUMED
{
    public class Clients : DBTable
    {
        public int ID {get; set;}
        public string Username {get; set;}
        public string NumberPhone { get; set;}
        public string CreatedAt {get; set;} //DATE
        public Clients() {}
        public override bool HaveData(string varible, object value)
        {
            if (varible == "ID")
                if (Convert.ToInt32(value) == ID) return true;
            if (varible == "Username")
                if ((string)value == Username) return true;
            if (varible == "ID")
                if ((string)value == NumberPhone) return true;
            if (varible == "NumberPhone")
                if ((string)value == CreatedAt) return true;
            return false;
        }
        public override string cmdAddDB()
        {
            VARIBLE = $"({ID}, '{Username}', {NumberPhone}, {CreatedAt})";

            return base.cmdAddDB();
        }
        public override string cmdDellDB(string Value)
        {
            string temp;
            if(Username == Value) temp = "Username";
            if (NumberPhone == Value) temp = "NumberPhone";
            else if(CreatedAt == Value) temp = "CreatedAt";
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