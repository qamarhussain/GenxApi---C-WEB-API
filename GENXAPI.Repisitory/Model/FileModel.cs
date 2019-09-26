using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory.Model
{
    public class FileModel
    {
        public bool  Status { get; set; }
        public Guid GuId { get; set; }
        public string FileUploadedName { get; set; }
        public string FileName { get; set; }
    }
}
