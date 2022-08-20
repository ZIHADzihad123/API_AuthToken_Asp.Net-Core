using System;
using System.Collections.Generic;

namespace DAL.EF
{
    public partial class User
    {
        public User()
        {
            Blogs = new HashSet<Blog>();
            Tokens = new HashSet<Token>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Type { get; set; } = null!;

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Token> Tokens { get; set; }
    }
}
