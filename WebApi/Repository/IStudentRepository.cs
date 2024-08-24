using WebApi.Controllers.Data.ValueObject;

namespace WebApi.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentVO>> FindAll();
        Task<StudentVO> FindById(long id);
        Task<StudentVO> Create(StudentVO vo);
        Task<StudentVO> Update(StudentVO vo);
        Task<bool> Delete(long id);
    }
}
