using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private string _dataSrc;
        private List<EventModel> _events
        {
            get
            {
                return JsonConvert.DeserializeObject<List<EventModel>>(_dataSrc);
            }
            set { _events = value; }
        }

        public TestController()
        {
            var path = Directory.GetCurrentDirectory() + "/wwwroot/assets/data/events.json";
            _dataSrc = System.IO.File.ReadAllText(path);
        }
        /// <summary>
        /// Returns events found in events.json file. 
        /// There's an optional random sort param.
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(bool random = false)
        {
            var model = _events;
            if (random)
                model = model.OrderBy(x => Guid.NewGuid()).ToList();
            return Ok(model);
        }

    }
}
