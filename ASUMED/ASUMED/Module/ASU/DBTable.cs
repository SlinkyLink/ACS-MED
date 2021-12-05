using System;

namespace ASUMED
{
    public abstract class DBTable
    {
        public const string ErrorExceptrionSTR = "EXCEPTION";
        public const int ErrorExceptrionINT = 004;
        
        public const string TIME = "('now')";

        protected string DELETE = "DELETE FROM";
        protected string WHERE = "WHERE";
        protected string INSERT = "INSERT INTO";
        protected string TABLE = "";
        protected string VALUES = "VALUES";
        protected string VARIBLE = "";
        
        public virtual string GetName()
        {
            return GetType().Name;
        }

        public virtual string GetDATA()
        {
            return "";
        }

        public virtual string cmdAddDB()
        {
            TABLE =  $"{GetName()}";
            return INSERT + " " + TABLE + " " + VALUES + " " + VARIBLE + ";";
        }

        public virtual string cmdDellDB(int value)
        {
            TABLE = GetName();
            return DELETE +" "+ TABLE +" "+ WHERE +" "+ VARIBLE + ";";
        }
        
        public virtual string cmdDellDB(string value)
        {
            TABLE = GetName();
            return DELETE +" "+ TABLE +" "+ WHERE +" "+ VARIBLE + ";";
        }

    }
}