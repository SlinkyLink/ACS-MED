using System;

namespace ASUMED
{
    public class Specialization : DBTable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Specialization() { }
        public override bool HaveData(string varible, object value)
        {
            if (varible == "ID")
                if (Convert.ToInt32(value) == ID) return true;
            if (varible == "Name")
                if ((string)value == Name) return true;
            return false;
        }
        public override string cmdAddDB()
        {

            VARIBLE = $"({ID}, '{Name}')";
            return base.cmdAddDB();
        }
        public override string cmdDellDB(string Value)
        {
            string temp;
            if (Name == Value) temp = "Name";
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
