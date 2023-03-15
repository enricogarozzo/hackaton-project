using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DefaultNamespace;

    public class UserAnswerContext : DbContext
    {
        public UserAnswerContext (DbContextOptions<UserAnswerContext> options)
            : base(options)
        {
        }

        public DbSet<DefaultNamespace.UserAnswer> UserAnswers { get; set; } = default!;
        public DbSet<DefaultNamespace.User> Users { get; set; } = default!;
        
        public DbSet<DefaultNamespace.Game> Games { get; set; } = default!;
    }