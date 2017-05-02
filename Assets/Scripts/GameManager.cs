using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Transform platformGenerator;
	private Vector3 platformStartPoint;
	public ScoreManager theScoreManager;
	//public PlayerController thePlayer;

	public GameObject QuestionPanel;

	public GameObject thePlayerBlue;
	public GameObject thePlayerRed;
	public GameObject thePlayerGreen;
	public GameObject thePlayerGrey;
	public GameObject thePlayerAlienBlue;
	public GameObject thePlayerTruckRed;
	public GameObject thePlayerTruckYellow;
	public GameObject thePlayerDiskRed;
	public GameObject thePlayerTruckBlue;
	public GameObject thePlayerTruckGreen;
	public GameObject thePlayerBlueReverse;
	public GameObject thePlayerRedReverse;
	public GameObject thePlayerGreenReverse;
	public GameObject thePlayerGreyReverse;
	public GameObject thePlayerAlienYellow;
	public GameObject thePlayerAlienBiege;
	public GameObject thePlayerAlienPink;
	public GameObject thePlayerAlienDarkBlue;
	public GameObject thePlayerDevil;

	public PauseMenu thePause;
	public GameObject thePauseObject;
	public GameObject thePauseMenu;

	public bool escape;

	public CameraController theCamera;
	private int selectCharacter;
	public PlatformGenerator thePlatform;

	public Questions theQuestions;

	private Vector3 playerStartPoint;
	//public PickUpCoins thePickUp;
	public PlatformDestroyer [] platformList;
	public CoinTextGenerator theCoinText;
	public DeathMenu theDeath;
	public GameObject pauseButton;
	public GameObject CoinBronze,CoinGold;
	public Vector3 CoinBronzeTransform,CoinGoldTransform;
	// Use this for initialization
	void Start () {
		CoinGoldTransform = CoinGold.transform.position;
		CoinBronzeTransform = CoinBronze.transform.position;
		platformStartPoint = platformGenerator.position;
		theScoreManager = FindObjectOfType<ScoreManager> ();
		thePlatform = FindObjectOfType<PlatformGenerator> ();
		selectCharacter = PlayerPrefs.GetInt ("CharacterSelected");
		switch (selectCharacter) {
		case 0:
			playerStartPoint = thePlayerBlue.transform.position;	
			break;
		case 1:
			playerStartPoint = thePlayerRed.transform.position;	
			break;
		case 2:
			playerStartPoint = thePlayerGreen.transform.position;	
			break;
		case 3:
			playerStartPoint = thePlayerGrey.transform.position;	
			break;
		case 4:
			playerStartPoint = thePlayerAlienBlue.transform.position;
			break;
		case 5:
			playerStartPoint = thePlayerTruckRed.transform.position;	
			break;
		case 6:
			playerStartPoint = thePlayerTruckYellow.transform.position;
			break;
		case 7:
			playerStartPoint = thePlayerTruckBlue.transform.position;
			break;
		case 8:
			playerStartPoint = thePlayerTruckGreen.transform.position;	
			break;
		case 9:
			playerStartPoint = thePlayerDiskRed.transform.position;
			break;
		case 10:
			playerStartPoint = thePlayerBlueReverse.transform.position;	
			break;
		case 11:
			playerStartPoint = thePlayerRedReverse.transform.position;	
			break;
		case 12:
			playerStartPoint = thePlayerGreenReverse.transform.position;	
			break;
		case 13:
			playerStartPoint = thePlayerGreyReverse.transform.position;
			break;
		case 14:
			playerStartPoint = thePlayerDevil.transform.position;	
			break;
		case 15:
			playerStartPoint = thePlayerAlienBiege.transform.position;
			break;
		case 16:
			playerStartPoint = thePlayerAlienYellow.transform.position;
			break;
		case 17:
			playerStartPoint = thePlayerAlienDarkBlue.transform.position;	
			break;
		case 18:
			playerStartPoint = thePlayerAlienPink.transform.position;
			break;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void RestartGame(){
		/*QuestionPanel.SetActive (true);
		theQuestions.gameObject.SetActive (true);*/
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
		theScoreManager.scoreIncreasing = false;
		theDeath.gameObject.SetActive (true);
		PlayerPrefs.SetInt ("noStuck", 0);

		//StartCoroutine ("RestartCall");
	}

	public void Reset(){		
		thePauseObject.SetActive (true);
		PlayerPrefs.SetInt ("noStuck", 1);
		if (! thePlatform.addObjectReset) {
			thePlatform.addObject = false;
		} else {
			thePlatform.addObject = true;
		}

		theCamera.addDebug = 0;
		theCamera.addDebug2 = 0;
		theCamera.stopOrNot = false;
		theCamera.stopOrNot2 = false;
		theCamera.stopOrNot3 = false;
		theCamera.time = 0;
		theCamera.timeAdd = 0;
		theCamera.timeF = 0;
		theCamera.moveToF = 0;
		theCamera.moveToIa = 0;
		theCamera.moveToIb = 0;
		theCamera.a = (int) Random.Range (0f,18.5f);
		theCoinText.coinInt = 0;
		CoinGold.transform.position = CoinGoldTransform;
		CoinBronze.transform.position = CoinBronzeTransform;
		theDeath.gameObject.SetActive (false);
		pauseButton.SetActive (true);
		theCoinText.coinBronze = 0;
		theCoinText.coinGold = 0;
		platformList = FindObjectsOfType<PlatformDestroyer> ();
		for (int i = 0; i < platformList.Length; i++) {

			platformList [i].gameObject.SetActive (false);
		}

		switch (selectCharacter) {
		case 0:
			thePlayerBlue.transform.position = playerStartPoint;
			thePlayerBlue.gameObject.SetActive (true);
			break;
		case 1:
			thePlayerRed.transform.position = playerStartPoint;
			thePlayerRed.gameObject.SetActive (true);
			break;
		case 2:
			thePlayerGreen.transform.position = playerStartPoint;
			thePlayerGreen.gameObject.SetActive (true);
			break;
		case 3:
			thePlayerGrey.transform.position = playerStartPoint;
			thePlayerGrey.gameObject.SetActive (true);
			break;
		case 4:
			thePlayerAlienBlue.transform.position = playerStartPoint;
			thePlayerAlienBlue.gameObject.SetActive (true);
			break;
		case 5:
			thePlayerTruckRed.transform.position = playerStartPoint;
			thePlayerTruckRed.gameObject.SetActive (true);
			break;
		case 6:
			thePlayerTruckYellow.transform.position = playerStartPoint;
			thePlayerTruckYellow.gameObject.SetActive (true);
			break;
		case 7:
			thePlayerTruckBlue.transform.position = playerStartPoint;
			thePlayerTruckBlue.gameObject.SetActive (true);
			break;
		case 8:
			thePlayerTruckGreen.transform.position = playerStartPoint;
			thePlayerTruckGreen.gameObject.SetActive (true);
			break;
		case 9:
			thePlayerDiskRed.transform.position = playerStartPoint;
			thePlayerDiskRed.gameObject.SetActive (true);
			break;
		case 10:
			thePlayerBlueReverse.transform.position = playerStartPoint;
			thePlayerBlueReverse.gameObject.SetActive (true);
			break;
		case 11:
			thePlayerRedReverse.transform.position = playerStartPoint;
			thePlayerRedReverse.gameObject.SetActive (true);
			break;
		case 12:
			thePlayerGreenReverse.transform.position = playerStartPoint;
			thePlayerGreenReverse.gameObject.SetActive (true);
			break;
		case 13:
			thePlayerGreyReverse.transform.position = playerStartPoint;
			thePlayerGreyReverse.gameObject.SetActive (true);
			break;
		case 14:
			thePlayerDevil.transform.position = playerStartPoint;
			thePlayerDevil.gameObject.SetActive (true);
			break;
		case 15:
			thePlayerAlienBiege.transform.position = playerStartPoint;
			thePlayerAlienBiege.gameObject.SetActive (true);
			break;
		case 16:
			thePlayerAlienYellow.transform.position = playerStartPoint;
			thePlayerAlienYellow.gameObject.SetActive (true);
			break;
		case 17:
			thePlayerAlienDarkBlue.transform.position = playerStartPoint;
			thePlayerAlienDarkBlue.gameObject.SetActive (true);
			break;
		case 18:
			thePlayerAlienPink.transform.position = playerStartPoint;
			thePlayerAlienPink.gameObject.SetActive (true);
			break;
		}


		//thePlayer.transform.position = playerStartPoint;
		platformGenerator.transform.position = platformStartPoint;
		//thePlayer.gameObject.SetActive (true);
		//thePickUp.gameObject.SetActive (true);
		
		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
		SceneManager.LoadScene ("Run");
	}
	public void PauseButton ()	{
		//if (!escape) {
			//escape = true;
		if (PlayerPrefs.GetInt ("ESC") == 1) {
			thePauseObject.SetActive (true);	
			thePause.PauseGame ();
		}
	}

	/*public IEnumerator RestartCall(){
		thePlayer.gameObject.SetActive (false);
		theScoreManager.scoreIncreasing = false;
		//thePickUp.gameObject.SetActive (false);
		yield return new WaitForSeconds (0.5f);
		//Application.LoadLevel ("Run");

		platformList = FindObjectsOfType<PlatformDestroyer> ();
		for (int i = 0; i < platformList.Length; i++) {
			
			platformList [i].gameObject.SetActive (false);
		}
	
		thePlayer.transform.position = playerStartPoint;
		platformGenerator.transform.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true);
		//thePickUp.gameObject.SetActive (true);

		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	}*/
}
