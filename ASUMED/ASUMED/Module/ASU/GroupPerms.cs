namespace ASUMED
{
    public class GroupPerms : DBTable
    {
        public int GroupID {get; private set;}
        public int PermID {get; private set;}

        private GroupPerms() {}
        
        public GroupPerms( int GroupID, 
                           int PermID )
        {
            this.GroupID = GroupID;
            this.PermID = PermID;
        }

        public override string GetDATA()
        {
            return @$"|->{GroupID}<-|->{PermID}<-|";
        }

        public override string cmdAddDB()
        {
            VARIBLE = $"({GroupID}, {PermID})";

            return base.cmdAddDB();
        }

        public override string cmdDellDB(string Value)
        {
            return ErrorExceptrionSTR;
        }

        public override string cmdDellDB(int Value)
        {
            string temp;
            if(Value == GroupID) temp = "GroupID";
            else if (Value == PermID) temp = "PermID";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
    }
}