using System;
using System.Data.Common;
namespace ASUMED
{
    public class RankGroups : DBTable
    {
        public int ID {get; set;}
        public string CreatedBy {get; set;}
        public string CreatedAt {get; set;} //DATE
        public string Name {get; set;}
        public RankGroups() {}
        public override bool HaveData(string varible, object value)
        {
            if (varible == "ID")
                if (Convert.ToInt32(value) == ID) return true;
            if (varible == "CreatedBy")
                if ((string)value == CreatedBy) return true;
            if (varible == "CreatedAt")
                if ((string)value == CreatedAt) return true;
            if (varible == "Name")
                if ((string)value == Name) return true;
            return false;
        }
        public override string cmdAddDB()
        {
            VARIBLE = $"({ID}, '{CreatedBy}', {CreatedAt}, '{Name}')";
            return base.cmdAddDB();
        }
        public override string cmdDellDB(string Value)
        {
            string temp;
            if(CreatedAt == Value) temp = "CreatedAt";
            else if(CreatedBy == Value) temp = "CreatedBy";
            else if(Name == Value) temp = "Name";
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