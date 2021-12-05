namespace ASUMED
{
    public class RankSys : DBTable
    {
        public int UserID {get; private set;}
        public int RankID {get; private set;}

        private RankSys() {}

        public RankSys( int UserID, 
                        int RankID )
        {
            this.UserID = UserID;
            this.RankID = RankID;
        }

        public override string GetDATA()
        {
            return @$"|->{UserID}<-|->{RankID}<-|";
        }   

        public override string cmdAddDB()
        {
            VARIBLE = $"({UserID}, {UserID})";

            return base.cmdAddDB();
        } 

         public override string cmdDellDB(string Value)
        {
            return ErrorExceptrionSTR;
        }

        public override string cmdDellDB(int Value)
        {
            string temp;
            if(Value == UserID) temp = "UserID";
            else if(Value == RankID) temp = "RankID";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
    }
}