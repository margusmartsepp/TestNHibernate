using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MF.Models.Entities
{
    public class Standing
    {
        public string TeamName;
        public int TeamW;
        public int TeamL;
        public int TeamT;

        public static IList<Standing> Of()
        {


            var standings = new List<Standing>();
            var data = Result.GetAllResults();
            var winner = (data.Where(c => c.ResultFirstScore > c.ResultSecondScore).Select(c => c.ResultFirst.TeamId)
                ).Union(data.Where(c => c.ResultFirstScore < c.ResultSecondScore).Select(c => c.ResultSecond.TeamId)).ToList();
            var tie = data.Where(c => c.ResultFirstScore == c.ResultSecondScore).Select(c => c.ResultFirst.TeamId).ToList();
            var loser = (data.Where(c => c.ResultFirstScore < c.ResultSecondScore).Select(c => c.ResultFirst.TeamId)
                ).Union(data.Where(c => c.ResultFirstScore > c.ResultSecondScore).Select(c => c.ResultSecond.TeamId)).ToList();

            foreach (var team in Team.GetAllTeams())
            {
                var teamid = team.TeamId;
                int count = loser.Count(s => s == teamid);
                int count1 = tie.Count(s => s == teamid);
                int count2 = winner.Count(s => s == teamid);

                standings.Add(item: new Standing
                {
                    TeamName = team.TeamName,
                    TeamW = count2,
                    TeamT = count1,
                    TeamL = count
                });
            }
            return standings;
        }
    }
}