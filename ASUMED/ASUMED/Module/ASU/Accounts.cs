using System;

namespace ASUMED
{
    
    public class Accounts : DBTable
    {
        public int ID {get; set;}
        public string Username { get; set; }
        public string Password { get; set; }
        public string CreatedBy { get; set; }
        public Accounts() {}
        public override bool HaveData(string varible, object value)
        {
            if (varible == "ID")
                if (Convert.ToInt32(value) == ID) return true;
            if (varible == "Username")
                if ((string)value == Username) return true;
            if (varible == "Password")
                if ((string)value == Password) return true;
            if (varible == "CreatedBy")
                if ((string)value == CreatedBy) return true;
            return false;
        }
        public override string cmdAddDB()
        {
            VARIBLE = $"({ID}, '{Username}', '{Password}', '{CreatedBy}')";

            return base.cmdAddDB();
        }
        public override string cmdDellDB(string Value)
        {
            string temp;
            if (Username == Value) temp = "Username";
            else if (Password == Value) temp = "Password";
            else if (CreatedBy == Value) temp = "CreatedBy";
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