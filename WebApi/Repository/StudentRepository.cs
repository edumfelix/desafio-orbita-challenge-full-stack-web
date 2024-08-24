using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Controllers.Data.ValueObject;
using WebApi.Models;
using WebApi.Models.Context;

namespace WebApi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly PsqlContext _context;
        private IMapper _mapper;

        public StudentRepository(PsqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentVO>> FindAll()
        {
            List<Student> students = await _context.Students.ToListAsync();
            return _mapper.Map<List<StudentVO>>(students);
        }
        public async Task<StudentVO> FindById(long id)
        {
            Student? student = await _context.Students
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();

            return _mapper.Map<StudentVO>(student);
        }
        public async Task<StudentVO> Create(StudentVO vo)
        {
            Student student = _mapper.Map<Student>(vo);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return _mapper.Map<StudentVO>(student);
        }
        public async Task<StudentVO> Update(StudentVO vo)
        {
            Student student = _mapper.Map<Student>(vo);
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return _mapper.Map<StudentVO>(student);
        }
        public async Task<bool> Delete(long id)
        {
            try
            {
                Student? student = await _context.Students
                    .Where(s => s.Id == id)
                    .FirstOrDefaultAsync();

                if (student == null) return false;

                _context.Students.Remove(student);
                await _context.SaveChangesAsync(true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
