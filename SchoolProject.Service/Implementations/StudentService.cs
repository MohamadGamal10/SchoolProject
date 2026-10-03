using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentRepository.GetStudentsListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            //return await _studentRepository.GetByIdAsync(id);
            var student = await _studentRepository.GetTableNoTracking()
                .Include(x => x.Department)
                .Where(s => s.StudID == id)
                .FirstOrDefaultAsync();
            return student;
        }

        public async Task<string> AddAsync(Student student)
        {
            // check if the is exist or not
            var studentExist = _studentRepository.GetTableNoTracking()
                .Where(x => x.Name.Equals(student.Name))
                .FirstOrDefault();

            if (studentExist != null)
            {
                return "Exist";
            }

            // added student
            await _studentRepository.AddAsync(student);
            return "Success";
        }
    }
}
