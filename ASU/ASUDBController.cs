using System.Collections.Generic;
using System;
using System.Data.SQLite;

namespace ASU
{
    namespace Controller
    {
        public class ASUDBController
        {
            SQLiteConnection DataBase;
            SQLiteCommand CmdDataBase;
            SQLiteDataReader ReaderDataBase;
            
            List<DBTable> Tables;

        
            public ASUDBController()
            {
                DataBase = new("Data Source = asu.db; Version = 3;");
                DataBase.Open();
                CmdDataBase = new();
                Tables = new();
                CmdDataBase.Connection = DataBase;
                __Update();
            }


            public void AddData(DBTable table)
            {
                CmdDataBase.CommandText = table.cmdAddDB();
                CmdDataBase.ExecuteNonQuery();
                __Update(); 
            }


            public void DellData(DBTable table, object value)
            {
                if(value is int valueINT)
                    CmdDataBase.CommandText = table.cmdDellDB(valueINT);
                else if(value is string valueSTRING)
                    CmdDataBase.CommandText = table.cmdDellDB(valueSTRING);
                if(CmdDataBase.CommandText != DBTable.ErrorExceptrionSTR)
                    CmdDataBase.ExecuteNonQuery();
                __Update();
            }

            
            public void DBClose()
            {
                if(ReaderDataBase != null)
                {
                    if(!ReaderDataBase.IsClosed)
                    {
                        ReaderDataBase.Close();
                    }
                }
                DataBase.Close();
            }

            public string GetDATAs()
            {
                string temp = "";
                foreach(var table in Tables)
                {
                    temp += $"{table.GetName()}\t{table.GetDATA()}\n";
                }
                return temp;
            }

            public string GetDATA(string ntable)
            {
                string temp = "";
                foreach(var table in Tables)
                {
                    if(table.GetName() == ntable)
                    {
                        temp += $"{table.GetDATA()}\n";
                    }
                }
                return temp;
            }



            private void __Update()
            {
                if(Tables.Count > 0)
                    Tables.Clear();

                List<string> tables = new();

                CmdDataBase.CommandText = @"SELECT name
                                            FROM sqlite_schema
                                            WHERE type ='table' AND name NOT LIKE 'sqlite_%';";
                ReaderDataBase = CmdDataBase.ExecuteReader();
                while(ReaderDataBase.Read())
                {
                    tables.Add(ReaderDataBase.GetString(0));
                }
                ReaderDataBase.Close();

                foreach(var table in tables)
                {
                    
                    CmdDataBase.CommandText = $"SELECT * FROM {table}";
                    ReaderDataBase = CmdDataBase.ExecuteReader();
                    while(ReaderDataBase.Read())
                    {
                        if(table == "AccActions")
                        {
                            Tables.Add
                            (
                                new AccActions
                                (  
                                    ReaderDataBase.GetInt32(0),
                                    ReaderDataBase.GetString(1),
                                    ReaderDataBase.GetString(2),
                                    ReaderDataBase.GetString(3)
                                )
                            );
                        }
                        else if(table == "Accounts")
                        {
                            Tables.Add
                            (
                                new Accounts
                                (  
                                    ReaderDataBase.GetInt32(0),
                                    ReaderDataBase.GetString(1),
                                    ReaderDataBase.GetString(2),
                                    ReaderDataBase.GetString(3)
                                )
                            );
                        }
                        else if(table == "Clients")
                        {
                            Tables.Add
                            (
                                new Clients
                                (  
                                    ReaderDataBase.GetInt32(0),
                                    ReaderDataBase.GetString(1),
                                    ReaderDataBase.GetString(2),
                                    ReaderDataBase.GetString(3),
                                    ReaderDataBase.GetString(4)
                                )
                            );
                        }
                        else if(table == "DocsCl")
                        {
                            Tables.Add
                            (
                                new DocsCl
                                (  
                                    ReaderDataBase.GetInt32(0),
                                    ReaderDataBase.GetInt32(1)
                                )
                            );
                        }
                        else if(table == "Doctors")
                        {
                            Tables.Add
                            (
                                new Doctors
                                (  
                                    ReaderDataBase.GetInt32(0),
                                    ReaderDataBase.GetString(1),
                                    ReaderDataBase.GetString(2),
                                    ReaderDataBase.GetString(3)
                                )
                            );
                        }
                        else if(table == "DrugsDef")
                        {
                            Tables.Add
                            (
                                new DrugsDef
                                (  
                                    ReaderDataBase.GetInt32(0),
                                    ReaderDataBase.GetString(1),
                                    ReaderDataBase.GetInt32(2),
                                    ReaderDataBase.GetString(3),
                                    ReaderDataBase.GetString(4)
                                )
                            );
                        }
                        else if(table == "GroupPerms")
                        {
                            Tables.Add
                            (
                                new GroupPerms
                                (  
                                    ReaderDataBase.GetInt32(0),
                                    ReaderDataBase.GetInt32(1)
                                )
                            );
                        }
                        else if(table == "Perms")
                        {
                            Tables.Add
                            (
                                new Perms
                                (  
                                    ReaderDataBase.GetInt32(0),
                                    ReaderDataBase.GetString(1),
                                    ReaderDataBase.GetString(2),
                                    ReaderDataBase.GetString(3),
                                    ReaderDataBase.GetString(4)
                                )
                            );
                        }
                        else if(table == "PhysDef")
                        {
                            Tables.Add
                            (
                                new PhysDef
                                (  
                                    ReaderDataBase.GetInt32(0),
                                    ReaderDataBase.GetString(1),
                                    ReaderDataBase.GetString(2),
                                    ReaderDataBase.GetString(3),
                                    ReaderDataBase.GetString(4)
                                )
                            );
                        }
                        else if(table == "Plan")
                        {
                            Tables.Add
                            (
                                new Plan
                                (  
                                    ReaderDataBase.GetInt32(0),
                                    ReaderDataBase.GetString(1),
                                    ReaderDataBase.GetString(2),
                                    ReaderDataBase.GetString(3),
                                    ReaderDataBase.GetString(4),
                                    ReaderDataBase.GetString(5)
                                )
                            );
                        }
                        else if(table == "PlanningCl")
                        {
                            Tables.Add
                            (
                                new PlanningCl
                                (  
                                    ReaderDataBase.GetInt32(0),
                                    ReaderDataBase.GetInt32(1)
                                )
                            );
                        }
                        else if(table == "RankGroups")
                        {
                            Tables.Add
                            (
                                new RankGroups
                                (  
                                    ReaderDataBase.GetInt32(0),
                                    ReaderDataBase.GetString(1),
                                    ReaderDataBase.GetString(2),
                                    ReaderDataBase.GetString(3),
                                    ReaderDataBase.GetString(4)
                                )
                            );
                        }
                        else if(table == "RankSys")
                        {
                            Tables.Add
                            (
                                new RankSys
                                (  
                                    ReaderDataBase.GetInt32(0),
                                    ReaderDataBase.GetInt32(1)
                                )
                            );
                        }
                        else if(table == "Sheduler")
                        {
                            Tables.Add
                            (
                                new Sheduler
                                (  
                                    ReaderDataBase.GetInt32(0),
                                    ReaderDataBase.GetInt32(1),
                                    ReaderDataBase.GetInt32(2),
                                    ReaderDataBase.GetString(3),
                                    ReaderDataBase.GetInt32(4),
                                    ReaderDataBase.GetInt32(5)
                                )
                            );
                        }
                        else if(table == "UseDocsCl")
                        {
                            Tables.Add
                            (
                                new UseDocsCl
                                (  
                                    ReaderDataBase.GetInt32(0),
                                    ReaderDataBase.GetInt32(1)
                                )
                            );
                        }
                    }
                    ReaderDataBase.Close();
                }
                
            }


        }
    }
}