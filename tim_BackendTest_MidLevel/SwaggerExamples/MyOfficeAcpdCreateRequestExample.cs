using Swashbuckle.AspNetCore.Filters;
using tim_BackendTest_MidLevel.Dtos;

namespace tim_BackendTest_MidLevel.SwaggerExamples
{
  public class MyOfficeAcpdCreateRequestExample : IExamplesProvider<MyOfficeAcpdCreateRequestDto>
  {
    public MyOfficeAcpdCreateRequestDto GetExamples()
    {
      return new MyOfficeAcpdCreateRequestDto
      {
        AcpdCname = "王小明",
        AcpdEname = "Wang",
        AcpdSname = "Tim",
        AcpdEmail = "tim@example.com",
        AcpdStatus = 1,
        AcpdStop = false,
        AcpdStopMemo = "",
        AcpdLoginId = "tim001",
        AcpdLoginPwd = "P@ssw0rd",
        AcpdMemo = "swagger create test",
        AcpdNowId = "SYSTEM"
      };
    }
  }
}