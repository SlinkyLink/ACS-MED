namespace ASU
{
    
    public class Accounts : DBTable
    {
        public int ID {get; private set;}
        public string Username {get; private set;}
        public string CreatedBy {get; private set;}
        public string CreatedAt {get; private set;} //DATE

        private Accounts() {}

        public Accounts( int ID, 
                         string Username, 
                         string CreatedBy, 
                         string CreatedAt )
        {
            this.ID = ID;
            this.Username = Username;
            this.CreatedBy = CreatedBy;
            this.CreatedAt = CreatedAt;
        }

        public override string GetDATA()
        {
            return @$"|->{ID}<-|->{Username}<-|->{CreatedBy}<-|->{CreatedAt}<-|";
        }

        public override string cmdAddDB()
        {
            VARIBLE = $"({ID}, '{Username}', '{CreatedBy}', {CreatedAt})";

            return base.cmdAddDB();
        }

        public override string cmdDellDB(string Value)
        {
            string temp = "";
            if(Username == Value) temp = "Username";
            else if(CreatedBy == Value) temp = "CreatedBy";
            else if(CreatedAt == Value) temp = "CreatedAt";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = '{Value}'";
            return base.cmdDellDB(Value);
        }

        public override string cmdDellDB(int Value)
        {
            string temp = "";
            if(Value == ID) temp = "ID";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
    }
}