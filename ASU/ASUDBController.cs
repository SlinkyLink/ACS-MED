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

            
            public ASUDBController()
            {
                DataBase = new("Data Source = asu.db; Version = 3;");
                CmdDataBase = new();
                CmdDataBase.Connection = DataBase;
            }

            public void AddData<T>( object one = null,
                                    object two = null,
                                    object three = null,
                                    object four = null,
                                    object five = null,
                                    object six = null)
            {
                Dictionary<Type, Action> @switch = new()
                {
                    {
                        typeof(AccAction), () =>
                        {
                            if(five != null)
                            {
                                Console.WriteLine("For AccAction must be 4 attributes");
                                return;
                            }
                            if( one == null ||
                                two == null ||
                                three == null ||
                                four == null )
                            {
                                Console.WriteLine("Not null attributes!");
                                return;
                            }
                            if( one is int ID &&
                                two is string CreatedBy &&
                                three is string CreatedAt &&
                                four is string Action)
                            {
                                WriteInDB<AccAction>(new AccAction(ID, CreatedBy, CreatedAt, Action));
                            }
                        } 
                    },
                    {
                        typeof(Accounts), () =>
                        {
                             if(five != null)
                            {
                                Console.WriteLine("For Accounts must be 4 attributes");
                                return;
                            }
                            if( one == null ||
                            two == null ||
                            three == null ||
                            four == null )
                            {
                                Console.WriteLine("Not null attributes!");
                                return;
                            }
                            if( one is int ID &&
                                two is string Username &&
                                three is string CreatedBy &&
                                four is string CreatedAt)
                            {
                                WriteInDB<Accounts>(new Accounts(ID, Username, CreatedBy, CreatedAt));
                            }
                        }
                    },
                    {
                        typeof(Clients), () =>
                        {
                            if(six != null)
                            {
                                Console.WriteLine("For Clients must be 5 attributes");
                                return;
                            }
                            if( one == null ||
                            two == null ||
                            three == null ||
                            four == null ||
                            five == null)
                            {
                                Console.WriteLine("Not null attributes!");
                                return;
                            }
                            if( one is int ID &&
                                two is string Username &&
                                three is string DateStart &&
                                four is string DateEnd &&
                                five is string CreatedAt)
                            {
                                WriteInDB<Clients>(new Clients(ID, Username, DateStart, DateEnd, CreatedAt));
                            }
                        }
                    },
                    {
                        typeof(DocsCl), () =>
                        {
                            if(three != null)
                            {
                                Console.WriteLine("For DocsCl must be 2 attributes");
                                return;
                            }
                            if( one == null ||
                                two == null )
                            {
                                Console.WriteLine("Not null attributes!");
                                return;
                            }
                            if( one is int AccId &&
                                two is int DocID )
                            {
                                WriteInDB<DocsCl>(new DocsCl(AccId, DocID));
                            }
                        }
                    },
                    {
                        typeof(Doctors), () =>
                        {
                             if(five != null)
                            {
                                Console.WriteLine("For Doctors must be 4 attributes");
                                return;
                            }
                            if( one == null ||
                            two == null ||
                            three == null ||
                            four == null )
                            {
                                Console.WriteLine("Not null attributes!");
                                return;
                            }
                            if( one is int ID &&
                                two is string Username &&
                                three is string CreatedAt &&
                                four is string CreatedBy)
                            {
                                WriteInDB<Doctors>(new Doctors(ID, Username, CreatedAt, CreatedBy));
                            }
                        }
                    },                
                    {
                        typeof(GroupPerms), () =>
                        {
                             if(three != null)
                            {
                                Console.WriteLine("For GroupPerms must be 2 attributes");
                                return;
                            }
                            if( one == null ||
                                two == null)
                            {
                                Console.WriteLine("Not null attributes!");
                                return;
                            }
                            if( one is int GroupID &&
                                two is int PermID )
                            {
                                WriteInDB<GroupPerms>(new GroupPerms(GroupID, PermID));
                            }
                        }
                    },          
                    {
                        typeof(Perms), () =>
                        {
                            if(six != null)
                            {
                                Console.WriteLine("For Perms must be 5 attributes");
                                return;
                            }
                            if( one == null ||
                                two == null ||
                                three == null ||
                                four == null ||
                                five == null)
                            {
                                Console.WriteLine("Not null attributes!");
                                return;
                            }
                            if( one is int ID &&
                                two is string CreatedBy &&
                                three is string CreatedAt &&
                                four is string Key &&
                                five is string Desc)
                            {
                                WriteInDB<Perms>(new Perms(ID, CreatedBy, CreatedAt, Key, Desc));
                            }
                        }
                    },
                    {
                        typeof(Plan), () =>
                        {
                            if( one == null ||
                            two == null ||
                            three == null ||
                            four == null ||
                            six == null)
                            {
                                Console.WriteLine("Not null attributes!");
                                return;
                            }
                            if( one is int ID &&
                                two is string Username &&
                                three is string PlanAction &&
                                four is string CreatedBy &&
                                five is string CreatedAt &&
                                six is string Desc)
                            {
                                WriteInDB<Plan>(new Plan(ID, Username, PlanAction, CreatedBy, CreatedAt, Desc));
                            }
                        }
                    },
                    {
                        typeof(PlanningCl), () =>
                        {
                            if(three != null)
                            {
                                Console.WriteLine("For PlanningCl must be 2 attributes");
                                return;
                            }
                            if( one == null ||
                            two == null )
                            {
                                Console.WriteLine("Not null attributes!");
                                return;
                            }
                            if( one is int ClientID &&
                                two is int PlanID )
                            {
                                WriteInDB<PlanningCl>(new PlanningCl(ClientID, PlanID));
                            }
                        }
                    },
                    {
                        typeof(RankGroups), () =>
                        {
                            if(six != null)
                            {
                                Console.WriteLine("For RankGroups must be 5 attributes");
                                return;
                            }
                            if( one == null ||
                                two == null ||
                                three == null ||
                                four == null ||
                                five == null ) 
                            {
                                Console.WriteLine("Not null attributes!");
                                return;
                            }
                            if( one is int ID &&
                                two is string CreatedBy &&
                                three is string CreatedAt &&
                                four is string Name &&
                                five is string ShortName)
                            {
                                WriteInDB<RankGroups>(new RankGroups(ID, CreatedBy, CreatedAt, Name, ShortName));
                            }
                        }
                    },
                    {
                        typeof(RankSys), () =>
                        {
                            if(three != null)
                            {
                                Console.WriteLine("For RankSys must be 2 attributes");
                                return;
                            }
                            if( one == null ||
                                two == null )
                            {
                                Console.WriteLine("Not null attributes!");
                                return;
                            }
                            if( one is int UserID &&
                                two is int RankID )
                            {
                                WriteInDB<RankSys>(new RankSys(UserID, RankID));
                            }
                        }
                    },
                    {
                        typeof(UseDocsCl), () =>
                        {
                            if(three != null)
                            {
                                Console.WriteLine("For UseDocsCl must be 2 attributes");
                                return;
                            }
                            if( one == null ||
                                two == null )
                            {
                                Console.WriteLine("Not null attributes!");
                                return;
                            }
                            if( one is int DocID &&
                                two is int ClientID )
                            {
                                WriteInDB<UseDocsCl>(new UseDocsCl(DocID, ClientID));
                            }
                        }
                    }

                };
                @switch[typeof(T)]();
                return;   
            }

            
            private void WriteInDB<T>(T data)
            {
                Dictionary<Type, Action> @switch = new()
                {
                    {
                        typeof(AccAction), () => 
                        {
                            
                            if(data is AccAction DATA)
                            {
                                CmdDataBase.CommandText = @$" INSERT INTO {DATA.GetType().Name} (ID, CreatedBy, CreatedAt, Action)
                                                              VALUES ( {DATA.ID}, '{DATA.CreatedBy}', {DATA.CreatedAt}, '{DATA.Action}' )";
                                CmdDataBase.ExecuteNonQuery();
                            }
                        }
                    },
                    {
                        typeof(Accounts), () => 
                        {
                            
                            if(data is Accounts DATA)
                            {
                                CmdDataBase.CommandText = @$" INSERT INTO {DATA.GetType().Name} (ID, Username, CreatedBy, CreatedAt)
                                                              VALUES ({DATA.ID}, '{DATA.Username}', '{DATA.CreatedBy}', {DATA.CreatedAt})";
                                CmdDataBase.ExecuteNonQuery();
                            }
                        }
                    },
                    {
                        typeof(Clients), () => 
                        {
                            if(data is Clients DATA)
                            {
                                CmdDataBase.CommandText = @$" INSERT INTO Clients (ID, Username, DateStart, DateEnd, CreatedAt)
                                                              VALUES ( {DATA.ID}, '{DATA.Username}', '{DATA.DateStart}', '{DATA.DateEnd}', {DATA.CreatedAt} )";
                                CmdDataBase.ExecuteNonQuery();
                               
                            }
                        }
                    },
                    {
                        typeof(DocsCl), () => 
                        {
                            if(data is DocsCl DATA)
                            {
                                CmdDataBase.CommandText = @$" INSERT INTO {DATA.GetType().Name} ( AccId, DocID )
                                                              VALUES ( {DATA.AccID}, {DATA.DocID} )";
                                CmdDataBase.ExecuteNonQuery();
                            }
                        }
                    },
                    {
                        typeof(Doctors), () => 
                        {
                            if(data is Doctors DATA)
                            {
                                CmdDataBase.CommandText = @$" INSERT INTO {DATA.GetType().Name} ( ID, Username,  CreatedAt, CreatedBy)
                                                              VALUES ( {DATA.ID}, '{DATA.Username}', {DATA.CreatedAt}, '{DATA.CreatedBy}' )";
                                CmdDataBase.ExecuteNonQuery();
                            }
                        }
                    },
                    {
                        typeof(GroupPerms), () => 
                        {
                            if(data is GroupPerms DATA)
                            {
                                CmdDataBase.CommandText = @$" INSERT INTO {DATA.GetType().Name} ( GroupID, PermID )
                                                              VALUES ( {DATA.GroupID}, {DATA.PermID} )";
                                CmdDataBase.ExecuteNonQuery();
                            }
                        }
                    },
                    {
                        typeof(Perms), () => 
                        {
                            if(data is Perms DATA)
                            {
                                CmdDataBase.CommandText = @$" INSERT INTO {DATA.GetType().Name} ( ID, CreatedBy, CreatedAt, Key, Desc )
                                                              VALUES ( {DATA.ID}, '{DATA.CreatedBy}', {DATA.CreatedAt}, '{DATA.Key}', '{DATA.Desc}' )";
                                CmdDataBase.ExecuteNonQuery();
                            }
                        }
                    },
                    {
                        typeof(Plan), () => 
                        {
                            if(data is Plan DATA)
                            {
                                CmdDataBase.CommandText = @$" INSERT INTO {DATA.GetType().Name} ( ID, Username, PlanAction, CreatedBy, CreatedAt, Desc )
                                                              VALUES ( {DATA.ID}, '{DATA.Username}', '{DATA.PlanAction}', '{DATA.CreatedBy}', {DATA.CreatedAt}, '{DATA.Desc}' )";
                                CmdDataBase.ExecuteNonQuery();
                            }
                        }
                    },
                    {
                        typeof(PlanningCl), () => 
                        {
                            if(data is PlanningCl DATA)
                            {
                                CmdDataBase.CommandText = @$" INSERT INTO {DATA.GetType().Name} ( ClientID, PlanID )
                                                              VALUES ( {DATA.ClientID}, {DATA.PlanID} )";
                                CmdDataBase.ExecuteNonQuery();
                            }
                        }
                    },
                    {
                        typeof(RankGroups), () => 
                        {
                            if(data is RankGroups DATA)
                            {
                                CmdDataBase.CommandText = @$" INSERT INTO {DATA.GetType().Name} ( ID, CreatedBy, CreatedAt, Name, ShortName )
                                                              VALUES ( {DATA.ID}, '{DATA.CreatedBy}', {DATA.CreatedAt}, '{DATA.Name}', '{DATA.ShortName}' )";
                                CmdDataBase.ExecuteNonQuery();
                            }
                        }
                    },
                    {
                        typeof(RankSys), () => 
                        {
                            if(data is RankSys DATA)
                            {
                                CmdDataBase.CommandText = @$" INSERT INTO {DATA.GetType().Name} ( UserID, RankID )
                                                              VALUES ( {DATA.UserID}, {DATA.RankID} )";
                                CmdDataBase.ExecuteNonQuery();
                            }
                        }
                    },
                    {
                        typeof(UseDocsCl), () => 
                        {
                            if(data is UseDocsCl DATA)
                            {
                                CmdDataBase.CommandText = @$" INSERT INTO {DATA.GetType().Name} ( DocID, ClientID )
                                                              VALUES ( {DATA.DocID}, {DATA.ClientID} )";
                                CmdDataBase.ExecuteNonQuery();
                            }
                        }
                    },
                };
                DataBase.Open();
                @switch[typeof(T)]();
                DataBase.Close();
                
            }
            
        }
    }
    
}