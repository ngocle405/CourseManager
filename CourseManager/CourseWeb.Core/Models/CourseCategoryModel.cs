﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Core.Models
{
    public class CourseCategoryModel
    {
        public Guid CourseCategoryId { get; set; }
        public string CourseCategoryCode { get; set; }
        public string CourseCategoryName { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
