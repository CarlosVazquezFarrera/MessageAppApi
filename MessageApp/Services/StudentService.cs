using AutoMapper;
using MessageApp.Data;
using MessageApp.DTOs;
using MessageApp.Enetities;
using MessageApp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MessageApp.Services
{
    public class StudentService : IStudentService
    {
        public StudentService(MessagesAppContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        private readonly MessagesAppContext _context;
        private readonly IMapper _mapper;
        public async Task<StudentDTO?> Login(LoginInfo info)
        {
            var student = await _context
                .Students
                .Where(s => s.Clave == info.Clave)
                .FirstOrDefaultAsync();
            if (student == null) return null;
            
            return _mapper.Map<StudentDTO>(student);
        }

        public async Task<StudentDTO> Create(StudentDTO student)
        {
            Student newStudent = _mapper.Map<Student>(student);
            await _context.Students.AddAsync(newStudent);
            await _context.SaveChangesAsync();
            return _mapper.Map<StudentDTO>(newStudent);
        }
    }
}
