using System;

namespace ASUMED
{
    public class Clients : DBTable
    {
        public int ID {get; set;}
        public string Username {get; set;}
        public string Sex {get; set;}
        public string DateOfBirth { get; set;}
        public int IDRhFactor {get; set;}
        public string Weight {get; set;}
        public int Growth { get; set;}
        public string NumberPhone { get; set;}
        public string CreatedAt {get; set;} //DATE
        public int DocID {get; set;}

        ////////
        public string MedStory { get; set; } 
        ///
        public Clients() {}
        public override bool HaveData(string varible, object value)
        {
            if (varible == "ID")
                if (Convert.ToInt32(value) == ID) return true;
            if (varible == "Username")
                if ((string)value == Username) return true;
            if (varible == "Sex")
                if ((string)value == Sex) return true;
            if (varible == "DateOfBirth")
                if ((string)value == DateOfBirth) return true;
            if (varible == "IDRhFactor")
                if (Convert.ToInt32(value) == IDRhFactor) return true;
            if (varible == "Weight")
                if ((string)value == Weight) return true;
            if (varible == "Growth")
                if ((int)value == Growth) return true;
            if (varible == "NumberPhone")
                if ((string)value == NumberPhone) return true;
            if (varible == "CreatedAt")
                if ((string)value == CreatedAt) return true;
            if (varible == "DocID")
                if (Convert.ToInt32(value) == DocID) return true;
            return false;
        }
        public override string cmdAddDB()
        {
            VARIBLE = $"({ID}, '{Username}', '{Sex}', '{DateOfBirth}', {IDRhFactor}, {Weight} , {Growth},  '{NumberPhone}', {CreatedAt}, {DocID}, '{MedStory}')";

            return base.cmdAddDB();
        }
        public override string cmdDellDB(string Value)
        {
            string temp;
            if(Username == Value) temp = "Username";
            else if (DateOfBirth == Value) temp = "DateOfBirth";
            else if (Weight == Value) temp = "Weight";
            else if (Sex == Value) temp = "Sex";
            else if (NumberPhone == Value) temp = "NumberPhone";
            else if(CreatedAt == Value) temp = "CreatedAt";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = '{Value}'";
            return base.cmdDellDB(Value);
        }
        public override string cmdDellDB(int Value)
        {
            
            string temp;
            if(Value == ID) temp = "ID";
            else if (Value == IDRhFactor) temp = "IDRhFactor";
            else if (Value == Growth) temp = "Growth";
            else if (Value == DocID) temp = "DocID";
            else return ErrorExceptrionSTR;
            VARIBLE = $"{temp} = {Value}";
            return base.cmdDellDB(Value);
        }
        public override string cmdDellDB(float Value)
        {
           
            return ErrorExceptrionSTR;

        }
    }
}