using ConnectionStringDAL;
using ConnectionStringDAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectionStringAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public ConnectionStringRepository repos;
        private readonly IConfiguration configuration;
        public HomeController(IConfiguration i)
        {
            configuration = i;

            repos = new ConnectionStringRepository(configuration);
        }

        public List<Course> GetCourses()
        {
            List<Course> lst = null;
            try
            {
                lst = repos.GetCourseDetails();
            }
            catch (Exception)
            {

                lst = null;
            }
            return lst;
        }
    }
}
