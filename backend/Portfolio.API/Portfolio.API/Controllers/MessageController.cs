using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.DTO;
using Portfolio.Service.DTO.Message;
using Portfolio.Service.Interfaces;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _msgServ;

        public MessageController(IMessageService msgServ)
        {
            _msgServ = msgServ;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<ActionResult<MessageDTO>> GetAll()
        {
            var messages = await _msgServ.GetAllAsync();
            return Ok(messages);
        }
        [HttpPost("Send")]
        public async Task<ActionResult<MessageDTO>> Send(CreateMessageDTO model)
        {
            if (!ModelState.IsValid) return BadRequest(new AuthResponseDTO
            {
                Status = false,
                Message = "Invalid request data"
            });

            var msg = await _msgServ.CreateAsync(model);
            if (msg == null)
            {
                return BadRequest(new AuthResponseDTO
                {
                    Status = false,
                    Message = "Failed to send message"
                });
            }

            return Ok(msg);
        }
    }
}
