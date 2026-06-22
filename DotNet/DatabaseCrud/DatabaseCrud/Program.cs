using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace DatabaseCrud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Database Crud");

            StudentiDAL dal = new();

            dal.Elenco().ForEach(e => Console.WriteLine(e));
        }
    }
}
