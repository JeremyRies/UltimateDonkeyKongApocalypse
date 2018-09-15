using System.Collections;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class MarioSpawner : MonoBehaviour
{
    [SerializeField] public float _setupTime;
    [SerializeField] private float _spawnsPerSeconds;
    [SerializeField] private float _increaseAddendOfSpawns;
    [SerializeField] private float _waveSize;
    [SerializeField] private float _increaseAddendOfWaveSize;
    [SerializeField] private GameObject _spawnObject;
    [SerializeField] private GameObject _spawnerLeft;
    [SerializeField] private GameObject _spawnerRight;
    [SerializeField] private float _spawnTime;
    
	void Start ()
	{
	   StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_setupTime);
        CalculateSpawnTime();
        StartNewWave();
        while (true)
        {
            /*while (isPaused)
            {
                yield return null;
            }*/
            
            GameObject randomSpawner = (Random.Range(0,2)==0) ? _spawnerLeft : _spawnerRight;
            Instantiate(_spawnObject, randomSpawner.transform);
            yield return new WaitForSeconds(_spawnTime);
        } 
    }

    void StartNewWave()
    {
        StartCoroutine(NextWave());
    }
    
    IEnumerator NextWave()
    {
       // Debug.Log(string.Format("Wavetime: {0}",_waveSize/_spawnsPerSeconds));
        yield return new WaitForSeconds(_waveSize/_spawnsPerSeconds);
        RateChange();
        StartNewWave();
    }

    void RateChange()
    {
        _spawnsPerSeconds += _increaseAddendOfSpawns;
        _waveSize += _increaseAddendOfWaveSize;
        CalculateSpawnTime();
    }

    void CalculateSpawnTime()
    {
        _spawnTime = 1 / _spawnsPerSeconds;
    }
}
