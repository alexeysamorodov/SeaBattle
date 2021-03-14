using SeaBattle.Data;

namespace SeaBattle.Services
{
    public interface IGameLifetimeService
    {
        Game Game { get; set; }

        void StartBattle();

        void FinishBattle();

        bool IsOperationValidNow();
    }

    public class GameLifetimeService
    {
    }
}
