using UnityEngine;
using System.Collections;
using SmartLocalization;
using UnityEngine.UI;
public class TextRun : MonoBehaviour {
	public Text tryAgain;
	public Text paused;
	public Text score;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("languageSelection") == 0) {
			LanguageManager.Instance.ChangeLanguage ("en");
		} else if (PlayerPrefs.GetInt ("languageSelection") == 1) {
			LanguageManager.Instance.ChangeLanguage ("tr");
		} else if (PlayerPrefs.GetInt ("languageSelection") == 2) {
			LanguageManager.Instance.ChangeLanguage ("de");			
		} else {
			LanguageManager.Instance.ChangeLanguage ("en");
		}

		tryAgain.text = LanguageManager.Instance.GetTextValue ("TryAgain");
		paused.text = LanguageManager.Instance.GetTextValue ("Paused");
		score.text = LanguageManager.Instance.GetTextValue ("Scoree");

	}
}
