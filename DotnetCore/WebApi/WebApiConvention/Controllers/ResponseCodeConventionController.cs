using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiConvention.Model;
using WebApiConvention.ReturnValue;

namespace WebApiConvention.Controllers
{
    /*
     * ״̬�뷵��ֵ
     * ����ִ������: ����200,
     * ���ݿ�����ʧ��/ sqlִ���쳣, ����������, �������쳣 , ����4xx�� 5xx
     * 
     * ҵ�����:
     *  4XX: 
     *      401      ���֤��Ȩʧ��  
     */
    [ApiController]
    [Route("[controller]/[action]")] //�Ƽ�ʹ�����·��
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
            //00:���붨�嵽�����ĸ��ֶ�
            //01:��ʾId�ֶ�

            if (id <= 0)
            {
                var err = new ErrorInfo()
                {
                    //2010
                    Code = $@"{(int)ErrorCodeFirst.��������}{"01"}{ErrorCodeLast.δ����}",
                    Message = $@"Id�����������0",
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
                    Code = $@"{(int)ErrorCodeFirst.ҵ�����}{"00"}{ErrorCodeLast.������Դ�Ҳ���}",
                    Message = $@"��Դ�����ݿ��в�����",
                };
                return NotFound(err);
            }
        }
    }

}