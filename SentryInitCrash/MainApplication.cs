using Android.Runtime;
using Microsoft.Extensions.Logging;
using Sentry.Extensions.Logging;

namespace SentryInitCrash;

[Application(
#if DEBUG
    Debuggable = true
#else
    Debuggable = false
#endif
)]
public class MainApplication : Application
{
    public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
        : base(javaReference, transfer)
    {
    }

    public MainApplication()
    {
    }

    public override void OnCreate()
    {
        base.OnCreate();

        var options = new SentryLoggingOptions
        {
            Dsn = "cool-dsn",
            MinimumEventLevel = LogLevel.Critical
        };
        options.DisableUnobservedTaskExceptionCapture();
        SentrySdk.Init(options);
    }
}
