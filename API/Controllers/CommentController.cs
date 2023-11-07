using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Infrastructure;
using API.Model;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [EnableCors]
        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetComments()
        {
            var comments = await _mediator.Send(new GetCommentsQuery());
            return Ok(comments);
        }

        [EnableCors]
        [HttpPost]
        public async Task<ActionResult<int>> AddComment([FromBody] AddCommentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}