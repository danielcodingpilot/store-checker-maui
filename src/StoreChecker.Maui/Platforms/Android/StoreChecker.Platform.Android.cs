#if ANDROID
using Android.App;
using Android.Content;

namespace StoreChecker.Maui;

internal static partial class StoreCheckerPlatform
{
    public static partial StoreSource GetSource()
    {
        var context = Application.Context;
        var installer = context.PackageManager?.GetInstallerPackageName(context.PackageName);

        if (string.IsNullOrWhiteSpace(installer))
        {
            return StoreSource.LocalSource;
        }

        return installer switch
        {
            "com.android.vending" => StoreSource.PlayStore,
            "com.google.android.packageinstaller" => StoreSource.PlayPackageInstaller,
            "com.android.packageinstaller" => StoreSource.PlayPackageInstaller,
            "com.amazon.venezia" => StoreSource.AmazonAppStore,
            "com.huawei.appmarket" => StoreSource.HuaweiAppGallery,
            "com.sec.android.app.samsungapps" => StoreSource.SamsungGalaxyStore,
            "com.sec.android.easyMover" => StoreSource.SamsungSmartSwitchMobile,
            "com.oppo.market" => StoreSource.OppoAppMarket,
            "com.xiaomi.mipicks" => StoreSource.XiaomiGetApps,
            "com.vivo.appstore" => StoreSource.VivoAppStore,
            "ru.vk.store" => StoreSource.RuStore,
            "com.android.shell" => StoreSource.LocalSource,
            _ => StoreSource.OtherSource,
        };
    }
}
#endif
