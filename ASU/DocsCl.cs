namespace ASU
{
    public class DocsCl
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
    }
}