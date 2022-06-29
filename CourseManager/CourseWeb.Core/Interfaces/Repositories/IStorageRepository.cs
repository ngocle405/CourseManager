using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Core.Interfaces.Repositories
{
    //lưu trữ ảnh
    public  interface IStorageRepository
    {
        string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String);
        string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData);
    }
}
