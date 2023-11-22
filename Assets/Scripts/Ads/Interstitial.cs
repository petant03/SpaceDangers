using UnityEngine;
using UnityEngine.Advertisements;

public class Interstitial : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public string androidAdUnitId;
    public string iosAdUnitId;

    string adUnitId;

    private void Awake()
    {
        #if UNITY_IOS
            adUnitId = iosAdUnitId;
        #elif UNITY_ANDROID
            adUnitId = androidAdUnitId;
        #endif
    }

    #region Load
    public void LoadAd()
    {
        print("Load interstitial");
        Advertisement.Load(adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        print("Loaded interstitial");
        ShowAd();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        print("Fail to load interstitial");
    }
    #endregion

    #region Show
    public void ShowAd()
    {
        print("Show interstitial");
        Advertisement.Show(adUnitId, this);
    }
    public void OnUnityAdsShowClick(string placementId)
    {
        print("Interstitial clicked");
        ShowAd();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        print("Interstitial show complete");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        print("Interstitial show failure");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        print("Interstitial show start");
    }
    #endregion
}
