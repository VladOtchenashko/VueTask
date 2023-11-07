using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Model;
using MediatR;

namespace API.Infrastructure
{
    public class GetCommentsQuery : IRequest<List<Comment>>
    {
        
    }
}