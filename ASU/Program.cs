using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using ASU.Controller;
using System.Data.SQLite;


namespace ASU
{
    class Program
    {
        static void Main(string[] args)
        {
            ASUDBController DBController = new();
            Console.WriteLine(DBController.GetDATA("AccActions"));
           

            
            DBController.DBClose();
        }
    
    }
    
}
