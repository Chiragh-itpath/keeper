using Keeper.Context.Model;
using Keeper.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService mailService;
        public MailController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost("Send")]
        public async Task<IActionResult> Send(MailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
