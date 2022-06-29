﻿using CourseWeb.Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Core.Interfaces.Services
{
    public interface ICourseService
    {
       object GetAll();
        object GetById(Guid CourseId);
        object Create(CourseRequest request);
        int Update(Guid CourseId, CourseRequest request);
        int Delete(Guid CourseId);
        int DeleteList(Guid CourseId);
        int ExportExcel();
        object Paging(string searchName, string searchCode,int pageSize, int pageIndex, bool? status, Guid? courseCategoryId,Guid? teacherId);
    }
}
