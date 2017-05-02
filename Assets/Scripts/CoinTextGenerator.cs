using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class CoinTextGenerator : MonoBehaviour {
	public Text bronze;
	public Text gold;
	public Text bronzeD;
	public Text goldD;
	/*public Text bronzeD2;
	public Text goldD2;
	public Text scoreDeath;*/
	public Text scoreBefore;

	public float scoreF;
	public GameObject goldCoin;
	public ScoreManager theScore;

	/*public GameObject greenGem;
	private Vector3 greenGemPos;*/

	/*private bool coinGem10;
	private bool coinGem100;
	private bool coinGem1000;
	private bool coinGem10000;
	private bool coinGem100000;*/

	public int coinGold;
	public int coinBronze;
	private float coinX;
	public int GCoin, BCoin;
	public int coinInt;
	// Use this for initialization
	void Start () {
		coinInt = 0;
		/*coinGem10 = true;
		coinGem100 = true;
		coinGem1000 = true;
		coinGem10000 = true;
		coinGem100000 = true;*/
	}
	
	// Update is called once per frame
	void Update () {		
		coinX = goldCoin.transform.position.x;
		bronze.text =  ""+coinBronze;
		gold.text =  ""+coinGold;
		bronzeD.text =  ""+coinBronze;
		goldD.text =  ""+coinGold;

		/*coinBronzeDouble = coinBronze * 2;
		coinGoldDouble = coinGold * 10;

/*		bronzeD2.text =  ""+coinBronzeDouble ;
		goldD2.text =  ""+coinGoldDouble;*/
		/*if (coinGem10) {
			if (coinBronzeDouble >= 10f || coinGoldDouble >= 10f || theScore.scoreCount >= 10f) {
				greenGem.transform.position = new Vector3 (greenGem.transform.position.x + 20, greenGem.transform.position.y, greenGem.transform.position.z);
				coinGem10 = false;		
			}
		} else if (coinGem100) {
			if (coinBronzeDouble >= 100f || coinGoldDouble >= 100f || theScore.scoreCount >= 100f) {
				greenGem.transform.position = new Vector3 (greenGem.transform.position.x + 40, greenGem.transform.position.y, greenGem.transform.position.z);
				coinGem100 = false;
			} 
		}else if (coinGem1000) {
				if (coinBronzeDouble >= 1000f || coinGoldDouble >= 1000f || theScore.scoreCount >= 1000f) {
					greenGem.transform.position = new Vector3 (greenGem.transform.position.x + 60, greenGem.transform.position.y, greenGem.transform.position.z);
					coinGem1000 = false;
				}				
		} else if (coinGem10000) {
				if (coinBronzeDouble >= 10000f || coinGoldDouble >= 10000f || theScore.scoreCount >= 10000f) {
					greenGem.transform.position = new Vector3 (greenGem.transform.position.x + 80, greenGem.transform.position.y, greenGem.transform.position.z);
					coinGem10000 = false;
				}
		} else if (coinGem100000) {
				if (coinBronzeDouble >= 100000f || coinGoldDouble >= 100000f || theScore.scoreCount >= 100000f) {
					greenGem.transform.position = new Vector3 (greenGem.transform.position.x + 100, greenGem.transform.position.y, greenGem.transform.position.z);
					coinGem100000 = false;
				}
			}*/

		//scoreF = coinGoldDouble + theScore.scoreCount + coinBronzeDouble; 
		//scoreDeath.text = "" + Mathf.Round(scoreF);
	//if(theScore.scoreCountL)	
	scoreBefore.text = "" + Mathf.Round(theScore.scoreCountL);
		if (PlayerPrefs.GetFloat ("HScore") < theScore.scoreCountL) {
			PlayerPrefs.SetFloat ("HScore", theScore.scoreCountL);
	}
		
	 //Mathf.Round(scoreF);
		/*if (scoreF > PlayerPrefs.GetFloat ("HScore")) {
			PlayerPrefs.SetFloat("HScore",scoreF);
		}*/

	}
	public void addCoin(int coinAddG,int coinAddB){
		coinBronze += coinAddB;
		coinGold += coinAddG;
		coin ();
	}
	public void coin(){
		/*switch (coinBronze) {
		case 99:
			goldCoin.transform.position = new Vector3 (coinX + 15, goldCoin.transform.position.y, goldCoin.transform.position.z);
			break;
		case 999:
			goldCoin.transform.position = new Vector3 (coinX + 30, goldCoin.transform.position.y, goldCoin.transform.position.z);
			break;
		case 9999:
			goldCoin.transform.position = new Vector3 (coinX + 30, goldCoin.transform.position.y, goldCoin.transform.position.z);
			break;
		default:
			break;
		}*/
		switch(coinInt){
		case 0:
			if (coinBronze >= 10) {
				goldCoin.transform.position = new Vector3 (coinX + 40, goldCoin.transform.position.y, goldCoin.transform.position.z);	
				coinInt = 1;
			} 
			break;
		case 1:
			if (coinBronze >= 100) {
				goldCoin.transform.position = new Vector3 (coinX + 80, goldCoin.transform.position.y, goldCoin.transform.position.z);		
				coinInt = 2;
			} 
			break;
		case 2:
			if (coinBronze >= 1000) {
				goldCoin.transform.position = new Vector3 (coinX + 120, goldCoin.transform.position.y, goldCoin.transform.position.z);
				coinInt = 3;
			} 
			break;
		case 3:
			if (coinBronze >= 10000) {
				goldCoin.transform.position = new Vector3 (coinX + 150, goldCoin.transform.position.y, goldCoin.transform.position.z);
				coinInt = 4;
			}
			break;
		case 4:
			if (coinBronze >= 100000) {
				goldCoin.transform.position = new Vector3 (coinX + 180, goldCoin.transform.position.y, goldCoin.transform.position.z);
				coinInt = 5;
			}
			break;
		case 5:
			if (coinBronze >= 1000000) {
				goldCoin.transform.position = new Vector3 (coinX + 210, goldCoin.transform.position.y, goldCoin.transform.position.z);
				coinInt = 6;
			}
			break;
		default:
			break;
		}

	}

	}


