using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Green.Darts.Model;
using System.Collections.Generic;

namespace Green.Darts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();

            var team1 = new Team();
            var team2 = new Team();

            var player1 = new Player();
            var player2 = new Player();
            var game = new Game
            {
                Name = "Game week 1",
                HomeTeam = team1,
                AwayTeam = team2,
                Rounds = new List<Round>
                {
                    new Round {
                        Name = "Single 1",
                        Number = 1,
                        BestOfLegs = 7,
                        BestOfSets = 5,
                        DoubleIn = false,
                        DoubleOut = true,
                        Sets = new List<Set> {
                            new Set {
                                Number = 1,
                                Legs = new List<Leg> {
                                    new Leg {
                                        Number = 1,
                                        Turns = new List<Turn> {
                                            new Turn {
                                                Number = 1,
                                                Player = player1,
                                                Throws = new List<Throw> {
                                                    new Throw { Number = 1, Score= "T20" },
                                                    new Throw { Number = 2, Score= "T20" },
                                                    new Throw { Number = 3, Score= "T20" }
                                                }
                                            },
                                            new Turn {
                                                Number = 1,
                                                Player = player2,
                                                Throws = new List<Throw> {
                                                    new Throw { Number = 1, Score= "T20" },
                                                    new Throw { Number = 2, Score= "T20" },
                                                    new Throw { Number = 3, Score= "T20" }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new Round {
                        Name = "Single 2",
                        Number = 2,
                        BestOfLegs = 7,
                        BestOfSets = 5,
                        DoubleIn = false,
                        DoubleOut = true,
                        Sets = new List<Set> {
                            new Set {
                                Number = 1,
                                Legs = new List<Leg> {
                                    new Leg {
                                        Number = 1,
                                        Turns = new List<Turn> {
                                            new Turn {
                                                Number = 1,
                                                Player = player1,
                                                Throws = new List<Throw> {
                                                    new Throw { Number = 1, Score= "T20" },
                                                    new Throw { Number = 2, Score= "T20" },
                                                    new Throw { Number = 3, Score= "T20" }
                                                }
                                            },
                                            new Turn {
                                                Number = 1,
                                                Player = player2,
                                                Throws = new List<Throw> {
                                                    new Throw { Number = 1, Score= "T20" },
                                                    new Throw { Number = 2, Score= "T20" },
                                                    new Throw { Number = 3, Score= "T20" }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
