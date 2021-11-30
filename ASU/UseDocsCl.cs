namespace ASU
{
    public class UseDocsCl : DBTable
    {
        public int DocID {get; private set;}
        public int ClientID {get; private set;}

        private UseDocsCl() {}
        
        public UseDocsCl( int DocID, 
                          int ClientID )
        {
            this.DocID = DocID;
            this.ClientID = ClientID;
        }  

        public override string GetDATA()
        {
            return @$"|->{DocID}<-|->{ClientID}<-|";
        }

        public override string cmdAddDB()
        {
            VARIBLE = $"({DocID}, {ClientID})";

            return base.cmdAddDB();
        } 

        public override string cmdDellDB(string Value)
        {
            return ErrorExceptrionSTR;
        }

        public override string cmdDellDB(int Value)
        {
            string temp;
            if(Value == DocID) temp = "DocID";
            else if(Value == ClientID) temp = "ClientID";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        } 
    }
}