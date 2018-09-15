using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CollectableSpawner : MonoBehaviour
{

	private float _setupTime;
	[SerializeField] private float _spawnTime;
	[SerializeField] public float _destroyTime;
	[SerializeField] private GameObject _collectablePrefab;
	
	void Start ()
	{
		_setupTime = GameObject.Find("Spawner").GetComponent<MarioSpawner>()._setupTime;
		StartCoroutine(Spawn());
	}

	IEnumerator Spawn()
	{
		yield return new WaitForSeconds(_setupTime);
		while (true)
		{
			/*while (isPaused)
            {
                yield return null;
            }*/
			GameObject collectable = Instantiate(_collectablePrefab);
			collectable.GetComponent<Collectable>().SetType(RandomCollectable());
			collectable.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-4, 2), 0);
			yield return new WaitForSeconds(_spawnTime);
		}
	}

	private CollectableEnum RandomCollectable()
	{
		// return some random enumtype;
		return CollectableEnum.Big;
	}
	
}
