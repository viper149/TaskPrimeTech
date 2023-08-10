using System.Collections.Generic;
using System.Threading.Tasks;
using PrimeTechApp.Interfaces.Base;
using PrimeTechApp.Models;

namespace PrimeTechApp.Interfaces
{
    public interface ICompany: IBaseService<Company>
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
        Task<bool> FindByCIDAsync(int cid);
        Task<bool> Create(Company company);
        Task<Company> FindByIdAsync(int id);
        Task<bool> Update(Company company);
        Task<bool> Delete(Company company);
        Task AddField(Company newCom);
    }
}
