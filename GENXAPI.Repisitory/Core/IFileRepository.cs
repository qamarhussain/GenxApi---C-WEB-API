using GENXAPI.Repisitory.Model;
using System;
using System.Web;

namespace GENXAPI.Repisitory
{
    public interface IFileRepository:IRepository<File>
    {
        FileModel UploadJobFile(HttpFileCollection httpFiles);
        string GetFileUniqueName(string fileName, Guid guid);
    }
}
