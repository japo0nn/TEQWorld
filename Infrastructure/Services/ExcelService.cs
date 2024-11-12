using Microsoft.Extensions.Logging;
using OfficeOpenXml;

namespace Infrastructure.Services;

public class ExcelService : IExcelService
{
    private readonly IItemRepository _repository;
    private readonly ILogger<ExcelService> _logger;

    public ExcelService(IItemRepository repository, ILogger<ExcelService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Result> ParseData(Stream stream)
    {
        var items = new List<Item>();
        using (var package = new ExcelPackage(stream))
        {
            var worksheet = package.Workbook.Worksheets.FirstOrDefault();

            if (worksheet == null)
                Result.Failure(["В таблице Excel отсутсвуют листы"]);

            for (int row = 2; row <= worksheet.Dimension.Rows; row++)
            {
                items.Add(
                    Item.Create(
                        worksheet.Cells[row, 1].Text,
                        worksheet.Cells[row, 2].Text,
                        double.Parse(worksheet.Cells[row, 3].Text),
                        int.Parse(worksheet.Cells[row, 4].Text)
                    )
                );
            }

            await _repository.AddRangeAsync(items);

            _logger.LogInformation(
                DateTimeOffset.UtcNow.ToString("dd.MM.yyyy HH:mm"),
                $"Записи успешно добавлены в Базу Данных"
            );
        }

        return Result.Success();
    }
}
