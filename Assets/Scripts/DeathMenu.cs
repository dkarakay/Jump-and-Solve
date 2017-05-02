using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;

public class DeathMenu : MonoBehaviour {

	public Ads theAds;
	public GameManager theManager;
	public GameObject threeSeconds;
	public GameObject thePause;
	//float sleepUntil = 0;
	private int GCoin,BCoin;
	public CoinTextGenerator theCoinText;
	void Start(){
		PlayerPrefs.SetInt ("aawwQ", 1);
		PlayerPrefs.SetInt("QuestionCorrect",PlayerPrefs.GetInt("QuestionCorrect")+PlayerPrefs.GetInt("AchQ"));
		PlayerPrefs.SetInt ("aaww", 1);
		PlayerPrefs.SetInt ("PlayedTimes", PlayerPrefs.GetInt ("PlayedTimes") + 1);
		if (PlayerPrefs.GetInt ("QuestionCorrect") >= 50) {
			Social.ReportProgress(AchievementsJS.achievement_50_correct_answer, 100.0f, (bool success) => {});
		}
		if (PlayerPrefs.GetInt ("QuestionCorrect") >= 100) {
			Social.ReportProgress(AchievementsJS.achievement_100_correct_answer, 100.0f, (bool success) => {});
		}
		if (PlayerPrefs.GetInt ("QuestionCorrect") >= 200) {
			Social.ReportProgress(AchievementsJS.achievement_200_correct_answer, 100.0f, (bool success) => {});
		}
		if (PlayerPrefs.GetInt ("QuestionCorrect") >= 500) {
			Social.ReportProgress(AchievementsJS.achievement_500_correct_answer, 100.0f, (bool success) => {});
		}

		if (PlayerPrefs.GetInt ("PlayedTimes") >= 10) {
			Social.ReportProgress(AchievementsJS.achievement_newbie_player, 100.0f, (bool success) => {});
		}
		if (PlayerPrefs.GetInt ("PlayedTimes") >= 25) {
			Social.ReportProgress(AchievementsJS.achievement_amateur_player, 100.0f, (bool success) => {});
		}
		if (PlayerPrefs.GetInt ("PlayedTimes") >= 100) {
			Social.ReportProgress(AchievementsJS.achievement_good_player, 100.0f, (bool success) => {});
		}
		if (PlayerPrefs.GetInt ("PlayedTimes") >= 500) {
			Social.ReportProgress(AchievementsJS.achievement_real_player, 100.0f, (bool success) => {});
		}

		Social.ReportProgress(AchievementsJS.achievement_first_death_, 100.0f, (bool success) => {
			// handle success or failure
		});
		float b = Mathf.Round (Random.Range (0f, 1f)); 
		if (b == 1f) {
			theAds.ShowInterstitial02 ();
		}
		if (theCoinText.coinGold != 0) {
			PlayerPrefs.SetString ("FirstStartG", "off");	
		} else if (theCoinText.coinBronze != 0) {			
			PlayerPrefs.SetString ("FirstStartB","off");
		}
		GCoin = PlayerPrefs.GetInt ("CoinGold");
		BCoin = PlayerPrefs.GetInt ("CoinBronze");
		threeSeconds.SetActive (false);
		thePause.SetActive (false);
		PlayerPrefs.SetInt ("CoinBronze", BCoin + theCoinText.coinBronze);
		PlayerPrefs.SetInt ("CoinGold", GCoin + theCoinText.coinGold);
		if (PlayerPrefs.GetInt ("CoinGold") > 50) {
			Social.ReportProgress(AchievementsJS.achievement_gold_collector, 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		if (PlayerPrefs.GetInt ("CoinBronze") > 50) {
			Social.ReportProgress(AchievementsJS.achievement_bronze_collector, 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		if (PlayerPrefs.GetInt ("CoinBronze") > 100 && PlayerPrefs.GetInt ("CoinGold") > 100) {
			Social.ReportProgress(AchievementsJS.achievement_real_collector, 100.0f, (bool success) => {
				// handle success or failure
			});
		}
	}

	public void RestartGame(){
		theManager.Reset ();	
	}
	public void GoToMain(){
		SceneManager.LoadScene ("MainMenu");
	}
}
