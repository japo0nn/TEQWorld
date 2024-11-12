using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/items")]
[ApiController]
public class ItemsController(IExcelService excelService) : ControllerBase
{
    private readonly IExcelService _excelService = excelService;

    [HttpPost("upload")]
    public async Task<Result> UploadFile(IFormFile file)
    {
        if (!file.FileName.EndsWith(".xlsx"))
            return Result.Failure(["Неправильный формат файла"]);

        await _excelService.ParseData(file.OpenReadStream());

        return Result.Success();
    }
}
