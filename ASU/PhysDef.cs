namespace ASU
{
    public class PhysDef : DBTable
    {
        public int ID {get; private set;}
        public string Name {get; private set;}
        public string CreatedAt {get; private set;}
        public string Category {get; private set;}
        public string Desc {get; private set;}

        private PhysDef() {}

        public PhysDef( int ID,
                        string Name,
                        string CreatedAt,
                        string Category,
                        string Desc)
        {
            this.ID = ID;
            this.Name = Name;
            this.CreatedAt = CreatedAt;
            this.Category = Category;
            this.Desc = Desc;
        }

        public override string GetDATA()
        {
            return @$"|->{ID}<-|->{Name}<-|->{CreatedAt}<-|->{Category}<-|->{Desc}<-|";
        }
        
        public override string cmdAddDB()
        {
            VARIBLE = $"({ID}, '{Name}', {CreatedAt}, '{Category}', '{Desc}')";

            return base.cmdAddDB();
        }

        public override string cmdDellDB(string Value)
        {
            string temp;
            if(Name == Value) temp = "Name";
            else if(CreatedAt == Value) temp = "CreatedAt";
            else if(Category == Value) temp = "Category";
            else if(Desc == Value) temp = "Desc";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = '{Value}'";
            return base.cmdDellDB(Value);
        }

        public override string cmdDellDB(int Value)
        {
            string temp;
            if(Value == ID) temp = "ID";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
    }
}