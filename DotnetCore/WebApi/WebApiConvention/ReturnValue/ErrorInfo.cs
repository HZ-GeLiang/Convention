using System.ComponentModel;

namespace WebApiConvention.ReturnValue
{
    /// <summary>
    /// 首尾错误码
    /// </summary>
    public enum ErrorCodeFirst
    {

        [Description("业务错误")]
        业务错误 = 1,

        /// <summary>
        /// 传入的参数直接非法
        /// </summary>
        [Description("参数错误")]
        参数错误 = 2,

    }

    /// <summary>
    /// 末尾错误码
    /// </summary>
    public enum ErrorCodeLast
    {
        未定义 = 0,

        /// <summary>
        /// 检验数据的过程中发现的参数无效
        /// <br>如:并发原因造成传入过来的版本号字段已经无效</br>
        /// </summary>
        参数非法 = 1,

        /// <summary>
        /// 在先查询后更新的操作中
        /// <br>如果是直接更新的若更新条数为0, 更倾向于参数非法</br>
        /// <br>如: 数据未找到, </br>
        /// </summary>
        请求资源找不到 = 2,

        /// <summary>
        /// 权限不足
        /// </summary>
        没有操作权限 = 3,

        /// <summary>
        /// 未登录/登录凭证失效
        /// </summary>
        未提供身份凭证 = 4,
    }


    /// <summary>
    /// 请求错误
    /// </summary>
    public record ErrorInfo
    {
        /*
         * 建议: 用特殊码位作为整个项目的通用错误码
         * 如: 
         * 首位Code:
         * 1. 业务错误
         * 
         * 末位Code
         * 1. 参数非法
         * 2. 请求资源找不到
         * 3. 没有操作权限
         * 
         * 举例: 用户管理中
         * 2xx0: {参数错误}{错误字段和错误消息}{未定义}      
         * 1xx2: {业务错误}{错误消息对应的错误码}{请求资源找不到}
         * 
         * xx:
         * 1.感觉2位数值足够用
         * 2.人为的定义从01开始, 00可以表示未定义的错误信息/在AOP拦截使用
         * 
         * 注:这里没有模块信息,所以,错误码会出现重复.如果要不重复, 可以使用Controller+Action信息
         */
        /// <summary>
        /// 业务错误码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string Message { get; set; }
 
    }

}