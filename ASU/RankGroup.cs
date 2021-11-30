using System.Data.Common;
namespace ASU
{
    public class RankGroups : DBTable
    {
        public int ID {get; private set;}
        public string CreatedBy {get; private set;}
        public string CreatedAt {get; private set;} //DATE
        public string Name {get; private set;}
        public string ShortName {get; private set;}

        private RankGroups() {}

        public RankGroups( int ID,
                          string CreatedBy, 
                          string CreatedAt, 
                          string Name, 
                          string ShortName )
        {
            this.ID = ID;
            this.CreatedBy = CreatedBy;
            this.CreatedAt = CreatedAt;
            this.Name = Name;
            this.ShortName = ShortName;
        }

        public override string GetDATA()
        {
            return @$"|->{ID}<-|->{CreatedBy}<-|->{CreatedAt}<-|->{Name}<-|->{ShortName}<-|";
        }

        public override string cmdAddDB()
        {
            VARIBLE = $"({ID}, '{CreatedBy}', {CreatedAt}, '{Name}', '{ShortName}')";
            return base.cmdAddDB();
        }

        public override string cmdDellDB(string Value)
        {
            string temp;
            if(CreatedAt == Value) temp = "CreatedAt";
            else if(CreatedBy == Value) temp = "CreatedBy";
            else if(Name == Value) temp = "Name";
            else if(ShortName == Value) temp = "ShortName";
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