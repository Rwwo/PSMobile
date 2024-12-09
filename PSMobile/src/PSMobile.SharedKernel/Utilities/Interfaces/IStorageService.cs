namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IStorageService
{
    Task SetAsync(string key, string value);
    Task<string?> GetAsync(string key);
    Task Remove(string key);
}
