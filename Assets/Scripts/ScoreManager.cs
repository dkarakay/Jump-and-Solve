using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using SmartLocalization;

public class ScoreManager : MonoBehaviour {
	public Text scoreText;
	public Text hiScoreText;

	public float scoreCount;
	public float scoreCountL;
	public float hiScoreCount;

	public float pointsPerSecond;

	public bool scoreIncreasing;
	public CoinTextGenerator theCoinText;

	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetFloat ("HScore", 0);
		PlayerPrefs.SetInt ("Starter", 0);
		scoreCount = 0;
		hiScoreCount = PlayerPrefs.GetFloat ("HScore");
	
	
	}
	
	// Update is called once per frame
	void Update () {
		
			if (scoreIncreasing) {
			if (PlayerPrefs.GetInt ("languageSelection") == 0) {
				LanguageManager.Instance.ChangeLanguage ("en");
			} else if (PlayerPrefs.GetInt ("languageSelection") == 1) {
				LanguageManager.Instance.ChangeLanguage ("tr");			
			} else if (PlayerPrefs.GetInt ("languageSelection") == 2) {
				LanguageManager.Instance.ChangeLanguage ("de");		
			} else {
				LanguageManager.Instance.ChangeLanguage ("en");
			}

			scoreCount += pointsPerSecond * Time.deltaTime;
			scoreCountL = scoreCount;
			scoreText.text = LanguageManager.Instance.GetTextValue("Score") + Mathf.Round (scoreCount);
			}
			
			/*if (scoreCount > hiScoreCount) {
				PlayerPrefs.SetFloat ("HScore", hiScoreCount);	
			}*/
			
//			hiScoreText.text = "Highscore: " + Mathf.Round (hiScoreCount);

			


	}
	public void AddScore(int pointsToAdd){
		scoreCount += pointsToAdd;
	}

}
