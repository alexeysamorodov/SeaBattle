using SeaBattle.Data;

namespace SeaBattle.Services
{
    public interface IGameLifetimeService
    {
        GameState GetGameState();

        bool CheckRequiredStateWithGameState(GameState requiredState);

        void MoveNextState();

        void ClearGame();

        void FinishGame();
    }
}