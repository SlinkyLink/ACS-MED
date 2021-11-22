using System.Collections.Generic;
namespace ASU
{
    public class UseDocsCl
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
    }
}