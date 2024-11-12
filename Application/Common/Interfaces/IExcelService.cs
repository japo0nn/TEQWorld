using Application.Common.Models;

namespace Application.Common.Interfaces;

public interface IExcelService
{
    Task<Result> ParseData(Stream stream);
}
