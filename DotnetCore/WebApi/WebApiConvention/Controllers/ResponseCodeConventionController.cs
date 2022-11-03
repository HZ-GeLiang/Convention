using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiConvention.Model;
using WebApiConvention.ReturnValue;

namespace WebApiConvention.Controllers
{
    /*
     * 状态码返回值
     * 请求执行正常: 返回200,
     * 数据库连接失败/ sql执行异常, 请求报文有误, 服务器异常 , 返回4xx和 5xx
     * 
     * 业务层面:
     *  4XX: 
     *      401      身份证授权失败  
     */
    [ApiController]
    [Route("[controller]/[action]")] //推荐使用这个路由
    public class ResponseCodeConventionController : ControllerBase
    {
        private readonly ILogger<ResponseCodeConventionController> _logger;

        public ResponseCodeConventionController(ILogger<ResponseCodeConventionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<WeatherForecast> GetSingle(int id)
        {
            //00:不想定义到底是哪个字段
            //01:表示Id字段

            if (id <= 0)
            {
                var err = new ErrorInfo()
                {
                    //2010
                    Code = $@"{(int)ErrorCodeFirst.参数错误}{"01"}{ErrorCodeLast.未定义}",
                    Message = $@"Id参数必须大于0",
                };
                return BadRequest(err);
            }

            if (id == 1)
            {
                return new WeatherForecast();
            }
            else
            {
                var err = new ErrorInfo()
                {
                    //1002
                    Code = $@"{(int)ErrorCodeFirst.业务错误}{"00"}{ErrorCodeLast.请求资源找不到}",
                    Message = $@"资源在数据库中不存在",
                };
                return NotFound(err);
            }
        }
    }

}