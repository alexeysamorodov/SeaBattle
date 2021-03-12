using SeaBattle.Data;

namespace SeaBattle.Services
{
    public interface IGameLifetimeService
    {
        IGame Game { get; set; }

        void StartBattle();

        void FinishBattle();

        bool IsOperationValidNow();
    }

    public class GameLifetimeService
    {
    }
}
