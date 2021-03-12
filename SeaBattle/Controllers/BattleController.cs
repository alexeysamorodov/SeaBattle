using Microsoft.AspNetCore.Mvc;
using SeaBattle.Models;

namespace SeaBattle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BattleController : ControllerBase
    {
        [Route("create-matrix")]
        [HttpPost]
        public void CreateMatrix(MatrixModel matrixModel)
        {
        }

        [Route("ship")]
        [HttpPost]
        public void CreateShip(ShipModel shipModel)
        {
        }

        [Route("shot")]
        [HttpPost]
        public ShotResult TakeShot(ShotModel shotModel)
        {
            return new ShotResult();
        }

        [Route("clear")]
        [HttpPost]
        public void ClearBattle()
        {

        }

        [Route("state")]
        [HttpGet]
        public BattleStatistics GetStatistics()
        {
            return new BattleStatistics();
        }
    }
}