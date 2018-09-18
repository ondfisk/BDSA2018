using System;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BDSA2018.Lecture04
{
    class Program
    {
        static void Main(string[] args)
        {
            //var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=Futurama";

            //var sql = "SELECT * FROM Characters WHERE Name LIKE '%'+@searchString+'%'";

            //using (var connection = new SqlConnection(connectionString))
            //using (var command = new SqlCommand(sql, connection))
            //{
            //    connection.Open();

            //    command.Parameters.AddWithValue("@searchString", search);

            //    var reader = command.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        Console.WriteLine(reader["Name"]);
            //    }
            //}

            using (var ctx = new FuturamaContext())
            {
                var fs = from c in ctx.Characters
                         select c;

                // Note: This is a 1+n problem!
                foreach (var c in fs)
                {
                    Console.WriteLine($"{c.Name} voiced by: {c.Actor.Name}");
                }

                //var character = new Character { Name = "Bender", Species = "Robot" };

                //ctx.Characters.Add(character);

                //ctx.SaveChanges();
            }
        }
    }
}
