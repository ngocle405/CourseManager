using System;
using System.Collections.Generic;

#nullable disable

namespace CourseWeb.Core.Entities
{
    public partial class Admin
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool? View { get; set; }
        public bool? Update { get; set; }
        public bool? Remove { get; set; }

        public bool? Create { get; set; }
    }
}
