namespace AdventOfCode.Day2;

public class RockPaperScissorsEngine
{
    public int Score { get; private set; }

    public void Play(char opponentAction, char yourNeededResultCode)
    {
        var round = new Round(opponentAction, yourNeededResultCode);
        Score += round.Points;
    }
}

public class Round
{
    public int Points { get; }
    
    private enum GameAction
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }
    
    private enum ResultOfRound
    {
        Success = 6,
        Tie = 3,
        Fail = 0
    }
    
    public Round(char opponent, char action)
    {
        var opponentsAction = GetAction(opponent);
        var yourNeededResult = GetNeededResult(action);
        var neededAction = GetNeededAction(opponentsAction, yourNeededResult);
        
        Points += (int)neededAction;
        var result = GetResult(opponentsAction, neededAction);
        Points += (int)result;
    }

    private ResultOfRound GetResult(GameAction opponent, GameAction yourGameAction)
    {
        return (opponent, yourAction: yourGameAction) switch
        {
            (GameAction.Rock, GameAction.Rock) => ResultOfRound.Tie,
            (GameAction.Rock, GameAction.Paper) => ResultOfRound.Success,
            (GameAction.Rock, GameAction.Scissors) => ResultOfRound.Fail,
            (GameAction.Paper, GameAction.Paper) => ResultOfRound.Tie,
            (GameAction.Paper, GameAction.Scissors) => ResultOfRound.Success,
            (GameAction.Paper, GameAction.Rock) => ResultOfRound.Fail,
            (GameAction.Scissors, GameAction.Scissors) => ResultOfRound.Tie,
            (GameAction.Scissors, GameAction.Rock) => ResultOfRound.Success,
            (GameAction.Scissors, GameAction.Paper) => ResultOfRound.Fail,
        };
    }

    private GameAction GetAction(char action)
    {
        return action switch
        {
            'A' => GameAction.Rock,
            'X' => GameAction.Rock,
            'B' => GameAction.Paper,
            'Y' => GameAction.Paper,
            'C' => GameAction.Scissors,
            'Z' => GameAction.Scissors,
            _ => throw new Exception("Possible!!!")
        };
    }
    
    private ResultOfRound GetNeededResult(char action)
    {
        return action switch
        {
            'X' => ResultOfRound.Fail,
            'Y' => ResultOfRound.Tie,
            'Z' => ResultOfRound.Success,
            _ => throw new Exception("Possible!!!")
        };
    }

    private GameAction GetNeededAction(GameAction opponentsAction, ResultOfRound neededResult)
    {
        return (opponentsAction, neededResult) switch
        {
            (GameAction.Rock, ResultOfRound.Tie) => GameAction.Rock,
            (GameAction.Rock, ResultOfRound.Fail) => GameAction.Scissors,
            (GameAction.Rock, ResultOfRound.Success) => GameAction.Paper,
            (GameAction.Paper, ResultOfRound.Tie) => GameAction.Paper,
            (GameAction.Paper, ResultOfRound.Fail) => GameAction.Rock,
            (GameAction.Paper, ResultOfRound.Success) => GameAction.Scissors,
            (GameAction.Scissors, ResultOfRound.Tie) => GameAction.Scissors,
            (GameAction.Scissors, ResultOfRound.Fail) => GameAction.Paper,
            (GameAction.Scissors, ResultOfRound.Success) => GameAction.Rock,
        };
    }
}