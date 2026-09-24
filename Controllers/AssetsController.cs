using DevOpsAssetWeb.Models;
using DevOpsAssetWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsAssetWeb.Controllers
{
    public class AssetsController : Controller
    {
        private readonly AssetApiService _assetApiService;

        public AssetsController(AssetApiService assetApiService)
        {
            _assetApiService = assetApiService;
        }

        public async Task<IActionResult> Index()
        {
            var assets = await _assetApiService.GetAssetsAsync();

            return View(assets);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Asset asset)
        {
            if (!ModelState.IsValid)
            {
                return View(asset);
            }

            await _assetApiService.CreateAssetAsync(asset);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var assets = await _assetApiService.GetAssetsAsync();

            var asset = assets.FirstOrDefault(a => a.Id == id);

            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Asset asset)
        {
            if (id != asset.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(asset);
            }

            var success = await _assetApiService.UpdateAssetAsync(asset);

            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _assetApiService.DeleteAssetAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}