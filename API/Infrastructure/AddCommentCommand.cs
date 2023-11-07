using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace API.Infrastructure
{
    public class AddCommentCommand : IRequest<int>

    {
        public string Author { get; set; }
        public string Text { get; set; }
    }
}