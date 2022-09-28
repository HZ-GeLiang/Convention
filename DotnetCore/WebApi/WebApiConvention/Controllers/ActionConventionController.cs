using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApiConvention.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")] //�Ƽ�ʹ�����·��
    public class ActionConventionController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ActionConventionController> _logger;

        public ActionConventionController(ILogger<ActionConventionController> logger)
        {
            _logger = logger;
        }

        private WeatherForecast[] _WeatherForecastArray = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray();


        #region Լ��:Action�����ķ���ֵ
        [HttpGet()]
        public ActionResult ReturnValue()  //���Ƽ��� ActionResult �� IActionResult
        {
            return new JsonResult(_WeatherForecastArray);
        }

        [HttpGet()]
        public ActionResult<IEnumerable<WeatherForecast>> ReturnValueConvention() //�Ƽ�ʹ�� ActionResult<T>, ԭ��:ʾ��4
        {
            return _WeatherForecastArray;
        }

        [HttpGet()]
        public IEnumerable<WeatherForecast> ReturnValueConvention_2() //���Ч��������һ��
        {
            return _WeatherForecastArray;
        }

        [HttpGet()]
        public ActionResult<int> ReturnValueConvention2() //ʾ��2
        {
            return 1;
        }

        [HttpGet()]
        public int ReturnValueConvention2_2() //ʾ��2,��ͳд��
        {
            return 1;
        }

        [HttpGet()]
        public ActionResult<WeatherForecast> ReturnValueConvention3()//ʾ��3
        {
            return _WeatherForecastArray[0];
        }

        [HttpGet()]
        public WeatherForecast ReturnValueConvention3_2() //ʾ��3,��ͳд��
        {
            return _WeatherForecastArray[0];
        }


        [HttpGet()]
        public ActionResult<ActionReturnValue<WeatherForecast>> ReturnValueConvention4()//ʾ��4
        {
            var value = new ActionReturnValue<WeatherForecast>() { Data = _WeatherForecastArray[0] };
            return new JsonResult(value) { };
        }

        //[HttpGet()]
        //public ActionReturnValue<WeatherForecast> ReturnValueConvention4_2() //ʾ��4, ��������д
        //{
        //    var value = new ActionReturnValue<WeatherForecast>() { Data = _WeatherForecastArray[0] };
        //    return new JsonResult(value) { }; //��ʽת��ʧ��
        //}

        #endregion
    }

    public class ActionReturnValue<T>
    {
        public T Data { get; set; }
    }
}