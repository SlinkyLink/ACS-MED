using System.Data.Common;
using System.Collections.Generic;
using System;
using System.Data.SQLite;
using System.Windows;
using Cryptography;

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
            public void UpdateData(DBTable table, string varibleUpdate, object valueUpdate, string whereVarible, object whereValue)
            {
                CmdDataBase.CommandText = table.cmdUpdateDB(varibleUpdate, valueUpdate, whereVarible, whereValue);
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
                                    CreatedBy = ReaderDataBase.GetInt32(3),
                                    RankID = ReaderDataBase.GetInt32(4)
                                }
                            );
                        }
                        else if (table == "ClientPills")
                        {
                            try
                            {
                                Tables.Add
                                (
                                    new ClientPills
                                    {
                                        ClientID = ReaderDataBase.GetInt32(0),
                                        PillID = ReaderDataBase.GetInt32(1),
                                        Amount = ReaderDataBase.GetInt32(2)
                                    }
                                );
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                        else if (table == "Clients")
                        {
                            try
                            {
                                Tables.Add
                                (
                                    new Clients
                                    {
                                        ID = ReaderDataBase.GetInt32(0),
                                        Username = ReaderDataBase.GetString(1),
                                        Sex = ReaderDataBase.GetString(2),
                                        DateOfBirth = ReaderDataBase.GetString(3),
                                        IDRhFactor = ReaderDataBase.GetInt32(4),
                                        Weight = ReaderDataBase.GetString(5),
                                        Growth = ReaderDataBase.GetInt32(6),
                                        NumberPhone = ReaderDataBase.GetString(7),
                                        CreatedAt = ReaderDataBase.GetString(8),
                                        DocID = ReaderDataBase.GetInt32(9),
                                        MedStory = ReaderDataBase.GetString(10)
                                    }
                                );
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            
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
                        else if (table == "Doctors")
                        {
                            if(ReaderDataBase.GetInt32(0) != 100)
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
                                        CreatedBy = ReaderDataBase.GetInt32(6),
                                        IDSpec = ReaderDataBase.GetInt32(7)
                                    }
                                );
                            }
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
                        else if (table == "PillType")
                        {
                            Tables.Add
                            (
                                new PillType
                                {
                                    ID = ReaderDataBase.GetInt32(0),
                                    Name = ReaderDataBase.GetString(1),
                                }
                            );
                        }
                        else if (table == "Pills")
                        {
                            Tables.Add
                            (
                                new Pills
                                {
                                    ID = ReaderDataBase.GetInt32(0),
                                    Name= ReaderDataBase.GetString(1),
                                    Amount = ReaderDataBase.GetInt32(2),
                                    TypeID = ReaderDataBase.GetInt32(3)
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
                        else if (table == "ProcedClients")
                        {
                            Tables.Add
                            (
                                new ProcedClients
                                {
                                    ProcedureID = ReaderDataBase.GetInt32(0),
                                    ClientID = ReaderDataBase.GetInt32(1) ,
                                    DocID = ReaderDataBase.GetInt32(2),
                                    Time = ReaderDataBase.GetString(3)
                                }
                            );
                        }
                        else if (table == "Procedures")
                        {
                            Tables.Add
                            (
                                new Procedures
                                {
                                    ID = ReaderDataBase.GetInt32(0),
                                    Name = ReaderDataBase.GetString(1)
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
                                    Name = ReaderDataBase.GetString(1)
                                }
                            );
                        }
                        else if (table == "RhFactor")
                        {
                            Tables.Add
                            (
                                new RhFactor
                                {
                                    ID = ReaderDataBase.GetInt32(0),
                                    Name = ReaderDataBase.GetString(1)
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
                    }
                    ReaderDataBase.Close();
                }

            }
            //SPECIALY//////////////////////////////////////////////////////////////////////////////////////////////////////////
            public bool CheckLogPass(string log, string pass)
            {
                string p = Sha256.ToSHA256(pass);   
                foreach (DBTable table in Tables)
                {
                    if (table is Accounts acc)
                    {
                        if (log == acc.Username && p == acc.Password)
                        {
                            LogAcc = acc;
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
                                             INNER JOIN RankGroups ON RankGroups.ID = Accounts.RankID
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
            public int GetIdRhFactor(string rhfactor)
            {
                foreach(var table in Tables)
                {
                    if (table is RhFactor)
                    {
                        if((table as RhFactor).Name == rhfactor)
                        {
                            return (table as RhFactor).ID;
                        }
                    }
                }
                return 0;
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
            public int GetSpecializationID(string spec)
            {
                foreach (var table in Tables)
                {
                    if (table is Specialization)
                    {
                        if (((table as Specialization).Name == spec))
                        {
                            return (table as Specialization).ID;
                        }
                    }
                }
                return 0;
            }
            public string GetNameDoctor(int id)
            {
                foreach(var table in Tables)
                {
                    if(table is Doctors)
                    {
                        if((table as Doctors).ID == id)
                        {
                            return (table as Doctors).Username;
                        }
                    }
                }

                return "";
            }
            public string GetRhFactorOfPatient(Clients client)
            {
                string factor = "";
                CmdDataBase.CommandText = $@"SELECT RhFactor.Name
                                             FROM Clients
                                             INNER JOIN RhFactor ON RhFactor.ID = Clients.IDRhFactor
                                             WHERE Clients.ID = {client.ID}";
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
                    factor = ReaderDataBase.GetString(0);
                }
                ReaderDataBase.Close();
                return factor;
            }
            public string GetDoctorOfPatient(Clients client)
            {
                string username = "";
                CmdDataBase.CommandText = $@"SELECT Doctors.Username
                                             FROM Clients
                                             INNER JOIN Doctors ON Doctors.ID = Clients.DocID
                                             WHERE Clients.ID = {client.ID}";
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
                                             INNER JOIN Clients ON Doctors.ID = Clients.DocID
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
            public string GetSpecializationOfDoctor(Doctors doctor)
            {
                string specialization = "";
                CmdDataBase.CommandText = $@"SELECT Specialization.Name
                                             FROM Doctors
                                             INNER JOIN Specialization ON Specialization.ID = Doctors.IDSpec
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
            public string GetDoctorRank(Doctors doctor)
            {
                string rank = "";
                CmdDataBase.CommandText = $@"SELECT RankGroups.Name
                                             FROM Doctors
                                             INNER JOIN Accounts ON Accounts.ID = Doctors.ID
                                             INNER JOIN RankGroups ON RankGroups.ID = Accounts.RankID
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
            public List<List<DBTable>> GetAboutProcedure(Procedures procedure)
            {
                List<List<DBTable>> list = new();
                CmdDataBase.CommandText = $@"SELECT Procedures.Name, Doctors.Username, Clients.Username, ProcedClients.Time
                                             FROM ProcedClients
                                             INNER JOIN Procedures ON ProcedClients.ProcedureID = Procedures.ID
                                             INNER JOIN Doctors ON Doctors.ID = ProcedClients.DocID
                                             INNER JOIN Clients ON Clients.ID = ProcedClients.ClientID
                                             WHERE ProcedClients.ProcedureID = {procedure.ID}";
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
                    List<DBTable> lst = new();
                    foreach(var table in Tables)
                    {
                        if(table is Procedures proc)
                        {
                            if (ReaderDataBase.GetString(0) == proc.Name)
                            {
                                lst.Add(proc);
                                continue;
                            }
                        }
                        if (table is Doctors doctor)
                        {
                            if (ReaderDataBase.GetString(1) == doctor.Username)
                            {
                                lst.Add(doctor);
                                continue;
                            }

                        }
                        if (table is Clients client)
                        {
                            if (ReaderDataBase.GetString(2) == client.Username)
                            {
                                lst.Add(client);
                                continue;
                            }
                        }
                        if (table is ProcedClients procC)
                        {
                            if (procC.ProcedureID == procedure.ID && ReaderDataBase.GetString(3) == procC.Time)
                            {
                                lst.Add(procC);
                                continue;
                            }
                        }
                    }
                    if (lst.Count < 4) return null;
                    list.Add(lst);
                }
                ReaderDataBase.Close();
                return list;
            }
            public void UpdateProcedure(int procedID, int clientID, int DocID, string time)
            {
                CmdDataBase.CommandText = $@"UPDATE ProcedClients
                                             SET 
                                                DocId = {DocID},
                                                Time = '{time}'
                                             WHERE
                                                ProcedureID = {procedID} AND ClientID = {clientID}";
                try
                {
                    CmdDataBase.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            public List<Pills> GetPills(PillType type)
            {
                List<Pills> list = new();
                CmdDataBase.CommandText = $@"SELECT Pills.ID
                                             FROM PillType
                                             INNER JOIN Pills ON PillType.ID = Pills.TypeID
                                             WHERE PillType.ID = {type.ID}";
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
                    foreach(var table in Tables)
                    {
                        if(table is Pills pill)
                        {
                            if (pill.ID == ReaderDataBase.GetInt32(0))
                            {
                                list.Add(pill);
                            }
                        }
                            
                    }
                }
                ReaderDataBase.Close();

                return list;
            }
            public PillType GetTypeOfPill(Pills pill)
            {
                PillType pillType = null;
                CmdDataBase.CommandText = $@"SELECT PillType.ID
                                             FROM Pills
                                             INNER JOIN PillType ON PillType.ID = Pills.TypeID
                                             WHERE Pills.ID = {pill.ID}";
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
                   foreach(var table in Tables)
                    {
                        if(table is PillType pp)
                        {
                            if(pp.ID == ReaderDataBase.GetInt32(0)) { pillType = pp; break; }
                        }
                    }
                }
                ReaderDataBase.Close();
                if(pillType != null) return pillType;
                else return null;
            }
            public List<Clients> GetPatientsPill(Pills pill)
            {
                List<Clients> clients = new List<Clients> ();
                CmdDataBase.CommandText = $@"SELECT Clients.ID
                                             FROM Pills
                                             INNER JOIN ClientPills ON Pills.ID = ClientPills.PillID
                                             INNER JOIN Clients ON ClientPills.ClientID = Clients.ID
                                             WHERE Pills.ID = {pill.ID}";
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
                    foreach (var table in Tables)
                    {
                        if (table is Clients)
                        {
                            var client = (Clients)table;
                            if(client.ID == ReaderDataBase.GetInt32(0))
                                clients.Add(client);
                        }
                    }
                }
                ReaderDataBase.Close();
                return clients;
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }
    }
}