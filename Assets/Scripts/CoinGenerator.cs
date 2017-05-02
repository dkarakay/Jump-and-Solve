using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour {
	public ObjectPooler coinGoldPool;
	public ObjectPooler coinBronzePool;
	public ObjectPooler arrowPool;
	public ObjectPooler BG01_1,BG01,BG02,BG03,BG04,BG05;
	public float distanceBetweenCoins;
	public float randomHeight,randomHeight02;
	public float randomHeight03;
	// Use this for initialization
	void Update(){
		randomHeight = Random.Range (-1f, 1f);
		randomHeight02 = Random.Range (0.2f,0.6f);
		randomHeight03 = Random.Range (0f, 0.5f);
	}
	/*public void Background01(Vector3 startpos){
		GameObject bg = BG01.GetPooledObject ();
		GameObject bg2 = BG01_1.GetPooledObject (); 
		bg.transform.position = startpos;
		bg2.transform.position = startpos;
		bg.SetActive (true);
		bg2.SetActive (true);
	}/*
	public void Background02(){
		GameObject bg = BG02.GetPooledObject ();
		bg.SetActive (true);
	}
	public void Background03(){
		GameObject bg = BG03.GetPooledObject ();
		bg.SetActive (true);
	}
	public void Background04(){
		GameObject bg = BG04.GetPooledObject ();
		bg.SetActive (true);
	}
	public void Background05(){
		GameObject bg = BG05.GetPooledObject ();
		bg.SetActive (true);*/
	//}
	public void Arrow(Vector3 startPos){
		GameObject arrow = arrowPool.GetPooledObject ();
		arrow.transform.position = startPos;
		arrow.SetActive (true);
	}
	public void SpawnCoinsUpAndUpGold(Vector3 startPos){
		GameObject coin1 = coinGoldPool.GetPooledObject ();
		coin1.transform.position =  new Vector3(startPos.x,startPos.y + randomHeight02 ,startPos.z);
		coin1.SetActive (true);

		GameObject coin2 = coinGoldPool.GetPooledObject ();
		coin2.transform.position = new Vector3(startPos.x - distanceBetweenCoins - randomHeight03,startPos.y ,startPos.z);
		coin2.SetActive (true);

		GameObject coin3 = coinGoldPool.GetPooledObject ();
		coin3.transform.position = new Vector3(startPos.x + distanceBetweenCoins+randomHeight03,startPos.y ,startPos.z);
		coin3.SetActive (true);
	}
	public void SpawnCoinsUpAndUpBronze(Vector3 startPos){
		GameObject coin1 = coinBronzePool.GetPooledObject ();
		coin1.transform.position =  new Vector3(startPos.x,startPos.y + randomHeight02 ,startPos.z);
		coin1.SetActive (true);

		GameObject coin2 = coinBronzePool.GetPooledObject ();
		coin2.transform.position = new Vector3(startPos.x - distanceBetweenCoins-randomHeight03,startPos.y,startPos.z);
		coin2.SetActive (true);

		GameObject coin3 = coinBronzePool.GetPooledObject ();
		coin3.transform.position = new Vector3(startPos.x + distanceBetweenCoins+randomHeight03,startPos.y,startPos.z);
		coin3.SetActive (true);
	}

	public void SpawnCoinsGold(Vector3 startPos){

		GameObject coin1 = coinGoldPool.GetPooledObject ();
		coin1.transform.position = startPos;
		coin1.SetActive (true);

		GameObject coin2 = coinGoldPool.GetPooledObject ();
		coin2.transform.position = new Vector3(startPos.x - distanceBetweenCoins,startPos.y,startPos.z);
		coin2.SetActive (true);

		GameObject coin3 = coinGoldPool.GetPooledObject ();
		coin3.transform.position = new Vector3(startPos.x + distanceBetweenCoins,startPos.y,startPos.z);
		coin3.SetActive (true);

	}
	public void SpawnCoinsOneGold(Vector3 startPos){

		GameObject coin1 = coinGoldPool.GetPooledObject ();
		coin1.transform.position = startPos;
		coin1.SetActive (true);
	}
	public void SpawnCoinsTwoGold(Vector3 startPos){

		GameObject coin1 = coinGoldPool.GetPooledObject ();
		coin1.transform.position = startPos;
		coin1.SetActive (true);

		GameObject coin2 = coinGoldPool.GetPooledObject ();
		coin2.transform.position = new Vector3(startPos.x - 1.5f,startPos.y - randomHeight ,startPos.z);
		coin2.SetActive (true);

	}
	public void SpawnCoinsThreeGold(Vector3 startPos){

		GameObject coin1 = coinGoldPool.GetPooledObject ();
		coin1.transform.position = startPos;
		coin1.SetActive (true);

		GameObject coin2 = coinGoldPool.GetPooledObject ();
		coin2.transform.position = new Vector3(startPos.x - 1.5f,startPos.y - randomHeight ,startPos.z);
		coin2.SetActive (true);

		GameObject coin3 = coinGoldPool.GetPooledObject ();
		coin3.transform.position = new Vector3(startPos.x + 1.5f,startPos.y + randomHeight,startPos.z);
		coin3.SetActive (true);

	}
	public void SpawnCoinsBronze(Vector3 startPos){

		GameObject coin1 = coinBronzePool.GetPooledObject ();
		coin1.transform.position = startPos;
		coin1.SetActive (true);

		GameObject coin2 = coinBronzePool.GetPooledObject ();
		coin2.transform.position = new Vector3(startPos.x - distanceBetweenCoins,startPos.y,startPos.z);
		coin2.SetActive (true);

		GameObject coin3 = coinBronzePool.GetPooledObject ();
		coin3.transform.position = new Vector3(startPos.x + distanceBetweenCoins,startPos.y,startPos.z);
		coin3.SetActive (true);

	}
	public void SpawnCoinsOneBronze(Vector3 startPos){

		GameObject coin1 = coinBronzePool.GetPooledObject ();
		coin1.transform.position = startPos;
		coin1.SetActive (true);
	}
	public void SpawnCoinsTwoBronze(Vector3 startPos){

		GameObject coin1 = coinBronzePool.GetPooledObject ();
		coin1.transform.position = startPos;
		coin1.SetActive (true);

		GameObject coin2 = coinBronzePool.GetPooledObject ();
		coin2.transform.position = new Vector3(startPos.x - 1.5f,startPos.y - randomHeight ,startPos.z);
		coin2.SetActive (true);

	}
	public void SpawnCoinsThreeBronze(Vector3 startPos){

		GameObject coin1 = coinBronzePool.GetPooledObject ();
		coin1.transform.position = startPos;
		coin1.SetActive (true);

		GameObject coin2 = coinBronzePool.GetPooledObject ();
		coin2.transform.position = new Vector3(startPos.x - 1.5f,startPos.y - randomHeight ,startPos.z);
		coin2.SetActive (true);

		GameObject coin3 = coinBronzePool.GetPooledObject ();
		coin3.transform.position = new Vector3(startPos.x + 1.5f,startPos.y + randomHeight,startPos.z);
		coin3.SetActive (true);

	}

}
