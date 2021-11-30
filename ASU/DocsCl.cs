namespace ASU
{
    public class DocsCl : DBTable
    {
        public int AccID {get; private set;}
        public int DocID {get; private set;}

        private DocsCl() {}

        public DocsCl( int AccID, 
                       int DocID )
        {
            this.AccID = AccID;
            this.DocID = DocID;
        }

        public override string GetDATA()
        {
            return @$"|->{AccID}<-|->{DocID}<-|";
        }

        public override string cmdAddDB()
        {

            VARIBLE = $"({AccID}, {DocID})";

            return base.cmdAddDB();
        }

        public override string cmdDellDB(string Value)
        {
            return ErrorExceptrionSTR;
        }

        public override string cmdDellDB(int Value)
        {
            string temp;
            if(Value == AccID) temp = "AccID";
            else if (Value == DocID) temp = "DocID";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
    }
}