using MessageApp.DTOs;

namespace MessageApp.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDTO?>Login(LoginInfo info);
        Task<StudentDTO> Create(StudentDTO newStudent);
    }
}
