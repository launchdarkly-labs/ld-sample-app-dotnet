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

        client = new LdClient("sdk-c511170a-a72e-48d9-8d16-5ef0270975f1");
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

    public static Context Context
    {
        set
        {
            Context c = value;
            string flag = "test-flag";
            LdClient client = Instance.client;
            client.FlagTracker.FlagChanged += client.FlagTracker.FlagValueChangeHandler(
                flag,
                c,
                (s, e) =>
                {
                    Console.WriteLine(
                        "Flag \"{0}\" for context \"{1}\" has changed from {2} to {3}",
                        flag,
                        c.Key,
                        e.OldValue,
                        e.NewValue
                    );
                }
            );
        }
    }
}