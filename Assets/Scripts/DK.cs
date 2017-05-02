using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using SmartLocalization;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;

public class DK : MonoBehaviour {

	// Use this for initialization
	void Start () {	
		PlayGamesClientConfiguration config = 
			new PlayGamesClientConfiguration.Builder().Build();
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.InitializeInstance(config);
		PlayGamesPlatform.Activate();
		if (PlayerPrefs.GetInt ("lannf") == 1) {			
		} else {
			PlayerPrefs.SetInt ("languageSelected", 0);
		}

		if (PlayerPrefs.GetInt ("languageSelected") == 1) {			
		} else {
			PlayerPrefs.SetInt ("languageSelection", 0);
		}

		if (PlayerPrefs.GetInt ("aaww") == 1) {
		} else {
			PlayerPrefs.SetInt ("PlayedTimes", 0);
		}
		if (PlayerPrefs.GetInt ("aawwQ") == 1) {
		} else {
			PlayerPrefs.SetInt ("QuestionCorrect", 0);
		}

		if (PlayerPrefs.GetInt ("languageSelection") == 0) {
			LanguageManager.Instance.ChangeLanguage ("en");
		} else if (PlayerPrefs.GetInt ("languageSelection") == 1) {
			LanguageManager.Instance.ChangeLanguage ("tr");		
		}else if (PlayerPrefs.GetInt ("languageSelection") == 2) {
			LanguageManager.Instance.ChangeLanguage ("de");		
		}
		//PlayerPrefs.SetString ("SelectedBG", "off");
		//PlayerPrefs.SetString ("SelectedTile", "off");
		/*PlayerPrefs.SetInt ("selectedThickCharacter", 0);
		PlayerPrefs.SetInt ("CharacterSelected", 0);
		PlayerPrefs.SetString ("Bought1", "no");
		PlayerPrefs.SetString ("Bought2", "no");
		PlayerPrefs.SetString ("Bought3", "no");
		PlayerPrefs.SetString ("Bought4", "no");
		PlayerPrefs.SetString ("Bought5", "no");
		PlayerPrefs.SetString ("Bought6", "no");
		PlayerPrefs.SetString ("Bought7", "no");
		PlayerPrefs.SetString ("Bought8", "no");
		PlayerPrefs.SetString ("Bought9", "no");
		PlayerPrefs.SetString ("Bought10", "no");
		PlayerPrefs.SetString ("Bought11", "no");
		PlayerPrefs.SetString ("Bought12", "no");
		PlayerPrefs.SetString ("Bought13", "no");
		PlayerPrefs.SetString ("Bought14", "no");
		PlayerPrefs.SetString ("Bought15", "no");
		PlayerPrefs.SetString ("Bought16", "no");
		PlayerPrefs.SetString ("Bought17", "no");
		PlayerPrefs.SetString ("Bought18", "no");
		PlayerPrefs.SetString ("Bought19", "no");
		PlayerPrefs.SetString ("Bought0", "no");*/

//		PlayerPrefs.SetString ("IBoughtCharacter " + i , "yes" );

		/*for (int i = 0; i < 36; i++) {
			PlayerPrefs.SetString ("Bought" + i,"no");
		}*/

		//LocalNotification.CancelNotification (1);
		PlayerPrefs.SetInt ("dkStart", 0);
		PlayerPrefs.SetString("FBScreenFirst","active");
		if (PlayerPrefs.GetString ("FirstStartG") == "off") {
		} else {
			PlayerPrefs.SetInt ("CoinGold", 0);	
			PlayerPrefs.SetInt ("CoinGoldAllTime", 0);		
		}
		if (PlayerPrefs.GetString ("FirstStartB") == "off") {
		} else {			
			PlayerPrefs.SetInt ("CoinBronze", 0);
			PlayerPrefs.SetInt ("CoinBronzeAllTime", 0);		
		}

		if (PlayerPrefs.GetString ("CharacterOn") == "on") {
		} else {
			PlayerPrefs.SetInt ("CharacterSelected", 0);
			PlayerPrefs.SetInt ("selectedThickCharacter", 0);
		}if (PlayerPrefs.GetString ("SelectedTile") == "on") {
		} else {
			PlayerPrefs.SetInt ("selectedTile",5);
			PlayerPrefs.SetInt ("selectedThickTile", 5);
		}if (PlayerPrefs.GetString ("SelectedBG") == "on") {
			//PlayerPrefs.SetInt ("selectedBG",2);
		} else {
			PlayerPrefs.SetInt ("selectedBG",2);
		}	PlayerPrefs.SetInt ("selectedThickBG", 2);

		if (PlayerPrefs.GetString ("MuteActive") == "active") {		
		} else {
			PlayerPrefs.SetFloat ("MusicSound", 0.5f);
		}

		if (PlayerPrefs.GetString ("MuteEffectActive") == "active") {
		} else {
			PlayerPrefs.SetFloat ("SoundEffect", 1);
		}
		if (PlayerPrefs.GetString ("FBScreenFirst") == "active") {
			PlayerPrefs.SetInt ("FBScreen", 1);
			Debug.Log ("1");
		} else {
			PlayerPrefs.SetInt ("FBScreen", 0);
			Debug.Log ("0");
		}


			
		StartCoroutine ("dk");
	}

	// Update is called once per frame
	void Update () {
	
	}
	public IEnumerator dk(){
		yield return new WaitForSeconds(0.1f);
		SceneManager.LoadScene ("MainMenu");
	}
}
