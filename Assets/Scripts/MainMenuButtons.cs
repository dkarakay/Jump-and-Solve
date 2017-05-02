using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using SmartLocalization;
using UnityEngine.Advertisements;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;

public class MainMenuButtons : MonoBehaviour {
	public GameObject Play,panel4,achievementButton,LeaderButton,AdsButton;
	public GameObject CreditsPanel;
	public GameObject Highscore;
	public GameObject BG;
	public GameObject textLoading;
	public GameObject textDK;
	public GameObject shopButton,LangPanel,LangPanelFirst,langClose;
	public GameObject panelSettings;
	public GameObject settingsButton;
	//float sleepUntil = 0;
	//public GameObject[] FBScreen;
	public GameObject d;
	public GameObject muteSoundSprite, muteMusicSprite, musicSprite, soundSprite;
	//public GameObject flagTR, flagEN;

	public Vector3 lastGroundedPos;
	public UnityAdss theAdsUnity;
	public AudioClip backgroundMusic;
	public float musicSound,soundEffect;
	public int dk = 0;
	// Use this for initialization
	private float muteFloat,muteEffectFloat;


	void Awake(){
		Sign ();
	}
	void Start () {
	//	Vungle.init("5815fa0c2717a0c91d0001cc","Test_iOS", "Test_Windows");

		//PlayGamesPlatform.Instance.Authenticate(SignInCallback, true);
	/*	if (!Social.localUser.authenticated) {
			Social.localUser.Authenticate ((bool success) => {
		
			});
		}*/
		Debug.Log ("Question:: " + PlayerPrefs.GetInt ("QuestionCorrect"));
		CreditsPanel.SetActive (false);
		musicSound = PlayerPrefs.GetFloat ("MusicSound");
		soundEffect = PlayerPrefs.GetFloat ("SoundEffect");
		MundoSound.Play (backgroundMusic,(musicSound),true);
		if (PlayerPrefs.GetInt ("dkStart") == 0) {
			StartCoroutine ("StartGame");
		}
	}
	void Update(){	

		if (PlayerPrefs.GetInt ("languageSelection") == 0) {
			LanguageManager.Instance.ChangeLanguage ("en");
		} else if (PlayerPrefs.GetInt ("languageSelection") == 1) {
			LanguageManager.Instance.ChangeLanguage ("tr");
		} else if (PlayerPrefs.GetInt ("languageSelection") == 2) {
			LanguageManager.Instance.ChangeLanguage ("de");	
		} else {
			LanguageManager.Instance.ChangeLanguage ("en");
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			CloseApp ();
		}
		muteFloat = PlayerPrefs.GetFloat ("MusicSound");
		muteEffectFloat = PlayerPrefs.GetFloat ("SoundEffect");
		if (muteFloat != 0f) {
			muteMusicSprite.SetActive (false);
			musicSprite.SetActive (true);
		} else {
			musicSprite.SetActive (false);
			muteMusicSprite.SetActive (true);
		}
		if (muteEffectFloat == 0f) {
			soundSprite.SetActive (false);
			muteSoundSprite.SetActive (true);
		} else {
			muteSoundSprite.SetActive (false);
			soundSprite.SetActive (true);
		}
	}

	public void ButtonStart(){
		StartCoroutine ("load");
	}
	public IEnumerator load(){		
		dk += 1;
		PlayerPrefs.SetString ("Playy","start");
		Play.SetActive(false);
		Highscore.SetActive(false);
		shopButton.SetActive (false);
		/*FBScreen[0].SetActive (false);
		FBScreen[1].SetActive (false);
		FBScreen[2].SetActive (false);*/
		textLoading.SetActive (true);
		settingsButton.SetActive (false);
		AdsButton.SetActive (false);
		achievementButton.SetActive (false);
		LeaderButton.SetActive (false);
		Debug.Log("Notification 1 Active");
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene ("Run");
	}
	public IEnumerator StartGame(){	
		PlayerPrefs.SetInt("dkStart",1);
		Play.SetActive(false);
		/*FBScreen[0].SetActive (false);
		FBScreen[1].SetActive (false);
		FBScreen[2].SetActive (false);*/
		Highscore.SetActive(false);
		BG.SetActive (false);
		shopButton.SetActive (false);
		settingsButton.SetActive (false);
		AdsButton.SetActive (false);
		achievementButton.SetActive (false);
		LeaderButton.SetActive (false);
		textDK.SetActive (true);
		yield return new WaitForSeconds(3f);
		shopButton.SetActive (true);
		Play.SetActive(true);
		/*FBScreen[0].SetActive (true);
		FBScreen[1].SetActive (true);*/
		Highscore.SetActive(true);
		BG.SetActive (true);
		AdsButton.SetActive (true);
		achievementButton.SetActive (true);
		LeaderButton.SetActive (true);
		textDK.SetActive (false);
		settingsButton.SetActive (true);
		if (PlayerPrefs.GetInt ("languageSelected") == 0) {	
			LangFirstOpen ();
		}


	}
	public void NotificationButton(){
		/*LocalNotification.SendNotification(1, 10, "Title", "Long exact message text", new Color32(0xff, 0x44, 0x44, 0), executeMode: LocalNotification.NotificationExecuteMode.ExactAndAllowWhileIdle);
		sleepUntil = Time.time + 10;
		LocalNotification.SendNotification(1, 15, "Can you solve?", "Try and see :)", new Color32(0xff, 0x44, 0x44, 0), true, true, true, "app_icon");
		sleepUntil = Time.time + 15;
		LocalNotification.SendRepeatingNotification(1, 900, 36000, "Can you solve?", "Try and see :)", new Color32(0xff, 0x44, 0x44, 255),true,false,true);
		sleepUntil = Time.time + 99999;*/

	}
	public void ShopButton(){
	/*	LocalNotification.CancelNotification(1);
		/sleepUntil = 0;*/
		SceneManager.LoadScene ("Shop");
	}
	public void SettingsButton(){
		settingsButton.SetActive (false);
		shopButton.SetActive (false);
		panelSettings.SetActive (true);
		AdsButton.SetActive (false);
		achievementButton.SetActive (false);
		LeaderButton.SetActive (false);
	}
	public void MuteButton(){
		PlayerPrefs.SetString ("MuteActive", "active");
		muteFloat = PlayerPrefs.GetFloat ("MusicSound");
		if (muteFloat == 0.5f) {
			PlayerPrefs.SetFloat ("MusicSound", 0);
			Debug.Log ("Music OFF!");
			musicSprite.SetActive (false);
			muteMusicSprite.SetActive (true);
		} else if (muteFloat == 0f) {
			PlayerPrefs.SetFloat ("MusicSound",  0.5f);
			Debug.Log ("Music ON!");
			muteMusicSprite.SetActive (false);
			musicSprite.SetActive (true);
		}
	}
	public void MuteEffectButton(){
		PlayerPrefs.SetString ("MuteEffectActive", "active");
		muteEffectFloat = PlayerPrefs.GetFloat ("SoundEffect");
		if (muteEffectFloat == 1f) {
			PlayerPrefs.SetFloat ("SoundEffect", 0);
			Debug.Log ("Sound Effect OFF!");
			soundSprite.SetActive (false);
			muteSoundSprite.SetActive (true);

		} else if (muteEffectFloat == 0f) {
			PlayerPrefs.SetFloat ("SoundEffect", 1);
			Debug.Log ("Sound Effect ON!");
			muteSoundSprite.SetActive (false);
			soundSprite.SetActive (true);
		}
	}
	public void SaveButton(){
		panelSettings.SetActive (false);
		settingsButton.SetActive (true);
		shopButton.SetActive (true);
		AdsButton.SetActive (true);
		achievementButton.SetActive (true);
		LeaderButton.SetActive (true);
		SceneManager.LoadScene ("MainMenu");
	}
	private void ResetApp(){
		PlayerPrefs.SetString ("FirstStartB","on");
		PlayerPrefs.SetString ("FirstStartG","on");
		PlayerPrefs.SetString ("CharacterOn","off");
		PlayerPrefs.SetString ("SelectedTile","off");
		PlayerPrefs.SetString ("SelectedBG","off");
		PlayerPrefs.SetString ("MuteActive","off");
		PlayerPrefs.SetInt ("lannf",0);		
		PlayerPrefs.SetInt ("aaww",0);		
		PlayerPrefs.SetInt ("aawwQ",0);		
		PlayerPrefs.SetString ("MuteEffectActive","off");
		for (int i = 0; i < 36; i++) {
			PlayerPrefs.SetString ("Bought" + i, "no");
		}
		PlayerPrefs.SetFloat ("HScore", 0);
		OKPanel();
	}
	public void Credits(){
		Social.ReportProgress(AchievementsJS.achievement_thanks_, 100.0f, (bool success) => {
			// handle success or failure
		});
		CreditsPanel.SetActive (true);
	}
	public void CloseCredits(){
		CreditsPanel.SetActive (false);
	}

	public void CloseApp(){
		PlatformDialog.SetButtonLabel(LanguageManager.Instance.GetTextValue("Yes"), LanguageManager.Instance.GetTextValue("No"));
		PlatformDialog.Show(
			LanguageManager.Instance.GetTextValue("Warning"),
			LanguageManager.Instance.GetTextValue("GoodPerson"), 
			PlatformDialog.Type.OKCancel, 
			() => {
				Debug.Log("Yes");
				PlatformDialog.Dismiss();
			},
			() => {
				Debug.Log("No");							
				/*LocalNotification.SendRepeatingNotification(2, 15, 60, "Can you solve?", "Try and see :)", new Color32(0xff, 0x44, 0x44, 255),true,false,true);
				sleepUntil = Time.time + 99999;*/
				Debug.Log("Notification 2 Active");
				Application.Quit();
			}
		);
	}
	public void ResetSure(){
		PlatformDialog.SetButtonLabel(LanguageManager.Instance.GetTextValue("Yes"), LanguageManager.Instance.GetTextValue("No"));
		PlatformDialog.Show(
			LanguageManager.Instance.GetTextValue("Warning"),
			LanguageManager.Instance.GetTextValue("Reset"), 
			PlatformDialog.Type.OKCancel, 
			() => {
				Debug.Log("Yes");
				Debug.Log("TrueReset");
				ResetApp();

			},
			() => {
				Debug.Log("No");							
				/*LocalNotification.SendRepeatingNotification(2, 15, 60, "Can you solve?", "Try and see :)", new Color32(0xff, 0x44, 0x44, 255),true,false,true);
				sleepUntil = Time.time + 99999;*/
				Debug.Log("FalseReset");
				PlatformDialog.Dismiss();

			}
		);
	}private void OKPanel(){
		PlatformDialog.SetButtonLabel(LanguageManager.Instance.GetTextValue("OK"));
		PlatformDialog.Show(
			LanguageManager.Instance.GetTextValue("Warning"),
			LanguageManager.Instance.GetTextValue("Restart"), 
			PlatformDialog.Type.SubmitOnly, 
			() => {
				Debug.Log("OK");
				Application.Quit();
			},
			null
		);
	}public void LanguageDE(){
		PlayerPrefs.SetInt ("languageSelected", 1);
		LanguageManager.Instance.ChangeLanguage ("de");
		PlayerPrefs.SetInt ("languageSelection", 2);
		PlayerPrefs.SetInt ("lannf",1);		
		LangClose();
	}public void LanguageTR(){
		PlayerPrefs.SetInt ("languageSelected", 1);
		LanguageManager.Instance.ChangeLanguage ("tr");
		PlayerPrefs.SetInt ("languageSelection", 1);
		PlayerPrefs.SetInt ("lannf",1);		
		LangClose();

	//	SceneManager.LoadScene ("DK");
	}public void LanguageEN(){
		PlayerPrefs.SetInt ("languageSelected", 1);
		LanguageManager.Instance.ChangeLanguage("en");
		PlayerPrefs.SetInt ("languageSelection", 0);
		PlayerPrefs.SetInt ("lannf",1);	
		LangClose();
	}public void LanguageDEFirst(){
		PlayerPrefs.SetInt ("languageSelected", 1);
		LanguageManager.Instance.ChangeLanguage ("de");
		PlayerPrefs.SetInt ("languageSelection", 2);
		PlayerPrefs.SetInt ("lannf",1);		
		Play.SetActive(true);
		Highscore.SetActive(true);
		shopButton.SetActive (true);
		AdsButton.SetActive (true);
		achievementButton.SetActive (true);
		LeaderButton.SetActive (true);
		settingsButton.SetActive (true);
		LangPanelFirst.SetActive(false);

	}public void LanguageTRFirst(){
			PlayerPrefs.SetInt ("languageSelected", 1);
			LanguageManager.Instance.ChangeLanguage ("tr");
			PlayerPrefs.SetInt ("languageSelection", 1);
			PlayerPrefs.SetInt ("lannf",1);		
		Play.SetActive(true);
		Highscore.SetActive(true);
		shopButton.SetActive (true);
		AdsButton.SetActive (true);
		achievementButton.SetActive (true);
		LeaderButton.SetActive (true);
		settingsButton.SetActive (true);
		LangPanelFirst.SetActive(false);


			//	SceneManager.LoadScene ("DK");
		}public void LanguageENFirst(){
			PlayerPrefs.SetInt ("languageSelected", 1);
			LanguageManager.Instance.ChangeLanguage("en");
			PlayerPrefs.SetInt ("languageSelection", 0);
			PlayerPrefs.SetInt ("lannf",1);	
		Play.SetActive(true);
		Highscore.SetActive(true);
		shopButton.SetActive (true);
		settingsButton.SetActive (true);
		AdsButton.SetActive (true);
		achievementButton.SetActive (true);
		LeaderButton.SetActive (true);
		LangPanelFirst.SetActive(false);



			//	SceneManager.LoadScene ("DK");
	}public void LanguageOpen(){
		LangPanel.SetActive(true);
		panelSettings.SetActive(false);
		langClose.SetActive(true);

	}public void LangClose(){
		LangPanel.SetActive(false);
		panelSettings.SetActive(true);

	}public void LangFirstOpen(){
		Play.SetActive(false);
		Highscore.SetActive(false);
		shopButton.SetActive (false);
		textLoading.SetActive (false);
		settingsButton.SetActive (false);
		AdsButton.SetActive (false);
		achievementButton.SetActive (false);
		LeaderButton.SetActive (false);
		LangPanelFirst.SetActive(true);
		langClose.SetActive(false);


	
	}public void RequestAD(){
		//Vungle.playAd();
	}
	public void Achievements(){
		if (Social.localUser.authenticated) {
			Social.ShowAchievementsUI ();
		} else {


		}
	}
	private void SignInCallback(bool success){
		if (success){				
		}else{
			Sign ();
		}
	}
	public void Leaderboards(){
		int score = (int) Mathf.Round(PlayerPrefs.GetFloat ("HScore"));
		int q = PlayerPrefs.GetInt ("QuestionCorrect");
		Social.ReportScore (score, AchievementsJS.leaderboard_highscore, (bool success) => {});
		Social.ReportScore (q, AchievementsJS.leaderboard_correct_answer, (bool success) => {});
		if (Social.localUser.authenticated) {
			//PlayGamesPlatform.Instance.ShowLeaderboardUI(AchievementsJS.leaderboard_highscore);
			Social.ShowLeaderboardUI ();
		} else {
			Sign ();
		}
	}
	public void MoneyHack(){
		PlatformDialog.SetButtonLabel(LanguageManager.Instance.GetTextValue("OK"));
		PlatformDialog.Show(
			"Money Hack",
			"Added 1000 Gold Thanks", 
			PlatformDialog.Type.SubmitOnly, 
			() => {
				PlayerPrefs.SetInt("CoinGold",PlayerPrefs.GetInt("CoinGold") + 1000);
				Debug.Log("OK");
			},
			null
		);	// handle success or failure
	}


 
	public void Sign(){
		Social.localUser.Authenticate((bool success) => {
			if(!success){
				PlatformDialog.SetButtonLabel(LanguageManager.Instance.GetTextValue("OK"));
				PlatformDialog.Show(
					LanguageManager.Instance.GetTextValue("Warning"),
					LanguageManager.Instance.GetTextValue("Unable"), 
					PlatformDialog.Type.SubmitOnly, 
					() => {
						Debug.Log("OK");
					},
					null
				);	// handle success or failure
			}
		});
	}
}
