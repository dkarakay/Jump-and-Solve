using UnityEngine;
using System.Collections;

public class CoinPlatform : MonoBehaviour {
	public GameObject a;
	// Use this for initialization
	void  OnCollisionEnter2D(Collision2D other){
		Debug.Log ("Not");
		if (other.gameObject.tag == "Ground") {
			Debug.Log ("GroundWork");
			gameObject.SetActive (false);
			Destroy (gameObject);
		} else if (other.gameObject.name == "Platform_Blue_5") {
			gameObject.SetActive (false);
			Debug.Log ("NameWork");
			Destroy (gameObject);
		}
	}
}
