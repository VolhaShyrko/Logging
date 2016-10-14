using PerformanceCounterHelper;

namespace PerformanceCounters
{
    [PerformanceCounterCategory("MvcMusicStore", System.Diagnostics.PerformanceCounterCategoryType.MultiInstance, "MvcMusicStore")]
    public enum Counter
    {
        [PerformanceCounter("Login", "Login", System.Diagnostics.PerformanceCounterType.NumberOfItems32)]
        Login,

        [PerformanceCounter("Logoff", "Logoff", System.Diagnostics.PerformanceCounterType.NumberOfItems32)]
        Logoff,

        [PerformanceCounter("OnlineUsers", "OnlineUsers", System.Diagnostics.PerformanceCounterType.NumberOfItems32)]
        OnlineUsers
    }
}
