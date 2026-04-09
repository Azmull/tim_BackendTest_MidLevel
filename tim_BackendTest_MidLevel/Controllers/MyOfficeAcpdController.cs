using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tim_BackendTest_MidLevel.Dtos;
using tim_BackendTest_MidLevel.Models;

namespace tim_BackendTest_MidLevel.Controllers
{
  [Route("api/myofficeacpd")]
  [ApiController]
  public class MyOfficeAcpdController : ControllerBase
  {
    private readonly Myoffice_ACPDContext _context;

    public MyOfficeAcpdController(Myoffice_ACPDContext context)
    {
      _context = context;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<MyOfficeAcpdResponseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<MyOfficeAcpdResponseDto>>> GetAll()
    {
      var items = await _context.MyOfficeAcpd
          .AsNoTracking()
          .OrderBy(x => x.AcpdSid)
          .Select(x => MapToResponseDto(x))
          .ToListAsync();

      return Ok(items);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(MyOfficeAcpdResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MyOfficeAcpdResponseDto>> GetById(string id)
    {
      var item = await _context.MyOfficeAcpd
          .AsNoTracking()
          .FirstOrDefaultAsync(x => x.AcpdSid == id);

      if (item == null)
      {
        return NotFound();
      }

      return Ok(MapToResponseDto(item));
    }

    [HttpPost]
    [ProducesResponseType(typeof(MyOfficeAcpdResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MyOfficeAcpdResponseDto>> Create(MyOfficeAcpdCreateRequestDto request)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var entity = new MyOfficeAcpd
      {
        AcpdSid = await GenerateAcpdSidAsync(),
        AcpdCname = request.AcpdCname,
        AcpdEname = request.AcpdEname,
        AcpdSname = request.AcpdSname,
        AcpdEmail = request.AcpdEmail,
        AcpdStatus = request.AcpdStatus ?? 0,
        AcpdStop = request.AcpdStop ?? false,
        AcpdStopMemo = request.AcpdStopMemo,
        AcpdLoginId = request.AcpdLoginId,
        AcpdLoginPwd = request.AcpdLoginPwd,
        AcpdMemo = request.AcpdMemo,
        AcpdNowDateTime = DateTime.Now,
        AcpdNowId = request.AcpdNowId,
        AcpdUpddateTime = DateTime.Now,
        AcpdUpdid = request.AcpdNowId
      };

      _context.MyOfficeAcpd.Add(entity);
      await _context.SaveChangesAsync();

      var response = MapToResponseDto(entity);

      return CreatedAtAction(nameof(GetById), new { id = entity.AcpdSid }, response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(MyOfficeAcpdResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MyOfficeAcpdResponseDto>> Update(string id, MyOfficeAcpdUpdateRequestDto request)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var entity = await _context.MyOfficeAcpd.FirstOrDefaultAsync(x => x.AcpdSid == id);

      if (entity == null)
      {
        return NotFound();
      }

      entity.AcpdCname = request.AcpdCname;
      entity.AcpdEname = request.AcpdEname;
      entity.AcpdSname = request.AcpdSname;
      entity.AcpdEmail = request.AcpdEmail;
      entity.AcpdStatus = request.AcpdStatus ?? entity.AcpdStatus;
      entity.AcpdStop = request.AcpdStop ?? entity.AcpdStop;
      entity.AcpdStopMemo = request.AcpdStopMemo;
      entity.AcpdLoginId = request.AcpdLoginId;
      entity.AcpdLoginPwd = request.AcpdLoginPwd;
      entity.AcpdMemo = request.AcpdMemo;
      entity.AcpdUpddateTime = DateTime.Now;
      entity.AcpdUpdid = request.AcpdUpdid;

      await _context.SaveChangesAsync();

      return Ok(MapToResponseDto(entity));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
      var entity = await _context.MyOfficeAcpd.FirstOrDefaultAsync(x => x.AcpdSid == id);

      if (entity == null)
      {
        return NotFound();
      }

      _context.MyOfficeAcpd.Remove(entity);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private static MyOfficeAcpdResponseDto MapToResponseDto(MyOfficeAcpd entity)
    {
      return new MyOfficeAcpdResponseDto
      {
        AcpdSid = entity.AcpdSid,
        AcpdCname = entity.AcpdCname,
        AcpdEname = entity.AcpdEname,
        AcpdSname = entity.AcpdSname,
        AcpdEmail = entity.AcpdEmail,
        AcpdStatus = entity.AcpdStatus,
        AcpdStop = entity.AcpdStop,
        AcpdStopMemo = entity.AcpdStopMemo,
        AcpdLoginId = entity.AcpdLoginId,
        AcpdLoginPwd = entity.AcpdLoginPwd,
        AcpdMemo = entity.AcpdMemo,
        AcpdNowDateTime = entity.AcpdNowDateTime,
        AcpdNowId = entity.AcpdNowId,
        AcpdUpddateTime = entity.AcpdUpddateTime,
        AcpdUpdid = entity.AcpdUpdid
      };
    }

    private async Task<string> GenerateAcpdSidAsync()
    {
      while (true)
      {
        var sid = $"A{DateTime.Now:yyyyMMddHHmmss}{Random.Shared.Next(10000, 99999)}";

        var exists = await _context.MyOfficeAcpd.AnyAsync(x => x.AcpdSid == sid);

        if (!exists)
        {
          return sid;
        }
      }
    }
  }
}