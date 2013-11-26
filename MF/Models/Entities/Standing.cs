using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace MF.Models.Entities
{
    public class Standing
    {
        public string TeamName;
        public int TeamW;
        public int TeamL;
        public int TeamD;
        public int TeamF;
        public int TeamA;

        public static IList<Standing> Of()
        {
            var standings = new List<Standing>();
            var data = Result.GetAllResults();
            var winner = (data.Where(c => c.ResultFirstScore > c.ResultSecondScore).Select(c => c.ResultFirst.TeamId)
                ).Concat(data.Where(c => c.ResultFirstScore < c.ResultSecondScore).Select(c => c.ResultSecond.TeamId)).ToList();
            var tie = data.Where(c => c.ResultFirstScore == c.ResultSecondScore).Select(c => c.ResultFirst.TeamId).ToList();
            var loser = (data.Where(c => c.ResultFirstScore < c.ResultSecondScore).Select(c => c.ResultFirst.TeamId)
                ).Concat(data.Where(c => c.ResultFirstScore > c.ResultSecondScore).Select(c => c.ResultSecond.TeamId)).ToList();
            var dataByTeam1 = data.ToLookup(c => c.ResultFirst.TeamId);
            var dataByTeam2 = data.ToLookup(c => c.ResultSecond.TeamId);

            foreach (var team in Team.GetAllTeams())
            {
                var teamid = team.TeamId;
                int countL = loser.Count(s => s == teamid);
                int countD = tie.Count(s => s == teamid);
                int countW = winner.Count(s => s == teamid);
                int countF = dataByTeam1[teamid].Sum(s => s.ResultFirstScore) +
                    dataByTeam2[teamid].Sum(s => s.ResultSecondScore);
                int countA = dataByTeam1[teamid].Sum(s => s.ResultSecondScore) +
                    dataByTeam2[teamid].Sum(s => s.ResultFirstScore);
                standings.Add(item: new Standing
                {
                    TeamName = team.TeamName,
                    TeamW = countW,
                    TeamD = countD,
                    TeamL = countL,
                    TeamF = countF,
                    TeamA = countA
                });
            }
            return standings;
        }
    }
}