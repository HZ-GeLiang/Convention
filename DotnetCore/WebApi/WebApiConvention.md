1. 控制器父类
   1. Web API 建议 ControllerBase, 除非 webapi control 需要提供 和MVC一样的功能
2. action方法
   1. 使用异步,方法名可以不用Async 结尾(因为action是给前端调用的)
   2. 推荐使用ActionResult<T> 
      1. 优势: 可以让swagger 知道方法的返回值
      2. 跟多优势详见: https://learn.microsoft.com/zh-cn/aspnet/core/web-api/action-return-types?view=aspnetcore-6.0