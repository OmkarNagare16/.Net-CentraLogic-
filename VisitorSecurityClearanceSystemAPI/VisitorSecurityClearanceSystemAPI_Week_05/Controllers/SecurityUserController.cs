using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VisitorSecurityClearanceSystemAPI.Interfaces;
using VisitorSecurityClearanceSystemAPI_Week_05.DTO;
using VisitorSecurityClearanceSystemAPI_Week_05.Entities;
using VisitorSecurityClearanceSystemAPI_Week_05.Interfaces;

namespace VisitorSecurityClearanceSystemAPI_Week_05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityUserController : ControllerBase
    {
        private readonly ISecurityUserService _securityUserService;
        private readonly IMapper _mapper;

        public SecurityUserController(ISecurityUserService securityUserService, IMapper mapper)
        {
            _securityUserService = securityUserService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSecurityUser([FromBody] SecurityUserModel securityUserModel)
        {
            var securityUser = _mapper.Map<SecurityUser>(securityUserModel);
            var result = await _securityUserService.AddSecurityUserAsync(securityUser);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSecurityUserById(string id)
        {
            var result = await _securityUserService.GetSecurityUserByIdAsync(id);
            if (result == null)
            {
                return NotFound("Security user not found.");
            }

            var model = _mapper.Map<SecurityUserModel>(result);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSecurityUser(string id, [FromBody] SecurityUserModel securityUserModel)
        {
            var securityUser = _mapper.Map<SecurityUser>(securityUserModel);
            securityUser.UId = id;

            var result = await _securityUserService.UpdateSecurityUserAsync(securityUser);
            if (result)
            {
                return Ok("Security user updated successfully.");
            }
            else
            {
                return NotFound("Security user not found.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSecurityUser(string id)
        {
            var result = await _securityUserService.DeleteSecurityUserAsync(id);
            if (result)
            {
                return Ok("Security user deleted successfully.");
            }
            else
            {
                return NotFound("Security user not found.");
            }
        }
    }
}
