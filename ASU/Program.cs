using ASU.Controller;
using System.Data.SQLite;
namespace ASU
{
    class Program
    {
        static void Main(string[] args)
        {
            ASUDBController gg = new();
            gg.AddData<Accounts>(54, "kryss", "GG", "DATE('now')");


        
        }
    
    }
    
}
