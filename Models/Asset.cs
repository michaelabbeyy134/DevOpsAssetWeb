namespace DevOpsAssetWeb.Models
{
    public class Asset
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string IPAddress { get; set; } = string.Empty;

        public string Environment { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
    }
}