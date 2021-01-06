using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Xl.Core.API.Filters;
using Xl.Core.ArchiveService.User;
using Xl.Core.DomainModel.File;
using Xl.Core.UniversalCommon.Log;

namespace Xl.Core.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILog _log;
        private IUserService userService;
        public UserController(ILog log, IUserService service)
        {
            this._log = log;
            this.userService = service;
        }

        //[LogTrace]
        public ActionResult Login(int id)
        {
            string msg = "登录时间:" + DateTime.Now.ToString();
            _log.WriteLogSync(msg);
            var userInfo = userService.GetAllInfoById(id);
            return Ok(userInfo);
        }

        /// <summary>
        /// 获取文件 兼容apple
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public FileResult GetFilesById(long fileId)
        {
            //var file = _fileService.GetFileInfoDetail(fileId);
            //获取文件信息
            var file = new AttachFile();
            var bytes = System.IO.File.ReadAllBytes(file.LocalPath);
            string contentType = "";
            new FileExtensionContentTypeProvider().TryGetContentType(file.LocalPath, out contentType);

            var context = ControllerContext.HttpContext;
            var reqRange = context.Request.Headers["Range"].ToString();
            string[] reqBlockRange = null;
            if (!string.IsNullOrEmpty(reqRange))
            {
                reqBlockRange = reqRange.Replace("bytes=", "").Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                context.Response.StatusCode = 206;

                long fileSize = bytes.Length;
                long startPosition = 0;
                long partialSize = fileSize;
                if (reqBlockRange != null)
                {
                    startPosition = Convert.ToInt64(reqBlockRange[0]);
                    if (reqBlockRange.Length > 1)
                    {
                        long endPosition = fileSize;
                        if (long.TryParse(reqBlockRange[1], out endPosition))
                        {
                            partialSize = endPosition - startPosition + 1;
                        }
                    }
                    else
                    {
                        partialSize = fileSize - startPosition;
                    }
                }

                byte[] buffer = new byte[(int)partialSize];
                Array.Copy(bytes, startPosition, buffer, 0, partialSize);

                context.Response.Headers.Add("accept-ranges", "bytes");
                context.Response.Headers.Add("access-control-allow-methods", "HEAD, GET, OPTIONS");
                context.Response.Headers.Add("cache-control", "public, max-age=30726563");
                context.Response.ContentType = contentType;
                context.Response.Headers.Add("Connection", "keep-alive");
                context.Response.Headers.Add("content-range", $"bytes {startPosition}-{startPosition + partialSize - 1 }/{fileSize}");
                context.Response.Headers.Add("Content-Length", $"{partialSize}");
                return File(buffer, contentType);
            }
            else
            {
                return File(bytes, contentType);
            }
        }


    }
}
