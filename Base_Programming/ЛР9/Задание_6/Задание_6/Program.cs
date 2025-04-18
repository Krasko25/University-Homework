using System;
using System.Collections.Generic;

public class TournamentSimulator
{
    static Random rng = new Random();

    class Game
    {
        public string Player1;
        public string Player2;
        public int Score1;
        public int Score2;
        public Game LeftMatch;
        public Game RightMatch;

        public string Winner => Score1 > Score2 ? Player1 : Player2;
    }

    static Game SimulateGame(string player1, string player2)
    {
        int score1 = rng.Next(0, 6);
        int score2 = rng.Next(0, 6);
        while (score1 == score2)
        {
            score1 = rng.Next(0, 6);
            score2 = rng.Next(0, 6);
        }
        return new Game { Player1 = player1, Player2 = player2, Score1 = score1, Score2 = score2 };
    }

    static Game SimulateRound(List<Game> previousGames)
    {
        var upcomingMatches = new List<Game>();
        for (int i = 0; i < previousGames.Count; i += 2)
        {
            var left = previousGames[i];
            var right = previousGames[i + 1];
            var game = SimulateGame(left.Winner, right.Winner);
            game.LeftMatch = left;
            game.RightMatch = right;
            upcomingMatches.Add(game);
        }
        return upcomingMatches.Count == 1 ? upcomingMatches[0] : SimulateRound(upcomingMatches);
    }

    static void DisplayTournamentTree(Game game, int level = 0)
    {
        if (game == null) return;
        string indent = new string(' ', level * 4);
        Console.WriteLine($"{indent}{game.Player1} vs {game.Player2} : {game.Score1} - {game.Score2}");
        DisplayTournamentTree(game.LeftMatch, level + 1);
        DisplayTournamentTree(game.RightMatch, level + 1);
    }

    public static void Main()
    {
        var competitors = new List<string>
        {
            "ААА", "БББ", "ВВВ", "ГГГ",
            "ДДД", "ЕЕЕ", "ЁЁЁ", "ЖЖЖ",
            "ИИИ", "ЙЙЙ", "ККК", "ЛЛЛ",
            "МММ", "ННН", "ООО", "ППП"
        };

        var firstStageMatches = new List<Game>();
        for (int i = 0; i < competitors.Count; i += 2)
        {
            firstStageMatches.Add(SimulateGame(competitors[i], competitors[i + 1]));
        }

        var finalMatch = SimulateRound(firstStageMatches);
        DisplayTournamentTree(finalMatch);
    }
}
