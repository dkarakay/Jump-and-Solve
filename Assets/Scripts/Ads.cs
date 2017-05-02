using UnityEngine;
using System;
using System.Collections;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class Ads : MonoBehaviour {
	private InterstitialAd interstitial;
	private InterstitialAd interstitial02;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void RequestInterstitial()
	{
		// These ad units are configured to always serve test ads.
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-4225221187766585/2498808553";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-3940256099942544/4411468910";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create an interstitial.
		this.interstitial = new InterstitialAd(adUnitId);

		// Register for ad events.
		this.interstitial.OnAdLoaded += this.HandleInterstitialLoaded;
		this.interstitial.OnAdFailedToLoad += this.HandleInterstitialFailedToLoad;
		this.interstitial.OnAdOpening += this.HandleInterstitialOpened;
		this.interstitial.OnAdClosed += this.HandleInterstitialClosed;
		this.interstitial.OnAdLeavingApplication += this.HandleInterstitialLeftApplication;

		// Load an interstitial ad.
		this.interstitial.LoadAd(this.CreateAdRequest());
		}
	private AdRequest CreateAdRequest()
		{
			return new AdRequest.Builder()
			.AddTestDevice(AdRequest.TestDeviceSimulator)
		//.AddTestDevice("6529464773F8AA3599FB90BBBA0DE721")
			.AddKeyword("game")
			.SetGender(Gender.Male)
			.SetBirthday(new DateTime(1985, 1, 1))
			.TagForChildDirectedTreatment(false)
			.AddExtra("color_bg", "9B30FF")
			.Build();
		}
	public void ShowInterstitial()
		{
		if (this.interstitial.IsLoaded())		{
		this.interstitial.Show();
		}	else	{
			MonoBehaviour.print("Interstitial is not ready yet");
		}
		}
	public void RequestInterstitial02()
		{
		// These ad units are configured to always serve test ads.
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-4225221187766585/6178801755";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-3940256099942544/4411468910";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create an interstitial.
		this.interstitial02 = new InterstitialAd(adUnitId);

		// Register for ad events.
		this.interstitial02.OnAdLoaded += this.HandleInterstitialLoaded;
		this.interstitial02.OnAdFailedToLoad += this.HandleInterstitialFailedToLoad;
		this.interstitial02.OnAdOpening += this.HandleInterstitialOpened;
		this.interstitial02.OnAdClosed += this.HandleInterstitialClosed;
		this.interstitial02.OnAdLeavingApplication += this.HandleInterstitialLeftApplication;

		// Load an interstitial ad.
		this.interstitial02.LoadAd(this.CreateAdRequest());
		}

		public void ShowInterstitial02()
		{
		if (this.interstitial02.IsLoaded())		{
		this.interstitial02.Show();
		}	else	{
		MonoBehaviour.print("Interstitial is not ready yet");
		}
		}
		#region Banner callback handlers

		public void HandleAdLoaded(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleAdLoaded event received");
		}

		public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
		{
		MonoBehaviour.print("HandleFailedToReceiveAd event received with message: " + args.Message);
		}

		public void HandleAdOpened(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleAdOpened event received");
		}

		public void HandleAdClosed(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleAdClosed event received");
		}

		public void HandleAdLeftApplication(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleAdLeftApplication event received");
		}

		#endregion

		#region Interstitial callback handlers

		public void HandleInterstitialLoaded(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleInterstitialLoaded event received");
		}

		public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
		{
		MonoBehaviour.print(
		"HandleInterstitialFailedToLoad event received with message: " + args.Message);
		}

		public void HandleInterstitialOpened(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleInterstitialOpened event received");
		}

		public void HandleInterstitialClosed(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleInterstitialClosed event received");
		}

		public void HandleInterstitialLeftApplication(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleInterstitialLeftApplication event received");
		}

		#endregion

		#region Native express ad callback handlers

		public void HandleNativeExpressAdLoaded(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleNativeExpressAdAdLoaded event received");
		}

		public void HandleNativeExpresseAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
		{
		MonoBehaviour.print(
		"HandleNativeExpressAdFailedToReceiveAd event received with message: " + args.Message);
		}

		public void HandleNativeExpressAdOpened(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleNativeExpressAdAdOpened event received");
		}

		public void HandleNativeExpressAdClosed(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleNativeExpressAdAdClosed event received");
		}

		public void HandleNativeExpressAdLeftApplication(object sender, EventArgs args)
		{
		MonoBehaviour.print("HandleNativeExpressAdAdLeftApplication event received");
		}

		#endregion



}
