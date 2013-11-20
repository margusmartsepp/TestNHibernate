using System;
using NHibernateFootballChampionshipTests.Entities;

namespace NHibernateFootballChampionshipTests.Test.Custom
{
    public static class Custom
    {
        public static void ResultCustomTest()
        {
            var team1 = new Team { TeamName = "Margus1" };
            var team2 = new Team { TeamName = "Margus2" };
            var result1 = new Result { ResultFirst = team1, ResultFirstScore = 1, ResultSecond = team2, ResultSecondScore = 5 };

            //Create
            Result.Add(result1);
            Console.WriteLine(result1);

            //READ
            var result2 = Result.GetResultById(1);
            Console.WriteLine(result1);

            //UPDATE shallow
            result1.ResultFirstScore = 3;
            result1.ResultSecondScore = 3;
            Result.Update(result1);

            var result3 = Result.GetResultById(1);
            Console.WriteLine(result3);

            //UPDATE deep
            result2.ResultFirst.TeamName = "Martsepp1";
            result2.ResultSecond.TeamName = "Martsepp2";
            Result.Update(result2);

            var result4 = Result.GetResultById(1);
            Console.WriteLine(result4);

            //DELETE 
            var id = result4.ResultId;
            Result.Delete(result4);
            var result5 = Result.GetResultById(id);
            Console.WriteLine(result5);
        }

        public static void TeamCustomTest()
        {
            var team1 = new Team { TeamName = "Margus1" };
            var team2 = new Team { TeamName = "Margus2" };

            //CREATE
            Team.Add(team1);
            Team.Add(team2);

            //READ
            var team3 = Team.GetTeamById(1);
            var team4 = Team.GetTeamById(2);
            Console.WriteLine(team3);
            Console.WriteLine(team4);

            //Update
            team1.TeamName = "Martsepp1";
            team2.TeamName = "Martsepp2";
            Team.Update(team1);
            Team.Update(team2);

            var team5 = Team.GetTeamById(1);
            var team6 = Team.GetTeamById(2);
            Console.WriteLine(team5);
            Console.WriteLine(team6);

            //DELETE
            var id = team5.TeamId;
            Team.Delete(team5);
            var team7 = Team.GetTeamById(id);
            Console.WriteLine(team7);
        }
    }
}
