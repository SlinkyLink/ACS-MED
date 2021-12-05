namespace ASUMED
{
    public class Clients : DBTable
    {
        public int ID {get; private set;}
        public string Username {get; private set;}
        public string DateStart {get; private set;}
        public string DateEnd {get; private set;}
        public string CreatedAt {get; private set;} //DATE

        private Clients() {}

        public Clients( int ID, 
                        string Username, 
                        string DateStart, 
                        string DateEnd, 
                        string CreatedAt)
        {
            this.ID = ID;
            this.Username = Username;
            this.DateStart = DateStart;
            this.DateEnd = DateEnd;
            this.CreatedAt = CreatedAt;
        }

        public override string GetDATA()
        {
            return @$"|->{ID}<-|->{Username}<-|->{DateStart}<-|->{DateEnd}<-|->{CreatedAt}<-|";
        }

        public override string cmdAddDB()
        {
            VARIBLE = $"({ID}, '{Username}', {DateStart}, {DateEnd}, {CreatedAt})";

            return base.cmdAddDB();
        }

        public override string cmdDellDB(string Value)
        {
            string temp;
            if(Username == Value) temp = "Username";
            else if(DateStart == Value) temp = "DateStart";
            else if(DateEnd == Value) temp = "DateEnd";
            else if(CreatedAt == Value) temp = "CreatedAt";
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