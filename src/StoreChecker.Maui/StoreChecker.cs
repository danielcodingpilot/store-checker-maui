namespace StoreChecker.Maui;

public static class StoreChecker
{
    public static StoreSource GetSource()
    {
        return StoreCheckerPlatform.GetSource();
    }

    public static Task<StoreSource> GetSourceAsync()
    {
        return Task.FromResult(GetSource());
    }
}

internal static partial class StoreCheckerPlatform
{
    public static partial StoreSource GetSource();
}
