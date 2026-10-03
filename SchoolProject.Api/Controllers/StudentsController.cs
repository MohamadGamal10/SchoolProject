using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    //[Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Router.StudentRouting.getAll)]
        public async Task<IActionResult> GetStudentsList()
        {
            var query = new GetStudentListQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet(Router.StudentRouting.getById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var query = new GetStudentByIdQuery(id);
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet(Router.StudentRouting.create)]
        public async Task<IActionResult> create([FromBody] AddStudentCommand command)
        {
            //var query = new AddStudentCommand(addStudentCommand);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
