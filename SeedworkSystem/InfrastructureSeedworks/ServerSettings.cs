using System.Text.Json.Serialization;

namespace InfrastructureSeedworks;

public class ServerSettings : object
{
	[JsonIgnore]
	public static string DomainApiProjectManager { get; } = "https://api.decoyab.com/";
	// public static string DomainApiProjectManager { get; } = "https://localhost:7161/";
	
	[JsonIgnore]
	public static string DomainAdmin { get; } = "https://admin.decoyab.com/";
	// public static string DomainAdmin { get; } = "https://localhost:50001/";

	[JsonIgnore]
	public static string DomainWeb { get; } = "https://decoyab.com/";

	public string VisualizerUrl()
	{
		return $"{UploadsFolderName}/{VisualizerFolderName}/";
	}

	public string ReturnRequestUrl()
	{
		return $"{UploadsFolderName}/{ReturnRequestOrderFolderName}/";
	}

	public string DecoCutUrl()
	{
		return $"{UploadsFolderName}/{DecoCutFolderName}/";
	}

	public string PageSettingsUrl()
	{
		return $"{UploadsFolderName}/{PageSettingsFolderName}/";
	}

	public string AppVersionHistoryUrl()
	{
		return $"{UploadsFolderName}/{AppVersionHistoryFolderName}/";
	}

	public string PublicSliderUrl()
	{
		return $"{UploadsFolderName}/{PublicSliderFolderName}/";
	}
	
	public string ProductImagesUrl()
	{
		return $"{UploadsFolderName}/{PublicSliderFolderName}/";
	}

	public string NotificationsUrl()
	{
		return $"{UploadsFolderName}/{NotificationsFolderName}/";
	}

	[JsonIgnore] public static string UploadsFolderName { get; } = "Uploads";

	[JsonIgnore] public static string ProductCategoryImagesFolderName { get; set; } = "product-category-image";
	
	[JsonIgnore] public static string ProductImagesFolderName { get; set; } = "product-image";
	
	[JsonIgnore] public static string PublicSliderFolderName { get; set; } = "product-public-slider";


	[JsonIgnore] public static string DecoCutFolderName { get; } = "DecoCut";

	[JsonIgnore] public static string VisualizerFolderName { get; } = "Visualizer";

	[JsonIgnore] public static string ReturnRequestOrderFolderName { get; } = "ReturnRequestOrder";

	[JsonIgnore] public static string PageSettingsFolderName { get; } = "PageSettings";

	[JsonIgnore] public static string AppVersionHistoryFolderName { get; } = "AppVersionHistory";
	
	[JsonIgnore] public static string NotificationsFolderName { get; } = "Notifications";
}