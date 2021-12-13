namespace ASUMED
{
    public abstract class DBTable
    {
        public const string ErrorExceptrionSTR = "EXCEPTION";
        public const int ErrorExceptrionINT = 004;


        protected string DELETE = "DELETE FROM";
        protected string WHERE = "WHERE";
        protected string INSERT = "INSERT INTO";
        protected string TABLE = "";
        protected string VALUES = "VALUES";
        protected string VARIBLE = "";
        
        //FOR UPDATE
        protected string UPDATE = "UPDATE";
        protected string SET = "SET";

        public virtual string GetName()
        {
            return GetType().Name;
        }
        public virtual bool HaveData(string varible, object value)
        {
            return false;
        }
        public virtual string cmdUpdateDB(string varibleUpdate, string valueUpdate, string varible, string Value)
        {
            TABLE = $"{GetName()}";
            return $"{UPDATE} {TABLE} {SET} {varibleUpdate} = {valueUpdate} {WHERE} {varible} = {Value};";
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