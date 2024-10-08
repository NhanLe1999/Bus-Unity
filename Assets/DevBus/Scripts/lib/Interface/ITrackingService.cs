using Firebase.Analytics;
using System.Collections.Generic;

public interface ITrackingService
{
    void InitService();
    void LogEvent(string message);
    void LogEvent(string message, Dictionary<string, string> parameters);
    void ResourceChange(string key, string source, int amount);
    void HandleIAP(string productId, string price, string currency);
}
