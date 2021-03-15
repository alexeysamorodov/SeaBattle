using SeaBattle.Data;

namespace SeaBattle.Services
{
    public interface IGameLifetimeService
    {
        GameState GetGameState();

        void MoveNextState();

        void ClearGame();

        void FinishGame();
    }
}