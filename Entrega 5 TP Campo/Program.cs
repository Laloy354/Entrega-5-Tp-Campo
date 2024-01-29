using System;
using System.Windows.Forms;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Entrega_5_TP_Campo
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Entrega5Context>();
            var connectionString = "Host=localhost;Port=5433;Database=Entrega5;Persist Security Info=True;Password=WebAPIDesarrollo;Username=postgres";
            optionsBuilder.UseNpgsql(connectionString);

            using (var dbContext = new Entrega5Context(optionsBuilder.Options))
            {
                dbContext.Database.EnsureCreated();
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
