using System;
using System.Collections.Generic;

namespace DAL.EF
{
    public partial class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
