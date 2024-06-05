using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VisitorSecurityClearanceSystemAPI.Interfaces;
using VisitorSecurityClearanceSystemAPI_Week_05.DTO;
using VisitorSecurityClearanceSystemAPI_Week_05.Entities;

namespace VisitorSecurityClearanceSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeUserController : ControllerBase
    {
        private readonly IOfficeUserService _officeUserService;
        private readonly IMapper _mapper;

        public OfficeUserController(IOfficeUserService officeUserService, IMapper mapper)
        {
            _officeUserService = officeUserService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOfficeUser([FromBody] OfficeUserModel officeUserModel)
        {
            try
            {
                var officeUser = _mapper.Map<OfficeUser>(officeUserModel);
                var result = await _officeUserService.AddOfficeUserAsync(officeUser);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to create office user. " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOfficeUserById(string id)
        {
            try
            {
                var result = await _officeUserService.GetOfficeUserByIdAsync(id);
                if (result == null)
                {
                    return NotFound("Office user not found.");
                }

                var model = _mapper.Map<OfficeUserModel>(result);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to retrieve office user. " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOfficeUser(string id, [FromBody] OfficeUserModel officeUserModel)
        {
            try
            {
                var officeUser = _mapper.Map<OfficeUser>(officeUserModel);
                officeUser.UId = id;

                var result = await _officeUserService.UpdateOfficeUserAsync(officeUser);
                if (result)
                {
                    return Ok("Office user updated successfully.");
                }
                else
                {
                    return NotFound("Office user not found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to update office user. " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfficeUser(string id)
        {
            try
            {
                var result = await _officeUserService.DeleteOfficeUserAsync(id);
                if (result)
                {
                    return Ok("Office user deleted successfully.");
                }
                else
                {
                    return NotFound("Office user not found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to delete office user. " + ex.Message);
            }
        }
    }
}
