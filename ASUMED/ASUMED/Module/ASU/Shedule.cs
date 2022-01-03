using System;
namespace ASUMED
{
    public class Shedule : DBTable
    {
        public int ID { get; set; }
        public string Time { get; set; }
        public Shedule() { }
        public override bool HaveData(string varible, object value)
        {
            if (varible == "ID")
                if (Convert.ToInt32(value) == ID) return true;
            if (varible == "CreatedAt")
                if ((string)value == Time) return true;
            return false;
        }
        public override string cmdAddDB()
        {

            VARIBLE = $"({ID}, '{Time}')";
            return base.cmdAddDB();
        }
        public override string cmdDellDB(string Value)
        {
            string temp;
            if (Time == Value) temp = "Time";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = '{Value}'";
            return base.cmdDellDB(Value);
        }
        public override string cmdDellDB(int Value)
        {
            string temp;
            if (Value == ID) temp = "ID";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
    }
}