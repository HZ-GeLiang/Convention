# 控制器父类

- Web API 建议 ControllerBase, 除非 webapi control 需要提供 和MVC一样的功能

# action方法

- 使用异步,方法名可以不用Async 结尾(因为action是给前端调用的)
- 推荐使用 ActionResult<T> 
  - 可以让swagger 知道方法的返回值
  - 更多: https://learn.microsoft.com/zh-cn/aspnet/core/web-api/action-return-types?view=aspnetcore-6.0


# 状态码

## 常规状态码

- 200:请求执行正常
- 201:成功创建了一个新的资源
- 204:成功,但是没有什么要返回的

- 4xx 和 5xx : 数据库连接失败/ sql执行异常, 请求报文有误, 服务器异常

## 业务异常

- 401: 身份证授权失败

- 404: 资源不存在

- 4xx: 其他业务错误,同时提供错误信息和错误码

  - 注: 我觉得错误信息必须提供,因为直观, 错误码是可选的

  - 举例: 404: 删除用户时,发现已经被删除了, 可以返回404

  - 不知道用哪个状态码就用400(400表示请求错误)


好处:

- 网关等中间系统通过HTTP状态码检测错误信息
- 200:请求正常,
- 4xx和 5xx: 通知 管理员, 然后客户端可以只显示"系统错误,请联系管理员"



### 我觉得的包装结果对象

```
包装结果对象
{
  bool , "Success"  :  返回状态码 == 200 ? true : false
  object Result " 成功或失败的返回值消息
      {
          ErrorInfo / 实际的Result对象 
      }
 
}

public record ErrorInfo(string Code ,string Message)
```



## 附:abp的包装结果:应该是200党

如ABP

```
{
    "Result": {},
    "TargetUrl": null,
    "Success": true,                     应该是控制程序内部是否发生了异常把. ,对标的应该是500错误,
    "Error": null,                       ErrorInfo
    "UnAuthorizedRequest": false,        我觉得应该是业务是属于业务错误, 因为只有业务觉得是否要登录授权
    "__abp": true
}


```

```

"D:\06GitHub\abp\aspnetboilerplate-dev\src\Abp.Web.Common\Web\Models\ErrorInfo.cs"

using System;

namespace Abp.Web.Models
{
    /// <summary>
    /// Used to store information about an error.
    /// </summary>
    [Serializable]
    public class ErrorInfo
    {
        /// <summary>
        /// Error code.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Error message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Error details.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Validation errors if exists.
        /// </summary>
        public ValidationErrorInfo[] ValidationErrors { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="ErrorInfo"/>.
        /// </summary>
        public ErrorInfo()
        {

        }

        /// <summary>
        /// Creates a new instance of <see cref="ErrorInfo"/>.
        /// </summary>
        /// <param name="message">Error message</param>
        public ErrorInfo(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Creates a new instance of <see cref="ErrorInfo"/>.
        /// </summary>
        /// <param name="code">Error code</param>
        public ErrorInfo(int code)
        {
            Code = code;
        }

        /// <summary>
        /// Creates a new instance of <see cref="ErrorInfo"/>.
        /// </summary>
        /// <param name="code">Error code</param>
        /// <param name="message">Error message</param>
        public ErrorInfo(int code, string message)
            : this(message)
        {
            Code = code;
        }

        /// <summary>
        /// Creates a new instance of <see cref="ErrorInfo"/>.
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="details">Error details</param>
        public ErrorInfo(string message, string details)
            : this(message)
        {
            Details = details;
        }

        /// <summary>
        /// Creates a new instance of <see cref="ErrorInfo"/>.
        /// </summary>
        /// <param name="code">Error code</param>
        /// <param name="message">Error message</param>
        /// <param name="details">Error details</param>
        public ErrorInfo(int code, string message, string details)
            : this(message, details)
        {
            Code = code;
        }
    }
}

```

