using UnityEngine;
using System.Collections;
using SmartLocalization;
using UnityEngine.UI;

public class TextShop : MonoBehaviour {
	public Text no,yes,collectMoney,sure,ok,ok1,ok2,maximum,maximum2;
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

		no.text = LanguageManager.Instance.GetTextValue ("No");
		yes.text = LanguageManager.Instance.GetTextValue ("Yes");
		ok.text = LanguageManager.Instance.GetTextValue ("OK");
		ok1.text = LanguageManager.Instance.GetTextValue ("OK");
		ok2.text = LanguageManager.Instance.GetTextValue ("OK");
		sure.text = LanguageManager.Instance.GetTextValue ("AreYouSure");
		collectMoney.text = LanguageManager.Instance.GetTextValue ("PleaseCollect");
		maximum.text = LanguageManager.Instance.GetTextValue ("Maximum");
		maximum2.text = LanguageManager.Instance.GetTextValue ("Maximum");
	}
}
