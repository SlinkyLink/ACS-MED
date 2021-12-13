using System;

namespace ASUMED
{
    public class RankSys : DBTable
    {
        public int AccID {get; set;}
        public int RankID {get; set;}
        public RankSys() {}
        public override bool HaveData(string varible, object value)
        {
            if (varible == "AccID")
                if (Convert.ToInt32(value) == AccID) return true;
            if (varible == "RankID")
                if (Convert.ToInt32(value) == RankID) return true;
            return false;
        }
        public override string cmdAddDB()
        {
            VARIBLE = $"({AccID}, {RankID})";

            return base.cmdAddDB();
        } 
         public override string cmdDellDB(string Value)
        {
            return ErrorExceptrionSTR;
        }
        public override string cmdDellDB(int Value)
        {
            string temp;
            if(Value == AccID) temp = "AccID";
            else if(Value == RankID) temp = "RankID";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
    }
}