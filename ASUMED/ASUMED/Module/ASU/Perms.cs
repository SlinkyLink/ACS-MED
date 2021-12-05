namespace ASUMED
{
    public class Perms : DBTable
    {
        public int ID {get; private set;}
        public string CreatedBy {get; private set;}
        public string CreatedAt {get; private set;} //DATE
        public string Key {get; private set;}
        public string Desc {get; private set;}

        private Perms() {}
        
        public Perms( int ID, 
                      string CreatedBy, 
                      string CreatedAt, 
                      string Key,
                      string Desc) 
        {
            this.ID = ID;
            this.CreatedBy = CreatedBy;
            this.CreatedAt = CreatedAt;
            this.Key = Key;
            this.Desc = Desc;
        }

        public override string GetDATA()
        {
            return @$"|->{ID}<-|->{CreatedBy}<-|->{CreatedAt}<-|->{Key}<-|->{Desc}<-|";
        }

        public override string cmdAddDB()
        {
            VARIBLE = $"({ID}, '{CreatedBy}', {CreatedAt}, '{Key}', '{Desc}')";

            return base.cmdAddDB();
        }

        public override string cmdDellDB(string Value)
        {
            string temp;
            if(CreatedBy == Value) temp = "CreatedBy";
            else if(CreatedAt == Value) temp = "CreatedAt";
            else if(Key == Value) temp = "Key";
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