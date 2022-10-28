// using Microsoft.AspNetCore.Mvc;
// namespace webapiexercise.Controllers;

// [ApiController]
// [Route("api/[controller]")]
// public class HelloWorldController:ControllerBase{

// private readonly ILogger<HelloWorldController> _logger;
// IHelloWorldServices helloWorldServices;
//  public HelloWorldController(IHelloWorldServices helloWorld,ILogger<HelloWorldController> logger){
//     _logger=logger;
//     helloWorldServices=helloWorld;
//  }
// [HttpGet]
//  public IActionResult Get(){
//     _logger.LogInformation("Return HelloWorld message");
//     return Ok(helloWorldServices.GetHelloWorld());
//  }
// }