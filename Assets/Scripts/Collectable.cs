using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

	void Start()
	{
		StartCoroutine(Destroy());
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		//give status update to DonkeyKong
		if (other.gameObject.tag == "Barrel")
		{
			GameObject.Find("DonkeyKong").GetComponent<DonkeyKongController>().ReceivedCollectable("NormalBarrel");
			Destroy(this.gameObject);
		}
	}

	IEnumerator Destroy()
	{
		yield return new WaitForSeconds(GameObject.Find("Spawner").GetComponent<CollectableSpawner>()._destroyTime);
		Destroy(this.gameObject);
	}
}
