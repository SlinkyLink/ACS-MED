namespace ASU
{
    public class Sheduler : DBTable
    {
        public int ID {get; private set;}
        public int ClientID {get; private set;}
        public int DoctorID {get; private set;}
        public string DateSheduler {get; private set;} //DATE
        public int DrugID {get; private set;}
        public int ActionID {get; private set;}

        private Sheduler() {}

        public Sheduler( int ID,
                         int ClientID,
                         int DoctorID,
                         string DateSheduler,
                         int DrugID,
                         int ActionID)
        {
            this.ID = ID;
            this.ClientID = ClientID;
            this.DoctorID = DoctorID;
            this.DateSheduler = DateSheduler;
            this.DrugID = DrugID;
            this.ActionID = ActionID;
        }

        public override string GetDATA()
        {
            return @$"|->{ID}<-|->{ClientID}<-|->{DoctorID}<-|->{DateSheduler}<-|->{DrugID}<-|->{ActionID}<-|";
        }

        public override string cmdAddDB()
        {

            VARIBLE = $"({ID},{ClientID}, {DoctorID}, {DateSheduler}, {DrugID}, {ActionID})";

            return base.cmdAddDB();
        }

        public override string cmdDellDB(string Value)
        {
            string temp;
            if(DateSheduler == Value) temp = "DateSheduler";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = '{Value}'";
            return base.cmdDellDB(Value);
        }

        public override string cmdDellDB(int Value)
        {
            string temp;
            if(Value == ID) temp = "ID";
            else if (Value == ClientID) temp = "ClientID";
            else if(Value == DoctorID) temp = "DoctorID";
            else if(Value == DrugID) temp = "DrugID";
            else if(Value == ActionID) temp = "ActionID";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
    }
}