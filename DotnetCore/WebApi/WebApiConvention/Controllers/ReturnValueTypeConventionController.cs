using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiConvention.Model;

namespace WebApiConvention.Controllers
{

    /*
     * 控制器方法返回值:  建议使用 ActionResult<T>
     */
    [ApiController]
    [Route("[controller]/[action]")] //推荐使用这个路由
    public class ReturnValueTypeConventionController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ReturnValueTypeConventionController> _logger;

        public ReturnValueTypeConventionController(ILogger<ReturnValueTypeConventionController> logger)
        {
            _logger = logger;
        }

        private WeatherForecast[] _WeatherForecastArray = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray();


        #region 约定:Action方法的返回值
        [HttpGet()]
        public ActionResult ReturnValue()  //不推荐用 ActionResult 或 IActionResult
        {
            return new JsonResult(_WeatherForecastArray);
        }

        [HttpGet()]
        public ActionResult<IEnumerable<WeatherForecast>> ReturnValueConvention() //推荐使用 ActionResult<T>, 原因:示例4
        {
            return _WeatherForecastArray;
        }

        [HttpGet()]
        public IEnumerable<WeatherForecast> ReturnValueConvention_2() //这个效果和上面一样
        {
            return _WeatherForecastArray;
        }

        [HttpGet()]
        public ActionResult<int> ReturnValueConvention2() //示例2
        {
            return 1;
        }

        [HttpGet()]
        public int ReturnValueConvention2_2() //示例2,传统写法
        {
            return 1;
        }

        [HttpGet()]
        public ActionResult<WeatherForecast> ReturnValueConvention3()//示例3
        {
            return _WeatherForecastArray[0];
        }

        [HttpGet()]
        public WeatherForecast ReturnValueConvention3_2() //示例3,传统写法
        {
            return _WeatherForecastArray[0];
        }


        [HttpGet()]
        public ActionResult<ReturnValue<WeatherForecast>> ReturnValueConvention4()//示例4
        {
            var value = new ReturnValue<WeatherForecast>() { Data = _WeatherForecastArray[0] };
            return new JsonResult(value) { };
        }

        [HttpGet()]
        public ReturnValue<WeatherForecast> ReturnValueConvention4_2() //示例4 的另一种写法
        {
            ReturnValue<WeatherForecast> value = new ReturnValue<WeatherForecast>() { Data = _WeatherForecastArray[0] };
            return value;
        }

        #endregion
    }

    public class ReturnValue<T>
    {
        public T Data { get; set; }
    }
}