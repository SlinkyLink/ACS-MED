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
            
            public List<DBTable> Tables { get; private set; }

            public DBTable activeTable { get; set; }


            private string _loginText;
            private string _passwordText;

            public string LoginText
            {
                get { return _loginText; } 
                set { _loginText = value; }
            }

            public string PasswordText
            {
                set { _passwordText = value; }
                get { return _passwordText; }
            }


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

            public bool CheckLogPass(string Log, string Pass)
            {
                foreach(DBTable table in Tables)
                {
                    if(table is Accounts acc)
                    {
                        if(Log == acc.Username && Pass == acc.Password)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }



            public void AddData(DBTable table)
            {
                CmdDataBase.CommandText = table.cmdAddDB();
                CmdDataBase.ExecuteNonQuery();
                _Update(); 
            }


            public void DellData(DBTable table, object value)
            {
                if(value is int valueINT)
                    CmdDataBase.CommandText = table.cmdDellDB(valueINT);
                else if(value is string valueSTRING)
                    CmdDataBase.CommandText = table.cmdDellDB(valueSTRING);
                if(CmdDataBase.CommandText != DBTable.ErrorExceptrionSTR)
                    CmdDataBase.ExecuteNonQuery();
                _Update();
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

            public string GetDATA(DBTable dBTable)
            {
                return dBTable.GetDATA();
            }


            private void _Update()
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
                                    ReaderDataBase.GetString(3),
                                    ReaderDataBase.GetString(4)
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