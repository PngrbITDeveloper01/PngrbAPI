using AspCoreDapperAPI.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreDapperAPI.Controllers
{
    [Route("api/Branch")]
    [ApiController, Authorize]
    public class BranchController : ControllerBase
    {
        private readonly IBranchRepository _branchRepository;

        public BranchController(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetBranches()
        {
            var branches = await _branchRepository.GetAllBranches();
            return Ok(branches);
        }
    }
}
