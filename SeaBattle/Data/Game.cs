namespace SeaBattle.Data
{
    public interface IGame
    {
        public GameState State { get; set; }
    }

    public class Game
    {

    }

    public enum GameState
    {
        Beginning = 0,
        InProgress = 1,
        Finished = 2
    }
}
