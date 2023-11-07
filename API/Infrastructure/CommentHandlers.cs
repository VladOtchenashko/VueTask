using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure
{
    public class CommentHandlers : IRequestHandler<GetCommentsQuery, List<Comment>>,
    IRequestHandler<AddCommentCommand, int>
    {
        private readonly CommentDbContext _context;

        public CommentHandlers(CommentDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Comments.OrderByDescending(x => x.Date).ToListAsync();
        }

        public async Task<int> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment
            {
                Author = request.Author,
                Text = request.Text,
                Date = DateTime.Now
            };

            _context.Comments.Add(comment);
            return await _context.SaveChangesAsync();
        }
    }
}