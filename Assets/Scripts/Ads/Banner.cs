using UnityEngine;
using UnityEngine.Advertisements;
public class Banner : MonoBehaviour
{
    public string androidAdUnitId;
    public string iosAdUnitId;

    string adUnitId;

    BannerPosition bannerPosition = BannerPosition.BOTTOM_CENTER;

    private void Start()
    {
        #if UNITY_IOS
            adUnitId = iosAdUnitId;
        #elif UNITY_ANDROID
            adUnitId = androidAdUnitId;
        #endif

        Advertisement.Banner.SetPosition(bannerPosition);
    }

    #region Load
    public void LoadBanner()
    {
        BannerLoadOptions opt = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerLoadError
        };

        Advertisement.Banner.Load(adUnitId, opt);
    }

    void OnBannerLoaded()
    {
        print("Banner loaded");
        ShowBannerAd();
    }

    void OnBannerLoadError(string error)
    {
        print("Errore: " + error);
    }
    #endregion

    #region Show
    public void ShowBannerAd()
    {
        BannerOptions opt = new BannerOptions
        {
            showCallback = OnBannerShow,
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden
        };

        Advertisement.Banner.Show(adUnitId, opt);
    }

    void OnBannerShow()
    {

    }

    void OnBannerClicked()
    {

    }

    void OnBannerHidden()
    {

    }
    #endregion

    #region Hide
    public void HidenBannerAd()
    {
        Advertisement.Banner.Hide();
    }
    #endregion
}
