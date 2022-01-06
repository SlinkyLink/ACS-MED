using System;
using System.Diagnostics;
namespace ASUMED
{
    public class Pills : DBTable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int TypeID { get; set; }
        public Pills() { }
        public override bool HaveData(string varible, object value)
        {
            if (varible == "ID")
                if (Convert.ToInt32(value) == ID) return true;
            if (varible == "Amount")
                if (Convert.ToInt32(value) == Amount) return true;
            if (varible == "TypeID")
                if (Convert.ToInt32(value) == TypeID) return true;
            if (varible == "Name")
                if ((string)value == Name) return true;
            return false;
        }
        public override string cmdAddDB()
        {
            VARIBLE = $"({ID}, '{Name}', {Amount}, {TypeID})";

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
            else if (Value == Amount) temp = "Amount";
            else if (Value == TypeID) temp = "TypeID";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
    }
}