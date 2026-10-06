using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    //[Route("[controller]")]
    [ApiController]
    public class StudentsController : AppControllerBase
    {


        [HttpGet(Router.StudentRouting.getAll)]
        public async Task<IActionResult> GetStudentsList()
        {
            var query = new GetStudentListQuery();
            var response = await Mediator.Send(query);
            return NewResult(response);
        }

        [HttpGet(Router.StudentRouting.getById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var query = new GetStudentByIdQuery(id);
            var response = await Mediator.Send(query);
            return NewResult(response);
        }

        [HttpPost(Router.StudentRouting.create)]
        public async Task<IActionResult> create([FromBody] AddStudentCommand command)
        {
            //var query = new AddStudentCommand(addStudentCommand);
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

    }
}
