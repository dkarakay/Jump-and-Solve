using UnityEngine;
using System.Collections;

public class Scrolling : MonoBehaviour {

	public float speed;
	public float timeF;
	//public PlayerController[] thePlayer;
	private int selectCharacter;
	public Vector2 offset;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetString ("Scrolling","on");
		selectCharacter = PlayerPrefs.GetInt ("CharacterSelected");
	}
	
	// Update is called once per frame
	void Update () {	
	
		//speedD2 ();
		//speed -= 7;
		/*for (speedD02 = speed;speedD02 <= speedD;a++){
			speedD -= 0.75f;

		}*/
		timeF = Time.time;
		if (timeF != 0f) {
			PlayerPrefs.SetFloat ("timeFF", timeF);
		} else if (PlayerPrefs.GetInt ("ScrollBGStop") == 1) {
			PlayerPrefs.SetFloat ("timeFF", timeF);
		}
		if (speed != 0) {
			offset = new Vector2 (PlayerPrefs.GetFloat("timeFF") * speed, 0); 
		}

		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
	/*void speedD2(){
		switch (selectCharacter) {
		case 0:
			speed = thePlayer [0].moveSpeed;
			break;
		case 1:
			speed = thePlayer [1].moveSpeed;
			break;
		case 2:
			speed = thePlayer [2].moveSpeed;
			break;
		case 3:
			speed = thePlayer [3].moveSpeed;
			break;
		case 4:
			speed = thePlayer [4].moveSpeed;
			break;
		case 5:
			speed = thePlayer [5].moveSpeed;
			break;
		case 6:
			speed = thePlayer [6].moveSpeed;
			break;
		case 7:
			speed = thePlayer [7].moveSpeed;
			break;
		case 8:
			speed = thePlayer [8].moveSpeed;
			break;
		case 9:
			speed = thePlayer [9].moveSpeed;
			break;
		case 10:
			speed = thePlayer [10].moveSpeed;
			break;
		case 11:
			speed = thePlayer [11].moveSpeed;
			break;
		case 12:
			speed = thePlayer [12].moveSpeed;
			break;
		case 13:
			speed = thePlayer [13].moveSpeed;
			break;
		case 14:
			speed = thePlayer [14].moveSpeed;
			break;
		case 15:
			speed = thePlayer [15].moveSpeed;
			break;
		case 16:
			speed = thePlayer [16].moveSpeed;
			break;
		case 17:
			speed = thePlayer [17].moveSpeed;
			break;
		case 18:
			speed = thePlayer [18].moveSpeed;
			break;
		}
	}*/
}
