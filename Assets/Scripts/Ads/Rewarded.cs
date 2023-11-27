using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class Rewarded : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public string androidAdUnitId;
    public string iosAdUnitId;

    public Text progress50;
    public Text progress75;
    public Text progress100;

    string adUnitId;

    private void Start()
    {
        progress50.text = "0/2";
        progress75.text = "0/3";
        progress100.text = "0/4";
    }

    private void Awake()
    {
#if UNITY_IOS
            adUnitId = iosAdUnitId;
#elif UNITY_ANDROID
        adUnitId = androidAdUnitId;
#endif
    }

    #region Load
    public void LoadAd(int buttonId)
    {
        var ss = new SaveLoadSystem();
        
        print("Load rewarded");
        Advertisement.Load(adUnitId, this);

        if (buttonId == 25)
        {
            ss.SaveCoins(25);
        }
        else if (buttonId == 50)
        {
            if (PlayerPrefs.GetInt("50Monete") == 1)
            {
                PlayerPrefs.SetInt("50Monete", 0);
                ss.SaveCoins(50);
            }
            else
                PlayerPrefs.SetInt("50Monete", (PlayerPrefs.GetInt("50Monete") + 1));

            progress50.text = PlayerPrefs.GetInt("50Monete").ToString() + "/2";
        }
        else if (buttonId == 75)
        {
            if (PlayerPrefs.GetInt("75Monete") == 2)
            {
                PlayerPrefs.SetInt("75Monete", 0);
                ss.SaveCoins(75);
            }
            else
                PlayerPrefs.SetInt("75Monete", (PlayerPrefs.GetInt("75Monete") + 1));

            progress75.text = PlayerPrefs.GetInt("75Monete").ToString() + "/3";
        }
        else if (buttonId == 100)
        {
            if (PlayerPrefs.GetInt("100Monete") == 3)
            {
                PlayerPrefs.SetInt("100Monete", 0);
                ss.SaveCoins(100);
            }
            else
                PlayerPrefs.SetInt("100Monete", (PlayerPrefs.GetInt("100Monete") + 1));

            progress100.text = PlayerPrefs.GetInt("100Monete").ToString() + "/4";
        }
        else
            Debug.LogError("Id errato");
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (placementId.Equals(adUnitId))
        {
            print("Loaded rewarded");
            ShowAd();
        }
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        print("Fail to load rewarded");
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
        print("Rewarded clicked");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId.Equals(adUnitId) && showCompletionState.Equals(UnityAdsCompletionState.COMPLETED))
            print("Rewarded show complete");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        print("Rewarded show failure");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        print("Rewarded show start");
    }
    #endregion
}
