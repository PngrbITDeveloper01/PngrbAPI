using AspCoreDapperAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreDapperAPI.Contracts
{
    public interface IBranchRepository
    {
        public Task<IEnumerable<Branch>> GetAllBranches();
        public Task<IEnumerable<ReturnConnection>> GetConnention(ReturnConnection obj);
        public Task<IEnumerable<ReturnConnection>> GetConnentionByMonthYear(ReturnConnection obj);
    }
}
