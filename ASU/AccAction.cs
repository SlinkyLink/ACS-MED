using System;
namespace ASU
{
    public class AccActions : DBTable
    {
        public int ID {get; private set;}
        public string CreatedBy {get; private set;}
        public string CreatedAt {get; private set;} //DATE
        public string Action {get; private set;}

        private AccActions() {}

        public AccActions( int ID, 
                          string CreatedBy, 
                          string CreatedAt, 
                          string Action )
        {
            this.ID = ID;
            this.CreatedBy = CreatedBy;
            this.CreatedAt = CreatedAt;
            this.Action = Action;
        }

        public override string GetDATA()
        {
            return @$"|->{ID}<-|->{CreatedBy}<-|->{CreatedAt}<-|->{Action}<-|";
        }

        public override string cmdAddDB()
        {

            VARIBLE = $"({ID}, '{CreatedBy}', {CreatedAt}, '{Action}')";
            return base.cmdAddDB();
        }

        public override string cmdDellDB(string Value)
        {
            string temp;
            if(CreatedBy == Value) temp = "CreatedBy";
            else if(CreatedAt == Value) temp = "CreatedAt";
            else if(Action == Value) temp = "Action";
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