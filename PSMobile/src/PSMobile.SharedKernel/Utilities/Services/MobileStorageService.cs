using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class MobileStorageService : IStorageService
{
    public Task SetAsync(string key, string value)
    {
        return SecureStorage.SetAsync(key, value);
    }

    public async Task<string?> GetAsync(string key)
    {
        return await SecureStorage.GetAsync(key);
    }

    public async Task Remove(string key)
    {
        SecureStorage.Remove(key);
    }
}
