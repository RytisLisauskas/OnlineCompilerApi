using Microsoft.EntityFrameworkCore;
using OnlineCompiler.Data.DBModels;
using System;

namespace OnlineCompiler.Data
{
    public class OnlineCompilerDbContext : DbContext
    {
        public DbSet<AppTask> AppTasks { get; set; }
        public string DbPath { get; set; }

        public OnlineCompilerDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Combine(path, "CompilerDB.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}
