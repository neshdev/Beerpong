using NeshStudios.Games.Beerpong.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeshStudios.Games.Beerpong.Data.Migration
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BeerpongContext())
            {
                var game = new Game();
                game.StartTime = DateTime.Now;
                game.Status = GameStatus.Created;
                game.Mode = GameMode.TwoOnTwo;

                var player1 = db.Players.Single(x => x.Name == "Dhinesh");
                var player2 = db.Players.Single(x => x.Name == "Harija");
                var player3 = db.Players.Single(x => x.Name == "Asce");
                var player4 = db.Players.Single(x => x.Name == "Luffy");

                var team1 = new Team { Name = "Team 1" };
                var team2 = new Team { Name = "Team 2" };

                var teamMembers = new List<TeamMember>()
                {
                    new TeamMember { Player = player1, Team = team1 },
                    new TeamMember { Player = player2, Team = team1 },
                    new TeamMember { Player = player3, Team = team2 },
                    new TeamMember { Player = player4, Team = team2 },
                };

                db.TeamMembers.AddRange(teamMembers);

                var rack = db.Racks.Single(x => x.Name.Contains("6 Cup Standard"));

                var shots = new List<Shot>()
                {
                    new Shot 
                    { 
                        Rack = rack,
                        Cup = null,
                        OffensiveShotResult = new OffensiveShotResult
                        {
                            Status = BallStatus.Air,    
                            Trajectory = TrajectoryType.Projectile,
                            TeamMember = teamMembers[0],
                        }                       
                    },
                    new Shot 
                    { 
                        Rack = rack,
                        Cup = rack.Cups.Single(x => x.Order == 1),
                        OffensiveShotResult = new OffensiveShotResult
                        {
                            Status = BallStatus.Hit,  
                            Trajectory = TrajectoryType.Projectile,
                            TeamMember = teamMembers[1],
                        }
                    },
                    new Shot 
                    { 
                        Rack = rack,
                        Cup = null,
                        OffensiveShotResult = new OffensiveShotResult
                        {
                            Status = BallStatus.Air,
                            Trajectory = TrajectoryType.Projectile,
                            TeamMember = teamMembers[2],
                        }
                    },
                    new Shot 
                    { 
                        Rack = rack,
                        Cup = rack.Cups.Single(x => x.Order == 1),
                        OffensiveShotResult = new OffensiveShotResult
                        {
                            Status = BallStatus.Defended,    
                            Trajectory = TrajectoryType.Projectile,
                            TeamMember = teamMembers[3],
                        },
                        DefensiveShotResult = new DefensiveShotResult
                        {
                            Defence = DefenceType.Finger,
                            TeamMember = teamMembers[1],
                        }
                    },
                        
                };

                game.Shots = shots;
                game.Status = GameStatus.InProgress;


                game.GameResults = new List<GameResult>
                {
                    new GameResult
                    {
                        TeamMember = teamMembers[0],
                        Outcome = GameOutcome.Win,
                    },
                    new GameResult
                    {
                        TeamMember = teamMembers[1],
                        Outcome = GameOutcome.Win,
                    },
                    new GameResult
                    {
                        TeamMember = teamMembers[2],
                        Outcome = GameOutcome.Loss,
                    },
                    new GameResult
                    {
                        TeamMember = teamMembers[3],
                        Outcome = GameOutcome.Loss,
                    },
                };

                game.Status = GameStatus.Completed;
                game.EndTime = DateTime.Now;

                db.Games.Add(game);
                db.SaveChanges();

                var query = db.Games.OrderBy(x => x.GameID);

                foreach (var item in query)
                {
                    Console.WriteLine("Test Game {0}", item.GameID);
                }
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
