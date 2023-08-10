using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrimeTechApp.Data;
using PrimeTechApp.Interfaces;
using PrimeTechApp.Models;
using PrimeTechApp.Repositories.Base;

namespace PrimeTechApp.Repositories
{
    public class CompanyRepository:BaseRepository<Company>, ICompany
    {
        private readonly AppDbContext _appDbContext;

        public CompanyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            try
            {
                return await _appDbContext.Company.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<bool> FindByCIDAsync(int cid)
        {
            return !await _appDbContext.Company.AnyAsync(d => d.CID.Equals(cid));
        }

        public async Task<bool> Create(Company company)
        {
            try
            {
                await _appDbContext.Set<Company>().AddAsync(company);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Company> FindByIdAsync(int id)
        {
            return await _appDbContext.Company
                .Where(d => d.ID.Equals(id))
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Update(Company company)
        {
            try
            {
                var result = _appDbContext.Set<Company>().Update(company);
                result.State = EntityState.Modified;
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<bool> Delete(Company company)
        {
            try
            {
                _appDbContext.Set<Company>().Remove(company);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task AddField(Company newCom)
        {
            try
            {
                _appDbContext.Company.Add(newCom);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}