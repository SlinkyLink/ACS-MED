using System.Data.Common;
using System.Collections.Generic;
using System;
using System.Data.SQLite;
using System.Windows;

namespace ASUMED
{
    namespace Controller
    {
        public class ASUDBController
        {
            SQLiteConnection DataBase;
            SQLiteCommand CmdDataBase;
            SQLiteDataReader ReaderDataBase;
            public static string TIME = "DATE('now')";
            public List<DBTable> Tables { get; private set; }
            public DBTable activeTable { get; set; }
            public Accounts LogAcc { get; private set; }
            public Doctors LogDoctor { get; private set; }
            public ASUDBController()
            {
                DataBase = new("Data Source = asu.db; Version = 3;");
                try
                {
                    DataBase.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    System.Environment.Exit(0);
                }
                CmdDataBase = new();
                Tables = new();
                CmdDataBase.Connection = DataBase;
                _Update();
            }
            public void UpdateData(DBTable table, string varibleUpdate, string valueUpdate, string varible, string value)
            {
                CmdDataBase.CommandText = table.cmdUpdateDB(varibleUpdate, valueUpdate, varible, value);
                try
                {
                    CmdDataBase.ExecuteNonQuery();
                    _Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            public void AddData(DBTable table)
            {
                CmdDataBase.CommandText = table.cmdAddDB();
                try
                {
                    CmdDataBase.ExecuteNonQuery();
                    _Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

            }
            public DBTable GetTable(string nameT, string varible, object value)
            {
                foreach(var table in Tables)
                {
                    if(table.GetName() == nameT)
                    {
                        if(table.HaveData(varible, value))
                        {
                            return table;
                        }
                    }
                }
                return null;
            }
            public void DellData(DBTable table, object value)
            {
                if (value is int valueINT)
                    CmdDataBase.CommandText = table.cmdDellDB(valueINT);
                else if (value is string valueSTRING)
                    CmdDataBase.CommandText = table.cmdDellDB(valueSTRING);
                if (CmdDataBase.CommandText != DBTable.ErrorExceptrionSTR)
                    CmdDataBase.ExecuteNonQuery();
                _Update();
            }
            public void DBClose()
            {
                if (ReaderDataBase != null)
                {
                    if (!ReaderDataBase.IsClosed)
                    {
                        ReaderDataBase.Close();
                    }
                }
                DataBase.Close();
            }
            public void Update()
            {
                _Update();
            }
            private void _Update()
            {
                if (Tables.Count > 0)
                    Tables.Clear();

                List<string> tables = new();

                CmdDataBase.CommandText = @"SELECT name
                                            FROM sqlite_schema
                                            WHERE type ='table' AND name NOT LIKE 'sqlite_%';";
                ReaderDataBase = CmdDataBase.ExecuteReader();
                while (ReaderDataBase.Read())
                {
                    tables.Add(ReaderDataBase.GetString(0));
                }
                ReaderDataBase.Close();

                foreach (var table in tables)
                {

                    CmdDataBase.CommandText = $"SELECT * FROM {table}";
                    ReaderDataBase = CmdDataBase.ExecuteReader();
                    while (ReaderDataBase.Read())
                    {
                        if (table == "AccActions")
                        {
                            Tables.Add
                            (
                                new AccActions
                                {
                                    ID = ReaderDataBase.GetInt32(0),
                                    CreatedBy = ReaderDataBase.GetString(1),
                                    CreatedAt = ReaderDataBase.GetString(2),
                                    Action = ReaderDataBase.GetString(3)
                                }
                            );
                        }
                        else if (table == "Accounts")
                        {
                            Tables.Add
                            (
                                new Accounts
                                {
                                    ID = ReaderDataBase.GetInt32(0),
                                    Username = ReaderDataBase.GetString(1),
                                    Password = ReaderDataBase.GetString(2),
                                    CreatedBy = ReaderDataBase.GetString(3),
                                }
                            );
                        }
                        else if (table == "Clients")
                        {
                            Tables.Add
                            (
                                new Clients
                                {
                                    ID = ReaderDataBase.GetInt32(0),
                                    Username = ReaderDataBase.GetString(1),
                                    NumberPhone = ReaderDataBase.GetString(2),
                                    CreatedAt = ReaderDataBase.GetString(3)
                                }
                            );
                        }
                        else if (table == "DayOfWeek")
                        {
                            Tables.Add
                            (
                                new DayOfWeek
                                {
                                    ID = ReaderDataBase.GetInt32(0),
                                    Day = ReaderDataBase.GetString(1)
                                }
                            );
                        }
                        else if (table == "DocsCl")
                        {
                            Tables.Add
                            (
                                new DocsCl
                                {
                                    DocID = ReaderDataBase.GetInt32(0),
                                    AccID = ReaderDataBase.GetInt32(1)
                                }
                            );
                        }
                        else if (table == "Doctors")
                        {
                            Tables.Add
                            (
                                new Doctors
                                {
                                    ID = ReaderDataBase.GetInt32(0),
                                    Username = ReaderDataBase.GetString(1),
                                    Sex = ReaderDataBase.GetString(2),
                                    DateOfBirth = ReaderDataBase.GetString(3),
                                    IDPassport = ReaderDataBase.GetInt32(4),
                                    CreatedAt = ReaderDataBase.GetString(5),
                                    CreatedBy = ReaderDataBase.GetString(6)
                                }
                            );
                        }
                        else if (table == "DrugsDef")
                        {
                            Tables.Add
                            (
                                new DrugsDef
                                {
                                    ID= ReaderDataBase.GetInt32(0),
                                    Name = ReaderDataBase.GetString(1),
                                    Amount = ReaderDataBase.GetInt32(2),
                                    Category = ReaderDataBase.GetString(3),
                                    Desc = ReaderDataBase.GetString(4)
                                }
                            );
                        }
                        else if (table == "GroupPerms")
                        {
                            Tables.Add
                            (
                                new GroupPerms
                                {
                                    GroupID = ReaderDataBase.GetInt32(0),
                                    PermID = ReaderDataBase.GetInt32(1)
                                }
                            );
                        }
                        else if (table == "Perms")
                        {
                            Tables.Add
                            (
                                new Perms
                                {
                                    ID = ReaderDataBase.GetInt32(0),
                                    CreatedBy= ReaderDataBase.GetString(1),
                                    CreatedAt= ReaderDataBase.GetString(2),
                                    Key = ReaderDataBase.GetString(3),
                                    Desc= ReaderDataBase.GetString(4)
                                }
                            );
                        }
                        else if (table == "PhysDef")
                        {
                            Tables.Add
                            (
                                new PhysDef
                                {
                                    ID = ReaderDataBase.GetInt32(0),
                                    Name = ReaderDataBase.GetString(1),
                                    CreatedAt = ReaderDataBase.GetString(2),
                                    Category= ReaderDataBase.GetString(3),
                                    Desc = ReaderDataBase.GetString(4),
                                }
                            );
                        }
                        else if (table == "Plan")
                        {
                            Tables.Add
                            (
                                new Plan
                                {
                                    ID = ReaderDataBase.GetInt32(0),
                                    Username = ReaderDataBase.GetString(1),
                                    PlanSheduler = ReaderDataBase.GetString(2),
                                    CreatedBy = ReaderDataBase.GetString(3),
                                    CreatedAt = ReaderDataBase.GetString(4),
                                    Desc = ReaderDataBase.GetString(5)
                                }
                            );
                        }
                        else if (table == "PlanningCl")
                        {
                            Tables.Add
                            (
                                new PlanningCl
                                {
                                    ClientID = ReaderDataBase.GetInt32(0),
                                    PlanID = ReaderDataBase.GetInt32(1)
                                }
                            );
                        }
                        else if (table == "RankGroups")
                        {
                            Tables.Add
                            (
                                new RankGroups
                                {
                                    ID = ReaderDataBase.GetInt32(0),
                                    CreatedBy = ReaderDataBase.GetString(1),
                                    CreatedAt = ReaderDataBase.GetString(2),
                                    Name = ReaderDataBase.GetString(3)
                                }
                            );
                        }
                        else if (table == "RankSys")
                        {
                            Tables.Add
                            (
                                new RankSys
                                {
                                    AccID = ReaderDataBase.GetInt32(0),
                                    RankID = ReaderDataBase.GetInt32(1)
                                }
                            );
                        }
                        else if (table == "Shedule")
                        {
                            Tables.Add
                            (
                                new Shedule
                                {
                                    ID = ReaderDataBase.GetInt32(0),
                                    Time = ReaderDataBase.GetString(1)
                                }
                            );
                        }
                        else if (table == "SheduleDoctors")
                        {
                            Tables.Add
                            (
                                new SheduleDoctors
                                {
                                    DocID = ReaderDataBase.GetInt32(0),
                                    TimeID = ReaderDataBase.GetInt32(1),
                                    DayID = ReaderDataBase.GetInt32(2)
                                }
                            );
                        }
                        else if (table == "Sheduler")
                        {
                            Tables.Add
                            (
                                new Sheduler
                                {
                                    ID = ReaderDataBase.GetInt32(0),
                                    ClientID = ReaderDataBase.GetInt32(1),
                                    DoctorID = ReaderDataBase.GetInt32(2),
                                    DateTime = ReaderDataBase.GetString(3),
                                    DrugID = ReaderDataBase.GetInt32(4),
                                    ActionID = ReaderDataBase.GetInt32(5)
                                }
                            );
                        }
                        else if (table == "SpecDocs")
                        {
                            Tables.Add
                            (
                                new SpecDocs
                                {
                                    DocID = ReaderDataBase.GetInt32(0),
                                    SpecID = ReaderDataBase.GetInt32(1)
                                }
                            );
                        }
                        else if (table == "Specialization")
                        {
                            Tables.Add
                            (
                                new Specialization
                                {
                                    ID = ReaderDataBase.GetInt32(0),
                                    Name = ReaderDataBase.GetString(1)
                                }
                            );
                        }
                        else if (table == "UseDocsCl")
                        {
                            Tables.Add
                            (
                                new UseDocsCl
                                {
                                    DocID = ReaderDataBase.GetInt32(0),
                                    ClientID = ReaderDataBase.GetInt32(1)
                                }
                            );
                        }
                    }
                    ReaderDataBase.Close();
                }

            }
            //SPECIALY//////////////////////////////////////////////////////////////////////////////////////////////////////////
            public bool CheckLogPass(string log, string pass)
            {
                foreach (DBTable table in Tables)
                {
                    if (table is Accounts acc)
                    {
                        if (log == acc.Username && pass == acc.Password)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            public void GetAcc(string login, string pass)
            {
                foreach (DBTable table in Tables)
                {
                    if (table is Accounts acc)
                    {
                        if (login == acc.Username && pass == acc.Password)
                        {
                            LogAcc = acc;
                            break;
                        }
                    }
                }
                foreach (DBTable table in Tables)
                {
                    if (table is Doctors doc)
                    {
                        if(LogAcc.ID == doc.ID)
                        {
                            LogDoctor = doc;
                            return;
                        }
                    }
                }
                return;
            }
            public int GenerateID(string table)
            {
                int id = 0;
                CmdDataBase.CommandText = $@"SELECT MAX(ID)
                                             FROM {table};";
                                             
                try
                {
                    ReaderDataBase = CmdDataBase.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }

                while (ReaderDataBase.Read())
                {
                    id = ReaderDataBase.GetInt32(0);
                }
                ReaderDataBase.Close();
                return id+1;
            }
            public string GetLogDoctorRank()
            {
                string rank = "";
                CmdDataBase.CommandText = $@"SELECT RankGroups.Name
                                             FROM Accounts
                                             INNER JOIN RankSys ON Accounts.ID = RankSys.AccID
                                             INNER JOIN RankGroups ON RankGroups.ID = RankSys.RankID
                                             WHERE Accounts.ID = {LogAcc.ID}";
                try
                {
                    ReaderDataBase = CmdDataBase.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return "";
                }

                while (ReaderDataBase.Read())
                {
                    rank = ReaderDataBase.GetString(0);
                }
                ReaderDataBase.Close();
                return rank;
            }
            public string GetDoctorRank(Doctors doctor)
            {
                string rank = "";
                CmdDataBase.CommandText = $@"SELECT RankGroups.Name
                                             FROM Doctors
                                             INNER JOIN Accounts ON Accounts.ID = Doctors.ID
                                             INNER JOIN RankSys ON Accounts.ID = RankSys.AccID
                                             INNER JOIN RankGroups ON RankGroups.ID = RankSys.RankID
                                             WHERE Doctors.ID = {doctor.ID}";
                try
                {
                    ReaderDataBase = CmdDataBase.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return "";
                }

                while (ReaderDataBase.Read())
                {
                    rank = ReaderDataBase.GetString(0);
                }
                ReaderDataBase.Close();
                return rank;
            }
            public int GetRankID(string position)
            {
                foreach(var table in Tables)
                {
                    if(table is RankGroups)
                    {
                       if(((table as RankGroups).Name == position))
                       {
                            return (table as RankGroups).ID;
                       }
                    }
                }
                return 0;
            }
            public string GetDoctorOfPatient(Clients client)
            {
                string username = "";
                CmdDataBase.CommandText = $@"SELECT Doctors.Username
                                             FROM Clients
                                             INNER JOIN UseDocsCl ON UseDocsCl.ClientID = Clients.ID
                                             INNER JOIN Doctors ON Doctors.ID = UseDocsCl.DocID
                                             WHERE Clients.ID = {client.ID}";
                try
                {
                    ReaderDataBase = CmdDataBase.ExecuteReader();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                while(ReaderDataBase.Read())
                {
                    username = ReaderDataBase.GetString(0);
                }
                ReaderDataBase.Close();
                return username;
            }
            public List<Clients> GetPatientsOfDoctor(Doctors doctor)
            {
                List<Clients> clients = new List<Clients>();
                string username = "";
                CmdDataBase.CommandText = $@"SELECT Clients.Username
                                             FROM Doctors
                                             INNER JOIN UseDocsCl ON Doctors.ID = UseDocsCl.DocID
                                             INNER JOIN Clients ON UseDocsCl.ClientID = Clients.ID
                                             WHERE Doctors.ID = {doctor.ID}";
                try
                {
                    ReaderDataBase = CmdDataBase.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                while (ReaderDataBase.Read())
                {
                    username = ReaderDataBase.GetString(0);
                    foreach(var table in Tables)
                    {
                        if(table is Clients)
                        {
                            var client = (Clients)table;
                            if(client.Username == username)
                                clients.Add(client);
                        }
                    }
                }
                ReaderDataBase.Close();
                return clients;
            }
            public string GetSpecializationOfDoctor(Doctors doctor)
            {
                string specialization = "";
                CmdDataBase.CommandText = $@"SELECT Specialization.Name
                                             FROM Doctors
                                             INNER JOIN SpecDocs ON Doctors.ID = SpecDocs.DocID
                                             INNER JOIN Specialization ON Specialization.ID = SpecDocs.SpecID
                                             WHERE Doctors.ID = {doctor.ID}";
                try
                {
                    ReaderDataBase = CmdDataBase.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                while (ReaderDataBase.Read())
                {
                    specialization = ReaderDataBase.GetString(0);
                }
                ReaderDataBase.Close();
                return specialization;
            }
            public List<string> GetSheduleOfDoctor(Doctors doctor)
            {
                List<string> shedule = new List<string>();
                CmdDataBase.CommandText = $@"SELECT Shedule.Time, DayOfWeek.Day
                                             FROM Doctors
                                             INNER JOIN SheduleDocotrs ON Doctors.ID = SheduleDocotrs.DocID
                                             INNER JOIN Shedule ON SheduleDocotrs.TimeID = Shedule.ID
                                             INNER JOIN DayOfWeek ON SheduleDocotrs.DayID = DayOfWeek.ID
                                             WHERE Doctors.ID = {doctor.ID}";
                try
                {
                    ReaderDataBase = CmdDataBase.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                while (ReaderDataBase.Read())
                {
                    shedule.Add($"{ReaderDataBase.GetString(1)} {ReaderDataBase.GetString(0)}");
                }
                ReaderDataBase.Close();
                return shedule;
            }
            public string GetSheduleTodayOfDoctor(Doctors doctor)
            {
                string shedule = "";
                CmdDataBase.CommandText = $@"SELECT Shedule.Time, DayOfWeek.Day
                                            FROM Doctors
                                            INNER JOIN SheduleDoctors ON Doctors.ID = SheduleDoctors.DocID
                                            INNER JOIN Shedule ON SheduleDoctors.TimeID = Shedule.ID
                                            INNER JOIN DayOfWeek ON SheduleDoctors.DayID = DayOfWeek.ID
                                            WHERE Doctors.ID = {doctor.ID} AND DayOfWeek.ID = {(int)DateTime.Today.DayOfWeek} ";
                try
                {
                    ReaderDataBase = CmdDataBase.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                while (ReaderDataBase.Read())
                {
                    shedule = $"{ReaderDataBase.GetString(0)} {ReaderDataBase.GetString(1)}";
                }
                ReaderDataBase.Close();
                return shedule;
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }
    }
}