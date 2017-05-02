using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SmartLocalization;
public class HighScoreText : MonoBehaviour {	
	public Text HS;
	public Text Loading;
	public Text Credits;
	// Use this for initialization
	void Start () {
		

	//	HS.text = "Highscore: " + (PlayerPrefs.GetFloat ("HScore"));
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("languageSelection") == 0) {
			LanguageManager.Instance.ChangeLanguage ("en");
		} else if (PlayerPrefs.GetInt ("languageSelection") == 1) {
			LanguageManager.Instance.ChangeLanguage ("tr");	
		} else if (PlayerPrefs.GetInt ("languageSelection") == 2) {
			LanguageManager.Instance.ChangeLanguage ("de");		
		}
		/*} else {
			LanguageManager.Instance.ChangeLanguage ("en");
		}*/
		//PlayerPrefs.SetFloat ("HScore",0);	
		if (PlayerPrefs.HasKey ("HScore")) {			
			HS.text = LanguageManager.Instance.GetTextValue ("Highscore") + Mathf.Round(PlayerPrefs.GetFloat ("HScore"));
		}
		Loading.text = LanguageManager.Instance.GetTextValue ("Loading");
		Credits.text = LanguageManager.Instance.GetTextValue ("Credits");
	}

}
