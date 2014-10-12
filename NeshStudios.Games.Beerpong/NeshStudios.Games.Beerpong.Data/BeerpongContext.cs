using NeshStudios.Games.Beerpong.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeshStudios.Games.Beerpong.Data
{
    public class BeerpongContext : DbContext
    {
        public BeerpongContext()
            : base("beerpong")
        {
            Database.SetInitializer<BeerpongContext>(new BeerpongDBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>().Property(x => x.GameStatus);
            modelBuilder.Entity<Game>().Property(x => x.GameMode);
            modelBuilder.Entity<OffensiveShotResult>().Property(x => x.BallStatus);
            modelBuilder.Entity<OffensiveShotResult>().Property(x => x.TrajectoryType);
            modelBuilder.Entity<DefensiveShotResult>().Property(x => x.DefenceType);
            modelBuilder.Entity<GameResult>().Property(x => x.GameOutcome);


            modelBuilder.Entity<OffensiveShotResult>()
                .HasKey(x => x.ShotID);

            modelBuilder.Entity<OffensiveShotResult>()
                .HasRequired(x => x.Shot)
                .WithOptional(x => x.OffensiveShotResult);

            modelBuilder.Entity<DefensiveShotResult>()
                .HasKey(x => x.ShotID);

            modelBuilder.Entity<DefensiveShotResult>()
                .HasRequired(x => x.Shot)
                .WithOptional(x => x.DefensiveShotResult);

        }

        public DbSet<Rack> Racks { get; set; }
        public DbSet<Cup> Cups { get; set; }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

        public DbSet<Game> Games { get; set; }
        public DbSet<Shot> Shots { get; set; }
        public DbSet<OffensiveShotResult> OffensiveShotResults { get; set; }
        public DbSet<DefensiveShotResult> DefensiveShotResults { get; set; }
        public DbSet<GameResult> Results { get; set; }
        
    }

    class BeerpongDBInitializer : DropCreateDatabaseAlways<BeerpongContext>
    {
        protected override void Seed(BeerpongContext context)
        {
            //base.Seed(context);

            var threeCupRack = new List<Cup> 
            {
                new Cup 
                {  
                    Order = 1,
                    Radius = 1,
                    X = 0.5m, 
                    Y= 0.5m, 
                },
                new Cup 
                {  
                    Order = 2,
                    Radius = 1,
                    X = 0.5m, 
                    Y= 1.5m, 
                },
                new Cup 
                {  
                    Order = 3,
                    Radius = 1,
                    X = 0.5m, 
                    Y= 2.5m, 
                },
            };

            var sixRackCups = new List<Cup>
            {
                new Cup 
                {  
                    Order = 1,
                    Radius = 1,
                    X = 1.5m, 
                    Y= 0.5m, 
                },
                new Cup 
                {  
                    Order = 2,
                    Radius = 1,
                    X = 1m, 
                    Y= 1.5m, 
                },
                new Cup 
                {  
                    Order = 3,
                    Radius = 1,
                    X = 2m, 
                    Y= 1.5m, 
                },
                new Cup 
                {  
                    Order = 4,
                    Radius = 1,
                    X = 0.5m, 
                    Y= 2.5m, 
                },
                new Cup 
                {  
                    Order = 5,
                    Radius = 1,
                    X = 1.5m, 
                    Y= 2.5m, 
                },
                new Cup 
                {  
                    Order = 6,
                    Radius = 1,
                    X = 2.5m, 
                    Y= 2.5m, 
                },
            };

            context.Racks.Add(new Rack { Name = "3 Cup Standard (Straight Line)", Cups = threeCupRack });
            context.Racks.Add(new Rack { Name = "6 Cup Standard (Triangle)", Cups = sixRackCups });


            var players = new List<Player>
            {
                new Player { Name= "Dhinesh" },
                new Player { Name= "Harija" },
                new Player { Name= "Asce" },
                new Player { Name= "Luffy" },
            };

            context.Players.AddRange(players);

            context.SaveChanges();
        }
    }
}
