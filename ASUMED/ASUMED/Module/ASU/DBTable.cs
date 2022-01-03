using System;
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
        public virtual string cmdUpdateDB(string varibleUpdate, object valueUpdate, string varible, object Value)
        {
            TABLE = $"{GetName()}";
            if(valueUpdate is int && Value is int )
            {
                int valUp = Convert.ToInt32(valueUpdate);
                int val  = Convert.ToInt32(Value);
                return $"{UPDATE} {TABLE} {SET} {varibleUpdate} = {valUp} {WHERE} {varible} = {val};";
            }
            else if (valueUpdate is string && Value is string)
            {
                string valUp = Convert.ToString(valueUpdate);
                string val = Convert.ToString(Value);
                return $"{UPDATE} {TABLE} {SET} {varibleUpdate} = '{valUp}' {WHERE} {varible} = '{val}';";
            }
            else if (valueUpdate is string && Value is int)
            {
                string valUp = Convert.ToString(valueUpdate);
                int val = Convert.ToInt32(Value);
                return $"{UPDATE} {TABLE} {SET} {varibleUpdate} = '{valUp}' {WHERE} {varible} = {val};";
            }
            return ErrorExceptrionSTR;
            
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
        public virtual string cmdDellDB(float value)
        {
            TABLE = GetName();
            return DELETE + " " + TABLE + " " + WHERE + " " + VARIBLE + ";";
        }
    }
}