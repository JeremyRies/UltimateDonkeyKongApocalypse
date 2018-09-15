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
            int rand = Random.Range(0, 2);
            GameObject randomSpawner = _spawnerLeft;
            Vector2 movement = Vector2.left;

            switch (rand)
            {
                case 0:
                    randomSpawner = _spawnerLeft;
                    movement = Vector2.left;
                    break;

                case 1:
                    randomSpawner = _spawnerRight;
                    movement = Vector2.right;
                    break;
            }
            GameObject Mario = Instantiate(_spawnObject, randomSpawner.transform);
            

            yield return new WaitForSeconds(_spawnTime);
        } 
    }

    void StartNewWave()
    {
        StartCoroutine(NextWave());
    }
    
    IEnumerator NextWave()
    {
        Debug.Log(string.Format("Wavetime: {0}",_waveSize/_spawnsPerSeconds));
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
