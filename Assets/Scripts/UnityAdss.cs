using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class UnityAdss : MonoBehaviour{

	public GameObject theGoldAd;

	void Start(){
		Advertisement.Initialize("1187358",true);
	}
	public void ClickForMoney(){
		//StartCoroutine ("loadingAd");
		ShowRewardedAd();
	}
	/*IEnumerator loadingAd(){
		while(!Advertisement.IsReady("rewardedVideo")){
			yield return null;
		}
		ShowRewardedAd ();
	}*/
	public void ShowAd()
	{
		if (Advertisement.IsReady("rewardDeath"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult2 };
			Advertisement.Show("rewardDeath", options);
		}
	}
	public void ShowRewardedAd()
	{
		if (Advertisement.IsReady("rewardedVideo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
		}
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log ("The ad was successfully shown.");
			PlayerPrefs.SetInt ("CoinBronze", PlayerPrefs.GetInt ("CoinBronze") + 20);
			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			break;
		}
	}
	private void HandleShowResult2(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log ("The ad was successfully shown.");
			PlayerPrefs.SetInt ("CoinGold", PlayerPrefs.GetInt ("CoinGold") + 20);
			theGoldAd.SetActive (false);
			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			break;
		}
	}
}