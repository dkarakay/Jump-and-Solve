using UnityEngine;
using System.Collections;

public class adInter : MonoBehaviour {
	public Ads theAds;	
	// Use this for initialization
	void Start () {
	theAds.RequestInterstitial ();
		theAds.RequestInterstitial02 ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
