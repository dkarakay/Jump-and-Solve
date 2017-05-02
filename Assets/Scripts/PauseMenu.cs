using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using SmartLocalization;

public class PauseMenu : MonoBehaviour {
	public Text ThreeSec,remainingQuestion;
	public GameObject three;
	public string mainMenuLevel = "MainMenu";
	public GameManager theManager;
	public GameObject pauseMenu;
	public GameObject pauseButton;
	public Vector3 b;
	public float a,q;
	public GameObject thisIsYourLastToContinue;
	public GameObject theDead;

	public AudioClip backgroundMusic;

	public Ads theAds;

	public Image remainBG;
	public GameObject remainBGG;
	public int remainingQ;

	public PlayerController thePlayerBlue;
	public PlayerController thePlayerRed;
	public PlayerController thePlayerGreen;
	public PlayerController thePlayerGrey;
	public PlayerController thePlayerAlienBlue;
	public PlayerController thePlayerTruckRed;
	public PlayerController thePlayerTruckYellow;
	public PlayerController thePlayerDiskRed;
	public PlayerController thePlayerTruckBlue;
	public PlayerController thePlayerTruckGreen;

	public PlayerController thePlayerBlueReverse;
	public PlayerController thePlayerRedReverse;
	public PlayerController thePlayerGreenReverse;
	public PlayerController thePlayerGreyReverse;
	public PlayerController thePlayerAlienYellow;
	public PlayerController thePlayerAlienBiege;
	public PlayerController thePlayerAlienPink;
	public PlayerController thePlayerAlienDarkBlue;
	public PlayerController thePlayerDevil;
	public int minus;
	public int selectCharacter,selectedBackground;
	public int minusX = 3;
	public float minusPlayer;
	public ScoreManager theScore;
	public Questions theQuestions;
	public GameObject QuestionPanel;
	public float posx,posy,speedPos,soundEffect;
	public Vector3 lastChance;

	void Start(){
		PlayerPrefs.SetInt ("AchQ", 0);
		q = Mathf.Round (Random.Range (-0.5f,3.5f));
		soundEffect = PlayerPrefs.GetFloat ("SoundEffect");
		//theScroll = FindObjectOfType<Scrolling> ();
		selectCharacter = PlayerPrefs.GetInt ("CharacterSelected");
		selectedBackground = PlayerPrefs.GetInt ("selectedBG");
	}
	void Update(){
		if (PlayerPrefs.GetInt ("AchQ") == 5) {
			Social.ReportProgress(AchievementsJS.achievement_all_right, 100.0f, (bool success) => {
				// handle success or failure
			});
		}

		if (PlayerPrefs.GetInt ("languageSelection") == 0) {
			LanguageManager.Instance.ChangeLanguage ("en");
		} else if (PlayerPrefs.GetInt ("languageSelection") == 1) {
			LanguageManager.Instance.ChangeLanguage ("tr");
		} else if (PlayerPrefs.GetInt ("languageSelection") == 2) {
			LanguageManager.Instance.ChangeLanguage ("de");		
		} else {
			LanguageManager.Instance.ChangeLanguage ("en");
		}

		speedPos = PlayerPrefs.GetFloat ("moveSpeed");
		if (speedPos > 11f && speedPos < 14f) {
			posx = 4.5f;
			posy = 1f;
		} else if (speedPos <= 8f) {
			posx = 1.5f;
			posy = 0.5f;
		} else if (speedPos <= 11f && speedPos <= 10f) {
			posx = 3f;
			posy = 1f;
		}else if (speedPos >= 14f) {
			posx = 6.5f;
			posy = 1f;
		
		}else{
				posx = 2.5f;
				posy = 0.5f;

			}

		if (PlayerPrefs.GetInt ("ESC") == 0) {
			if (Input.GetKeyUp (KeyCode.Escape)) {
				PlayerPrefs.SetInt ("ESC",1);
				Debug.Log ("Resume");
					ResumeGame ();

			}
		}

	}
	public void RestartGame(){
		PlayerPrefs.SetInt ("noStuck", 0);
		PlayerPrefs.SetInt ("Starter", 1);
		Time.timeScale = 1f;
		thePlayerBlue.moveSpeed = 7;
		thePlayerRed.moveSpeed = 7;
		thePlayerGreen.moveSpeed = 7;
		thePlayerGrey.moveSpeed = 7;
		thePlayerBlueReverse.moveSpeed = 7;
		thePlayerGreenReverse.moveSpeed = 7;
		thePlayerGreyReverse.moveSpeed = 7;
		thePlayerRedReverse.moveSpeed = 7;
		thePlayerDevil.moveSpeed = 7;
		thePlayerAlienBiege.moveSpeed = 7;
		thePlayerAlienBlue.moveSpeed = 7;
		thePlayerAlienDarkBlue.moveSpeed = 7;
		thePlayerAlienPink.moveSpeed = 7;
		thePlayerAlienYellow.moveSpeed = 7;
		thePlayerTruckBlue.moveSpeed = 7;
		thePlayerTruckGreen.moveSpeed = 7;
		thePlayerTruckRed.moveSpeed = 7;
		thePlayerTruckYellow.moveSpeed = 7;
		thePlayerDiskRed.moveSpeed = 7;

		pauseMenu.SetActive (false);

		PlayerPrefs.SetFloat ("TimeAdded", 0);
		pauseButton.SetActive (false);
		switch (selectCharacter) {
		case 0:
			thePlayerBlue.gameObject.SetActive (false);			
			break;
		case 1:
			thePlayerRed.gameObject.SetActive (false);		
			break;
		case 2:
			thePlayerGreen.gameObject.SetActive (false);			
			break;
		case 3:
			thePlayerGrey.gameObject.SetActive (false);	
			break;
		case 4:
			thePlayerAlienBlue.gameObject.SetActive (false);	
			break;
		case 5:
			thePlayerTruckRed.gameObject.SetActive (false);			
			break;
		case 6:
			thePlayerTruckYellow.gameObject.SetActive (false);
			break;
		case 7:
			thePlayerTruckBlue.gameObject.SetActive (false);		
			break;
		case 8:
			thePlayerTruckGreen.gameObject.SetActive (false);	
			break;
		case 9:
			thePlayerDiskRed.gameObject.SetActive (false);	
			break;
		case 10:
			thePlayerBlueReverse.gameObject.SetActive (false);		
			break;
		case 11:
			thePlayerRedReverse.gameObject.SetActive (false);		
			break;
		case 12:
			thePlayerGreenReverse.gameObject.SetActive (false);			
			break;
		case 13:
			thePlayerGreyReverse.gameObject.SetActive (false);		
			break;
		case 14:
			thePlayerDevil.gameObject.SetActive (false);	
			break;
		case 15:
			thePlayerAlienBiege.gameObject.SetActive (false);
			break;
		case 16:
			thePlayerAlienYellow.gameObject.SetActive (false);
			break;
		case 17:
			thePlayerAlienDarkBlue.gameObject.SetActive (false);
			break;
		case 18:
			thePlayerAlienPink.gameObject.SetActive (false);		
			break;
		}

		//thePlayer.gameObject.SetActive (false);
		theScore.scoreIncreasing = false;
		//SceneManager.LoadScene ("Run");

		gameObject.SetActive (true);
		Debug.Log ("GOBJECT");
		theManager.Reset ();	
	}
	public void GoToMain(){
		pauseMenu.SetActive (false);
		Time.timeScale = 1f;
		SceneManager.LoadScene (mainMenuLevel);
	}

	public void QuestionPause (){
		
		//gameObject.SetActive (true);
		PlayerPrefs.SetString("NOTPAUSE","not");
		PlayerPrefs.SetInt ("SpeedUPP", 0);
		switch (selectCharacter) {
		case 0:
			thePlayerBlue.gameObject.SetActive (false);	
			break;
		case 1:
			thePlayerRed.gameObject.SetActive (false);	
			break;
		case 2:
			thePlayerGreen.gameObject.SetActive (false);	
			break;
		case 3:
			thePlayerGrey.gameObject.SetActive (false);	
			break;
		case 4:
			thePlayerAlienBlue.gameObject.SetActive (false);
			break;
		case 5:
			thePlayerTruckRed.gameObject.SetActive (false);	
			break;
		case 6:
			thePlayerTruckYellow.gameObject.SetActive (false);
			break;
		case 7:
			thePlayerTruckBlue.gameObject.SetActive (false);
			break;
		case 8:
			thePlayerTruckGreen.gameObject.SetActive (false);	
			break;
		case 9:
			thePlayerDiskRed.gameObject.SetActive (false);
			break;
		case 10:
			thePlayerBlueReverse.gameObject.SetActive (false);	
			break;
		case 11:
			thePlayerRedReverse.gameObject.SetActive (false);	
			break;
		case 12:
			thePlayerGreenReverse.gameObject.SetActive (false);	
			break;
		case 13:
			thePlayerGreyReverse.gameObject.SetActive (false);
			break;
		case 14:
			thePlayerDevil.gameObject.SetActive (false);	
			break;
		case 15:
			thePlayerAlienBiege.gameObject.SetActive (false);
			break;
		case 16:
			thePlayerAlienYellow.gameObject.SetActive (false);
			break;
		case 17:
			thePlayerAlienDarkBlue.gameObject.SetActive (false);	
			break;
		case 18:
			thePlayerAlienPink.gameObject.SetActive (false);
			break;
		}
		theScore.scoreIncreasing = false;
		pauseMenu.SetActive (false);
		theDead.SetActive (false);
		PlayerPrefs.SetString ("StopMusic", "stop");
		PlayerPrefs.SetInt ("ScrollBGG", 1);
		switch (selectCharacter) {
		case 0:
			lastChance = thePlayerBlue.lastGroundedPos;
			thePlayerBlue.MRigidbody.drag = 100000000f;
			thePlayerBlue.moveSpeed = 0;	
			thePlayerBlue.speedUp = false;
			thePlayerBlue.gameObject.SetActive (true);
			thePlayerBlue.transform.position = new Vector3(thePlayerBlue.lastGroundedPos.x-posx,thePlayerBlue.lastGroundedPos.y+posy,thePlayerBlue.lastGroundedPos.z);
			break;
		case 1:
			lastChance = thePlayerRed.lastGroundedPos;
			thePlayerRed.MRigidbody.drag = 100000000f;
			thePlayerRed.moveSpeed = 0;	
			thePlayerRed.speedUp = false;
			thePlayerRed.gameObject.SetActive (true);
			thePlayerRed.transform.position = new Vector3(thePlayerRed.lastGroundedPos.x-posx,thePlayerRed.lastGroundedPos.y+posy,thePlayerRed.lastGroundedPos.z);
			break;
		case 2:
			lastChance = thePlayerGreen.lastGroundedPos;
			thePlayerGreen.MRigidbody.drag = 100000000f;
			thePlayerGreen.moveSpeed = 0;	
			thePlayerGreen.speedUp = false;
			thePlayerGreen.gameObject.SetActive (true);
			thePlayerGreen.transform.position = new Vector3(thePlayerGreen.lastGroundedPos.x-posx,thePlayerGreen.lastGroundedPos.y+posy,thePlayerGreen.lastGroundedPos.z);
			break;
		case 3:
			lastChance = thePlayerGrey.lastGroundedPos;
			thePlayerGrey.MRigidbody.drag = 100000000f;
			thePlayerGrey.moveSpeed = 0;	
			thePlayerGrey.speedUp = false;
			thePlayerGrey.gameObject.SetActive (true);
			thePlayerGrey.transform.position = new Vector3(thePlayerGrey.lastGroundedPos.x-posx,thePlayerGrey.lastGroundedPos.y+posy,thePlayerGrey.lastGroundedPos.z);
			break;
		case 4:
			lastChance = thePlayerAlienBlue.lastGroundedPos;
			thePlayerAlienBlue.MRigidbody.drag = 100000000f;
			thePlayerAlienBlue.moveSpeed = 0;	
			thePlayerAlienBlue.speedUp = false;
			thePlayerAlienBlue.gameObject.SetActive (true);
			thePlayerAlienBlue.transform.position = new Vector3(thePlayerAlienBlue.lastGroundedPos.x-posx,thePlayerAlienBlue.lastGroundedPos.y+posy,thePlayerAlienBlue.lastGroundedPos.z);
			break;
		case 5:
			lastChance = thePlayerTruckRed.lastGroundedPos;
			thePlayerTruckRed.MRigidbody.drag = 100000000f;
			thePlayerTruckRed.moveSpeed = 0;	
			thePlayerTruckRed.speedUp = false;
			thePlayerTruckRed.gameObject.SetActive (true);
			thePlayerTruckRed.transform.position = new Vector3(thePlayerTruckRed.lastGroundedPos.x-posx,thePlayerTruckRed.lastGroundedPos.y+posy,thePlayerTruckRed.lastGroundedPos.z);
			break;
		case 6:
			lastChance = thePlayerTruckYellow.lastGroundedPos;
			thePlayerTruckYellow.MRigidbody.drag = 100000000f;
			thePlayerTruckYellow.moveSpeed = 0;	
			thePlayerTruckYellow.speedUp = false;
			thePlayerTruckYellow.gameObject.SetActive (true);
			thePlayerTruckYellow.transform.position = new Vector3(thePlayerTruckYellow.lastGroundedPos.x-posx,thePlayerTruckYellow.lastGroundedPos.y+posy,thePlayerTruckYellow.lastGroundedPos.z);
			break;
		case 7:
			lastChance = thePlayerTruckBlue.lastGroundedPos;
			thePlayerTruckBlue.MRigidbody.drag = 100000000f;
			thePlayerTruckBlue.moveSpeed = 0;	
			thePlayerTruckBlue.speedUp = false;
			thePlayerTruckBlue.gameObject.SetActive (true);
			thePlayerTruckBlue.transform.position = new Vector3(thePlayerTruckBlue.lastGroundedPos.x-posx,thePlayerTruckBlue.lastGroundedPos.y+posy,thePlayerTruckBlue.lastGroundedPos.z);
			break;
		case 8:
			lastChance = thePlayerTruckGreen.lastGroundedPos;
			thePlayerTruckGreen.MRigidbody.drag = 100000000f;
			thePlayerTruckGreen.moveSpeed = 0;	
			thePlayerTruckGreen.speedUp = false;
			thePlayerTruckGreen.gameObject.SetActive (true);
			thePlayerTruckGreen.transform.position = new Vector3(thePlayerTruckGreen.lastGroundedPos.x-posx,thePlayerTruckGreen.lastGroundedPos.y+posy,thePlayerTruckGreen.lastGroundedPos.z);
			break;
		case 9:
			lastChance = thePlayerDiskRed.lastGroundedPos;
			thePlayerDiskRed.MRigidbody.drag = 100000000f;
			thePlayerDiskRed.moveSpeed = 0;	
			thePlayerDiskRed.speedUp = false;
			thePlayerDiskRed.gameObject.SetActive (true);
			thePlayerDiskRed.transform.position = new Vector3(thePlayerDiskRed.lastGroundedPos.x-posx,thePlayerDiskRed.lastGroundedPos.y+posy,thePlayerDiskRed.lastGroundedPos.z);
			break;
		case 10:
			lastChance = thePlayerBlueReverse.lastGroundedPos;
			thePlayerBlueReverse.MRigidbody.drag = 100000000f;
			thePlayerBlueReverse.moveSpeed = 0;	
			thePlayerBlueReverse.speedUp = false;
			thePlayerBlueReverse.gameObject.SetActive (true);
			thePlayerBlueReverse.transform.position = new Vector3(thePlayerBlueReverse.lastGroundedPos.x-posx,thePlayerBlueReverse.lastGroundedPos.y+posy,thePlayerBlueReverse.lastGroundedPos.z);
			break;
		case 11:
			lastChance = thePlayerRedReverse.lastGroundedPos;
			thePlayerRedReverse.MRigidbody.drag = 100000000f;
			thePlayerRedReverse.moveSpeed = 0;	
			thePlayerRedReverse.speedUp = false;
			thePlayerRedReverse.gameObject.SetActive (true);
			thePlayerRedReverse.transform.position = new Vector3(thePlayerRedReverse.lastGroundedPos.x-posx,thePlayerRedReverse.lastGroundedPos.y+posy,thePlayerRedReverse.lastGroundedPos.z);
			break;
		case 12:
			lastChance = thePlayerGreenReverse.lastGroundedPos;
			thePlayerGreenReverse.MRigidbody.drag = 100000000f;
			thePlayerGreenReverse.moveSpeed = 0;	
			thePlayerGreenReverse.speedUp = false;
			thePlayerGreenReverse.gameObject.SetActive (true);
			thePlayerGreenReverse.transform.position = new Vector3(thePlayerGreenReverse.lastGroundedPos.x-posx,thePlayerGreenReverse.lastGroundedPos.y+posy,thePlayerGreenReverse.lastGroundedPos.z);
			break;
		case 13:
			lastChance = thePlayerGreyReverse.lastGroundedPos;
			thePlayerGreyReverse.MRigidbody.drag = 100000000f;
			thePlayerGreyReverse.moveSpeed = 0;	
			thePlayerGreyReverse.speedUp = false;
			thePlayerGreyReverse.gameObject.SetActive (true);
			thePlayerGreyReverse.transform.position = new Vector3(thePlayerGreyReverse.lastGroundedPos.x-posx,thePlayerGreyReverse.lastGroundedPos.y+posy,thePlayerGreyReverse.lastGroundedPos.z);
			break;
		case 14:
			lastChance = thePlayerDevil.lastGroundedPos;
			thePlayerDevil.MRigidbody.drag = 100000000f;
			thePlayerDevil.moveSpeed = 0;	
			thePlayerDevil.speedUp = false;
			thePlayerDevil.gameObject.SetActive (true);
			thePlayerDevil.transform.position = new Vector3(thePlayerDevil.lastGroundedPos.x-posx,thePlayerDevil.lastGroundedPos.y+posy,thePlayerDevil.lastGroundedPos.z);
			break;
		case 15:
			lastChance = thePlayerAlienBiege.lastGroundedPos;
			thePlayerAlienBiege.MRigidbody.drag = 100000000f;
			thePlayerAlienBiege.moveSpeed = 0;	
			thePlayerAlienBiege.speedUp = false;
			thePlayerAlienBiege.gameObject.SetActive (true);
			thePlayerAlienBiege.transform.position = new Vector3(thePlayerAlienBiege.lastGroundedPos.x-posx,thePlayerAlienBiege.lastGroundedPos.y+posy,thePlayerAlienBiege.lastGroundedPos.z);
			break;
		case 16:
			lastChance = thePlayerAlienYellow.lastGroundedPos;
			thePlayerAlienYellow.MRigidbody.drag = 100000000f;
			thePlayerAlienYellow.moveSpeed = 0;	
			thePlayerAlienYellow.speedUp = false;
			thePlayerAlienYellow.gameObject.SetActive (true);
			thePlayerAlienYellow.transform.position = new Vector3(thePlayerAlienYellow.lastGroundedPos.x-posx,thePlayerAlienYellow.lastGroundedPos.y+posy,thePlayerAlienYellow.lastGroundedPos.z);
			break;
		case 17:
			lastChance = thePlayerAlienDarkBlue.lastGroundedPos;
			thePlayerAlienDarkBlue.MRigidbody.drag = 100000000f;
			thePlayerAlienDarkBlue.moveSpeed = 0;	
			thePlayerAlienDarkBlue.speedUp = false;
			thePlayerAlienDarkBlue.gameObject.SetActive (true);
			thePlayerAlienDarkBlue.transform.position = new Vector3(thePlayerAlienDarkBlue.lastGroundedPos.x-posx,thePlayerAlienDarkBlue.lastGroundedPos.y+posy,thePlayerAlienDarkBlue.lastGroundedPos.z);
			break;
		case 18:
			lastChance = thePlayerAlienPink.lastGroundedPos;
			thePlayerAlienPink.MRigidbody.drag = 100000000f;
			thePlayerAlienPink.moveSpeed = 0;	
			thePlayerAlienPink.speedUp = false;
			thePlayerAlienPink.gameObject.SetActive (true);
			thePlayerAlienPink.transform.position = new Vector3(thePlayerAlienPink.lastGroundedPos.x-posx,thePlayerAlienPink.lastGroundedPos.y+posy,thePlayerAlienPink.lastGroundedPos.z);
			break;
		}
		//PlayerPrefs.SetInt ("ESC",1);
		theManager.escape = false;
		pauseButton.SetActive (false);
		//gameObject.SetActive (true);
		QuestionPanel.SetActive (true);
		theQuestions.gameObject.SetActive (true);
		Debug.Log ("Question PAUSE");
	}
	public void PauseGame(){
		
		PlayerPrefs.SetInt ("ESC",0);
		theDead.SetActive (false);
		PlayerPrefs.SetString ("StopMusic", "stop");
		pauseButton.SetActive (false);

		theScore.scoreIncreasing = false;
		switch (selectCharacter) {
		case 0:
			b = thePlayerBlue.transform.position;	
			break;
		case 1:
			b = thePlayerRed.transform.position;	
			break;
		case 2:
			b = thePlayerGreen.transform.position;
			break;
		case 3:
			b = thePlayerGrey.transform.position; 
			break;
		case 4:
			b = thePlayerAlienBlue.transform.position;
			break;
		case 5:
			b = thePlayerTruckRed.transform.position; 
			break;
		case 6:
			b = thePlayerTruckYellow.transform.position;
			break;
		case 7:
			b = thePlayerTruckBlue.transform.position;
			break;
		case 8:
			b = thePlayerTruckGreen.transform.position; 
			break;
		case 9:
			b = thePlayerDiskRed.transform.position;
			break;
		case 10:
			b = thePlayerBlueReverse.transform.position;	
			break;
		case 11:
			b = thePlayerRedReverse.transform.position;
			break;
		case 12:
			b = thePlayerGreenReverse.transform.position; 
			break;
		case 13:
			b = thePlayerGreyReverse.transform.position;
			break;
		case 14:
			b = thePlayerDevil.transform.position; 
			break;
		case 15:
			b = thePlayerAlienBiege.transform.position;
			break;
		case 16:
			b = thePlayerAlienYellow.transform.position;
			break;
		case 17:
			b = thePlayerAlienDarkBlue.transform.position; 
			break;
		case 18:
			b = thePlayerAlienPink.transform.position;
			break;

		}

		Debug.Log ("Paused");
		pauseMenu.SetActive (true);
		gameObject.SetActive (true);
		Time.timeScale = 0f;
		/*if(theManager.escape){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			ResumeGame ();
				theManager.escape = false;
			}*/
		//}

	}
	public void ResumeGame(){
		//minusTime += 3;
		//PlayerPrefs.SetInt ("minusTime", minusTime);
		//minusTime = 0;

		switch (selectCharacter) {
		case 0:
			thePlayerBlue.jumpOff = false;
			break;
		case 1:
			thePlayerRed.jumpOff = false;
			break;
		case 2:
			thePlayerGreen.jumpOff = false;
			break;
		case 3:
			thePlayerGrey.jumpOff = false;
			break;
		case 4:
			thePlayerAlienBlue.jumpOff = false;
			break;
		case 5:
			thePlayerTruckRed.jumpOff = false;
			break;
		case 6:
			thePlayerTruckYellow.jumpOff = false;
			break;
		case 7:
			thePlayerTruckBlue.jumpOff = false;
			break;
		case 8:
			thePlayerTruckGreen.jumpOff = false;
			break;
		case 9:
			thePlayerDiskRed.jumpOff = false;
			break;
		case 10:
			thePlayerBlueReverse.jumpOff = false;
			break;
		case 11:
			thePlayerRedReverse.jumpOff = false;
			break;
		case 12:
			thePlayerGreenReverse.jumpOff = false;
			break;
		case 13:
			thePlayerGreyReverse.jumpOff = false;
			break;
		case 14:
			thePlayerDevil.jumpOff = false;
			break;
		case 15:
			thePlayerAlienBiege.jumpOff = false;
			break;
		case 16:
			thePlayerAlienYellow.jumpOff = false;
			break;
		case 17:
			thePlayerAlienDarkBlue.jumpOff = false;
			break;
		case 18:
			thePlayerAlienPink.jumpOff = false;
			break;
		}
		theManager.escape = false;
		pauseButton.SetActive (false);
		//ThreeSec.text = "" + 2;
		gameObject.SetActive (true);
		pauseMenu.SetActive (false);
		PlayerPrefs.SetInt ("ESC",1);
		StartCoroutine ("s");
	}
	public IEnumerator sss(){
		PlayerPrefs.SetInt ("noStuck", 0);
		PlayerPrefs.SetInt ("ESC", 1);
		ThreeSec.text = "" + 3;

		switch (selectCharacter) {
		case 0:
			thePlayerBlue.MRigidbody.drag = 1000000f;
			thePlayerBlue.moveSpeed = 0;	
			thePlayerBlue.speedUp = false;
			thePlayerBlue.gameObject.SetActive (true);
			break;
		case 1:
			thePlayerRed.MRigidbody.drag = 1000000f;
			thePlayerRed.moveSpeed = 0;	
			thePlayerRed.speedUp = false;
			thePlayerRed.gameObject.SetActive (true);
			break;
		case 2:
			thePlayerGreen.MRigidbody.drag = 1000000f;
			thePlayerGreen.moveSpeed = 0;	
			thePlayerGreen.speedUp = false;
			thePlayerGreen.gameObject.SetActive (true);
			break;
		case 3:
			thePlayerGrey.MRigidbody.drag = 1000000f;
			thePlayerGrey.moveSpeed = 0;	
			thePlayerGrey.speedUp = false;
			thePlayerGrey.gameObject.SetActive (true);
			break;
		case 4:
			thePlayerAlienBlue.MRigidbody.drag = 1000000f;
			thePlayerAlienBlue.moveSpeed = 0;	
			thePlayerAlienBlue.speedUp = false;
			thePlayerAlienBlue.gameObject.SetActive (true);
			break;
		case 5:
			thePlayerTruckRed.MRigidbody.drag = 1000000f;
			thePlayerTruckRed.moveSpeed = 0;	
			thePlayerTruckRed.speedUp = false;
			thePlayerTruckRed.gameObject.SetActive (true);
			break;
		case 6:
			thePlayerTruckYellow.MRigidbody.drag = 1000000f;
			thePlayerTruckYellow.moveSpeed = 0;	
			thePlayerTruckYellow.speedUp = false;
			thePlayerTruckYellow.gameObject.SetActive (true);
			break;
		case 7:
			thePlayerTruckBlue.MRigidbody.drag = 1000000f;
			thePlayerTruckBlue.moveSpeed = 0;	
			thePlayerTruckBlue.speedUp = false;
			thePlayerTruckBlue.gameObject.SetActive (true);
			break;
		case 8:
			thePlayerTruckGreen.MRigidbody.drag = 1000000f;
			thePlayerTruckGreen.moveSpeed = 0;	
			thePlayerTruckGreen.speedUp = false;
			thePlayerTruckGreen.gameObject.SetActive (true);
			break;
		case 9:
			thePlayerDiskRed.MRigidbody.drag = 1000000f;
			thePlayerDiskRed.moveSpeed = 0;	
			thePlayerDiskRed.speedUp = false;
			thePlayerDiskRed.gameObject.SetActive (true);
			break;
		case 10:
			thePlayerBlueReverse.MRigidbody.drag = 1000000f;
			thePlayerBlueReverse.moveSpeed = 0;	
			thePlayerBlueReverse.speedUp = false;
			thePlayerBlue.gameObject.SetActive (true);
			break;
		case 11:
			thePlayerRedReverse.MRigidbody.drag = 1000000f;
			thePlayerRedReverse.moveSpeed = 0;	
			thePlayerRedReverse.speedUp = false;
			thePlayerRedReverse.gameObject.SetActive (true);
			break;
		case 12:
			thePlayerGreenReverse.MRigidbody.drag = 1000000f;
			thePlayerGreenReverse.moveSpeed = 0;	
			thePlayerGreenReverse.speedUp = false;
			thePlayerGreenReverse.gameObject.SetActive (true);
			break;
		case 13:
			thePlayerGreyReverse.MRigidbody.drag = 1000000f;
			thePlayerGreyReverse.moveSpeed = 0;	
			thePlayerGreyReverse.speedUp = false;
			thePlayerGreyReverse.gameObject.SetActive (true);
			break;
		case 14:
			thePlayerDevil.MRigidbody.drag = 1000000f;
			thePlayerDevil.moveSpeed = 0;	
			thePlayerDevil.speedUp = false;
			thePlayerDevil.gameObject.SetActive (true);
			break;
		case 15:
			thePlayerAlienBiege.MRigidbody.drag = 1000000f;
			thePlayerAlienBiege.moveSpeed = 0;	
			thePlayerAlienBiege.speedUp = false;
			thePlayerAlienBiege.gameObject.SetActive (true);
			break;
		case 16:
			thePlayerAlienYellow.MRigidbody.drag = 1000000f;
			thePlayerAlienYellow.moveSpeed = 0;	
			thePlayerAlienYellow.speedUp = false;
			thePlayerAlienYellow.gameObject.SetActive (true);
			break;
		case 17:
			thePlayerAlienDarkBlue.MRigidbody.drag = 1000000f;
			thePlayerAlienDarkBlue.moveSpeed = 0;	
			thePlayerAlienDarkBlue.speedUp = false;
			thePlayerAlienDarkBlue.gameObject.SetActive (true);
			break;
		case 18:
			thePlayerAlienPink.MRigidbody.drag = 1000000f;
			thePlayerAlienPink.moveSpeed = 0;	
			thePlayerAlienPink.speedUp = false;
			thePlayerAlienPink.gameObject.SetActive (true);
			break;
		}
		thisIsYourLastToContinue.SetActive (true);
		remainBGG.SetActive (true);

		//remainingQ = theQuestions.i - 4; 
		remainingQ = Mathf.Abs(theQuestions.i - 5);

		switch (remainingQ) {
		case 0:
			//remainingQuestion.color = new Color32 (255, 69, 0, 255);
			remainBG.color = new Color32 (255, 69, 0, 100);
			break;
		case 1:
			//remainingQuestion.color = new Color32 (255, 174, 0, 255);
			remainBG.color = new Color32 (255, 174, 0, 100);
			break;
		case 2:
			//remainingQuestion.color = new Color32 (255, 248, 0, 255);
			remainBG.color = new Color32 (255, 248, 0, 100);
			break;
		case 3:
			//remainingQuestion.color = new Color32 (146, 255, 0, 255);
			remainBG.color = new Color32 (146, 255, 0, 100);
			break;
		case 4:
			//remainingQuestion.color = new Color32 (19, 255, 0, 255);
			remainBG.color = new Color32 (19, 255, 0, 100);
			break;
		case 5:
			break;
		}

		if (remainingQ == 1) {
			remainingQuestion.text = LanguageManager.Instance.GetTextValue("RemainingLast");
		} else if (remainingQ == 0) {
			remainingQuestion.text = LanguageManager.Instance.GetTextValue("Continue");
		} else {
			remainingQuestion.text = LanguageManager.Instance.GetTextValue("RemainingQuestion") +" " + remainingQ;
		}

		three.SetActive (true);
		yield return new WaitForSeconds (1f);
		ThreeSec.text = "" + 2;
		yield return new WaitForSeconds (1f);
		ThreeSec.text = "" + 1;
		yield return new WaitForSeconds (1f);
		thisIsYourLastToContinue.SetActive (false);
		remainBGG.SetActive (false);
		//theScore.scoreCountL = a;
		pauseButton.SetActive(true);
		theScore.scoreIncreasing = true;
		minusPlayer = PlayerPrefs.GetFloat ("moveSpeed");

		if(minusPlayer <= 10.75f){
		minusPlayer -= 7.75f;
		}else if(minusPlayer > 10.75 && minusPlayer < 14){
			minusPlayer -= 8.5f;		
		}else if(minusPlayer >= 14 && minusPlayer < 16){
			if (minusPlayer == 12.25f) {
				minusPlayer = 12.75f;
			}
			minusPlayer -= 12f;
		}else if(minusPlayer >= 16 && minusPlayer < 18){
			minusPlayer -= 15f;
		}else if(minusPlayer >= 18 && minusPlayer < 20){
			minusPlayer -= 17f;
		}else if(minusPlayer <= 20){
			minusPlayer -= 25f;
		}

		switch (selectCharacter) {
		case 0:
			thePlayerBlue.MRigidbody.drag = 0f;
			thePlayerBlue.speedUp = true;	
			thePlayerBlue.moveSpeed += thePlayerBlue.moveSpeedL +  minusPlayer;
			break;
		case 1:
			thePlayerRed.MRigidbody.drag = 0f;
			thePlayerRed.speedUp = true;
			thePlayerRed.moveSpeed += thePlayerRed.moveSpeedL +  minusPlayer;		
			break;
		case 2:
			thePlayerGreen.MRigidbody.drag = 0f;
			thePlayerGreen.speedUp = true;		
			thePlayerGreen.moveSpeed += thePlayerGreen.moveSpeedL +  minusPlayer;	
			break;
		case 3:
			thePlayerGrey.MRigidbody.drag = 0f;
			thePlayerGrey.speedUp = true;
			thePlayerGrey.moveSpeed += thePlayerGrey.moveSpeedL +  minusPlayer;
			break;
		case 4:
			thePlayerAlienBlue.MRigidbody.drag = 0f;
			thePlayerAlienBlue.speedUp = true;
			thePlayerAlienBlue.moveSpeed += thePlayerAlienBlue.moveSpeedL + minusPlayer;		
			break;
		case 5:
			thePlayerTruckRed.MRigidbody.drag = 0f;
			thePlayerTruckRed.speedUp = true;
			thePlayerTruckRed.moveSpeed += thePlayerTruckRed.moveSpeedL + minusPlayer;
			break;
		case 6:
			thePlayerTruckYellow.MRigidbody.drag = 0f;
			thePlayerTruckYellow.speedUp = true;
			thePlayerTruckYellow.moveSpeed += thePlayerTruckYellow.moveSpeedL +minusPlayer;
			break;
		case 7:
			thePlayerTruckBlue.MRigidbody.drag = 0f;
			thePlayerTruckBlue.speedUp = true;
			thePlayerTruckBlue.moveSpeed += thePlayerTruckBlue.moveSpeedL + minusPlayer;
			break;
		case 8:
			thePlayerTruckGreen.MRigidbody.drag = 0f;
			thePlayerTruckGreen.speedUp = true;
			thePlayerTruckGreen.moveSpeed += thePlayerTruckGreen.moveSpeedL +minusPlayer;		
			break;
		case 9:
			thePlayerDiskRed.MRigidbody.drag = 0f;
			thePlayerDiskRed.speedUp = true;
			thePlayerDiskRed.moveSpeed += thePlayerDiskRed.moveSpeedL + minusPlayer;
			break;
		case 10:
			thePlayerBlueReverse.MRigidbody.drag = 0f;
			thePlayerBlueReverse.speedUp = true;
			thePlayerBlueReverse.moveSpeed += thePlayerBlueReverse.moveSpeedL +  minusPlayer;		
			break;
		case 11:
			thePlayerRedReverse.MRigidbody.drag = 0f;
			thePlayerRedReverse.speedUp = true;		
			thePlayerRedReverse.moveSpeed += thePlayerRedReverse.moveSpeedL +  minusPlayer;		
			break;
		case 12:
			thePlayerGreenReverse.MRigidbody.drag = 0f;
			thePlayerGreenReverse.speedUp = true;
			thePlayerGreenReverse.moveSpeed += thePlayerGreenReverse.moveSpeedL + minusPlayer;
			break;
		case 13:
			thePlayerGreyReverse.MRigidbody.drag = 0f;
			thePlayerGreyReverse.speedUp = true;
			thePlayerGreyReverse.moveSpeed += thePlayerGreyReverse.moveSpeedL + minusPlayer;		
			break;
		case 14:
			thePlayerDevil.MRigidbody.drag = 0f;
			thePlayerDevil.speedUp = true;
			thePlayerDevil.moveSpeed += thePlayerDevil.moveSpeedL +  minusPlayer;		
			break;
		case 15:
			thePlayerAlienBiege.MRigidbody.drag = 0f;
			thePlayerAlienBiege.speedUp = true;
			thePlayerAlienBiege.moveSpeed += thePlayerAlienBiege.moveSpeedL + minusPlayer;		
			break;
		case 16:
			thePlayerAlienYellow.MRigidbody.drag = 0f;
			thePlayerAlienYellow.speedUp = true;
			thePlayerAlienYellow.moveSpeed += thePlayerAlienYellow.moveSpeedL + minusPlayer;
			break;
		case 17:
			thePlayerAlienDarkBlue.MRigidbody.drag = 0f;
			thePlayerAlienDarkBlue.speedUp = true;
			thePlayerAlienDarkBlue.moveSpeed += thePlayerAlienDarkBlue.moveSpeedL + minusPlayer;
			break;
		case 18:
			thePlayerAlienPink.MRigidbody.drag = 0f;
			thePlayerAlienPink.speedUp = true;
			thePlayerAlienPink.moveSpeed += thePlayerAlienPink.moveSpeedL +  minusPlayer;
			break;
		}

		PlayerPrefs.SetInt ("ScrollBGStop", 0);
		gameObject.SetActive (false);
		theManager.escape = false;
		PlayerPrefs.SetString ("StopMusic", "start");
		three.SetActive (false);
		PlayerPrefs.SetInt ("SpeedUPP", 1);
		PlayerPrefs.SetString("NOTPAUSE","pause");
		//StopAllCoroutines ();
	}
	public void ResumeButton(){
		PlayerPrefs.SetInt ("ESC",0);
		if (PlayerPrefs.GetInt ("ESC") == 0) {
			PlayerPrefs.SetInt ("ESC",1);
			Debug.Log ("Resume");
			ResumeGame ();
		}
	}

	public IEnumerator s(){
		PlayerPrefs.SetInt ("noStuck", 0);
		/*if (PlayerPrefs.GetInt ("cevap") == 1) {
		} else {*/
		Time.timeScale = 1f;
		//}
		ThreeSec.text = "" + 3;

		switch (selectCharacter) {
		case 0:
			thePlayerBlue.MRigidbody.drag = 1000000f;
			thePlayerBlue.moveSpeed = 0;	
			thePlayerBlue.speedUp = false;
			thePlayerBlue.gameObject.SetActive (true);
			break;
		case 1:
			thePlayerRed.MRigidbody.drag = 1000000f;
			thePlayerRed.moveSpeed = 0;	
			thePlayerRed.speedUp = false;
			thePlayerRed.gameObject.SetActive (true);
			break;
		case 2:
			thePlayerGreen.MRigidbody.drag = 1000000f;
			thePlayerGreen.moveSpeed = 0;	
			thePlayerGreen.speedUp = false;
			thePlayerGreen.gameObject.SetActive (true);
			break;
		case 3:
			thePlayerGrey.MRigidbody.drag = 1000000f;
			thePlayerGrey.moveSpeed = 0;	
			thePlayerGrey.speedUp = false;
			thePlayerGrey.gameObject.SetActive (true);
			break;
		case 4:
			thePlayerAlienBlue.MRigidbody.drag = 1000000f;
			thePlayerAlienBlue.moveSpeed = 0;	
			thePlayerAlienBlue.speedUp = false;
			thePlayerAlienBlue.gameObject.SetActive (true);
			break;
		case 5:
			thePlayerTruckRed.MRigidbody.drag = 1000000f;
			thePlayerTruckRed.moveSpeed = 0;	
			thePlayerTruckRed.speedUp = false;
			thePlayerTruckRed.gameObject.SetActive (true);
			break;
		case 6:
			thePlayerTruckYellow.MRigidbody.drag = 1000000f;
			thePlayerTruckYellow.moveSpeed = 0;	
			thePlayerTruckYellow.speedUp = false;
			thePlayerTruckYellow.gameObject.SetActive (true);
			break;
		case 7:
			thePlayerTruckBlue.MRigidbody.drag = 1000000f;
			thePlayerTruckBlue.moveSpeed = 0;	
			thePlayerTruckBlue.speedUp = false;
			thePlayerTruckBlue.gameObject.SetActive (true);
			break;
		case 8:
			thePlayerTruckGreen.MRigidbody.drag = 1000000f;
			thePlayerTruckGreen.moveSpeed = 0;	
			thePlayerTruckGreen.speedUp = false;
			thePlayerTruckGreen.gameObject.SetActive (true);
			break;
		case 9:
			thePlayerDiskRed.MRigidbody.drag = 1000000f;
			thePlayerDiskRed.moveSpeed = 0;	
			thePlayerDiskRed.speedUp = false;
			thePlayerDiskRed.gameObject.SetActive (true);
			break;
		case 10:
			thePlayerBlueReverse.MRigidbody.drag = 1000000f;
			thePlayerBlueReverse.moveSpeed = 0;	
			thePlayerBlueReverse.speedUp = false;
			thePlayerBlue.gameObject.SetActive (true);
			break;
		case 11:
			thePlayerRedReverse.MRigidbody.drag = 1000000f;
			thePlayerRedReverse.moveSpeed = 0;	
			thePlayerRedReverse.speedUp = false;
			thePlayerRedReverse.gameObject.SetActive (true);
			break;
		case 12:
			thePlayerGreenReverse.MRigidbody.drag = 1000000f;
			thePlayerGreenReverse.moveSpeed = 0;	
			thePlayerGreenReverse.speedUp = false;
			thePlayerGreenReverse.gameObject.SetActive (true);
			break;
		case 13:
			thePlayerGreyReverse.MRigidbody.drag = 1000000f;
			thePlayerGreyReverse.moveSpeed = 0;	
			thePlayerGreyReverse.speedUp = false;
			thePlayerGreyReverse.gameObject.SetActive (true);
			break;
		case 14:
			thePlayerDevil.MRigidbody.drag = 1000000f;
			thePlayerDevil.moveSpeed = 0;	
			thePlayerDevil.speedUp = false;
			thePlayerDevil.gameObject.SetActive (true);
			break;
		case 15:
			thePlayerAlienBiege.MRigidbody.drag = 1000000f;
			thePlayerAlienBiege.moveSpeed = 0;	
			thePlayerAlienBiege.speedUp = false;
			thePlayerAlienBiege.gameObject.SetActive (true);
			break;
		case 16:
			thePlayerAlienYellow.MRigidbody.drag = 1000000f;
			thePlayerAlienYellow.moveSpeed = 0;	
			thePlayerAlienYellow.speedUp = false;
			thePlayerAlienYellow.gameObject.SetActive (true);
			break;
		case 17:
			thePlayerAlienDarkBlue.MRigidbody.drag = 1000000f;
			thePlayerAlienDarkBlue.moveSpeed = 0;	
			thePlayerAlienDarkBlue.speedUp = false;
			thePlayerAlienDarkBlue.gameObject.SetActive (true);
			break;
		case 18:
			thePlayerAlienPink.MRigidbody.drag = 1000000f;
			thePlayerAlienPink.moveSpeed = 0;	
			thePlayerAlienPink.speedUp = false;
			thePlayerAlienPink.gameObject.SetActive (true);
			break;
		}

		three.SetActive (true);
		yield return new WaitForSeconds (1f);
		ThreeSec.text = "" + 2;
		yield return new WaitForSeconds (1f);
		ThreeSec.text = "" + 1;
		yield return new WaitForSeconds (1f);
		//theScore.scoreCountL = a;
		pauseButton.SetActive(true);
		theScore.scoreIncreasing = true;
		minusPlayer = PlayerPrefs.GetFloat ("moveSpeed");
		minusPlayer -= 7f;

		switch (selectCharacter) {
		case 0:
			thePlayerBlue.MRigidbody.drag = 0f;
			thePlayerBlue.speedUp = true;	
			thePlayerBlue.moveSpeed += thePlayerBlue.moveSpeedL +  minusPlayer;
			break;
		case 1:
			thePlayerRed.MRigidbody.drag = 0f;
			thePlayerRed.speedUp = true;
			thePlayerRed.moveSpeed += thePlayerRed.moveSpeedL +  minusPlayer;		
			break;
		case 2:
			thePlayerGreen.MRigidbody.drag = 0f;
			thePlayerGreen.speedUp = true;		
			thePlayerGreen.moveSpeed += thePlayerGreen.moveSpeedL +  minusPlayer;	
			break;
		case 3:
			thePlayerGrey.MRigidbody.drag = 0f;
			thePlayerGrey.speedUp = true;
			thePlayerGrey.moveSpeed += thePlayerGrey.moveSpeedL +  minusPlayer;
			break;
		case 4:
			thePlayerAlienBlue.MRigidbody.drag = 0f;
			thePlayerAlienBlue.speedUp = true;
			thePlayerAlienBlue.moveSpeed += thePlayerAlienBlue.moveSpeedL + minusPlayer;		
			break;
		case 5:
			thePlayerTruckRed.MRigidbody.drag = 0f;
			thePlayerTruckRed.speedUp = true;
			thePlayerTruckRed.moveSpeed += thePlayerTruckRed.moveSpeedL + minusPlayer;
			break;
		case 6:
			thePlayerTruckYellow.MRigidbody.drag = 0f;
			thePlayerTruckYellow.speedUp = true;
			thePlayerTruckYellow.moveSpeed += thePlayerTruckYellow.moveSpeedL +minusPlayer;
			break;
		case 7:
			thePlayerTruckBlue.MRigidbody.drag = 0f;
			thePlayerTruckBlue.speedUp = true;
			thePlayerTruckBlue.moveSpeed += thePlayerTruckBlue.moveSpeedL + minusPlayer;
			break;
		case 8:
			thePlayerTruckGreen.MRigidbody.drag = 0f;
			thePlayerTruckGreen.speedUp = true;
			thePlayerTruckGreen.moveSpeed += thePlayerTruckGreen.moveSpeedL +minusPlayer;		
			break;
		case 9:
			thePlayerDiskRed.MRigidbody.drag = 0f;
			thePlayerDiskRed.speedUp = true;
			thePlayerDiskRed.moveSpeed += thePlayerDiskRed.moveSpeedL + minusPlayer;
			break;
		case 10:
			thePlayerBlueReverse.MRigidbody.drag = 0f;
			thePlayerBlueReverse.speedUp = true;
			thePlayerBlueReverse.moveSpeed += thePlayerBlueReverse.moveSpeedL +  minusPlayer;		
			break;
		case 11:
			thePlayerRedReverse.MRigidbody.drag = 0f;
			thePlayerRedReverse.speedUp = true;		
			thePlayerRedReverse.moveSpeed += thePlayerRedReverse.moveSpeedL +  minusPlayer;		
			break;
		case 12:
			thePlayerGreenReverse.MRigidbody.drag = 0f;
			thePlayerGreenReverse.speedUp = true;
			thePlayerGreenReverse.moveSpeed += thePlayerGreenReverse.moveSpeedL + minusPlayer;
			break;
		case 13:
			thePlayerGreyReverse.MRigidbody.drag = 0f;
			thePlayerGreyReverse.speedUp = true;
			thePlayerGreyReverse.moveSpeed += thePlayerGreyReverse.moveSpeedL + minusPlayer;		
			break;
		case 14:
			thePlayerDevil.MRigidbody.drag = 0f;
			thePlayerDevil.speedUp = true;
			thePlayerDevil.moveSpeed += thePlayerDevil.moveSpeedL +  minusPlayer;		
			break;
		case 15:
			thePlayerAlienBiege.MRigidbody.drag = 0f;
			thePlayerAlienBiege.speedUp = true;
			thePlayerAlienBiege.moveSpeed += thePlayerAlienBiege.moveSpeedL + minusPlayer;		
			break;
		case 16:
			thePlayerAlienYellow.MRigidbody.drag = 0f;
			thePlayerAlienYellow.speedUp = true;
			thePlayerAlienYellow.moveSpeed += thePlayerAlienYellow.moveSpeedL + minusPlayer;
			break;
		case 17:
			thePlayerAlienDarkBlue.MRigidbody.drag = 0f;
			thePlayerAlienDarkBlue.speedUp = true;
			thePlayerAlienDarkBlue.moveSpeed += thePlayerAlienDarkBlue.moveSpeedL + minusPlayer;
			break;
		case 18:
			thePlayerAlienPink.MRigidbody.drag = 0f;
			thePlayerAlienPink.speedUp = true;
			thePlayerAlienPink.moveSpeed += thePlayerAlienPink.moveSpeedL +  minusPlayer;
			break;
		}
		gameObject.SetActive (false);
		theManager.escape = false;
		PlayerPrefs.SetString ("StopMusic", "start");
		three.SetActive (false);
		PlayerPrefs.SetInt ("SpeedUPP", 1);
		//StopAllCoroutines ();
	}


	public void Answer01(){
		switch (theQuestions.answerRandom) {
		case 0:
			Social.ReportProgress(AchievementsJS.achievement_first_correct_answer, 100.0f, (bool success) => {
				// handle success or failure
			});
			PlayerPrefs.SetInt ("AchQ",PlayerPrefs.GetInt ("AchQ") + 1);
			PlayerPrefs.SetInt ("aawwQ", 1);
			MundoSound.Play (backgroundMusic, soundEffect, false);
			theQuestions.j += 1;
			PlayerPrefs.SetInt ("cevap", 1);
			theScore.scoreCount += 20;
			QuestionPanel.SetActive (false);
			gameObject.SetActive (true);
			switch (selectCharacter) {
			case 0:
				thePlayerBlue.jumpOff = false;
				break;
			case 1:
				thePlayerRed.jumpOff = false;
				break;
			case 2:
				thePlayerGreen.jumpOff = false;
				break;
			case 3:
				thePlayerGrey.jumpOff = false;
				break;
			case 4:
				thePlayerAlienBlue.jumpOff = false;
				break;
			case 5:
				thePlayerTruckRed.jumpOff = false;
				break;
			case 6:
				thePlayerTruckYellow.jumpOff = false;
				break;
			case 7:
				thePlayerTruckBlue.jumpOff = false;
				break;
			case 8:
				thePlayerTruckGreen.jumpOff = false;
				break;
			case 9:
				thePlayerDiskRed.jumpOff = false;
				break;
			case 10:
				thePlayerBlueReverse.jumpOff = false;
				break;
			case 11:
				thePlayerRedReverse.jumpOff = false;
				break;
			case 12:
				thePlayerGreenReverse.jumpOff = false;
				break;
			case 13:
				thePlayerGreyReverse.jumpOff = false;
				break;
			case 14:
				thePlayerDevil.jumpOff = false;
				break;
			case 15:
				thePlayerAlienBiege.jumpOff = false;
				break;
			case 16:
				thePlayerAlienYellow.jumpOff = false;
				break;
			case 17:
				thePlayerAlienDarkBlue.jumpOff = false;
				break;
			case 18:
				thePlayerAlienPink.jumpOff = false;
				break;
			}
			if (q == 0f) {
				theAds.ShowInterstitial ();
			}
			StartCoroutine ("sss");
			break;
		case 1:
			theQuestions.death ();
			break;
		case 2:
			theQuestions.death ();
			break;
		case 3:
			theQuestions.death ();
			break;
		}
		QuestionPanel.SetActive (false);
		theQuestions.gameObject.SetActive (false);
	}
	public void Answer02(){
		switch (theQuestions.answerRandom) {
		case 0:	
			theQuestions.death ();
			break;
		case 1:
			Social.ReportProgress(AchievementsJS.achievement_first_correct_answer, 100.0f, (bool success) => {
				// handle success or failure
			});
			PlayerPrefs.SetInt ("AchQ",PlayerPrefs.GetInt ("AchQ") + 1);
			PlayerPrefs.SetInt ("aawwQ", 1);
			MundoSound.Play (backgroundMusic, soundEffect, false);
			theQuestions.j += 1;
			PlayerPrefs.SetInt ("cevap", 1);
			theScore.scoreCount += 20;
			QuestionPanel.SetActive (false);
			gameObject.SetActive (true);
			switch (selectCharacter) {
			case 0:
				thePlayerBlue.jumpOff = false;
				break;
			case 1:
				thePlayerRed.jumpOff = false;
				break;
			case 2:
				thePlayerGreen.jumpOff = false;
				break;
			case 3:
				thePlayerGrey.jumpOff = false;
				break;
			case 4:
				thePlayerAlienBlue.jumpOff = false;
				break;
			case 5:
				thePlayerTruckRed.jumpOff = false;
				break;
			case 6:
				thePlayerTruckYellow.jumpOff = false;
				break;
			case 7:
				thePlayerTruckBlue.jumpOff = false;
				break;
			case 8:
				thePlayerTruckGreen.jumpOff = false;
				break;
			case 9:
				thePlayerDiskRed.jumpOff = false;
				break;
			case 10:
				thePlayerBlueReverse.jumpOff = false;
				break;
			case 11:
				thePlayerRedReverse.jumpOff = false;
				break;
			case 12:
				thePlayerGreenReverse.jumpOff = false;
				break;
			case 13:
				thePlayerGreyReverse.jumpOff = false;
				break;
			case 14:
				thePlayerDevil.jumpOff = false;
				break;
			case 15:
				thePlayerAlienBiege.jumpOff = false;
				break;
			case 16:
				thePlayerAlienYellow.jumpOff = false;
				break;
			case 17:
				thePlayerAlienDarkBlue.jumpOff = false;
				break;
			case 18:
				thePlayerAlienPink.jumpOff = false;
				break;
			}
			if (q == 1f) {
				theAds.ShowInterstitial ();
			}
				StartCoroutine ("sss");
			break;
		case 2:
			theQuestions.death ();
			break;
		case 3:		
			theQuestions.death ();
			break;
		}
		QuestionPanel.SetActive (false);
		theQuestions.gameObject.SetActive (false);
	}
	public void Answer03(){
		switch (theQuestions.answerRandom) {
		case 0:
			theQuestions.death ();
			break;
		case 1:
			theQuestions.death ();
			break;
		case 2:
			Social.ReportProgress(AchievementsJS.achievement_first_correct_answer, 100.0f, (bool success) => {
				// handle success or failure
			});
			PlayerPrefs.SetInt ("AchQ",PlayerPrefs.GetInt ("AchQ") + 1);
			PlayerPrefs.SetInt ("aawwQ", 1);
			MundoSound.Play (backgroundMusic, soundEffect, false);
			theQuestions.j += 1;
			PlayerPrefs.SetInt ("cevap", 1);
			theScore.scoreCount += 20;
			QuestionPanel.SetActive (false);
			gameObject.SetActive (true);
			switch (selectCharacter) {
			case 0:
				thePlayerBlue.jumpOff = false;
				break;
			case 1:
				thePlayerRed.jumpOff = false;
				break;
			case 2:
				thePlayerGreen.jumpOff = false;
				break;
			case 3:
				thePlayerGrey.jumpOff = false;
				break;
			case 4:
				thePlayerAlienBlue.jumpOff = false;
				break;
			case 5:
				thePlayerTruckRed.jumpOff = false;
				break;
			case 6:
				thePlayerTruckYellow.jumpOff = false;
				break;
			case 7:
				thePlayerTruckBlue.jumpOff = false;
				break;
			case 8:
				thePlayerTruckGreen.jumpOff = false;
				break;
			case 9:
				thePlayerDiskRed.jumpOff = false;
				break;
			case 10:
				thePlayerBlueReverse.jumpOff = false;
				break;
			case 11:
				thePlayerRedReverse.jumpOff = false;
				break;
			case 12:
				thePlayerGreenReverse.jumpOff = false;
				break;
			case 13:
				thePlayerGreyReverse.jumpOff = false;
				break;
			case 14:
				thePlayerDevil.jumpOff = false;
				break;
			case 15:
				thePlayerAlienBiege.jumpOff = false;
				break;
			case 16:
				thePlayerAlienYellow.jumpOff = false;
				break;
			case 17:
				thePlayerAlienDarkBlue.jumpOff = false;
				break;
			case 18:
				thePlayerAlienPink.jumpOff = false;
				break;
			}
			if(q == 2f){
			theAds.ShowInterstitial ();
		}
			StartCoroutine ("sss");
			break;
		case 3:
			theQuestions.death ();
			break;
		}
		QuestionPanel.SetActive (false);
		theQuestions.gameObject.SetActive (false);
	}
	public void Answer04(){
		switch (theQuestions.answerRandom) {
		case 0:
			theQuestions.death ();
			break;
		case 1:
			theQuestions.death ();
			break;
		case 2:
			theQuestions.death ();
			break;
		case 3:
			Social.ReportProgress (AchievementsJS.achievement_first_correct_answer, 100.0f, (bool success) => {
				// handle success or failure
			});
			PlayerPrefs.SetInt ("AchQ", PlayerPrefs.GetInt ("AchQ") + 1);
			PlayerPrefs.SetInt ("aawwQ", 1);
			MundoSound.Play (backgroundMusic, soundEffect, false);
			theQuestions.j += 1;
			PlayerPrefs.SetInt ("cevap", 1);
			theScore.scoreCount += 20;
			QuestionPanel.SetActive (false);
			gameObject.SetActive (true);
			switch (selectCharacter) {
			case 0:
				thePlayerBlue.jumpOff = false;
				break;
			case 1:
				thePlayerRed.jumpOff = false;
				break;
			case 2:
				thePlayerGreen.jumpOff = false;
				break;
			case 3:
				thePlayerGrey.jumpOff = false;
				break;
			case 4:
				thePlayerAlienBlue.jumpOff = false;
				break;
			case 5:
				thePlayerTruckRed.jumpOff = false;
				break;
			case 6:
				thePlayerTruckYellow.jumpOff = false;
				break;
			case 7:
				thePlayerTruckBlue.jumpOff = false;
				break;
			case 8:
				thePlayerTruckGreen.jumpOff = false;
				break;
			case 9:
				thePlayerDiskRed.jumpOff = false;
				break;
			case 10:
				thePlayerBlueReverse.jumpOff = false;
				break;
			case 11:
				thePlayerRedReverse.jumpOff = false;
				break;
			case 12:
				thePlayerGreenReverse.jumpOff = false;
				break;
			case 13:
				thePlayerGreyReverse.jumpOff = false;
				break;
			case 14:
				thePlayerDevil.jumpOff = false;
				break;
			case 15:
				thePlayerAlienBiege.jumpOff = false;
				break;
			case 16:
				thePlayerAlienYellow.jumpOff = false;
				break;
			case 17:
				thePlayerAlienDarkBlue.jumpOff = false;
				break;
			case 18:
				thePlayerAlienPink.jumpOff = false;
				break;
			}
			if (q == 3f) {
				theAds.ShowInterstitial ();
			}
			StartCoroutine ("sss");
			break;
		}
		QuestionPanel.SetActive (false);
		theQuestions.gameObject.SetActive (false);

	}
}
