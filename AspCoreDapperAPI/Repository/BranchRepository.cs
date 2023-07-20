using AspCoreDapperAPI.Context;
using AspCoreDapperAPI.Contracts;
using AspCoreDapperAPI.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AspCoreDapperAPI.Repository
{
    public class BranchRepository : IBranchRepository
    {
        private readonly DapperContext _dapperContext;

        public BranchRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<Branch>> GetAllBranches()
        {
            var connection = _dapperContext.CreateConnection();
            IEnumerable<Branch> result = await connection.QueryAsync<Branch>("sp_get_branchs", new { });
            return result;
        }
    }
}
