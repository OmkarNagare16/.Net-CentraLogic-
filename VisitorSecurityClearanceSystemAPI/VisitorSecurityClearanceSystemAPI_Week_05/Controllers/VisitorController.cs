using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using VisitorSecurityClearanceSystemAPI.DTO;
using VisitorSecurityClearanceSystemAPI.Entities;
using VisitorSecurityClearanceSystemAPI.Interfaces;
using VisitorSecurityClearanceSystemAPI_Week_05.Entities;
using VisitorSecurityClearanceSystemAPI_Week_05.Interfaces;

namespace VisitorSecurityClearanceSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly IVisitorService _visitorService;
        private readonly IMapper _mapper;

        public VisitorController(IVisitorService visitorService, IMapper mapper)
        {
            _visitorService = visitorService;
            _mapper = mapper;
        }

        [HttpPost("VisitRequest")]
        public async Task<IActionResult> VisitRequest([FromBody] VisitorModel visitorModel)
        {
            var visitor = _mapper.Map<Visitor>(visitorModel);
            var response = await _visitorService.AddVisitor(visitor);
            var model = _mapper.Map<VisitorModel>(response);
            SendMail(response.EmailId, "Visit Request Acknowledgment", GenerateAcknowledgmentEmail(response));
            return Ok($"Request Sent Successfully !!!\n Your VisitorId is {model.VisitorId}");
        }

        [HttpGet("CheckRequestStatus/{VisitorId}")]
        public async Task<IActionResult> CheckRequestStatus(string VisitorId)
        {
            var visitor = await _visitorService.GetVisitorByVisitorId(VisitorId);
            if (visitor == null)
                return NotFound("No Request Found !!!");

            var model = _mapper.Map<RequestModel>(visitor);
            return Ok(model);
        }

        [HttpPut("UpdateVisitor/{VisitorId}")]
        public async Task<IActionResult> UpdateVisitor(string VisitorId, [FromBody] VisitorModel visitorModel)
        {
            var existingVisitor = await _visitorService.GetVisitorByVisitorId(VisitorId);
            if (existingVisitor == null)
                return NotFound("Visitor not found.");

            var visitor = _mapper.Map<Visitor>(visitorModel);
            visitor.VisitorId = VisitorId;

            var result = await _visitorService.UpdateVisitorAsync(visitor);
            return result ? Ok("Visitor updated successfully.") : BadRequest("Failed to update visitor.");
        }

        [HttpDelete("DeleteVisitor/{VisitorId}")]
        public async Task<IActionResult> DeleteVisitor(string VisitorId)
        {
            var existingVisitor = await _visitorService.GetVisitorByVisitorId(VisitorId);
            if (existingVisitor == null)
                return NotFound("Visitor not found.");

            var result = await _visitorService.DeleteVisitorAsync(VisitorId);
            return result ? Ok("Visitor deleted successfully.") : BadRequest("Failed to delete visitor.");
        }

        private void SendMail(string mail, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("nisarga.v.jamdhare@gmail.com", "kbaxwnlysvijdppt"),
                EnableSsl = true,
            };
            smtpClient.Send("nisarga.v.jamdhare@gmail.com", mail, subject, body);
        }

        private string GenerateAcknowledgmentEmail(Visitor visitor)
        {
            return $@"
Hello {visitor.Name},
       Thank you for submitting your visit pass request to CentraLogic. Your Visitor ID is {visitor.VisitorId}. Kindly keep this ID for future reference.

We acknowledge receipt of your request and want to assure you that our team is in the process of reviewing and taking necessary actions. You can use the provided Visitor ID to check the status of your request.

If you have any immediate concerns or require further information, please feel free to contact our dedicated manager at manager@gmail.com . We appreciate your patience and look forward to welcoming you soon.

Best regards,

Nisarga Jamdhare
Manager
Centralogic    
";
        }
    }
}
