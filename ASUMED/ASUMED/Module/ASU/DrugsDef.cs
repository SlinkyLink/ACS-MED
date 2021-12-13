using System;

namespace ASUMED
{
    public class DrugsDef : DBTable
    {
        public int ID {get; set;}
        public string Name {get; set;}
        public int Amount {get; set;}
        public string Category {get; set;}
        public string Desc {get; set;}
        public DrugsDef() {}
        public override bool HaveData(string varible, object value)
        {
            if (varible == "ID")
                if (Convert.ToInt32(value) == ID) return true;
            if (varible == "Name")
                if ((string)value == Name) return true;
            if (varible == "Amount")
                if (Convert.ToInt32(value) == Amount) return true;
            if (varible == "Category")
                if ((string)value == Category) return true;
            if (varible == "Desc")
                if ((string)value == Desc) return true;
            return false;
        }
        public override string cmdAddDB()
        {
            VARIBLE = $"({ID}, '{Name}', {Amount}, '{Category}', '{Desc}')";

            return base.cmdAddDB();
        }
        public override string cmdDellDB(string Value)
        {
            string temp;
            if(Name == Value) temp = "Name";
            else if(Category == Value) temp = "Category";
            else if(Desc == Value) temp = "Decs";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = '{Value}'";
            return base.cmdDellDB(Value);
        }
        public override string cmdDellDB(int Value)
        {
            string temp;
            if(Value == ID) temp = "ID";
            else if (Value == Amount) temp = "Amount";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
    }
}