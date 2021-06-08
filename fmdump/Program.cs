using CsvHelper;
using FMScoutFramework.Core;
using FMScoutFramework.Core.Entities.InGame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace fmdump
{
    class Program
    {
        FMCore fm;
        Program() {
            fm = new FMCore();
        }

        const int premierLeagueUID = 11;

        static void Main(string[] args)
        {
            var program = new Program();

            program.WritePlayerAndTeamCSVs();
            program.EditAttributes();
        }

        private void EditAttributes()
        {
            // as an example, modify an attribute of Tammy Abraham
            var tammy = (from  t in Teams(fm, premierLeagueUID) from p in t.Players where p.UID == 28097985 select p ).First();
            Log($"Found {tammy}");
            var attrs = tammy.Attributes;
            attrs.Acceleration = 40;
            
            attrs.Save();
            tammy.Save();
        }

        private void WritePlayerAndTeamCSVs()
        {
            var teamsCSV = "teams.csv";
            var playersCSV = "players.csv";

            Log("Creating FM");

            Log("Loading data");
            fm.LoadData();
            Log("Loaded data");

            Log("Finding premier league teams");
            var premierLeagueTeams = Teams(fm, premierLeagueUID);
            var teamData = (
                from t in premierLeagueTeams
                select new { t.Club.UID, t.Club.Name, t.Reputation, LeagueUID = premierLeagueUID }
            ).ToList();
            Log($"Found {teamData.Count} teams");
            WriteCSV(teamData, teamsCSV);
            Log($"Teams written to {teamsCSV}");

            Log("Finding their players");
            var players = (
                from t in premierLeagueTeams
                from p in t.Players
                select new { p.UID, TeamUID = t.UID, p.ActualPerson.FirstName, p.ActualPerson.LastName, p.CA, p.PA, p.Attributes.Determination, p.CurrentReputation, p.Value }
            ).ToList();
            Log($"Found {players.Count} players");
            WriteCSV(players, playersCSV);
            Log($"Players written to {playersCSV}");

        }

        private static void WriteCSV<T>(IEnumerable<T> records, string path)
        {
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(records);
            }
        }

        private static IEnumerable<Competition> Competitions(FMCore fm) =>
            from league in fm.Competitions
            orderby league.Reputation descending
            select league;

        private static IEnumerable<Team> Teams(FMCore fm, int leagueUID) =>
            from league in fm.Competitions
            where league.UID == leagueUID
            from entrant in league.ActualCompetition.LeagueStages.First().LeagueTable
            select entrant.Team;

        private static void Log(string s) => Console.WriteLine(s);
    }
}
