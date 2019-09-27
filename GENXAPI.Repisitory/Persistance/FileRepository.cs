using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GENXAPI.Repisitory
{
    public class FileRepository : Repository<Model.File>, IFileRepository
    {
        public Entities context
        {
            get
            {
                return db as Entities;
            }
        }

        public FileRepository(Entities _db)
            : base(_db)
        {

        }
        public string GetFileUniqueName(string fileName, Guid guid)
        {
            if (string.IsNullOrEmpty(fileName)) return $"{guid}.jpg";
            //No need to use the file name
            string extension = new FileInfo(fileName).Extension;
            return string.Format("{0}{1}", guid, extension);
        }

        //public FileModel UploadJobFile(HttpPostedFile httpFiles)
        //{
        //    var mediaFolder = @"~/media";
        //    FileModel fm = new FileModel();
        //    try
        //    {
        //        var guid = Guid.NewGuid();
        //        var fileUniqueName = GetFileUniqueName(httpFiles.FileName, guid);

        //        var index = httpFiles.FileName.LastIndexOf('.');
        //        var filename = httpFiles.FileName.Substring(0, index);
        //        var completeFileName = filename + "-" + fileUniqueName;

        //        var mediaPath = Path.Combine(HttpContext.Current.Server.MapPath(mediaFolder));

        //        var path = Path.Combine(mediaPath, completeFileName);
        //        Directory.CreateDirectory(mediaPath);
        //        httpFiles.SaveAs(path);

        //        fm.Status = true;
        //        fm.GuId = guid;
        //        fm.FileUploadedName = completeFileName;
        //        fm.FileName = filename;
        //        return fm;
        //    }
        //    catch (Exception)
        //    {
        //        fm.Status = false;
        //        return fm;
        //    }
        //}


        public FileModel UploadJobFile(HttpFileCollection httpFiles)
        {
           var mediaFolder = @"~/media";
            FileModel fm = new FileModel();
            try
            {
                foreach (string file in httpFiles)
                {
                    var postedFile = httpFiles[file];
                    if (postedFile == null) continue;
                    var guid = Guid.NewGuid();
                    var fileUniqueName = GetFileUniqueName(postedFile.FileName, guid);

                    var index = postedFile.FileName.LastIndexOf('.');
                    var filename = postedFile.FileName.Substring(0, index);
                    var completeFileName = filename + "-" + fileUniqueName;

                    var mediaPath = Path.Combine(HttpContext.Current.Server.MapPath(mediaFolder));

                    var path = Path.Combine(mediaPath, completeFileName);
                    Directory.CreateDirectory(mediaPath);

                    postedFile.SaveAs(path);

                    fm.Status = true;
                    fm.GuId = guid;
                    fm.FileUploadedName = completeFileName;
                    fm.FileName = filename;
                    
                }
                return fm;
            }
            catch (Exception)
            {
                fm.Status = false;
                return fm;
            }
        }
    }

    
    }

