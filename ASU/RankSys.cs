namespace ASU
{
    public class RankSys
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


       
    }
}