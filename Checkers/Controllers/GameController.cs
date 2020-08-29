using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Checkers.BLL.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Checkers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _service;

        public GameController(IGameService service)
        {
            _service = service;

            var board = _service.CreateBoard();
            _service.RenderBoard(board);

            var figure = board.SingleOrDefault(x => x.Position.X == 0 && x.Position.Y == 2);
            figure.Move(new Point(1, 3));
            _service.RenderBoard(board);

            var figure1 = board.SingleOrDefault(x => x.Position.X == 2 && x.Position.Y == 2);
            figure1.Move(new Point(1, 3));
            _service.RenderBoard(board);
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
