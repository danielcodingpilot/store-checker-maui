#if IOS || MACCATALYST
using Foundation;

namespace StoreChecker.Maui;

internal static partial class StoreCheckerPlatform
{
    public static partial StoreSource GetSource()
    {
        var appStoreReceiptURL = NSBundle.MainBundle.AppStoreReceiptURL;
        var isSandboxReceipt = appStoreReceiptURL?.LastPathComponent == "sandboxReceipt";
        var hasEmbeddedProvisioningProfile = NSBundle.MainBundle.PathForResource("embedded", "mobileprovision") is not null;

        if (isSandboxReceipt && !hasEmbeddedProvisioningProfile)
        {
            return StoreSource.TestFlight;
        }

        if (!isSandboxReceipt && !hasEmbeddedProvisioningProfile)
        {
            return StoreSource.AppStore;
        }

        return StoreSource.LocalSource;
    }
}
#endif
