namespace BAS24.Product.Core;

public static class AppSettings
{
  // public static readonly int MaxCirclePlaceGallery = 6;
  // public static readonly int MaxDistanceLabelTimeline = 500;
  // public static readonly ushort MaxGPSAccuracyMeter = 500;
  // public static readonly ushort MaxDistanceInvalidSpeedMeter = 250;
  //
  // public static readonly int DefaultThumbnailHeight = 350;
  // public static readonly string CurrentMediaUploadProvider = MediaUploadProvider.Cloudinary;
  // public static readonly double SuccessfulCallDistanceMeter = 1000;
  //mobile supported version
  // public static readonly string[] AndroidUnSupportedVersion = { };
  // public static readonly string[] IOSUnSupportedVersion = { };
  // public static readonly int MobileMinSupportVersion = 4;

  //header middleware
  public static readonly Dictionary<string, string> ClientHeaders = new()
  {
    { "F9adySc", "Android" },
    { "dNawd36", "iOS" },
    { "Vv43kBn", "Web" },
    { "d36v43w", "Windows" },
    { "WbNk6U3", "Other" }
  };

  // Membership 
  public static readonly int MaxCircles = 3;
  public static readonly int MaxPlaces = 6;
  public static readonly int MaxMembers = 6;
  public static readonly int MaxTimelineGeneralUser = 3;
  public static readonly int MaxTimelinePeriod = 30;

  public static readonly int MinimunUserAge = 4;

  // Max Timeline location
  public static readonly int MaxLocationPerRow = 20000;
}
