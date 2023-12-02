using UnityEngine;
using UnityEngine.Advertisements;

public class InitializeAds : MonoBehaviour, IUnityAdsInitializationListener
{
    public string androidGameId;
    public string iosGameId;

    public bool isTestingMode = true;

    string gameId;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        InitAds();
    }

    void InitAds()
    {

#if UNITY_IOS
            gameId = iosGameId;
#elif UNITY_ANDROID
        gameId = androidGameId;
#elif UNITY_EDITOR
            gameId = androidGameId; //for testing
#endif

        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, isTestingMode, this);
        }
    }
    public void OnInitializationComplete()
    {
        print("Ads initialized");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        print("Fail to initilize");
    }
}
