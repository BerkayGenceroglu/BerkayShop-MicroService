namespace BerkayShop.WebUI.Settings
{
	public class ClientSettings
	{
        public Client BerkayShopVisitorClient { get; set; }
        public Client BerkayShopManagerClient { get; set; }
        public Client BerkayShopAdminClient { get; set; }
	}
	public class Client
	{
		public string ClientId { get; set; }
		public string ClientSecret { get; set; }
	}
}
