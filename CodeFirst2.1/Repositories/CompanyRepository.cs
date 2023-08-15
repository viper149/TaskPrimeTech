using CodeFirst.Data;
using CodeFirst.Interfaces;
using CodeFirst.Models;
using CodeFirst.Repositories.Base;

namespace CodeFirst.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompany
    {
        public CompanyRepository(MyDbContext myDbContext) : base(myDbContext)
        {
        }
    }
}