using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
	public AudioClip backgroundMusic;
	public float musicSound;
	// Use this for initialization
	void Awake(){

	}
	void Start () {
		
		musicSound = PlayerPrefs.GetFloat ("MusicSound");
		MundoSound.Play (backgroundMusic, (musicSound), true);

		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
