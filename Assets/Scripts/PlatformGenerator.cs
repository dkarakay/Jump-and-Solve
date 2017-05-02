using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform platformPoint;
	public Transform posEndBG;
	public Transform theCatcher;

	public GameObject BG, BG01;

	public int a = 0;
	public int ten = 72;
	public float distance;
	public bool addObject,addObjectReset;
	public float minDistance;
	public float maxDistance;
//	float platformWidth;
	public ObjectPooler[] theObjectPools,theObjectPoolsYellow,theObjectPoolsGreen;
	public ObjectPooler[] theObjectPoolsCake,theObjectPoolsCastle,theObjectPoolsChoco;
	public ObjectPooler[] theObjectPoolsDirt,theObjectPoolsGrass,theObjectPoolsMetal;
	public ObjectPooler[] theObjectPoolsPurple,theObjectPoolsSand,theObjectPoolsSnow;
	public ObjectPooler[] theObjectPoolsTundra;
	private int platformSelector;
	//public GameObject[] thePlatforms;
	private float medPlatform;
	private float minHeight; 
	private float maxHeight;
	public Transform maxHeightPoint;
	public float maxHeightChange;
	private float heightChange;
	private float[] platformWidths;
	private CoinGenerator theCoinGenerator;
	public float randomCoinGold;
	public float randomCoinBronze;
	private float randomHeight;

	public float minHeightChangeRandom;
	public float maxHeightChangeRandom;
	private int selectCharacter;
	private float distanceThree,distanceNormal;
	private float distanceNormal02;
	public int selectedTile,selectedBackground; 

	private GameObject newP;
	public Transform posEndBG2;
	public float posEndBG3;
	public Transform posCamera;
	public float transformMinusPos;

	void Start () {

		theCoinGenerator = FindObjectOfType<CoinGenerator> ();
	//	platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;1
		selectedTile = PlayerPrefs.GetInt("selectedTile");

		/*case 1:
			theCoinGenerator.Background02 ();
			break;
		case 2:
			theCoinGenerator.Background03 ();
			break;
		case 3:
			theCoinGenerator.Background04 ();
			break;
		case 4:
			theCoinGenerator.Background05 ();
			break;
		}*/
		switch (selectedTile) {
		case 0:
			addObject = false;
			addObjectReset = false;
			platformWidths = new float[theObjectPools.Length];
			for (int i = 0; i < theObjectPools.Length; i++) {
				platformWidths [i] = theObjectPools [i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
			}
			break;
		case 1:
			addObject = false;
			addObjectReset = false;
			platformWidths = new float[theObjectPoolsYellow.Length];
			for (int i = 0; i < theObjectPoolsYellow.Length; i++) {
				platformWidths [i] = theObjectPoolsYellow [i].pooledObject.GetComponent<BoxCollider2D> ().size.x;	
			}
			break;
		case 2:			
			addObject = false;
			addObjectReset = false;
			platformWidths = new float[theObjectPoolsGreen.Length];
			for (int i = 0; i < theObjectPoolsGreen.Length; i++) {
				platformWidths [i] = theObjectPoolsGreen [i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
			}
			break;
		case 3:
			addObject = true;
			addObjectReset = true;
			platformWidths = new float[theObjectPoolsCake.Length];
			for (int i = 0; i < theObjectPoolsCake.Length; i++) {
				platformWidths [i] = theObjectPoolsCake [i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
			}
			break;
		case 4:
			addObject = true;
			addObjectReset = true;
			platformWidths = new float[theObjectPoolsCastle.Length];
			for (int i = 0; i < theObjectPoolsCastle.Length; i++) {
				platformWidths [i] = theObjectPoolsCastle [i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
			}
			break;
		case 5:
			addObject = true;
			addObjectReset = true;
			platformWidths = new float[theObjectPoolsChoco.Length];
			for (int i = 0; i < theObjectPoolsChoco.Length; i++) {
				platformWidths [i] = theObjectPoolsChoco [i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
			}
			break;
		case 6:
			addObject = true;
			addObjectReset = true;
			platformWidths = new float[theObjectPoolsDirt.Length];
			for (int i = 0; i < theObjectPoolsDirt.Length; i++) {
				platformWidths [i] = theObjectPoolsDirt [i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
			}
			break;
		case 7:
			addObject = true;
			addObjectReset = true;
			platformWidths = new float[theObjectPoolsGrass.Length];
			for (int i = 0; i < theObjectPoolsGrass.Length; i++) {
				platformWidths [i] = theObjectPoolsGrass [i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
			}
			break;
		case 8:
			addObject = true;
			addObjectReset = true;
			platformWidths = new float[theObjectPoolsMetal.Length];
			for (int i = 0; i < theObjectPoolsMetal.Length; i++) {
				platformWidths [i] = theObjectPoolsMetal [i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
			}
			break;
		case 9:
			addObject = true;
			addObjectReset = true;
			platformWidths = new float[theObjectPoolsSand.Length];
			for (int i = 0; i < theObjectPoolsSand.Length; i++) {
				platformWidths [i] = theObjectPoolsSand [i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
			}
			break;
		case 10:
			addObject = true;
			addObjectReset = true;
			platformWidths = new float[theObjectPoolsSnow.Length];
			for (int i = 0; i < theObjectPoolsSnow.Length; i++) {
				platformWidths [i] = theObjectPoolsSnow [i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
			}
			break;
		case 11:
			addObject = true;
			addObjectReset = true;
			platformWidths = new float[theObjectPoolsTundra.Length];
			for (int i = 0; i < theObjectPoolsTundra.Length; i++) {
				platformWidths [i] = theObjectPoolsTundra [i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
			}
			break;
		case 12:
			addObject = true;
			addObjectReset = true;
			platformWidths = new float[theObjectPoolsPurple.Length];
			for (int i = 0; i < theObjectPoolsPurple.Length; i++) {
				platformWidths [i] = theObjectPoolsPurple [i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
			}
			break;
		}
		selectCharacter = PlayerPrefs.GetInt ("CharacterSelected");
		if (selectCharacter == 5 || selectCharacter == 6 || selectCharacter == 7 || selectCharacter == 8 || selectCharacter == 9) {
			minDistance = 1.9f;
			maxDistance = 2.45f;
			distanceThree = 2.4f;
			distanceNormal = 2f;
			distanceNormal02 = 2.4f;
		}
		else if (selectCharacter == 4 || selectCharacter == 15  || selectCharacter == 16 || selectCharacter == 17 || selectCharacter == 18) {
				minDistance = 1.9f;
				maxDistance = 2.45f;
				distanceThree = 2.3f;
				distanceNormal = 2f;
				distanceNormal02 = 2.4f;
		} else {
			minDistance = 1.7f;
			maxDistance = 2.25f;
			distanceThree = 2.2f;
			distanceNormal = 1.8f;
			distanceNormal02 = 2.2f ;

		}
			minHeight = transform.position.y;
			maxHeight = maxHeightPoint.position.y;



	}
	
	// Update is called once per frame
	void Update ()
	{
		/*if (transform.position.x < posEndBG.position.x) {
			posEndBG3 = posEndBG.position.x * a;
			selectedBackground = PlayerPrefs.GetInt ("selectedBG");
			transformMinusPos = posEndBG.position.x - posEndBG2.position.x;
			switch (selectedBackground) {
			case 0:	
				
				if (posEndBG3 <= ten) {
					
					theCoinGenerator.Background01 (new Vector3 (posEndBG.position.x + (72 * a), theCatcher.position.y + 5f, transform.position.z));
					//if(a == ten){

					a++;
				}
				if (posCamera.position.x > posEndBG3 -100  ) {
					ten += 72 ;
				}

				break;
			}
		}*/
		if (transform.position.x < platformPoint.position.x) {
			
			
			distance = Random.Range (minDistance, maxDistance);
				switch(selectedTile){
				case 0:
					platformSelector = Random.Range (0, theObjectPools.Length);					
					break;
				case 1:
					platformSelector = Random.Range (0, theObjectPoolsYellow.Length);					
					break;
				case 2:
					platformSelector = Random.Range (0, theObjectPoolsGreen.Length);
					break;
				case 3:
					platformSelector = Random.Range (0, theObjectPoolsCake.Length);
					break;
				case 4:
				platformSelector = Random.Range (0, theObjectPoolsCastle.Length);
					break;
				case 5:
				platformSelector = Random.Range (0, theObjectPoolsChoco.Length);
					break;
				case 6:
				platformSelector = Random.Range (0, theObjectPoolsDirt.Length);
					break;
				case 7:
				platformSelector = Random.Range (0, theObjectPoolsGrass.Length);
					break;
				case 8:
				platformSelector = Random.Range (0, theObjectPoolsMetal.Length);
					break;
				case 9:
				platformSelector = Random.Range (0, theObjectPoolsSand.Length);
					break;
				case 10:
				platformSelector = Random.Range (0, theObjectPoolsSnow.Length);
					break;
				case 11:
				platformSelector = Random.Range (0, theObjectPoolsTundra.Length);
					break;
				case 12:
				platformSelector = Random.Range (0, theObjectPoolsPurple.Length);
					break;
			}
			
			/*if (/*selectCharacter == 5 ||selectCharacter == 6 || selectCharacter == 7 || selectCharacter == 8 || selectCharacter == 9) {
				
				maxHeightChangeRandom = Random.Range (maxHeightChange, 3.5f);
				minHeightChangeRandom = Random.Range (-maxHeightChange, -3.5f);

			} else{
				maxHeightChangeRandom = Random.Range (maxHeightChange, 0.5f);
				minHeightChangeRandom = Random.Range (-maxHeightChange, -0.5f);
			}*/
			heightChange = transform.position.y + Random.Range (maxHeightChange,-maxHeightChange);

			if (heightChange > maxHeight) {
				heightChange = maxHeight;
			} else if (minHeight > heightChange) {
				heightChange = minHeight;
			}
			transform.position = new Vector3 (transform.position.x + (platformWidths [platformSelector] / 2) + distance, heightChange, transform.position.z);
			//break;
			/*switch (selectedTile) {
			case 0:
				transform.position = new Vector3 (transform.position.x + (platformWidths [platformSelector] / 2) + distance, heightChange, transform.position.z);
				break;
			case 1:
				transform.position = new Vector3 (transform.position.x + (platformWidths02 [platformSelector] / 2) + distance, heightChange, transform.position.z);
				break;
			case 2:
				transform.position = new Vector3 (transform.position.x + (platformWidths03 [platformSelector] / 2) + distance, heightChange, transform.position.z);
				break;
			}*/
			if (!addObject) {
				switch (platformSelector) {
				case 0:
					medPlatform = 0.4f;
					break;
				case 1:
					medPlatform = -0.73f;
					break;
				case 2:
					medPlatform = -1.73f;
					break;
				case 3: 
					medPlatform = -2.73f;
					break;
				default:
					break;
				}
			} else if (addObject) {
				switch (platformSelector) {
				case 0:
					medPlatform = 0.10f;
					break;
				case 1:
					medPlatform = 0.21f;
					break;
				case 2:
					medPlatform = 1.21f;
					break;
				case 3: 
					medPlatform = 2.21f;
					break;
				default:
					break;
				}
			}
			if (heightChange == maxHeight || heightChange == -maxHeight) {
				if (!addObject) {
					randomHeight = (Random.Range (2f, 3f));
				} else if(addObject){
					randomHeight = (Random.Range (2.4f, 3.4f));
				}
			} else if (heightChange < -maxHeight) {
				if (!addObject) {
					randomHeight = (Random.Range (1f, 1.5f));
				} else if(addObject){
					randomHeight = (Random.Range (1.4f, 1.9f));
				}

			}

			//Instantiate (/*thePlatform*/ thePlatforms[platformSelector], transform.position, transform.rotation);
			switch(selectedTile){
			case 0:
				newP = theObjectPools [platformSelector].GetPooledObject ();
				newP.transform.position = transform.position;
				break;
			case 1:
				newP = theObjectPoolsYellow [platformSelector].GetPooledObject ();
				newP.transform.position = transform.position;
				break;
			case 2:
				newP = theObjectPoolsGreen [platformSelector].GetPooledObject ();
				newP.transform.position = transform.position;
				break;
			case 3:
				newP = theObjectPoolsCake [platformSelector].GetPooledObject ();
				newP.transform.position = transform.position;
				break;
			case 4:
				newP = theObjectPoolsCastle [platformSelector].GetPooledObject ();
				newP.transform.position = transform.position;
				break;
			case 5:
				newP = theObjectPoolsChoco [platformSelector].GetPooledObject ();
				newP.transform.position = transform.position;
				break;
			case 6:
				newP = theObjectPoolsDirt [platformSelector].GetPooledObject ();
				newP.transform.position = transform.position;
				break;
			case 7:
				newP = theObjectPoolsGrass [platformSelector].GetPooledObject ();
				newP.transform.position = transform.position;
				break;
			case 8:
				newP = theObjectPoolsMetal [platformSelector].GetPooledObject ();
				newP.transform.position = transform.position;
				break;
			case 9:
				newP = theObjectPoolsSand [platformSelector].GetPooledObject ();
				newP.transform.position = transform.position;
				break;
			case 10:
				newP = theObjectPoolsSnow [platformSelector].GetPooledObject ();
				newP.transform.position = transform.position;
				break;
			case 11:
				newP = theObjectPoolsTundra [platformSelector].GetPooledObject ();
				newP.transform.position = transform.position;
				break;
			case 12:
				newP = theObjectPoolsPurple [platformSelector].GetPooledObject ();
				newP.transform.position = transform.position;
				break;
			}


			newP.transform.rotation = transform.rotation;
			newP.SetActive (true);
			float randomPosCoin = 1.4f;
			float randomPosCoin2 = 1.4f;
			int randomSwitch = (int)Mathf.Round (Random.Range (0f, 1.5f));
			if (Random.Range (0f, 100f) < 7) {
				if (!addObject) {
					theCoinGenerator.Arrow (new Vector3 (transform.position.x, transform.position.y + 1f, transform.position.z));
				} else if(addObject){
					theCoinGenerator.Arrow (new Vector3 (transform.position.x, transform.position.y + 1f, transform.position.z));
				}
			}

			if (Random.Range (0f, 100f) < randomCoinGold) {
				if (!addObject) {
					switch (randomSwitch) {
					case 0:
						theCoinGenerator.SpawnCoinsGold (new Vector3 (transform.position.x - medPlatform, transform.position.y + randomPosCoin, transform.position.z));
						break;
					case 1:
						theCoinGenerator.SpawnCoinsUpAndUpGold (new Vector3 (transform.position.x - medPlatform, transform.position.y + randomPosCoin, transform.position.z));
						break;
					
					}

				} else if (addObject) {
					switch (randomSwitch) {
					case 0:
						theCoinGenerator.SpawnCoinsGold (new Vector3 (transform.position.x - medPlatform, transform.position.y + randomPosCoin2, transform.position.z));
						break;
					case 1:
						theCoinGenerator.SpawnCoinsUpAndUpGold(new Vector3 (transform.position.x - medPlatform, transform.position.y + randomPosCoin2, transform.position.z));
						break;
					
					}
				} 
			}else if (Random.Range (0f, 100f) < randomCoinBronze) {
				if (!addObject) {
					switch (randomSwitch) {
					case 0:
						theCoinGenerator.SpawnCoinsBronze (new Vector3 (transform.position.x - medPlatform, transform.position.y + randomPosCoin, transform.position.z));
						break;
					case 1:
						theCoinGenerator.SpawnCoinsUpAndUpBronze (new Vector3 (transform.position.x - medPlatform, transform.position.y + randomPosCoin, transform.position.z));
						break;
					
					}

				} else if (addObject) {
					switch (randomSwitch) {
					case 0:
						theCoinGenerator.SpawnCoinsBronze (new Vector3 (transform.position.x - medPlatform, transform.position.y + randomPosCoin2, transform.position.z));
						break;
					case 1:
						theCoinGenerator.SpawnCoinsUpAndUpBronze (new Vector3 (transform.position.x  - medPlatform, transform.position.y + randomPosCoin2, transform.position.z));
						break;
					
					}
				} 
			}

			transform.position = new Vector3 (transform.position.x + (platformWidths [platformSelector] / 2) + distance, transform.position.y, transform.position.z);
			if (Random.Range (0f, 100f) < randomCoinGold) {
				if (distance < distanceNormal && distance > distanceNormal02) {
					
					//switch (Random.Range (0, 3)) {
					//case 1:
						theCoinGenerator.SpawnCoinsOneGold (new Vector3 (transform.position.x - medPlatform, transform.position.y + randomHeight, transform.position.z));
						/*break;
					case 2:
						theCoinGenerator.SpawnCoinsTwoGold (new Vector3 (transform.position.x - medPlatform, transform.position.y + 1.5f, transform.position.z));
						break;
					default:
						theCoinGenerator.SpawnCoinsOneGold (new Vector3 (transform.position.x - medPlatform, transform.position.y + randomHeight, transform.position.z));
						break;*/
					//}

				} else if (distance > distanceThree) {
					if (!addObject) {
						if (heightChange == maxHeight)
							theCoinGenerator.SpawnCoinsThreeGold (new Vector3 (transform.position.x - medPlatform, transform.position.y + 1.5f, transform.position.z));
						else if (heightChange == -maxHeight)
							theCoinGenerator.SpawnCoinsThreeGold (new Vector3 (transform.position.x - medPlatform, transform.position.y + 1.5f, transform.position.z));
						else {
							theCoinGenerator.SpawnCoinsTwoGold (new Vector3 (transform.position.x - medPlatform, transform.position.y + 1.6f, transform.position.z));
						}
					} else if (addObject){
						if (heightChange == maxHeight)
							theCoinGenerator.SpawnCoinsThreeGold (new Vector3 (transform.position.x - medPlatform, transform.position.y + 1.9f, transform.position.z));
						else if (heightChange == -maxHeight)
							theCoinGenerator.SpawnCoinsThreeGold (new Vector3 (transform.position.x - medPlatform, transform.position.y + 1.9f, transform.position.z));
						else {
							theCoinGenerator.SpawnCoinsTwoGold (new Vector3 (transform.position.x - medPlatform, transform.position.y + 2f, transform.position.z));
						}
					}
				}
			} else if (Random.Range (0f, 100f) < randomCoinBronze) {
				if (distance < distanceNormal && distance > distanceNormal02) {
					/*switch (Random.Range (0, 3)) {
					//case 1:
						theCoinGenerator.SpawnCoinsOneBronze (new Vector3 (transform.position.x - medPlatform, transform.position.y + randomHeight, transform.position.z));
						/*break;
					case 2:
						theCoinGenerator.SpawnCoinsTwoBronze (new Vector3 (transform.position.x - medPlatform, transform.position.y + 1.5f, transform.position.z));
						break;				
					default:
						theCoinGenerator.SpawnCoinsOneBronze (new Vector3 (transform.position.x - medPlatform, transform.position.y + randomHeight, transform.position.z));
						break;*/
					//}
				} else if (distance > distanceThree) {
					if (!addObject) {
						if (heightChange == maxHeight)
							theCoinGenerator.SpawnCoinsThreeBronze (new Vector3 (transform.position.x - medPlatform, transform.position.y + 1.5f, transform.position.z));
						else if (heightChange == -maxHeight)
							theCoinGenerator.SpawnCoinsThreeBronze (new Vector3 (transform.position.x - medPlatform, transform.position.y + 1.5f, transform.position.z));
						else {
							theCoinGenerator.SpawnCoinsTwoBronze (new Vector3 (transform.position.x - medPlatform, transform.position.y + 1.6f, transform.position.z));
						}
					} else if (addObject){
						if (heightChange == maxHeight)
							theCoinGenerator.SpawnCoinsThreeBronze (new Vector3 (transform.position.x - medPlatform, transform.position.y + 1.9f, transform.position.z));
						else if (heightChange == -maxHeight)
							theCoinGenerator.SpawnCoinsThreeBronze (new Vector3 (transform.position.x - medPlatform, transform.position.y + 1.9f, transform.position.z));
						else {
							theCoinGenerator.SpawnCoinsTwoBronze (new Vector3 (transform.position.x - medPlatform, transform.position.y + 2f, transform.position.z));
						}
					}
				}
			}
		}
	}
	
}



