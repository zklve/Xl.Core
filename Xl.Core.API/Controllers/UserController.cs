using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xl.Core.API.Filters;
using Xl.Core.ArchiveService.User;
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

        [LogTrace]
        public ActionResult Login(int id)
        {
            string msg = "登录时间:" + DateTime.Now.ToString();
            _log.WriteLogSync(msg);
            var userInfo = userService.GetAllInfoById(id);
            return Ok(userInfo);
        }
    }
}
