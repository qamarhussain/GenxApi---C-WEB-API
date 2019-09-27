using GENXAPI.Api.Helper;
using GENXAPI.Repisitory;
using GENXAPI.Repisitory.Model;
using System;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace GENXAPI.Api.Controllers
{
    [RoutePrefix("api/file")]
    public class FileController : ApiController
    {
        IUnitOfWork _unitOfWork;
        public FileController()
        {
            _unitOfWork = new UnitOfWork();
        }
        [HttpPost]
        [Route("upload")]
        public HttpResponseMessage Upload()
        {
            var model = new File();
            var httpRequest = HttpContext.Current.Request;
            var contractId = httpRequest.Form["FileContractId"];
            var jobId = httpRequest.Form["FileJobId"];
            var customerId = httpRequest.Form["FileCustomerId"];
            if (httpRequest.Files.Count <= 0) return WebHelper.SendResponse(new { sucess = true, fileInfo = (File)null });
            var response = _unitOfWork.File.UploadJobFile(httpRequest.Files);
                if (response.Status)
                {
                    
                    model.FileGuId = response.GuId;
                    model.FileName = response.FileName;
                    model.FileUploadedName = response.FileUploadedName;
                    model.FileCreateDate = DateTime.Now;
                    model.FileCustomerId = Convert.ToInt32(customerId);
                    model.FileJobId = Convert.ToInt32(jobId);
                    model.FileContractId = Convert.ToInt32(contractId);

                    _unitOfWork.File.Add(model);
                }

            

           _unitOfWork.SaveChanges();
            return WebHelper.SendResponse("");
            

        }
    }
}
