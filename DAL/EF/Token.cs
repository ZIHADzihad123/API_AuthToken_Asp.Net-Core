using System;
using System.Collections.Generic;

namespace DAL.EF
{
    public partial class Token
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AccessToken { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiredAt { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
