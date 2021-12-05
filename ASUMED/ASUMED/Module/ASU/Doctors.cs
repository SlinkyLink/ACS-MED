namespace ASUMED
{
    public class Doctors : DBTable
    {
        public int ID {get; private set;}
        public string Username {get; private set;}
        public string CreatedAt {get; private set;}
        public string CreatedBy {get; private set;}

        private Doctors() {}

        public Doctors( int ID, 
                        string Username, 
                        string CreatedAt, 
                        string CreatedBy)
        {
            this.ID = ID;
            this.Username = Username;
            this.CreatedAt = CreatedAt;
            this.CreatedBy = CreatedBy;
        }

        public override string GetDATA()
        {
            return @$"|->{ID}<-|->{Username}<-|->{CreatedAt}<-|->{CreatedBy}<-|";
        }

        public override string cmdAddDB()
        {
            VARIBLE = $"({ID}, '{Username}', {CreatedAt}, '{CreatedBy}')";

            return base.cmdAddDB();
        }

        public override string cmdDellDB(string Value)
        {
            string temp;
            if(Username == Value) temp = "Username";
            else if(Username == Value) temp = "Username";
            else if(CreatedAt == Value) temp = "CreatedAt";
            else if(CreatedBy == Value) temp = "CreatedBy";
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