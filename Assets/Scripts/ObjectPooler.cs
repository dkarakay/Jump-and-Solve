using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {

	public GameObject pooledObject;
	public int pooledAmount;
	List<GameObject> pooledObjects;
	// Use this for initialization
	void Start () {
		pooledObjects = new List<GameObject> ();
		for(int i = 0; i < pooledAmount; i++)
		{
			GameObject o = (GameObject)Instantiate (pooledObject);
			o.SetActive (false);
			pooledObjects.Add (o);
		}
	}
	
	// Update is called once per frame
	public GameObject GetPooledObject(){
		for (int i = 0; i < pooledObjects.Count; i++) {
			if (!pooledObjects [i].activeInHierarchy) {
				return pooledObjects [i];
			}
		}
			GameObject o = (GameObject)Instantiate (pooledObject);
			o.SetActive (false);
			pooledObjects.Add (o);
		return o;

	}
}

