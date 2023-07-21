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
        public async Task<IEnumerable<ReturnConnection>> GetConnention(ReturnConnection objConn)
        {
            var connection = _dapperContext.CreateConnection();
            IEnumerable<ReturnConnection> result = null;
            result = await connection.QueryAsync<ReturnConnection>("usp_getCNGConnectionStatewise", new { });
            return result;
        }
        public async Task<IEnumerable<ReturnConnection>> GetConnentionByMonthYear(ReturnConnection objConn)
        {
            var connection = _dapperContext.CreateConnection();
            DynamicParameters objParm = new DynamicParameters();
            objParm.Add("@Month", objConn.Month);
            objParm.Add("@Year", objConn.Year);
            IEnumerable<ReturnConnection> result =await  connection.QueryAsync<ReturnConnection>("usp_getCNGConnectionStatewiseByMonthYear", objParm, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
