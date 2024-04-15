using LaunchDarkly.Sdk;
using LaunchDarkly.Sdk.Server;
using LaunchDarkly.Sdk.Server.Interfaces;
using LaunchDarkly.Sdk.Server.Subsystems;

public sealed class LDClient
{
    private static readonly object myLock = new object();
    private static LDClient? instance = null;
    private LdClient client;

    private LDClient()
    {

        client = new LdClient(Environment.GetEnvironmentVariable("LD_SDK_KEY"));
        client.FlagTracker.FlagChanged += (s, e) =>
        {
            Console.WriteLine("Here: \"{0}\"!", e.Key);
        };
    }

    private static LDClient Instance
    {
        get
        {
            lock (myLock)
            {
                if (instance == null)
                {
                    instance = new LDClient();
                }
                return instance;
            }
        }
    }

    public static LdClient Client
    {
        get
        {
            return Instance.client;
        }
    }
}