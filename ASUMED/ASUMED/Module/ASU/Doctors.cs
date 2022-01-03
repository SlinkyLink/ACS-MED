using System;

namespace ASUMED
{
    public class Doctors : DBTable
    {
        public int ID {get; set;}
        public string Username {get; set;}
        public string Sex { get; set; }
        public string DateOfBirth {get; set;}
        public int IDPassport { get; set; }
        public string CreatedAt {get; set;}
        public int CreatedBy { get; set; }
        public int IDSpec { get; set; }
        public Doctors() {}
        public override bool HaveData(string varible, object value)
        {
            if (varible == "ID")
                if (Convert.ToInt32(value) == ID) return true;
            if (varible == "Username")
                if ((string)value == Username) return true;
            if (varible == "Sex")
                if ((string)value == Sex) return true;
            if (varible == "DateOfBirth")
                if ((string)value == DateOfBirth) return true;
            if (varible == "IDPassport")
                if (Convert.ToInt32(value) == IDPassport) return true;
            if (varible == "CreatedAt")
                if ((string)value == CreatedAt) return true;
            if (varible == "CreatedBy")
                if (Convert.ToInt32(value) == CreatedBy) return true;
            if (varible == "IDSpec")
                if (Convert.ToInt32(value) == IDSpec) return true;
            return false;
        }
        public override string cmdAddDB()
        {
            VARIBLE = $"({ID}, '{Username}', '{Sex}', '{DateOfBirth}', {IDPassport}, {CreatedAt}, {CreatedBy}, {IDSpec})";
            return base.cmdAddDB();
        }
        public override string cmdDellDB(string Value)
        {
            string temp;
            if(Username == Value) temp = "Username";
            else if (Sex == Value) temp = "Sex";
            else if (DateOfBirth == Value) temp = "DateOfBirth";
            else if(CreatedAt == Value) temp = "CreatedAt";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = '{Value}'";
            return base.cmdDellDB(Value);
        }
        public override string cmdDellDB(int Value)
        {
            string temp;
            if(Value == ID) temp = "ID";
            else if (Value == IDPassport) temp = "IDPassport";
            else if (CreatedBy == Value) temp = "CreatedBy";
            else if (IDSpec == Value) temp = "IDSpec";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
    }
}