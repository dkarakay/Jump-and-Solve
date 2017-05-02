using UnityEngine;
using System.Collections;

public class PickUpCoins : MonoBehaviour {
	private CoinTextGenerator theCoinTextGenerator;
	public int scoreToGive;
	public int coinAdd = 1;
	public AudioClip coinTake;
	private float sound;

	//private ScoreManager theScoreManager;
	// Use this for initialization
	void Start () {
		sound = PlayerPrefs.GetFloat ("SoundEffect");
		//theScoreManager = FindObjectOfType<ScoreManager> ();
		theCoinTextGenerator = FindObjectOfType<CoinTextGenerator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "PlayerBlue") {
			MundoSound.Play (coinTake,sound);
			//	theScoreManager.scoreCount += scoreToGive;
			//theScoreManager.AddScore (scoreToGive);
			theCoinTextGenerator.addCoin (coinAdd,0);
			gameObject.SetActive (false);
			/*}else if (other.gameObject.tag == "g") {
			theScoreManager.AddScore (1000);
			gameObject.SetActive (false);
		}*/
		} else if (other.gameObject.name == "PlayerRed") {
			MundoSound.Play (coinTake,sound);
			theCoinTextGenerator.addCoin (coinAdd, 0);
			gameObject.SetActive (false);
		} else if (other.gameObject.name == "PlayerGreen") {
			MundoSound.Play (coinTake,sound);
			theCoinTextGenerator.addCoin (coinAdd, 0);
			gameObject.SetActive (false);
		} else if (other.gameObject.name == "PlayerGrey") {
			MundoSound.Play (coinTake,sound);
			theCoinTextGenerator.addCoin (coinAdd, 0);
			gameObject.SetActive (false);
		} else if (other.gameObject.name == "PlayerAlienBlue") {
			MundoSound.Play (coinTake,sound);
			theCoinTextGenerator.addCoin (coinAdd,0);
			gameObject.SetActive (false);
		} else if (other.gameObject.name == "PlayerTruckRed") {
			MundoSound.Play (coinTake,sound);
			theCoinTextGenerator.addCoin (coinAdd, 0);
			gameObject.SetActive (false);
		} else if (other.gameObject.name == "PlayerTruckYellow") {
			MundoSound.Play (coinTake,sound);
			theCoinTextGenerator.addCoin (coinAdd,0);
			gameObject.SetActive (false);
		} else if (other.gameObject.name == "PlayerDiskRed") {
			MundoSound.Play (coinTake,sound);
			theCoinTextGenerator.addCoin (coinAdd,0);
			gameObject.SetActive (false);
		} else if (other.gameObject.name == "PlayerTruckGreen") {
			MundoSound.Play (coinTake,sound);
			theCoinTextGenerator.addCoin (coinAdd, 0);
			gameObject.SetActive (false);
		} else if (other.gameObject.name == "PlayerTruckBlue") {
			MundoSound.Play (coinTake,sound);
			theCoinTextGenerator.addCoin (coinAdd,0);
			gameObject.SetActive (false);
		} else if (other.gameObject.name == "PlayerBlueReverse") {
			MundoSound.Play (coinTake,sound);
			theCoinTextGenerator.addCoin (coinAdd, 0);
			gameObject.SetActive (false);
		} else if (other.gameObject.name == "PlayerGreenReverse") {
			MundoSound.Play (coinTake,sound);
			theCoinTextGenerator.addCoin (coinAdd, 0);
			gameObject.SetActive (false);
		} else if (other.gameObject.name == "PlayerGreyReverse") {
			MundoSound.Play (coinTake,sound);
			theCoinTextGenerator.addCoin (coinAdd, 0);
			gameObject.SetActive (false);
		} else if (other.gameObject.name == "PlayerDevil") {
			MundoSound.Play (coinTake,sound);
			theCoinTextGenerator.addCoin (coinAdd,0);
			gameObject.SetActive (false);
		} else if (other.gameObject.name == "PlayerRedReverse") {
			MundoSound.Play (coinTake,sound);
			theCoinTextGenerator.addCoin (coinAdd, 0);
			gameObject.SetActive (false);
		} else if (other.gameObject.name == "PlayerAlienYellow") {
			MundoSound.Play (coinTake,sound);
			theCoinTextGenerator.addCoin (coinAdd,0);
			gameObject.SetActive (false);
		} else if (other.gameObject.name == "PlayerAlienBiege") {
			MundoSound.Play (coinTake,sound);
			theCoinTextGenerator.addCoin (coinAdd,0);
			gameObject.SetActive (false);
		} else if (other.gameObject.name == "PlayerAlienDarkBlue") {
			MundoSound.Play (coinTake,sound);
			theCoinTextGenerator.addCoin (coinAdd, 0);
			gameObject.SetActive (false);
		} else if (other.gameObject.name == "PlayerAlienPink") {
			MundoSound.Play (coinTake,sound);
			theCoinTextGenerator.addCoin (coinAdd,0);
			gameObject.SetActive (false);
		} 
	}
}

