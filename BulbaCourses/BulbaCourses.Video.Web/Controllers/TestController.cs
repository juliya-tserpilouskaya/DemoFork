//using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
   
    public class FileUploadController : ApiController
    {
       // db_videoEntities1 wmsEN = new db_videoEntities1();
        [HttpPost()]
        public HttpResponseMessage UploadFiles()
        {
            var httpRequest = HttpContext.Current.Request;
            //Upload Image    
            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
            try
            {
                for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
                {
                    System.Web.HttpPostedFile hpf = hfc[iCnt];
                    if (hpf.ContentLength > 0)
                    {
                        //var filename = (Path.GetFileName(hpf.FileName));
                        //var filePath = HttpContext.Current.Server.MapPath("~/Vedios/" + filename);
                        //hpf.SaveAs(filePath);
                        //VideoMaster obj = new VideoMaster();
                        //obj.Videos = "http://localhost:50401/Vedios/" + filename;
                        //wmsEN.VideoMasters.Add(obj);
                        //wmsEN.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            { }
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPost]
        public object Vedios()
        {
            return null;//wmsEN.VideoMasters;
        }
    }
}