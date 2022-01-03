using System;

namespace ASUMED
{
    public class DayOfWeek : DBTable
    {
        public int ID { get; set; }
        public string Day { get; set; }
        public DayOfWeek() { }
        public override bool HaveData(string varible, object value)
        {
            if (varible == "DocID")
                if (Convert.ToInt32(value) == ID) return true;
            if (varible == "SpecID")
                if ((string)value == Day) return true;
            return false;
        }
        public override string cmdAddDB()
        {
            VARIBLE = $"({ID}, '{Day}')";
            return base.cmdAddDB();
        }
        public override string cmdDellDB(string Value)
        {
            string temp;
            if (Value == Day) temp = "Day";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
        public override string cmdDellDB(int Value)
        {
            string temp;
            if (Value == ID) temp = "DocID";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
    }
}