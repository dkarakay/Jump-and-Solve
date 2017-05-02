using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SmartLocalization;
public class PlayerController : MonoBehaviour {

    // Use this for initialization
	public Text DeathTryText;
	public GameObject DeathScoreText;

    public float moveSpeed;
	public float moveSpeedL = 0;
	public float timeAdded;
	private float moveSpeedStore;
	private float speedCountStore;

	public Vector3 lastGrounded2,lastGrounded3;

	public float speedAdder;
	public float speedIncrease;
	private float speedIncreaseStore;
	public float speedCount;

    public float jumpForce;
	public Rigidbody2D MRigidbody;

	public bool escape;

	public Animator MAnimatorBlue;
	public Animator MAnimatorGreen;
	public Animator MAnimatorGrey;
	public Animator MAnimatorRed;
	public Animator MAnimatorAlienBlue;
	public Animator MAnimatorTruckRed;
	public Animator MAnimatorTruckYellow;
	public Animator MAnimatorTruckGreen;
	public Animator MAnimatorTruckBlue;
	public Animator MAnimatorDiskRed;
	public Animator MAnimatorBlueReverse;
	public Animator MAnimatorGreenReverse;
	public Animator MAnimatorGreyReverse;
	public Animator MAnimatorRedReverse;
	public Animator MAnimatorAlienYellow;
	public Animator MAnimatorAlienPink;
	public Animator MAnimatorAlienBiege;
	public Animator MAnimatorAlienDarkBlue;
	public Animator MAnimatorDevil;

	public float jumpTime;
	private float jumpTimeCounter;
	 
	/*public GameObject greenGem;
	public Vector3 greenGemPos;*/

	private bool stoppedJumping;
	private bool canDoublejump;
	public bool speedUp;
	public bool grounded;
	public Transform groundCheck;
	public float groundCheckRadius;

	//public Collider2D MCollider;
	public LayerMask GroundOrAir;
	public int a;

	public PauseMenu thePause;
	public GameObject thePauseMenu;

	public GameManager theManager;
	public AudioClip jumpEffect;

	public int bgg;
	public int selectCharacter;
	public GameObject thePlayerBlue;
	public GameObject thePlayerRed;
	public GameObject thePlayerGreen;
	public GameObject thePlayerGrey;
	public GameObject thePlayerAlienBlue;
	public GameObject thePlayerTruckYellow;
	public GameObject thePlayerTruckRed;
	public GameObject thePlayerTruckBlue;
	public GameObject thePlayerTruckGreen;
	public GameObject thePlayerRedDisk;

	float sleepUntil = 0;

	public GameObject thePlayerBlueReverse;
	public GameObject thePlayerRedReverse;
	public GameObject thePlayerGreenReverse;
	public GameObject thePlayerGreyReverse;
	public GameObject thePlayerAlienYellow;
	public GameObject thePlayerAlienBiege;
	public GameObject thePlayerAlienPink;
	public GameObject thePlayerAlienDarkBlue;
	public GameObject thePlayerDevil;

	public float timeF;
	public int timeI;
	public int minusB = 3;
//	float sleepUntil= 0;
	public Transform coinTextTransform;
	public Transform scoreTextTransform;

	public float timeAdd = 0;
	public float t;
	public bool jumpOff;
	public int tt,q = 0;

	public CoinTextGenerator theCoin;

	public Scrolling theScroll;

	public Vector3 lastGroundedPos;

	public Questions theQuestions;

	public Image coinGold;
	public Image coinBronze;
	public Text [] texts;
	public Transform ColliderLight;

	public float soundEffect;
    void Start () {
		bgg = PlayerPrefs.GetInt ("selectedBG");
		if (bgg == 1) {
			for (int i = 0; i < texts.Length; i++) {
				texts [i].color = new Color32 (0, 0, 0, 255);
			}
		} else {
			for (int i = 0; i < texts.Length; i++) {
				texts [i].color = new Color32 (255,255,255,255);
			}
		}
		PlayerPrefs.SetInt ("ScrollBGStop", 1);
		theScroll = FindObjectOfType<Scrolling> ();	
		lastGroundedPos = new Vector3 (0, 0, 0);	
		if (PlayerPrefs.GetString ("Playy") == "start") {
			StartCoroutine ("stopPlay");
		}
		PlayerPrefs.SetString("NOTPAUSE","pause");
		PlayerPrefs.SetInt ("SpeedUPP", 1);
		soundEffect = PlayerPrefs.GetFloat ("SoundEffect");
		moveSpeedL = 7;
		//PlayerPrefs.SetInt ("CharacterSelected", 0);
		selectCharacter = PlayerPrefs.GetInt ("CharacterSelected");
		MRigidbody.GetComponent<Rigidbody2D> ();
//		MCollider.GetComponent<Collider2D> ();
		/*MAnimatorBlue.GetComponent<Animator> ();
		MAnimatorGrey.GetComponent<Animator> ();
		MAnimatorGreen.GetComponent<Animator> ();
		MAnimatorRed.GetComponent<Animator> ();*/
		jumpTimeCounter = jumpTime;
		moveSpeedStore = moveSpeed;
		speedCountStore = speedCount;
		speedIncreaseStore = speedIncrease;
		stoppedJumping = true;
		speedUp = true;
		jumpOff = false;
	//	greenGemPos = greenGem.transform.position;
		theCoin.coinInt = 0;
	}
	
	// Update is called once per frame
	void Update () {
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
		if (PlayerPrefs.GetInt ("languageSelection") == 0) {
			DeathTryText.fontSize = 250;
			DeathScoreText.GetComponent<Text> ().alignment = TextAnchor.UpperCenter;
			LanguageManager.Instance.ChangeLanguage ("en");
		} else if (PlayerPrefs.GetInt ("languageSelection") == 1) {
			DeathTryText.fontSize = 250;
			DeathScoreText.GetComponent<Text> ().alignment = TextAnchor.UpperCenter;
			LanguageManager.Instance.ChangeLanguage ("tr");			
		} else if (PlayerPrefs.GetInt ("languageSelection") == 2) {
			LanguageManager.Instance.ChangeLanguage ("de");
			DeathTryText.fontSize = 220;
			DeathScoreText.GetComponent<Text> ().alignment = TextAnchor.UpperLeft;
		} else {
			LanguageManager.Instance.ChangeLanguage ("en");
			DeathScoreText.GetComponent<Text> ().alignment = TextAnchor.UpperCenter;
			DeathTryText.fontSize = 250;
		}

		bgg = PlayerPrefs.GetInt ("selectedBG");	
		if (ColliderLight.position.y + 1f < transform.position.y) {
			if (bgg == 1) {
				texts [0].color = new Color32 (0, 0, 0, 50);
				texts [1].color = new Color32 (0, 0, 0, 50);
				texts [2].color = new Color32 (0, 0, 0, 50);
				texts [3].color = new Color32 (0, 0, 0, 50);
				coinGold.color = new Color32 (255, 255, 255, 50);
				coinBronze.color = new Color32 (255, 255, 255, 50);
				texts [4].color = new Color32 (0, 0, 0, 50);
			} else {
				texts [0].color = new Color32 (255, 255, 255, 50);
				texts [1].color = new Color32 (255, 255, 255, 50);
				texts [2].color = new Color32 (255, 255, 255, 50);
				texts [3].color = new Color32 (255, 255, 255, 50);
				coinGold.color = new Color32 (255, 255, 255, 50);
				coinBronze.color = new Color32 (255, 255, 255, 50);
				texts [4].color = new Color32 (255, 255, 255, 50);
			}
		} else {
			if (bgg == 1) {
				for (int i = 0; i < texts.Length; i++) {
					texts [i].color = new Color32 (0,0,0,255);
					coinGold.color = new Color32 (255, 255, 255, 255);
					coinBronze.color = new Color32 (255, 255, 255, 255);
				}
			} else {
				for (int i = 0; i < texts.Length; i++) {
					texts [i].color = new Color32 (255, 255, 255, 255);
					coinGold.color = new Color32 (255, 255, 255, 255);
					coinBronze.color = new Color32 (255, 255, 255, 255);
				}
		}
		}
		PlayerPrefs.SetInt ("ESC",1);
		//grounded = Physics2D.IsTouchingLayers (MCollider, GroundOrAir);

		grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,GroundOrAir); 

		if (transform.position.x > speedCount && speedUp ) {
			if (PlayerPrefs.GetInt ("SpeedUPP") == 1) {
				speedCount += speedIncrease;
				speedIncrease = speedIncrease + (speedAdder * 10);
				//moveSpeedL = moveSpeed;
				moveSpeed = moveSpeed + speedAdder;
				speedAdder = 0f;
				if (moveSpeed != 0f) {
					thePauseMenu.SetActive (false);
					PlayerPrefs.SetInt ("NOStuck", 1);

					PlayerPrefs.SetFloat ("moveSpeed", moveSpeed);
				}
			}
		
		}

		MRigidbody.velocity = new Vector2(moveSpeed,MRigidbody.velocity.y);
		if ((Input.GetKeyDown (KeyCode.Space)) || (Input.GetMouseButtonDown (0)) && !jumpOff) {
			//LocalNotification.SendRepeatingNotification(1, 21600, 86400, LanguageManager.Instance.GetTextValue("notif00"), LanguageManager.Instance.GetTextValue("notif01"), new Color32(0xff, 0x44, 0x44, 255),true,false,true);
			if (PlayerPrefs.GetInt ("languageSelection") == 0) {
				LocalNotification.SendRepeatingNotification (1, 21600, 86400, "Can you solve?", "Try and see :)", new Color32 (0xff, 0x44, 0x44, 255), true, false, true);
				sleepUntil = Time.time + 99999;
			}
			if (PlayerPrefs.GetInt ("languageSelection") == 0) {
				LocalNotification.SendRepeatingNotification (1, 21600, 86400, "Çözebilir misin?", "Dene ve gör :)", new Color32 (0xff, 0x44, 0x44, 255), true, false, true);
				sleepUntil = Time.time + 99999;

			}
			Debug.Log ("Notification Active");
			if (grounded) {
				if(PlayerPrefs.GetString("StopMusic") != "stop"){
					MundoSound.Play (jumpEffect,soundEffect,false);
				}
				MRigidbody.velocity = new Vector2(MRigidbody.velocity.x,jumpForce);
				stoppedJumping = false; 
			}
			if (!grounded && canDoublejump) {
				MundoSound.Play (jumpEffect,soundEffect,false);
				canDoublejump = false;
				stoppedJumping = false;
				jumpTimeCounter = jumpTime;
				MRigidbody.velocity = new Vector2(MRigidbody.velocity.x,jumpForce);
			}

		}
		if ((Input.GetKey (KeyCode.Space) || (Input.GetMouseButton (0)) && !stoppedJumping && !jumpOff )) {
			if (jumpTimeCounter > 0) {
				MRigidbody.velocity =  new Vector2(MRigidbody.velocity.x,jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}
		if(Input.GetKeyUp(KeyCode.Space)||(Input.GetMouseButtonUp(0))){
			jumpTimeCounter = 0;
			stoppedJumping = true;
		}

		if (grounded) {
			speedAdder = 0.75f;
			canDoublejump = true;
			jumpTimeCounter = jumpTime;
			switch (selectCharacter) {
			case 0:
				lastGroundedPos = thePlayerBlue.transform.position;
				break;
			case 1:
				lastGroundedPos = thePlayerRed.transform.position;
				break;
			case 2:
				lastGroundedPos = thePlayerGreen.transform.position;
				break;
			case 3:
				lastGroundedPos = thePlayerGrey.transform.position;
				break;
			case 4:
				lastGroundedPos = thePlayerAlienBlue.transform.position;
				break;
			case 5:
				lastGroundedPos = thePlayerTruckRed.transform.position;
				break;
			case 6:
				lastGroundedPos = thePlayerTruckYellow.transform.position;
				break;
			case 7:
				lastGroundedPos = thePlayerTruckBlue.transform.position;
				break;
			case 8:
				lastGroundedPos = thePlayerTruckGreen.transform.position;
				break;
			case 9:
				lastGroundedPos = thePlayerRedDisk.transform.position;
				break;
			case 10:
				lastGroundedPos = thePlayerBlueReverse.transform.position;
				break;
			case 11:
				lastGroundedPos = thePlayerRedReverse.transform.position;
				break;
			case 12:
				lastGroundedPos = thePlayerGreenReverse.transform.position;
				break;
			case 13:
				lastGroundedPos = thePlayerGreyReverse.transform.position;
				break;
			case 14:
				lastGroundedPos = thePlayerDevil.transform.position;
				break;
			case 15:
				lastGroundedPos = thePlayerAlienBiege.transform.position;
				break;
			case 16:
				lastGroundedPos = thePlayerAlienYellow.transform.position;
				break;
			case 17:
				lastGroundedPos = thePlayerAlienDarkBlue.transform.position;
				break;
			case 18:
				lastGroundedPos = thePlayerAlienPink.transform.position;
				break;			
			}
		}

		if (Input.GetKeyUp (KeyCode.Escape)) {			
			//theManager.escape = true;
			if (PlayerPrefs.GetString ("NOTPAUSE") == "pause") {
				PlayerPrefs.SetInt ("ScrollBGStop", 0);
				PPause ();
			} else if (PlayerPrefs.GetString ("NOTPAUSE") == "not") {
				Debug.Log ("NOT PAUSEE :)");
			}
		}

		switch (selectCharacter) {
		case 0:
			MAnimatorBlue.SetBool ("Grounded", grounded);
			MAnimatorBlue.SetFloat ("Speed", MRigidbody.velocity.x);
			break;
		case 1:
			MAnimatorRed.SetBool ("GroundRed", grounded);
			MAnimatorRed.SetFloat ("SpeedRed", MRigidbody.velocity.x);
			break;
		case 2:
			MAnimatorGreen.SetBool ("GroundGreen", grounded);
			MAnimatorGreen.SetFloat ("SpeedGreen", MRigidbody.velocity.x);
			break;
		case 3:
			MAnimatorGrey.SetBool ("GroudGrey", grounded);
			MAnimatorGrey.SetFloat ("SpeedGrey", MRigidbody.velocity.x);
			break;
		case 4:
			MAnimatorAlienBlue.SetBool ("GroundAlienBlue", grounded);
			MAnimatorAlienBlue.SetFloat ("SpeedAlienBlue", MRigidbody.velocity.x);
			break;
		case 5:
			MAnimatorTruckRed.SetBool ("GroundTruckRed", grounded);
			MAnimatorTruckRed.SetFloat ("SpeedTruckRed", MRigidbody.velocity.x);
			break;
		case 6:
			MAnimatorTruckYellow.SetBool ("GroundTruckYellow", grounded);
			MAnimatorTruckYellow.SetFloat ("SpeedTruckYellow", MRigidbody.velocity.x);
			break;
		case 7:
			MAnimatorTruckBlue.SetBool ("GroundTruckBlue", grounded);
			MAnimatorTruckBlue.SetFloat ("SpeedTruckBlue", MRigidbody.velocity.x);
			break;
		case 8:
			MAnimatorTruckGreen.SetBool ("GroundTruckGreen", grounded);
			MAnimatorTruckGreen.SetFloat ("SpeedTruckGreen", MRigidbody.velocity.x);
			break;
		case 9:
			MAnimatorDiskRed.SetBool ("GroundDiskRed", grounded);
			MAnimatorDiskRed.SetFloat ("SpeedDiskRed", MRigidbody.velocity.x);
			break;
		case 10:
			MAnimatorBlueReverse.SetBool ("GroundBlueReverse", grounded);
			MAnimatorBlueReverse.SetFloat ("SpeedBlueReverse", MRigidbody.velocity.x);
			break;
		case 11:
			MAnimatorRedReverse.SetBool ("GroundRedReverse", grounded);
			MAnimatorRedReverse.SetFloat ("SpeedRedReverse", MRigidbody.velocity.x);
			break;
		case 12:
			MAnimatorGreenReverse.SetBool ("GroundGreenReverse", grounded);
			MAnimatorGreenReverse.SetFloat ("SpeedGreenReverse", MRigidbody.velocity.x);
			break;
		case 13:
			MAnimatorGreyReverse.SetBool ("GroundGreyReverse", grounded);
			MAnimatorGreyReverse.SetFloat ("SpeedGreyReverse", MRigidbody.velocity.x);
			break;
		case 14:
			MAnimatorDevil.SetBool ("GroundDevil", grounded);
			MAnimatorDevil.SetFloat ("SpeedDevil", MRigidbody.velocity.x);
			break;
		case 15:
			MAnimatorAlienBiege.SetBool ("GroundAlienBiege", grounded);
			MAnimatorAlienBiege.SetFloat ("SpeedAlienBiege", MRigidbody.velocity.x);
			break;
		case 16:
			MAnimatorAlienYellow.SetBool ("GroundAlienYellow", grounded);
			MAnimatorAlienYellow.SetFloat ("SpeedAlienYellow", MRigidbody.velocity.x);
			break;
		case 17:
			MAnimatorAlienDarkBlue.SetBool ("GroundAlienDarkBlue", grounded);
			MAnimatorAlienDarkBlue.SetFloat ("SpeedAlienDarkBlue", MRigidbody.velocity.x);
			break;
		case 18:
			MAnimatorAlienPink.SetBool ("GroundAlienPink", grounded);
			MAnimatorAlienPink.SetFloat ("SpeedAlienPink", MRigidbody.velocity.x);
			break;
	
		}
	
		timeF = 1*Time.fixedTime;
		timeI = (int)Mathf.Round (timeF);

		switch (selectCharacter) {
		case 0:
			lastGrounded2 = thePlayerBlue.transform.position;
			break;
		case 1:
			lastGrounded2 = thePlayerRed.transform.position;
			break;
		case 2:
			lastGrounded2 = thePlayerGreen.transform.position;
			break;
		case 3:
			lastGrounded2 = thePlayerGrey.transform.position;
			break;
		case 4:
			lastGrounded2 = thePlayerAlienBlue.transform.position;
			break;
		case 5:
			lastGrounded2 = thePlayerTruckRed.transform.position;
			break;
		case 6:
			lastGrounded2 = thePlayerTruckYellow.transform.position;
			break;
		case 7:
			lastGrounded2 = thePlayerTruckBlue.transform.position;
			break;
		case 8:
			lastGrounded2 = thePlayerTruckGreen.transform.position;
			break;
		case 9:
			lastGrounded2 = thePlayerRedDisk.transform.position;
			break;
		case 10:
			lastGrounded2 = thePlayerBlueReverse.transform.position;
			break;
		case 11:
			lastGrounded2 = thePlayerRedReverse.transform.position;
			break;
		case 12:
			lastGrounded2 = thePlayerGreenReverse.transform.position;
			break;
		case 13:
			lastGrounded2 = thePlayerGreyReverse.transform.position;
			break;
		case 14:
			lastGrounded2 = thePlayerDevil.transform.position;
			break;
		case 15:
			lastGrounded2 = thePlayerAlienBiege.transform.position;
			break;
		case 16:
			lastGrounded2 = thePlayerAlienYellow.transform.position;
			break;
		case 17:
			lastGrounded2 = thePlayerAlienDarkBlue.transform.position;
			break;
		case 18:
			lastGrounded2 = thePlayerAlienPink.transform.position;
			break;			
		}
		//timeF = Time.deltaTime;

		for (timeI = (int)Mathf.Round (timeF); timeF == t;t++) {			
			/*if (minus != 0) {
				

				if (minus == minusB) {
					timeAdd -= 0.75f * minusB / 3;
					minusB += 3;
					PlayerPrefs.SetFloat ("TimeAdded", timeAdd);
				
				}*/

			
			//}

			timeAdd += 0.75f;
			PlayerPrefs.SetFloat ("TimeAdded", timeAdd);

			t = t+3;
		}
		timeAdded = PlayerPrefs.GetFloat ("TimeAdded");

	
	}

	void OnCollisionEnter2D (Collision2D other){

		if (other.gameObject.tag == "killbox") {
			//a = Random.Range (0, 2);
			//	greenGem.transform.position = greenGemPos;

			PlayerPrefs.SetInt ("ScrollBGStop", 0);
			PlayerPrefs.SetInt ("Starter", 1);
			PlayerPrefs.SetInt ("noStuck", 0);


			//theManager.RestartGame ();
			//	thePause.gameObject.SetActive(true);	
			if (theQuestions.i == PlayerPrefs.GetInt ("i")) {
				theManager.RestartGame ();
			} else {
				thePause.QuestionPause ();		
			}
//			theScroll.speed = 0f;
			moveSpeed = moveSpeedStore;
			speedCount = speedCountStore;
			speedIncrease = speedIncreaseStore;
		

		} else if (other.gameObject.tag == "collider") {
			Debug.Log ("Something Happened");
		

		}
		/*if (bgg == 1) {
		for (int i = 0; i < texts.Length; i++) {
			texts [i].color = new Color32 (0,0,0,255);
			coinGold.color = new Color32 (255, 255, 255, 255);
			coinBronze.color = new Color32 (255, 255, 255, 255);
		}
		} else {
			for (int i = 0; i < texts.Length; i++) {
				texts [i].color = new Color32 (255, 255, 255, 255);
				coinGold.color = new Color32 (255, 255, 255, 255);
				coinBronze.color = new Color32 (255, 255, 255, 255);
			}*/
	
	}

	public void TouchJumpOn(){
		jumpOff = true;
	}
	public IEnumerator stopPlay(){
		if ((Input.GetKey (KeyCode.Space) || (Input.GetMouseButton (0)) && !stoppedJumping && !jumpOff)) {
			Debug.Log ("0.25ff");
		}
		yield return new WaitForSeconds (0.1f);
	}
	public void PPause(){
		if (PlayerPrefs.GetInt ("ESC") == 1) {

			thePauseMenu.SetActive (true);	
			thePause.PauseGame ();
		}
	}
}
