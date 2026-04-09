using System.ComponentModel.DataAnnotations;

namespace tim_BackendTest_MidLevel.Dtos
{
  public class MyOfficeAcpdUpdateRequestDto
  {
    [Required]
    [StringLength(60)]
    public string AcpdCname { get; set; } = string.Empty;

    [Required]
    [StringLength(40)]
    public string AcpdEname { get; set; } = string.Empty;

    [Required]
    [StringLength(40)]
    public string AcpdSname { get; set; } = string.Empty;

    [Required]
    [StringLength(60)]
    [EmailAddress]
    public string AcpdEmail { get; set; } = string.Empty;

    public byte? AcpdStatus { get; set; }

    public bool? AcpdStop { get; set; }

    [StringLength(60)]
    public string? AcpdStopMemo { get; set; }

    [Required]
    [StringLength(30)]
    public string AcpdLoginId { get; set; } = string.Empty;

    [Required]
    [StringLength(60)]
    public string AcpdLoginPwd { get; set; } = string.Empty;

    [StringLength(600)]
    public string? AcpdMemo { get; set; }

    [Required]
    [StringLength(20)]
    public string AcpdUpdid { get; set; } = string.Empty;
  }
}