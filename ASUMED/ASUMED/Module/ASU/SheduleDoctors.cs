using System;
namespace ASUMED
{
    public class SheduleDoctors : DBTable
    {
        public int DocID { get; set; }
        public int TimeID { get; set; }
        public int DayID { get; set; } //DATE
        public SheduleDoctors() { }
        public override bool HaveData(string varible, object value)
        {
            if (varible == "DocID")
                if (Convert.ToInt32(value) == DocID) return true;
            if (varible == "TimeID")
                if (Convert.ToInt32(value) == TimeID) return true;
            if (varible == "DayID")
                if (Convert.ToInt32(value) == DayID) return true;
            return false;
        }
        public override string cmdAddDB()
        {

            VARIBLE = $"({DocID}, {TimeID}, {DayID})";
            return base.cmdAddDB();
        }
        public override string cmdDellDB(string Value)
        {
            return ErrorExceptrionSTR;
        }
        public override string cmdDellDB(int Value)
        {
            string temp;
            if (Value == DocID) temp = "DocID";
            else if (Value == TimeID) temp = "TimeID";
            else if (Value == DayID) temp = "DayID";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
    }
}