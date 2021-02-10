using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TODO_API.Domain.Commands;
using TODO_API.Domain.Data;
using TODO_API.Domain.Entities;
using TODO_API.Domain.Handlers;
using TODO_API.Domain.Repositories.Interfaces;



namespace TODO_API.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    [Authorize]
    public class TodoController : ControllerBase
    {
        [HttpPost]
        [Route("")]

        public ActionResult<GenericCommandResult> Post([FromServices] TodoHandler handler, [FromBody] CreateTodoCommand command)
        {
            try
            {
                command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
                return Ok((GenericCommandResult)handler.Handle(command));

            }
            catch (System.Exception)
            {
                return BadRequest(new { message = "Não foi possível cadastrar tarefa" });
            }
        }


        [HttpPut]
        [Route("")]
        public ActionResult<GenericCommandResult> Update([FromBody] UpdateTodoCommand command, [FromServices] TodoHandler handler)
        {
            try
            {
                command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
                return Ok((GenericCommandResult)handler.Handle(command));

            }
            catch (System.Exception)
            {
                return BadRequest(new { message = "Não foi possível cadastrar tarefa" });
            }
        }

        [HttpPut]
        [Route("mark-as-done")]
        public ActionResult<GenericCommandResult> MarkAsDone([FromBody] MarkTodoAsDoneCommand command, [FromServices] TodoHandler handler)
        {
            try
            {
                command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
                return Ok((GenericCommandResult)handler.Handle(command));

            }
            catch (System.Exception)
            {
                return BadRequest(new { message = "Não foi possível cadastrar tarefa" });
            }
        }

        [HttpPut]
        [Route("mark-as-undone")]
        public ActionResult<GenericCommandResult> MarkAsUndone([FromBody] MarkTodoAsUndoneCommand command, [FromServices] TodoHandler handler)
        {
            try
            {
                command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
                return Ok((GenericCommandResult)handler.Handle(command));

            }
            catch (System.Exception)
            {
                return BadRequest(new { message = "Não foi possível cadastrar tarefa" });
            }
        }

        [HttpGet]
        [Route("")]
        public ActionResult<IList<Todo>> GetALl([FromServices] ITodoRepository repository)
        {
            try
            {
                var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

                return Ok(repository.GetAll(user));

            }
            catch (System.Exception)
            {
                return BadRequest(new { message = "Não foi possível obter tarefas" });
            }

        }

        [HttpGet]
        [Route("done")]
        public ActionResult<IList<Todo>> GetAllDone([FromServices] ITodoRepository repository)
        {
            try
            {
                var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

                return Ok(repository.GetAllDone(user));

            }
            catch (System.Exception)
            {
                return BadRequest(new { message = "Não foi possível obter tarefas" });
            }

        }

        [HttpGet]
        [Route("done/today")]
        public ActionResult<IList<Todo>> GetAllDoneToday([FromServices] ITodoRepository repository)
        {
            try
            {
                var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

                return Ok(repository.GetByPeriod(user, DateTime.Now.Date, true));

            }
            catch (System.Exception)
            {
                return BadRequest(new { message = "Não foi possível obter tarefas" });
            }

        }

        [HttpGet]
        [Route("done/tomorrow")]
        public ActionResult<IList<Todo>> GetAllDoneTomorrow([FromServices] ITodoRepository repository)
        {
            try
            {
                var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

                return Ok(repository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), true));

            }
            catch (System.Exception)
            {
                return BadRequest(new { message = "Não foi possível obter tarefas" });
            }
        }

        [HttpGet]
        [Route("done/{quantity:int}")]
        public ActionResult<IList<Todo>> GetAllDoneForQuantityDay([FromServices] ITodoRepository repository, int quantity)
        {
            try
            {
                var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

                return Ok(repository.GetByPeriod(user, DateTime.Now.Date.AddDays(quantity), true));

            }
            catch (System.Exception)
            {
                return BadRequest(new { message = "Não foi possível obter tarefas" });
            }
        }

        [HttpGet]
        [Route("undone")]
        public ActionResult<IList<Todo>> GetAllUnDone([FromServices] ITodoRepository repository)
        {
            try
            {
                var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

                return Ok(repository.GetAllUndone(user));

            }
            catch (System.Exception)
            {
                return BadRequest(new { message = "Não foi possível obter tarefas" });
            }
        }

        [HttpGet]
        [Route("undone/today")]
        public ActionResult<IList<Todo>> GetAllUnDoneToday([FromServices] ITodoRepository repository)
        {
            try
            {
                var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

                return Ok(repository.GetByPeriod(user, DateTime.Now.Date, false));

            }
            catch (System.Exception)
            {
                return BadRequest(new { message = "Não foi possível obter tarefas" });
            }
        }

        [HttpGet]
        [Route("undone/tomorrow")]
        public ActionResult<IList<Todo>> GetAllUnDoneTomorrow([FromServices] ITodoRepository repository)
        {
            try
            {
                var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

                return Ok(repository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), false));

            }
            catch (System.Exception)
            {
                return BadRequest(new { message = "Não foi possível obter tarefas" });
            }

        }

        [HttpGet]
        [Route("undone/{quantity:int}")]
        public ActionResult<IList<Todo>> GetAllUnDoneForQuantityDay([FromServices] ITodoRepository repository, int quantity)
        {
            try
            {
                var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

                return Ok(repository.GetByPeriod(user, DateTime.Now.Date.AddDays(quantity), false));

            }
            catch (System.Exception)
            {
                return BadRequest(new { message = "Não foi possível obter tarefas" });
            }
        }

    }
}