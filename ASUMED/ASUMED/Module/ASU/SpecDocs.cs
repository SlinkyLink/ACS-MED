using System;

namespace ASUMED
{
    public class SpecDocs : DBTable
    {
        public int DocID { get; set; }
        public int SpecID { get; set; }
        public SpecDocs() { }
        public override bool HaveData(string varible, object value)
        {
            if (varible == "DocID")
                if (Convert.ToInt32(value) == DocID) return true;
            if (varible == "SpecID")
                if (Convert.ToInt32(value) == SpecID) return true;
            return false;
        }
        public override string cmdAddDB()
        {
            VARIBLE = $"({DocID}, {SpecID})";
            return base.cmdAddDB();
        }
        public override string cmdUpdateDB(string varibleUpdate, string valueUpdate, string varible, string Value)
        {
            return base.cmdUpdateDB(varibleUpdate, valueUpdate, varible, Value);
        }
        public override string cmdDellDB(string Value)
        {
            return ErrorExceptrionSTR;
        }
        public override string cmdDellDB(int Value)
        {
            string temp;
            if (Value == DocID) temp = "DocID";
            else if (Value == SpecID) temp = "SpecID";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
    }
}