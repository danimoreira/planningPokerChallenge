using System;
using Microsoft.EntityFrameworkCore;
using PlanningPocker.Domain.Entities;

namespace PlanningPocker.Repository.Context
{
    public class PlanningPockerContext : DbContext
    {
        public DbSet<Carta> Cartas { get; set; }
        public DbSet<HistoriaDoUsuario> HistoriaDoUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Voto> Votos { get; set; }

        public PlanningPockerContext()
        {
            
        }
        public PlanningPockerContext(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityByDefaultColumns();
        	modelBuilder.HasDefaultSchema("PlanningPoker");

            ConfigureVoto(modelBuilder);
        }

        public static string GetConnectionString()
        {
            string url = "postgres://lcuffiid:RlACufwwxdkjSWgzfwTKAHVz8mFFkitF@tuffi.db.elephantsql.com:5432/lcuffiid";

            var uri = new Uri(url);
            var db = uri.AbsolutePath.Trim('/');
            var user = uri.UserInfo.Split(':')[0];
            var passwd = uri.UserInfo.Split(':')[1];
            var port = uri.Port > 0 ? uri.Port : 5432;
            var connStr = string.Format("Server={0};Database={1};User Id={2};Password={3};Port={4}", 
                uri.Host, db, user, passwd, port);
            return connStr;
        }

        private void ConfigureVoto(ModelBuilder modelo)
        {
            modelo.Entity<Voto>()
                .HasOne<Usuario>(s => s.Usuario)
                .WithMany(x => x.Votos)
                .HasForeignKey(z => z.IdUsuario);

            modelo.Entity<Voto>()
                .HasOne<Carta>(s => s.Carta)
                .WithMany(x => x.Votos)
                .HasForeignKey(z => z.IdCarta);

            modelo.Entity<Voto>()
                .HasOne<HistoriaDoUsuario>(s => s.HistoriaDoUsuario)
                .WithMany(x => x.Votos)
                .HasForeignKey(z => z.IdHistoriaDoUsuario);

        }
        

    }
}