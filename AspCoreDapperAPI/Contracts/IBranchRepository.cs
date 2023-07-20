using AspCoreDapperAPI.Entities;

namespace AspCoreDapperAPI.Contracts
{
    public interface IBranchRepository
    {
        public Task<IEnumerable<Branch>> GetAllBranches();
    }
}
