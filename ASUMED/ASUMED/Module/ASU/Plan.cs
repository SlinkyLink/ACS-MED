using System.Diagnostics;
namespace ASUMED
{
    public class Plan : DBTable
    {
        public int ID {get; private set;}
        public string Username {get; private set;}
        public string PlanSheduler {get; private set;} //DATE
        public string CreatedBy {get; private set;}
        public string CreatedAt {get; private set;}
        public string Desc {get; private set;}

        private Plan() {}

        public Plan( int ID, 
                     string Username, 
                     string PlanSheduler, 
                     string CreatedBy, 
                     string CreatedAt, 
                     string Desc )
        {
            this.ID = ID;
            this.Username = Username;
            this.PlanSheduler = PlanSheduler;
            this.CreatedBy = CreatedBy;
            this.CreatedAt = CreatedAt;
            this.Desc = Desc;
        }

        public override string GetDATA()
        {
            return @$"|->{ID}<-|->{Username}<-|->{PlanSheduler}<-|->{CreatedBy}<-|->{CreatedAt}<-|->{Desc}<-|";
        }

        public override string cmdAddDB()
        {
            VARIBLE = $"({ID}, '{Username}', '{PlanSheduler}', '{CreatedBy}', {CreatedAt}, '{Desc}')";

            return base.cmdAddDB();
        }

        public override string cmdDellDB(string Value)
        {
            string temp;
            if(Username == Value) temp = "Username";
            else if(PlanSheduler == Value) temp = "PlanSheduler";
            else if(CreatedBy == Value) temp = "CreatedBy";
            else if(CreatedAt == Value) temp = "CreatedAt";
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