using System;

namespace ASUMED
{
    public class GroupPerms : DBTable
    {
        public int GroupID {get; set;}
        public int PermID {get; set;}
        public GroupPerms() {}
        public override bool HaveData(string varible, object value)
        {
            if (varible == "GroupID")
                if (Convert.ToInt32(value) == GroupID) return true;
            if (varible == "PermID")
                if (Convert.ToInt32(value) == PermID) return true;
            return false;
        }
        public override string cmdAddDB()
        {
            VARIBLE = $"({GroupID}, {PermID})";

            return base.cmdAddDB();
        }
        public override string cmdDellDB(string Value)
        {
            return ErrorExceptrionSTR;
        }
        public override string cmdDellDB(int Value)
        {
            string temp;
            if(Value == GroupID) temp = "GroupID";
            else if (Value == PermID) temp = "PermID";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
    }
}