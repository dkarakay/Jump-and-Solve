using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {
	//public PlayerController thePlayer;
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

	public Text[] texts;

	public GameObject[] BGs;

	public GameObject [] Platforms;
	public GameObject[] thePlayerAll;

	public Transform stopTransform;

	public PlayerController PLthePlayerBlue;
	public PlayerController PLthePlayerRed;
	public PlayerController PLthePlayerGreen;
	public PlayerController PLthePlayerGrey;
	public PlayerController PLthePlayerAlienBlue;
	public PlayerController PLthePlayerTruckRed;
	public PlayerController PLthePlayerTruckYellow;
	public PlayerController PLthePlayerDiskRed;
	public PlayerController PLthePlayerTruckBlue;
	public PlayerController PLthePlayerTruckGreen;
	public PlayerController PLthePlayerBlueReverse;
	public PlayerController PLthePlayerRedReverse;
	public PlayerController PLthePlayerGreenReverse;
	public PlayerController PLthePlayerGreyReverse;
	public PlayerController PLthePlayerAlienYellow;
	public PlayerController PLthePlayerAlienBiege;
	public PlayerController PLthePlayerAlienPink;
	public PlayerController PLthePlayerAlienDarkBlue;
	public PlayerController PLthePlayerDevil;
	public float windowAspect;
	public GameManager theManager;
	public PlayerController thePlay;

	public GameObject thePlayers;

	private Vector3 lastPlayerPos;
	public float MoveToDistance;
	private int selectCharacter,selectedTile,selectedBackground;
	public int time,moveToIa,moveToIb;
	public float timeF,moveToF;
	public int timeAdd;
	public int a,addDebug,addDebug2,randomm,randomBG;
	public bool stopOrNot,stopOrNot2,stopOrNot3;

	public Vector3 pos01,pos02,pos00;
	public float bg01, bg02;

	public Transform cameraTransform;
	public float BGQ002, BGQ001;
	public float cameraPos;
	public GameObject[] BGQ;
	public Vector3 poss;

	public GameObject theGoldAd;

	void Awake(){		
		PlayerPrefs.SetInt ("i",5);
		PlayerPrefs.SetInt ("ESC",1);
		PlayerPrefs.SetString("StopMusic","start");
		PlayerPrefs.SetInt ("noStuck", 1);
		timeF = 0;
		//a =(int) Random.Range (0f,18.5f);
		//a = (int) Mathf.Round (a);
		randomm = (int)Mathf.Round(Random.Range (0f,12.5f));
		randomBG = (int)Mathf.Round(Random.Range (-0.5f,2.5f));
		//PlayerPrefs.SetInt ("CharacterSelected", a);
		//PlayerPrefs.SetInt ("selectedTile", randomm);
		//PlayerPrefs.SetInt ("selectedBG", randomBG);
		selectedTile = PlayerPrefs.GetInt ("selectedTile");
		selectedBackground = PlayerPrefs.GetInt ("selectedBG");
		selectCharacter = PlayerPrefs.GetInt ("CharacterSelected");

	}
	void Start () {
		theGoldAd.SetActive (true);
		windowAspect = (float)Screen.width / (float)Screen.height;
		if (windowAspect == 4f / 3f) {
			transform.position = new Vector3 (transform.position.x - 1f, transform.position.y, transform.position.z);
		} else if (windowAspect == 1.24f || windowAspect == 1.25f) {
			transform.position = new Vector3 (transform.position.x - 1.5f, transform.position.y, transform.position.z);
		}
		PlayerPrefs.SetInt ("ScrollBGG", 0);
		PlayerPrefs.SetInt ("scrollCamera", 0);
		bg01 = 38.4f;
		bg02 = 76.8f;
		/*PlayerPrefs.SetInt ("ErrorThird", 0);
		switch (selectedBackground) {
		case 0:
			BGs [0].SetActive (true);
			break;
		case 1:
			BGs [1].SetActive (true);
			break;
		case 2:
			BGs [2].SetActive (true);
			break;
		case 3:
			BGs [3].SetActive (true);
			break;
		case 4:
			BGs [4].SetActive (true);
			break;
		case 5:
			BGs [5].SetActive (true);
			break;

		}*/
		theManager.escape = false;
		addDebug = 0;
		addDebug2 = 0;
		stopOrNot = false;
		stopOrNot2 = false;
		stopOrNot3 = false;
		timeAdd = 3;
		moveToIa = 0;
		moveToIb = 0;

		thePlay = FindObjectOfType<PlayerController> ();
		/*PlayerPrefs.SetInt ("CharacterSelected", 0);
		selectCharacter = PlayerPrefs.GetInt ("CharacterSelected");*/
		thePlayers.SetActive (true);
		switch (selectedBackground) {
		case 0:			
			BGs [0].SetActive (true);
			BGs [1].SetActive (true);
			break;
		case 1:			
			BGs [2].SetActive (true);
			BGs [3].SetActive (true);

			break;
		case 2:			
			BGs [4].SetActive (true);
			BGs [5].SetActive (true);
			break;	
		}
		switch (selectedTile) {
		case 0:
			Platforms [0].SetActive (true);
			Platforms [1].SetActive (true);
			break;
		case 1:
			Platforms [24].SetActive (true);
			Platforms [25].SetActive (true);
			break;
		case 2:
			Platforms [12].SetActive (true);
			Platforms [13].SetActive (true);
			break;
		case 3:
			Platforms [2].SetActive (true);
			Platforms [3].SetActive (true);
			break;
		case 4:
			Platforms [4].SetActive (true);
			Platforms [5].SetActive (true);
			break;
		case 5:
			Platforms [6].SetActive (true);
			Platforms [7].SetActive (true);
			break;
		case 6:
			Platforms [8].SetActive (true);
			Platforms [9].SetActive (true);
			break;
		case 7:
			Platforms [10].SetActive (true);
			Platforms [11].SetActive (true);
			break;
		case 8:
			Platforms [14].SetActive (true);
			Platforms [15].SetActive (true);
			break;
		case 9:
			Platforms [18].SetActive (true);
			Platforms [19].SetActive (true);
			break;
		case 10:
			Platforms [20].SetActive (true);
			Platforms [21].SetActive (true);
			break;
		case 11:
			Platforms [22].SetActive (true);
			Platforms [23].SetActive (true);
			break;
		case 12:
			Platforms [16].SetActive (true);
			Platforms [17].SetActive (true);
			break;
		
		}

		switch (selectCharacter) {
		case 0:
			thePlayerBlue.SetActive (true);
			lastPlayerPos = thePlayerBlue.transform.position;
			break;
		case 1:
			thePlayerRed.SetActive (true);
			lastPlayerPos = thePlayerRed.transform.position;
			break;
		case 2:
			thePlayerGreen.SetActive (true);
			lastPlayerPos = thePlayerGreen.transform.position;
			break;
		case 3:
			thePlayerGrey.SetActive (true);
			lastPlayerPos = thePlayerGrey.transform.position;
			break;
		case 4:
			thePlayerAlienBlue.SetActive (true);
			lastPlayerPos = thePlayerAlienBlue.transform.position;
			break;
		case 5:
			thePlayerTruckRed.SetActive (true);
			lastPlayerPos = thePlayerTruckRed.transform.position;
			break;
		case 6:
			thePlayerTruckYellow.SetActive (true);
			lastPlayerPos = thePlayerTruckYellow.transform.position;
			break;
		case 7:
			thePlayerTruckBlue.SetActive (true);
			lastPlayerPos = thePlayerTruckBlue.transform.position;
			break;
		case 8:
			thePlayerTruckGreen.SetActive (true);
			lastPlayerPos = thePlayerTruckGreen.transform.position;
			break;
		case 9:
			thePlayerDiskRed.SetActive (true);
			lastPlayerPos = thePlayerDiskRed.transform.position;
			break;
		case 10:
			thePlayerBlueReverse.SetActive (true);
			lastPlayerPos = thePlayerBlueReverse.transform.position;
			break;
		case 11:
			thePlayerRedReverse.SetActive (true);
			lastPlayerPos = thePlayerRedReverse.transform.position;
			break;
		case 12:
			thePlayerGreenReverse.SetActive (true);
			lastPlayerPos = thePlayerGreenReverse.transform.position;
			break;
		case 13:
			thePlayerGreyReverse.SetActive (true);
			lastPlayerPos = thePlayerGreyReverse.transform.position;
			break;
		case 14:
			thePlayerDevil.SetActive (true);
			lastPlayerPos = thePlayerDevil.transform.position;
			break;
		case 15:
			thePlayerAlienBiege.SetActive (true);
			lastPlayerPos = thePlayerAlienBiege.transform.position;
			break;
		case 16:
			thePlayerAlienYellow.SetActive (true);
			lastPlayerPos = thePlayerAlienYellow.transform.position;
			break;
		case 17:
			thePlayerAlienDarkBlue.SetActive (true);
			lastPlayerPos = thePlayerAlienDarkBlue.transform.position;
			break;
		case 18:
			thePlayerAlienPink.SetActive (true);
			lastPlayerPos = thePlayerAlienPink.transform.position;
			break;

		}



	
	}

	// Update is called once per frame
	void Update () {		
		/*BGQ001 = BGs [0].transform.position.x;
		BGQ002 = BGs [1].transform.position.x;*/

		cameraPos = transform.position.x;
		if(PlayerPrefs.GetInt("scrollCamera") == 0){
		if(cameraPos > bg01+4f  && cameraPos < bg01+6f ){
			Debug.Log ("ScrollBG 01");
			switch (selectedBackground) {
				case 0:
					BGs [0].transform.position = new Vector3 (BGs[0].transform.position.x + 76.8f,BGs[0].transform.position.y,BGs[0].transform.position.z);
					break;
				case 1:
					BGs [2].transform.position = new Vector3 (BGs[2].transform.position.x + 76.8f,BGs[2].transform.position.y,BGs[2].transform.position.z);
					break;
				case 2:
					BGs [4].transform.position = new Vector3 (BGs[4].transform.position.x + 76.8f,BGs[4].transform.position.y,BGs[4].transform.position.z);
					break;
				}
			
			PlayerPrefs.SetInt ("scrollCamera", 1);
		}  
		if(cameraPos > bg02+4f && cameraPos < bg02+6f ){
			Debug.Log ("ScrollBG 02");
				switch (selectedBackground) {
				case 0:
					BGs [1].transform.position = new Vector3 (BGs[1].transform.position.x + 76.8f,BGs[1].transform.position.y,BGs[1].transform.position.z);
					break;
				case 1:
					BGs [3].transform.position = new Vector3 (BGs[3].transform.position.x + 76.8f,BGs[3].transform.position.y,BGs[3].transform.position.z);
					break;
				case 2:
					BGs [5].transform.position = new Vector3 (BGs[5].transform.position.x + 76.8f,BGs[5].transform.position.y,BGs[5].transform.position.z);
					break;
				}
			PlayerPrefs.SetInt ("scrollCamera", 1);
		}
		}
		/*if (PlayerPrefs.GetInt ("ScrollBGG") == 1) {
			if (BGQ002 > BGQ001) {
				switch (selectedBackground) {
				case 0:
					BGQ [0].SetActive (true);
					BGQ [0].transform.position = new Vector3 (BGs [0].transform.position.x, BGs [0].transform.position.y, BGs [0].transform.position.z);
					break;
				case 1:
					BGQ [1].SetActive (true);
					BGQ [1].transform.position = new Vector3 (BGs [2].transform.position.x, BGs [2].transform.position.y, BGs [2].transform.position.z);
					break;
				case 2:
					BGQ [2].SetActive (true);
					BGQ [2].transform.position = new Vector3 (BGs [4].transform.position.x, BGs [4].transform.position.y, BGs [4].transform.position.z);
					break;
				}
			} else if (BGQ001 > BGQ002) {
				switch (selectedBackground) {
				case 0:
					BGQ [0].SetActive (true);
					BGQ [0].transform.position = new Vector3 (BGs [1].transform.position.x, BGs [1].transform.position.y, BGs [1].transform.position.z);
					break;
				case 1:
					BGQ [1].SetActive (true);
					BGQ [1].transform.position = new Vector3 (BGs [3].transform.position.x, BGs [3].transform.position.y, BGs [3].transform.position.z);
					break;
				case 2:
					BGQ [2].SetActive (true);
					BGQ [2].transform.position = new Vector3 (BGs [5].transform.position.x, BGs [5].transform.position.y, BGs [5].transform.position.z);
					break;
				 
				}
			}
			PlayerPrefs.SetInt ("ScrollBGG", 0);
			/*BGQ [0].SetActive (false);
			BGQ [1].SetActive (false);
			BGQ [2].SetActive (false);
		}*/
		if(cameraPos > bg01 +5f && cameraPos <bg01 +7f){
			bg01 += 38.4f*2;
			PlayerPrefs.SetInt ("scrollCamera", 0);
		}
		if(cameraPos > bg02 +5f && cameraPos <bg02 +7f){
			bg02 += 38.4f*2;
			PlayerPrefs.SetInt ("scrollCamera", 0);
		}
		switch (selectedBackground) {
		case 0:
			BGQ [0].SetActive (true);
			if (BGs [0].transform.position.x < BGs [1].transform.position.x) {
				BGQ [0].transform.position = new Vector3 (BGs[0].transform.position.x - 19.2f,BGQ[0].transform.position.y,BGQ[0].transform.position.z);
			}else if (BGs [0].transform.position.x > BGs [1].transform.position.x) {
				BGQ [0].transform.position = new Vector3 (BGs[1].transform.position.x - 19.2f,BGQ[0].transform.position.y,BGQ[0].transform.position.z);
			}
			break;
		case 1:
			BGQ [1].SetActive (true);
			if (BGs [2].transform.position.x < BGs [3].transform.position.x) {
				BGQ [1].transform.position = new Vector3 (BGs[2].transform.position.x - 19.2f,BGQ[1].transform.position.y,BGQ[1].transform.position.z);
		 	}else if (BGs [2].transform.position.x > BGs [3].transform.position.x) {
				BGQ [1].transform.position = new Vector3 (BGs[3].transform.position.x - 19.2f,BGQ[1].transform.position.y,BGQ[1].transform.position.z);
			}
			break;
		case 2:
			BGQ [2].SetActive (true);
			if (BGs [4].transform.position.x < BGs [5].transform.position.x) {
				BGQ [2].transform.position = new Vector3 (BGs[4].transform.position.x- 19.2f,BGQ[2].transform.position.y,BGQ[2].transform.position.z);
			}else if (BGs [4].transform.position.x > BGs [5].transform.position.x) {
				BGQ [2].transform.position = new Vector3 (BGs[5].transform.position.x - 19.2f,BGQ[2].transform.position.y,BGQ[2].transform.position.z);
			}
			break;

		}

		timeF = Time.fixedTime * 1;
		time = (int)timeF;
		moveToF = MoveToDistance * 20;
		if (time > 3) {
			for (time = (int)timeF; time >= timeAdd; timeAdd++) {
				if (PlayerPrefs.GetInt ("NOStuck") == 1) {
					PlayerPrefs.SetInt ("noStuck", 1);
				}
				if (moveToF == 0f) {
					stopOrNot = true;
				} else {
					stopOrNot = false;
				}
				/*for (time += 1; time >= timeAdd; timeAdd++) {
					if (stopOrNot == true) {
						if (moveToF == 0f) {
							stopOrNot2 = true;
						}
					} else {
						stopOrNot2 = false;
					}
					/*for (time += 1; time >= timeAdd; timeAdd++) {
						if (stopOrNot2 == true) {
							if (moveToF == 0f) {
								Position02 ();
								stopOrNot3 = true;
							}
						} else {
							stopOrNot3 = false;
						}
					}

					moveToIb += (int)moveToF;
					//time++;
				}*/
				Position01 ();
				moveToIa += (int)moveToF;
				//time++;

			}			
		}

		if (stopOrNot/* && stopOrNot2/* && stopOrNot3*/) {
			if (pos00.x > stopTransform.position.x) {
				Debug.Log ("Done " + addDebug);
				Stuck ();


				addDebug += 1;
			}
			//Debug.Log ("FPart " + addDebug);
			addDebug += 1;
		}

		
		switch(selectCharacter){
		case 0:	
			MoveToDistance = thePlayerBlue.transform.position.x - lastPlayerPos.x;
			transform.position = new Vector3 (transform.position.x + MoveToDistance, transform.position.y, transform.position.z);
			lastPlayerPos = thePlayerBlue.transform.position;
			pos00 = thePlayerBlue.transform.position;
			break;
		case 1:
			MoveToDistance = thePlayerRed.transform.position.x - lastPlayerPos.x;
			transform.position = new Vector3 (transform.position.x + MoveToDistance, transform.position.y, transform.position.z);
			lastPlayerPos = thePlayerRed.transform.position;
			pos00 = thePlayerRed.transform.position;
			break;
		case 2:	
			MoveToDistance = thePlayerGreen.transform.position.x - lastPlayerPos.x;
			transform.position = new Vector3 (transform.position.x + MoveToDistance, transform.position.y, transform.position.z);
			lastPlayerPos = thePlayerGreen.transform.position;
			pos00 = thePlayerGreen.transform.position;
			break;
		case 3:
			MoveToDistance = thePlayerGrey.transform.position.x - lastPlayerPos.x;
			transform.position = new Vector3 (transform.position.x + MoveToDistance, transform.position.y, transform.position.z);
			lastPlayerPos = thePlayerGrey.transform.position;
			pos00 = thePlayerGrey.transform.position;
			break;
		case 4:
			MoveToDistance = thePlayerAlienBlue.transform.position.x - lastPlayerPos.x;
			transform.position = new Vector3 (transform.position.x + MoveToDistance, transform.position.y, transform.position.z);
			lastPlayerPos = thePlayerAlienBlue.transform.position;
			pos00 = thePlayerAlienBlue.transform.position;
			break;
		case 5:
			MoveToDistance = thePlayerTruckRed.transform.position.x - lastPlayerPos.x;
			transform.position = new Vector3 (transform.position.x + MoveToDistance, transform.position.y, transform.position.z);
			lastPlayerPos = thePlayerTruckRed.transform.position;
			pos00 = PLthePlayerTruckRed.transform.position;
			break;
		case 6:
			MoveToDistance = thePlayerTruckYellow.transform.position.x - lastPlayerPos.x;
			transform.position = new Vector3 (transform.position.x + MoveToDistance, transform.position.y, transform.position.z);
			lastPlayerPos = thePlayerTruckYellow.transform.position;
			pos00 = thePlayerTruckYellow.transform.position;
			break;
		case 7:
			MoveToDistance = thePlayerTruckBlue.transform.position.x - lastPlayerPos.x;
			transform.position = new Vector3 (transform.position.x + MoveToDistance, transform.position.y, transform.position.z);
			lastPlayerPos = thePlayerTruckBlue.transform.position;
			pos00 = thePlayerTruckBlue.transform.position;
			break;
		case 8:
			MoveToDistance = thePlayerTruckGreen.transform.position.x - lastPlayerPos.x;
			transform.position = new Vector3 (transform.position.x + MoveToDistance, transform.position.y, transform.position.z);
			lastPlayerPos = thePlayerTruckGreen.transform.position;
			pos00 = thePlayerTruckGreen.transform.position;
			break;
		case 9:
			MoveToDistance = thePlayerDiskRed.transform.position.x - lastPlayerPos.x;
			transform.position = new Vector3 (transform.position.x + MoveToDistance, transform.position.y, transform.position.z);
			lastPlayerPos = thePlayerDiskRed.transform.position;
			pos00 = thePlayerDiskRed.transform.position;
			break;
		case 10:
			MoveToDistance = thePlayerBlueReverse.transform.position.x - lastPlayerPos.x;
			transform.position = new Vector3 (transform.position.x + MoveToDistance, transform.position.y, transform.position.z);
			lastPlayerPos = thePlayerBlueReverse.transform.position;
			pos00 = thePlayerBlueReverse.transform.position;
			break;
		case 11:	
			MoveToDistance = thePlayerRedReverse.transform.position.x - lastPlayerPos.x;
			transform.position = new Vector3 (transform.position.x + MoveToDistance, transform.position.y, transform.position.z);
			lastPlayerPos = thePlayerRedReverse.transform.position;
			pos00 = thePlayerRedReverse.transform.position;
			break;
		case 12:
			MoveToDistance = thePlayerGreenReverse.transform.position.x - lastPlayerPos.x;
			transform.position = new Vector3 (transform.position.x + MoveToDistance, transform.position.y, transform.position.z);
			lastPlayerPos = thePlayerGreenReverse.transform.position;
			pos00 = thePlayerGreenReverse.transform.position;
			break;
		case 13:
			MoveToDistance = thePlayerGreyReverse.transform.position.x - lastPlayerPos.x;
			transform.position = new Vector3 (transform.position.x + MoveToDistance, transform.position.y, transform.position.z);
			lastPlayerPos = thePlayerGreyReverse.transform.position;
			pos00 = thePlayerGreyReverse.transform.position;
			break;
		case 14:
			MoveToDistance = thePlayerDevil.transform.position.x - lastPlayerPos.x;
			transform.position = new Vector3 (transform.position.x + MoveToDistance, transform.position.y, transform.position.z);
			lastPlayerPos = thePlayerDevil.transform.position;
			pos00 = thePlayerDevil.transform.position;
			break;
		case 15:
			MoveToDistance = thePlayerAlienBiege.transform.position.x - lastPlayerPos.x;
			transform.position = new Vector3 (transform.position.x + MoveToDistance, transform.position.y, transform.position.z);
			lastPlayerPos = thePlayerAlienBiege.transform.position;
			pos00 = thePlayerAlienBiege.transform.position;
			break;
		case 16:
			MoveToDistance = thePlayerAlienYellow.transform.position.x - lastPlayerPos.x;
			transform.position = new Vector3 (transform.position.x + MoveToDistance, transform.position.y, transform.position.z);
			lastPlayerPos = thePlayerAlienYellow.transform.position;
			pos00 = thePlayerAlienYellow.transform.position;
			break;
		case 17:
			MoveToDistance = thePlayerAlienDarkBlue.transform.position.x - lastPlayerPos.x;
			transform.position = new Vector3 (transform.position.x + MoveToDistance, transform.position.y, transform.position.z);
			lastPlayerPos = thePlayerAlienDarkBlue.transform.position;
			pos00 = thePlayerAlienDarkBlue.transform.position;
			break;
		case 18:
			MoveToDistance = thePlayerAlienPink.transform.position.x - lastPlayerPos.x;
			transform.position = new Vector3 (transform.position.x + MoveToDistance, transform.position.y, transform.position.z);
			lastPlayerPos = thePlayerAlienPink.transform.position;
			pos00 = thePlayerAlienPink.transform.position;
			break;
		}

	
	}
	


/*moveToIa += (int)moveToF;
				time++;
				for (time += 1; time >= timeAdd; timeAdd++) {
					time++;
					moveToIb += (int)moveToF;
					for (time += 1 ; time >= timeAdd; timeAdd++) {
						moveToIc += (int)moveToF;
						moveToIT = moveToIa + moveToIb + moveToIc;
						if (moveToIT / 3 == 1) {
							PLthePlayerTruckRed.MRigidbody.velocity = new Vector2(PLthePlayerTruckRed.MRigidbody.velocity.x,PLthePlayerTruckRed.jumpForce);
						}
						//time++;
					}

				}*/
/*if (timeF >= 3) {
if (MoveToDistance == 0.0000) {
	switch (selectCharacter) {
	case 5:
		PLthePlayerTruckRed.MRigidbody.velocity = new Vector2(PLthePlayerTruckRed.MRigidbody.velocity.x,PLthePlayerTruckRed.jumpForce);
		break;
	}
}
}*/

void Position01(){
	switch (selectCharacter) {
	case 0:
		pos01 = PLthePlayerBlue.transform.position;
			break;
	case 1:
			pos01 = PLthePlayerRed.transform.position;
			break;
	case 2:
		pos01 = PLthePlayerGreen.transform.position;
		break;
	case 3:
		pos01 = PLthePlayerGrey.transform.position;
		break;
	case 4:
		pos01 = PLthePlayerAlienBlue.transform.position;
		break;
	case 5:
		pos01 = PLthePlayerTruckRed.transform.position;
		break;
	case 6:
		pos01 = PLthePlayerTruckYellow.transform.position;
		break;
	case 7:
		pos01 = PLthePlayerTruckBlue.transform.position;
		break;
	case 8:
		pos01 = PLthePlayerTruckGreen.transform.position;
		break;
	case 9:
		pos01 = PLthePlayerDiskRed.transform.position;
		break;
	case 10:
		pos01 = PLthePlayerBlueReverse.transform.position;
		break;
	case 11:
		pos01 = PLthePlayerRedReverse.transform.position;
		break;
	case 12:
		pos01 = PLthePlayerGreenReverse.transform.position;
		break;
	case 13:
		pos01 = PLthePlayerGreyReverse.transform.position;
		break;
	case 14:
		pos01 = PLthePlayerDevil.transform.position;
		break;
	case 15:
		pos01 = PLthePlayerAlienBiege.transform.position;
		break;
	case 16:
		pos01 = PLthePlayerAlienYellow.transform.position;
		break;
	case 17:
		pos01 = PLthePlayerAlienDarkBlue.transform.position;
		break;
	case 18:
		pos01 = PLthePlayerAlienPink.transform.position;
		break;


	}
	}
void Stuck (){
			switch (selectCharacter) {
			case 0:			
		if (PlayerPrefs.GetInt ("noStuck") == 1) {
				if (moveToF == 0) {
					if (pos01 == pos00 /*&& pos00 == pos02 && pos01 == pos02*/) {
						if (pos00 == PLthePlayerBlue.transform.position) {
							PLthePlayerBlue.MRigidbody.velocity = new Vector2 (PLthePlayerBlue.MRigidbody.velocity.x, 20);
							Debug.Log ("Donee :) " + addDebug2);
							stopOrNot3 = false;
							stopOrNot2 = false;
							stopOrNot = false;
							addDebug2 += 1;
						}
					}
				}
			}
				break;
			case 1:			
		if (PlayerPrefs.GetInt ("noStuck") == 1) {
				if (moveToF == 0) {
					if (pos01 == pos00 /*&& pos00 == pos02 && pos01 == pos02*/) {
						if (pos00 == PLthePlayerRed.transform.position) {
							PLthePlayerRed.MRigidbody.velocity = new Vector2 (PLthePlayerRed.MRigidbody.velocity.x, 20);
							Debug.Log ("Donee :) " + addDebug2);
							stopOrNot3 = false;
							stopOrNot2 = false;
							stopOrNot = false;
							addDebug2 += 1;
						}
					}
				}
			}
				break;
			case 2:			
		if (PlayerPrefs.GetInt ("noStuck") == 1){
				if (moveToF == 0) {
					if (pos01 == pos00 /*&& pos00 == pos02 && pos01 == pos02*/) {
						if (pos00 == PLthePlayerGreen.transform.position) {
							PLthePlayerGreen.MRigidbody.velocity = new Vector2 (PLthePlayerGreen.MRigidbody.velocity.x, 20);
							Debug.Log ("Donee :) " + addDebug2);
							stopOrNot3 = false;
							stopOrNot2 = false;
							stopOrNot = false;
							addDebug2 += 1;
						}
					}
				}
			}
				break;
			case 3:			
		if (PlayerPrefs.GetInt ("noStuck") == 1){
				if (moveToF == 0) {
					if (pos01 == pos00/* && pos00 == pos02 && pos01 == pos02*/) {
						if (pos00 == PLthePlayerGrey.transform.position) {
							PLthePlayerGrey.MRigidbody.velocity = new Vector2 (PLthePlayerGrey.MRigidbody.velocity.x, 20);
							Debug.Log ("Donee :) " + addDebug2);
							stopOrNot3 = false;
							stopOrNot2 = false;
							stopOrNot = false;
							addDebug2 += 1;
						}
					}
				}
			}
				break;
			case 4:			
		if (PlayerPrefs.GetInt ("noStuck") == 1) {
				if (moveToF == 0) {
					if (pos01 == pos00/* && pos00 == pos02 && pos01 == pos02*/) {
						if (pos00 == PLthePlayerAlienBlue.transform.position) {
							PLthePlayerAlienBlue.MRigidbody.velocity = new Vector2 (PLthePlayerAlienBlue.MRigidbody.velocity.x, 20);
							Debug.Log ("Donee :) " + addDebug2);
							stopOrNot3 = false;
							stopOrNot2 = false;
							stopOrNot = false;
							addDebug2 += 1;
						}
					}
				}
			}
				break;
			case 5:			
		if (PlayerPrefs.GetInt ("noStuck") == 1){
				if (moveToF == 0) {
					if (pos01 == pos00 /*&& pos00 == pos02 && pos01 == pos02*/) {
						if (pos00 == PLthePlayerTruckRed.transform.position) {
							PLthePlayerTruckRed.MRigidbody.velocity = new Vector2 (PLthePlayerTruckRed.MRigidbody.velocity.x, 20);
							Debug.Log ("Donee :) " + addDebug2);
							stopOrNot3 = false;
							stopOrNot2 = false;
							stopOrNot = false;
							addDebug2 += 1;
						}
					}
				}
			}
				break;
			case 6:			
		if (PlayerPrefs.GetInt ("noStuck") == 1){
				if (moveToF == 0) {
					if (pos01 == pos00/* && pos00 == pos02 && pos01 == pos02*/) {
						if (pos00 == PLthePlayerTruckYellow.transform.position) {
							PLthePlayerTruckYellow.MRigidbody.velocity = new Vector2 (PLthePlayerTruckYellow.MRigidbody.velocity.x, 20);
							Debug.Log ("Donee :) " + addDebug2);
							stopOrNot3 = false;
							stopOrNot2 = false;
							stopOrNot = false;
							addDebug2 += 1;
						}
					}
				}
			}
				break;
			case 7:			
		if (PlayerPrefs.GetInt ("noStuck") == 1) {
				if (moveToF == 0) {
					if (pos01 == pos00/* && pos00 == pos02 && pos01 == pos02*/) {
						if (pos00 == PLthePlayerTruckBlue.transform.position) {
							PLthePlayerTruckBlue.MRigidbody.velocity = new Vector2 (PLthePlayerTruckBlue.MRigidbody.velocity.x, 20);
							Debug.Log ("Donee :) " + addDebug2);
							stopOrNot3 = false;
							stopOrNot2 = false;
							stopOrNot = false;
							addDebug2 += 1;
						}
					}
				}
			}
				break;
			case 8:			
		if (PlayerPrefs.GetInt ("noStuck") == 1) {
				if (moveToF == 0) {
					if (pos01 == pos00 /*&& pos00 == pos02 && pos01 == pos02*/) {
						if (pos00 == PLthePlayerTruckGreen.transform.position) {
							PLthePlayerTruckGreen.MRigidbody.velocity = new Vector2 (PLthePlayerTruckGreen.MRigidbody.velocity.x, 20);
							Debug.Log ("Donee :) " + addDebug2);
							stopOrNot3 = false;
							stopOrNot2 = false;
							stopOrNot = false;
							addDebug2 += 1;
						}
					}
				}
			}
				break;
			case 9:			
		if (PlayerPrefs.GetInt ("noStuck") == 1) {
				if (moveToF == 0) {
					if (pos01 == pos00 /*&& pos00 == pos02 && pos01 == pos02*/) {
						if (pos00 == PLthePlayerDiskRed.transform.position) {
							PLthePlayerDiskRed.MRigidbody.velocity = new Vector2 (PLthePlayerDiskRed.MRigidbody.velocity.x, 20);
							Debug.Log ("Donee :) " + addDebug2);
							stopOrNot3 = false;
							stopOrNot2 = false;
							stopOrNot = false;
							addDebug2 += 1;
						}
					}
				}
			}
				break;
			case 10:			
		if (PlayerPrefs.GetInt ("noStuck") == 1) {
				if (moveToF == 0) {
					if (pos01 == pos00/* && pos00 == pos02 && pos01 == pos02*/) {
						if (pos00 == PLthePlayerBlueReverse.transform.position) {
							PLthePlayerBlueReverse.MRigidbody.velocity = new Vector2 (PLthePlayerBlueReverse.MRigidbody.velocity.x, 20);
							Debug.Log ("Donee :) " + addDebug2);
							stopOrNot3 = false;
							stopOrNot2 = false;
							stopOrNot = false;
							addDebug2 += 1;
						}
					}
				}
			}
				break;
			case 11:			
		if (PlayerPrefs.GetInt ("noStuck") == 1){
				if (moveToF == 0) {
					if (pos01 == pos00 /*&& pos00 == pos02 && pos01 == pos02*/) {
						if (pos00 == PLthePlayerRedReverse.transform.position) {
							PLthePlayerRedReverse.MRigidbody.velocity = new Vector2 (PLthePlayerRedReverse.MRigidbody.velocity.x, 20);
							Debug.Log ("Donee :) " + addDebug2);
							stopOrNot3 = false;
							stopOrNot2 = false;
							stopOrNot = false;
							addDebug2 += 1;
						}
					}
				}
			}
				break;
			case 12:			
		if (PlayerPrefs.GetInt ("noStuck") == 1){
				if (moveToF == 0) {
					if (pos01 == pos00/*&& pos00 == pos02 && pos01 == pos02*/) {
						if (pos00 == PLthePlayerGreenReverse.transform.position) {
							PLthePlayerGreenReverse.MRigidbody.velocity = new Vector2 (PLthePlayerGreenReverse.MRigidbody.velocity.x, 20);
							Debug.Log ("Donee :) " + addDebug2);
							stopOrNot3 = false;
							stopOrNot2 = false;
							stopOrNot = false;
							addDebug2 += 1;
						}
					}
				}
		}
				break;
			case 13:			
		if (PlayerPrefs.GetInt ("noStuck") == 1){
				if (moveToF == 0) {
					if (pos01 == pos00/* && pos00 == pos02 && pos01 == pos02*/) {
						if (pos00 == PLthePlayerGreyReverse.transform.position) {
							PLthePlayerGreyReverse.MRigidbody.velocity = new Vector2 (PLthePlayerGreyReverse.MRigidbody.velocity.x, 20);
							Debug.Log ("Donee :) " + addDebug2);
							stopOrNot3 = false;
							stopOrNot2 = false;
							stopOrNot = false;
							addDebug2 += 1;
						}
					}
				}
			}
				break;
			case 14:			
		if (PlayerPrefs.GetInt ("noStuck") == 1) {
				if (moveToF == 0) {
					if (pos01 == pos00/*&& pos00 == pos02 && pos01 == pos02*/) {
						if (pos00 == PLthePlayerDevil.transform.position) {
							PLthePlayerDevil.MRigidbody.velocity = new Vector2 (PLthePlayerDevil.MRigidbody.velocity.x, 20);
							Debug.Log ("Donee :) " + addDebug2);
							stopOrNot3 = false;
							stopOrNot2 = false;
							stopOrNot = false;
							addDebug2 += 1;
						}
					}
				}
			}
				break;
			case 15:			
		if (PlayerPrefs.GetInt ("noStuck") == 1) {
				if (moveToF == 0) {
					if (pos01 == pos00 /*&& pos00 == pos02 && pos01 == pos02*/) {
						if (pos00 == PLthePlayerAlienBiege.transform.position) {
							PLthePlayerAlienBiege.MRigidbody.velocity = new Vector2 (PLthePlayerAlienBiege.MRigidbody.velocity.x, 20);
							Debug.Log ("Donee :) " + addDebug2);
							stopOrNot3 = false;
							stopOrNot2 = false;
							stopOrNot = false;
							addDebug2 += 1;
						}
					}
				}
			}
				break;
			case 16:			
		if (PlayerPrefs.GetInt ("noStuck") == 1) {
				if (moveToF == 0) {
					if (pos01 == pos00/* && pos00 == pos02 && pos01 == pos02*/) {
						if (pos00 == PLthePlayerAlienYellow.transform.position) {
							PLthePlayerAlienYellow.MRigidbody.velocity = new Vector2 (PLthePlayerAlienYellow.MRigidbody.velocity.x, 20);
							Debug.Log ("Donee :) " + addDebug2);
							stopOrNot3 = false;
							stopOrNot2 = false;
							stopOrNot = false;
							addDebug2 += 1;
						}
					}
				}
			}
				break;
			case 17:			
		if (PlayerPrefs.GetInt ("noStuck") == 1) {
				//if (moveToF == 0) {
				if (pos01 == pos00/* && pos00 == pos02 && pos01 == pos02*/) {
					if (pos00 == PLthePlayerAlienDarkBlue.transform.position) {
						PLthePlayerAlienDarkBlue.MRigidbody.velocity = new Vector2 (PLthePlayerAlienDarkBlue.MRigidbody.velocity.x, 20);
						Debug.Log ("Donee :) " + addDebug2);
						stopOrNot3 = false;
						stopOrNot2 = false;
						stopOrNot = false;
						addDebug2 += 1;
					}
				}
				//}
			}
				break;
			case 18:			
		if (PlayerPrefs.GetInt ("noStuck") == 1) {
				if (moveToF == 0) {
					//if (pos01 == pos00/* && pos00 == pos02 && pos01 == pos02*/) {
					if (pos00 == PLthePlayerAlienPink.transform.position) {
						PLthePlayerAlienPink.MRigidbody.velocity = new Vector2 (PLthePlayerAlienPink.MRigidbody.velocity.x, 20);
						Debug.Log ("Donee :) " + addDebug2);
						stopOrNot3 = false;
						stopOrNot2 = false;
						stopOrNot = false;
						addDebug2 += 1;
					}
				}
				//}
			}
				break;
			}
		}
public void PauseButtonn(){
	switch (selectCharacter) {
	case 0:
		PLthePlayerBlue.PPause();
		break;
	case 1:
		PLthePlayerRed.PPause();
		break;
	case 2:
		PLthePlayerGreen.PPause();
		break;
	case 3:
		PLthePlayerGrey.PPause();
		break;
	case 4:
		PLthePlayerAlienBlue.PPause();
		break;
	case 5:
		PLthePlayerTruckRed.PPause();
		break;
	case 6:
		PLthePlayerTruckYellow.PPause();
		break;
	case 7:
		PLthePlayerTruckBlue.PPause();
		break;
	case 8:
		PLthePlayerTruckGreen.PPause();
		break;
	case 9:
		PLthePlayerDiskRed.PPause();
		break;
	case 10:
		PLthePlayerBlueReverse.PPause();
		break;
	case 11:
		PLthePlayerRedReverse.PPause();
		break;
	case 12:
		PLthePlayerGreenReverse.PPause();
		break;
	case 13:
		PLthePlayerGreyReverse.PPause();
		break;
	case 14:
		PLthePlayerDevil.PPause();
		break;
	case 15:
		PLthePlayerAlienBiege.PPause();
		break;
	case 16:
		PLthePlayerAlienYellow.PPause();
		break;
	case 17:
		PLthePlayerAlienDarkBlue.PPause();
		break;
	case 18:
		PLthePlayerAlienPink.PPause();
		break;


	}
}
	
}