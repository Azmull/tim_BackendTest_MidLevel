using Swashbuckle.AspNetCore.Filters;
using tim_BackendTest_MidLevel.Dtos;

namespace tim_BackendTest_MidLevel.SwaggerExamples
{
  public class MyOfficeAcpdUpdateRequestExample : IExamplesProvider<MyOfficeAcpdUpdateRequestDto>
  {
    public MyOfficeAcpdUpdateRequestDto GetExamples()
    {
      return new MyOfficeAcpdUpdateRequestDto
      {
        AcpdCname = "王小明-更新",
        AcpdEname = "Wang Updated",
        AcpdSname = "Tim",
        AcpdEmail = "tim.updated@example.com",
        AcpdStatus = 1,
        AcpdStop = false,
        AcpdStopMemo = "",
        AcpdLoginId = "tim001",
        AcpdLoginPwd = "P@ssw0rd123",
        AcpdMemo = "swagger update test",
        AcpdUpdid = "SYSTEM"
      };
    }
  }
}