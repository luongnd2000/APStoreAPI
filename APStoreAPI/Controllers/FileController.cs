using APStore.Common;
using APStoreAPI.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APStoreAPI.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class FileController : ApiController
    {
        [HttpPost]
        public async Task<BaseResponse<string>> UploadFile()
        {
            var ctx = HttpContext.Current;
            var list = new List<string>();
            var root = ctx.Server.MapPath("~/Upload/Image");
            var provider = new MultipartFormDataStreamProvider(root);
            var status = StatusResponse.Success;
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
                var file = provider.FileData[0];
                var name = file.Headers.ContentDisposition.FileName;
                name = name.Trim('"');
                name = "Product_Image_" + Guid.NewGuid() + name;
                var localFileName = file.LocalFileName;
                var filePath = Path.Combine(root, name);
                File.Move(localFileName, filePath);
                list.Add(Constant.BASE_URL + "Upload/Image/" + name);
            }
            catch (Exception)
            {
                status = StatusResponse.Fail;
            }
            BaseResponse<string> response = new BaseResponse<string>(status, "", list);
            return response;
        }
    }
}
