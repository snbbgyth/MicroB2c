using System.Data.Entity.Migrations;
using MySql.Data.Entity;
using MicroB2c.Web.Areas.Admin.Models;

namespace MicroB2c.Web.DAL.MySql
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetHistoryContextFactory("MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema));
        }

        protected override void Seed(ApplicationDbContext context)
        {

        }
    }
}