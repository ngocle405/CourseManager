using System;
using System.Collections.Generic;

#nullable disable

namespace CourseWeb.Core.Entities
{
    public partial class New
    {
        public Guid NewId { get; set; }
        public string Title { get; set; }
        public Guid? NewCategoryId { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreateBy { get; set; }
        public string LastEditBy { get; set; }
        public int? Type { get; set; }
        public bool? Status { get; set; }
        public string UpdateBy { get; set; }

        public virtual NewCategory NewCategory { get; set; }
    }
}
