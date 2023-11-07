using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Model;

namespace API.Infrastructure
{
    public class CommentDbContext : DbContext
    {
        public CommentDbContext(DbContextOptions<CommentDbContext> options) : base(options) { }
        public DbSet<Comment> Comments { get; set; }
    }
}