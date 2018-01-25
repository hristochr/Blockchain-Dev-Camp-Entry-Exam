namespace _03.Handball
{

using System;
using System.Collections.Generic;
using System.Linq;

    class Program
    {
        public static void Main()
        {
            HashSet<Team> teams = new HashSet<Team>();

            List<string> input = Console.ReadLine()
                .Split('|')
                .ToList();

            while (input[0] != "stop")
            {
                string team1 = input[0].Trim();
                string team2 = input[1].Trim();

                int t1HomePoints = int.Parse(input[2].Split(':')[0].Trim());
                int t2AwayPoints = int.Parse(input[2].Split(':')[1].Trim());

                int t2HomePoints = int.Parse(input[3].Split(':')[1].Trim());
                int t1AwayPoints = int.Parse(input[3].Split(':')[0].Trim());


                int totalPointsTeam1 = t1HomePoints + t2HomePoints;
                int totalPointsTeam2 = t2AwayPoints + t1AwayPoints;

                bool team1IsWinner = false;
                bool team2IsWinner = false;

                if (totalPointsTeam1 == totalPointsTeam2)
                {
                    team1IsWinner = t2HomePoints > t2AwayPoints;
                    team2IsWinner = t2AwayPoints > t1AwayPoints;
                }
                else
                {
                    team1IsWinner = totalPointsTeam1 > totalPointsTeam2;
                    team2IsWinner = totalPointsTeam2 > totalPointsTeam1;
                }


                Team existingTeam1 = teams.FirstOrDefault(t => t.Name == team1);
                if (existingTeam1 == null)
                {
                    teams.Add(new Team()
                    {
                        Name = team1,
                        Wins = team1IsWinner ? 1 : 0,
                        Oponents = new List<Team>()
                        {
                            new Team()
                            {
                                Name = team2
                            }
                        }
                    });
                }
                else
                {
                    Team opponentTeam = new Team()
                    {
                        Name = team2,
                        Wins = team2IsWinner ? 1 : 0
                    };
                    existingTeam1.Wins += (team1IsWinner ? 1 : 0);
                    existingTeam1.Oponents.Add(opponentTeam);
                }

                Team existingTeam2 = teams.FirstOrDefault(t => t.Name == team2);
                if (existingTeam2 == null)
                {
                    teams.Add(new Team()
                    {
                        Name = team2,
                        Wins = team2IsWinner ? 1 : 0,
                        Oponents = new List<Team>()
                        {
                            new Team()
                            {
                                Name = team1
                            }
                        }
                    });
                }
                else
                {
                    Team opponentTeam = new Team()
                    {
                        Name = team1,
                        Wins = team1IsWinner ? 1 : 0
                    };
                    existingTeam2.Wins += (team2IsWinner ? 1 : 0);
                    existingTeam2.Oponents.Add(opponentTeam);
                }
                input = input = Console.ReadLine()
                .Split('|')
                .ToList();
            }

            foreach (Team team in teams.OrderByDescending(t => t.Wins).ThenBy(t => t.Name))
            {
                Console.WriteLine(team.Name);
                Console.WriteLine($"- Wins: {team.Wins}");
                Console.WriteLine($"- Opponents: {string.Join(", ", team.Oponents.OrderBy(t => t.Name))}");
            }
        }
    }

    public class Team
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public List<Team> Oponents { get; set; }
    }
}
              
