using Detect_Toxic_Text.Models;
using Detect_Toxic_Text.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Toxic_Text.Models;

namespace Toxic_Text.Controllers;
public class HomeController : Controller
{
    private readonly IApiClient _apiClient;

    public HomeController(IApiClient apiClient)
    => _apiClient = apiClient;

    public IActionResult Index()
    => View();

    public IActionResult Privacy()
        => View();

    [ResponseCache(Duration = 5, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

    public IActionResult Search()
    => View();

    [HttpPost]
    public async Task<IActionResult> Search(Request request)
    => View(await _apiClient.PostAsync(request.Text));
}