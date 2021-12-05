namespace ASUMED
{
    public class DrugsDef : DBTable
    {
        public int ID {get; private set;}
        public string Name {get; private set;}
        public int Amount {get; private set;}
        public string Category {get; private set;}
        public string Desc {get; private set;}

        private DrugsDef() {}

        public DrugsDef( int ID, 
                         string Name, 
                         int Amount, 
                         string Category, 
                         string Desc )
        {
            this.ID = ID;
            this.Name = Name;
            this.Amount = Amount;
            this.Category = Category;
            this.Desc = Desc;
        }

        public override string GetDATA()
        {
            return @$"|->{ID}<-|->{Name}<-|->{Amount}<-|->{Category}<-|->{Desc}<-|";
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