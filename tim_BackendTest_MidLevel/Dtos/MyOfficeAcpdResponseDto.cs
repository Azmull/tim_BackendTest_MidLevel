namespace tim_BackendTest_MidLevel.Dtos
{
  public class MyOfficeAcpdResponseDto
  {
    public string AcpdSid { get; set; } = string.Empty;

    public string? AcpdCname { get; set; }

    public string? AcpdEname { get; set; }

    public string? AcpdSname { get; set; }

    public string? AcpdEmail { get; set; }

    public byte? AcpdStatus { get; set; }

    public bool? AcpdStop { get; set; }

    public string? AcpdStopMemo { get; set; }

    public string? AcpdLoginId { get; set; }

    public string? AcpdLoginPwd { get; set; }

    public string? AcpdMemo { get; set; }

    public DateTime? AcpdNowDateTime { get; set; }

    public string? AcpdNowId { get; set; }

    public DateTime? AcpdUpddateTime { get; set; }

    public string? AcpdUpdid { get; set; }
  }
}