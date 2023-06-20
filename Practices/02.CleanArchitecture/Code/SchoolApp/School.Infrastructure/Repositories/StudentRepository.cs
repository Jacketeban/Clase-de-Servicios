using School.Infrastructure.Common;
using School.Infrastructure.Context;
using School.Domain.Entities;
using School.Domain.Interfaces.Repositories;

namespace School.Infrastructure.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
