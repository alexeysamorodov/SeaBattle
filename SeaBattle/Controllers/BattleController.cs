using Microsoft.AspNetCore.Mvc;
using SeaBattle.Data;

namespace SeaBattle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BattleController : ControllerBase
    {
        [Route("create-matrix")]
        [HttpPost]
        public void CreateMatrix()
        {

        }

        [Route("ship")]
        [HttpPost]
        public void CreateShip()
        {

        }

        [Route("shot")]
        [HttpPost]
        public void TakeShot()
        {

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