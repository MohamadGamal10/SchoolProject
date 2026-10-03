using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
        IRequestHandler<AddStudentCommand, Response<string>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            // Map the AddStudentCommand to the Student entity
            var student = _mapper.Map<Student>(request);
            // Call the AddAsync method of the IStudentService to add the student
            var result = await _studentService.AddAsync(student);
            // Check if the result is null or empty, indicating that the student was not added successfully
            if (result == "Exist")
            {
                return UnprocessableEntity<string>("Student name is exist");
            }
            else if (result == "Success")
            {
                return Created<string>("Student Added successfully");
            }
            else
            {
                return BadRequest<string>();
            }
        }
    }
}
