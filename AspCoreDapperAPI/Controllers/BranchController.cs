using AspCoreDapperAPI.Contracts;
using AspCoreDapperAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AspCoreDapperAPI.Controllers
{
   
    [ApiController, Authorize]
    public class BranchController : ControllerBase
    {
        private readonly IBranchRepository _branchRepository;

        public BranchController(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }
        [HttpGet]
        [Route("api/Branch")]
        public async Task<IActionResult> GetBranches()
        {
            var branches = await _branchRepository.GetAllBranches();
            return Ok(branches);
        }
        [HttpGet]
        [Route("api/GetConnention")]
        public async Task<IActionResult> GetConnention()
        {
            ReturnConnection obj = new ReturnConnection();
            CNGConnection cngConnection= new CNGConnection();
            List<States> listState = new List<States>();
            List<Connection> listConnection = new List<Connection>();
            obj.Month = "0";
            obj.Year = "0";
            var connections = await _branchRepository.GetConnention(obj);
            //  var json = JsonSerializer.Serialize(connections);
            string strState = "";
            foreach (var conn in connections)
            {
                Connection connection = new Connection();
                States states = new States();
               
                states.State = conn.State;
                connection.Domestic = conn.Domestic;
                connection.CumDomestic = conn.CumDomestic;
                connection.Commercial = conn.Commercial;
                connection.CumCommercial = conn.CumCommercial;
                connection.Industrial = conn.Industrial;
                connection.CumIndustrial = conn.CumIndustrial;
                connection.Month = conn.Month;
                connection.Year = conn.Year;

                if (conn.State != strState && strState!="")
                {
                    states.Connections = listConnection;
                    listState.Add(states);
                    listConnection = new List<Connection>();
                }

                listConnection.Add(connection);               
                strState = conn.State;
            }
           
            return Ok(listState);
        }
        [HttpGet]
        [Route("api/GetConnentionByMonthYear")]
        public async Task<IActionResult> GetConnentionByMonthYear([FromBody]  ReturnConnection obj)
        {
            CNGConnection cngConnection = new CNGConnection();
            List<States> listState = new List<States>();
            List<Connection> listConnection = new List<Connection>();
            var connections = await _branchRepository.GetConnentionByMonthYear(obj);
            //  var json = JsonSerializer.Serialize(connections);
            string strState = "";
            foreach (var conn in connections)
            {
                Connection connection = new Connection();
                States states = new States();

                states.State = conn.State;
                connection.Domestic = conn.Domestic;
                connection.CumDomestic = conn.CumDomestic;
                connection.Commercial = conn.Commercial;
                connection.CumCommercial = conn.CumCommercial;
                connection.Industrial = conn.Industrial;
                connection.CumIndustrial = conn.CumIndustrial;
                connection.Month = conn.Month;
                connection.Year = conn.Year;

                if (conn.State != strState && strState != "")
                {
                    states.Connections = listConnection;
                    listState.Add(states);
                    listConnection = new List<Connection>();
                }

                listConnection.Add(connection);
                strState = conn.State;
            }

            return Ok(listState);
        }
    }
}
