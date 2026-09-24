using DevOpsAssetWeb.Models;
using System.Net.Http.Json;

namespace DevOpsAssetWeb.Services
{
    public class AssetApiService
    {
        private readonly HttpClient _httpClient;

        public AssetApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Asset>> GetAssetsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Asset>>(
                "/api/Assets") ?? new List<Asset>();
        }

        public async Task<Asset?> CreateAssetAsync(Asset asset)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "/api/Assets",
                asset);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Asset>();
        }

        public async Task<bool> UpdateAssetAsync(Asset asset)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"/api/Assets/{asset.Id}",
                asset);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAssetAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(
                $"/api/Assets/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}