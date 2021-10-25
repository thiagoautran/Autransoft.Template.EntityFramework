using System;
using System.Reflection;
using Autransoft.Template.EntityFramework.Lib.DTOs;
using Autransoft.Template.EntityFramework.Lib.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Autransoft.Template.EntityFramework.Lib.Data
{
    public class AutransoftContext : DbContext, IAutransoftContext
    {
        private readonly PosgreSQL _posgreSQL;

        public AutransoftContext(IOptions<AutransoftDatabase> database) => _posgreSQL = database?.Value?.PosgreSQL;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = !string.IsNullOrEmpty(_posgreSQL.LocalConnectionString) ? _posgreSQL.LocalConnectionString : GetConnectionString();

                try
                {
                    optionsBuilder.UseNpgsql(connectionString);
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Message={ex.Message}|ConnectionString={connectionString}");
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private string GetConnectionString() =>
            $"Server={_posgreSQL?.EndPoint};Database={_posgreSQL?.DataBaseName};Uid={_posgreSQL?.User};Pwd={_posgreSQL?.Pass}";
    }
}