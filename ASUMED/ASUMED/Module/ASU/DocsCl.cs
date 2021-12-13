using System;

namespace ASUMED
{
    public class DocsCl : DBTable
    {
        public int AccID {get; set;}
        public int DocID {get; set;}

        public DocsCl() {}

        public override bool HaveData(string varible, object value)
        {

            if (varible == "AccID")
                if (Convert.ToInt32(value) == AccID) return true;
            if (varible == "DocID")
                if (Convert.ToInt32(value) == DocID) return true;
            return false;
        }
        public override string cmdAddDB()
        {

            VARIBLE = $"({AccID}, {DocID})";

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
            else if (Value == DocID) temp = "DocID";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
    }
}