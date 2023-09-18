using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobManager : MonoBehaviour
{
    private BannerView bannerView;

    // 배너 광고 단위 ID를 여기에 입력합니다.
    private string adUnitId = "ca-app-pub-1054597906708679/8021721634";

    private void Start()
    {
        // 광고 요청을 초기화합니다.
        MobileAds.Initialize(initStatus => { });

        // 배너 광고 뷰를 생성합니다.
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        // 광고 요청을 생성합니다.
        AdRequest request = new AdRequest.Builder().Build();

        // 배너 광고를 로드하고 표시합니다.
        bannerView.LoadAd(request);
        bannerView.Show();
    }

    // 게임이 종료될 때 광고 뷰를 삭제합니다.
    private void OnDestroy()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
        }
    }
}
