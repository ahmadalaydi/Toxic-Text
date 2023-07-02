using Detect_Toxic_Text.Models;

namespace Detect_Toxic_Text.Services;
public interface IApiClient
{
    Task<Response> PostAsync(string text);
}