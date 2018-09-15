using System.Collections;
using UnityEngine;

public class MarioSpawner : MonoBehaviour
{
    [SerializeField] private float _setupTime;
    [SerializeField] private float _spawnsPerSeconds;
    [SerializeField] private float _waveSize;
    [SerializeField] private GameObject _spawnObject;
    [SerializeField] private GameObject _spawner;
    [SerializeField] private float _spawnTime;
    
	void Start ()
	{
	   CalculateSpawnTime();
	   StartCoroutine(Spawn());
       StartNewWave();
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_setupTime);
        while (true)
        {
            Instantiate(_spawnObject, _spawner.transform);
            yield return new WaitForSeconds(_spawnTime);
        } 
    }

    void StartNewWave()
    {
        StartCoroutine(NextWave());
    }
    
    IEnumerator NextWave()
    {
        yield return new WaitForSeconds(10);
        RateChange();
        StartNewWave();
    }

    void RateChange()
    {
        _spawnsPerSeconds +=2;
        CalculateSpawnTime();
    }

    void CalculateSpawnTime()
    {
        _spawnTime = 1 / _spawnsPerSeconds;
    }
}
