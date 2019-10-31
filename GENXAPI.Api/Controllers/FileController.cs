using GENXAPI.Api.Helper;
using GENXAPI.Repisitory;
using GENXAPI.Repisitory.Model;
using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

namespace GENXAPI.Api.Controllers
{
    [RoutePrefix("api/file")]
    public class FileController : ApiController
    {
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Entities"].ConnectionString);
        OleDbConnection Econ;
        IUnitOfWork _unitOfWork;
        public FileController()
        {
            _unitOfWork = new UnitOfWork();
        }
        [HttpPost]
        [Route("upload")]
        public HttpResponseMessage Upload()
        {
            var model = new Repisitory.Model.File();
            var httpRequest = HttpContext.Current.Request;
            var contractId = httpRequest.Form["FileContractId"];
            var jobId = httpRequest.Form["FileJobId"];
            var customerId = httpRequest.Form["FileCustomerId"];
            if (httpRequest.Files.Count <= 0) return WebHelper.SendResponse(new { sucess = true, fileInfo = (Repisitory.Model.File)null });
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

        [HttpGet]
       // [Route("GetById/{fileJobId}")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var file = _unitOfWork.File.Find(a =>a.FileJobId == id).ToList();
                foreach (var item in file)
                {
                    string path = "D:\\GenxApp Project\\GenxApi\\GENXAPI.Api\\media\\" + item.FileUploadedName;
                    item.FileUploadedName = path; 

                }
                //var file = _unitOfWork.File.Get(fileJobId);

                if (file == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(file);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [HttpPost]
        public IHttpActionResult UploadVendor()
        {
            var httpRequest = HttpContext.Current.Request;
            var contractId = httpRequest.Form["ContractId"];
            var customerId = httpRequest.Form["CustomerId"];
            BasicResponse br = new BasicResponse();
            try
            {
                if (httpRequest.ContentLength > 0)
                {
                    string extension = System.IO.Path.GetExtension(httpRequest.Files["file"].FileName).ToLower();
                    string query = null;
                    string connString = "";
                    string[] validFileTypes = { ".xls", ".xlsx", ".csv" };
                    var excelFolder = @"~/ExcelFolder/Uploads";
                    string path1 = string.Format("{0}/{1}", HttpContext.Current.Server.MapPath(excelFolder), HttpContext.Current.Request.Files["file"].FileName);
                    if (!Directory.Exists(path1))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(excelFolder));
                    }
                    if (validFileTypes.Contains(extension))
                    {

                        if (System.IO.File.Exists(path1))
                        { System.IO.File.Delete(path1); }
                        HttpContext.Current.Request.Files["file"].SaveAs(path1);
                        if (extension == ".csv")
                        {
                            DataTable dt = ConvertCSVtoDataTable(path1);
                            return Ok(dt);
                        }
                        //Connection String to Excel Workbook  
                        else if (extension.Trim() == ".xls")
                        {
                            connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path1 + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                            DataTable dt = ConvertXSLXtoDataTable(path1, connString);
                            return Ok(dt);
                        }
                        else if (extension.Trim() == ".xlsx")
                        {
                            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                            DataTable dt = ConvertXSLXtoDataTable(path1, connString);
                            // List<temp> obj = new List<temp>();
                            var list = ConvertDataTable<temp>(dt);
                            if (list != null)
                            {
                                try
                                {
                                    foreach (var item in list)
                                    {
                                        if (contractId == item.TenderId.ToString() && customerId == item.CustomerId.ToString())
                                        {
                                            return Ok(list);
                                        }
                                        else
                                        {
                                            return Ok("File does not match witht this detail");
                                        }

                                    }
                                }
                                catch (Exception)
                                {
                                    
                                }

                            }
                            //return Ok(list);
                        }

                    }
                    else
                    {
                        return Ok("Please Upload Files in .xls, .xlsx or .csv format");

                    }

                }
            }
            catch (Exception ex)
            {

               
                br.error = ex.Message;
                return Ok(br);
            }

            return Ok(br);
            // return null;
        }

        public static DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(strFilePath))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }

                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    if (rows.Length > 1)
                    {
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i].Trim();
                        }
                        dt.Rows.Add(dr);
                    }
                }

            }


            return dt;
        }

        public static DataTable ConvertXSLXtoDataTable(string strFilePath, string connString)
        {
            OleDbConnection oledbConn = new OleDbConnection(connString);
            DataTable dt = new DataTable();
            try
            {

                oledbConn.Open();
                using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM [data$]", oledbConn))
                {
                    OleDbDataAdapter oleda = new OleDbDataAdapter();
                    oleda.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    oleda.Fill(ds);

                    dt = ds.Tables[0];
                }
            }
            catch(Exception ex)
            {
            }
            finally
            {

                oledbConn.Close();
            }

            return dt;
    
        }

        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
    public class temp
    {
        public double SrNo { get; set; }
        public string ServiceName { get; set; }
        public string  ServiceType { get; set; }
        public string Unit { get; set; }
        public double TenderId { get; set; }
        public double CustomerId { get; set; }
        public double Amount{ get; set; }
        public double FleetServiceId { get; set; }
        public string DestinationFrom { get; set; }
        public string DestinationTo { get; set; }
        public string VehicleName { get; set; }
        public double DestinationToId { get; set; }
        public double DestinationFromId { get; set; }
        public double VehicleId { get; set; }
        public double DetailId { get; set; }
    }

    public class BasicResponse
    {
        public string error { get; set; }
    }
   
}
