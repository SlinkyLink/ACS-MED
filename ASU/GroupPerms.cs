namespace ASU
{
    public class GroupPerms
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
    }
}