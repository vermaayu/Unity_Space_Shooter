using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    
    [SerializeField]
    private GameObject _enemyContainer;
    
    //[SerializeField]
    //private GameObject _asteroidPrefab;
    
    [SerializeField]
    private GameObject[] _powerup;

    private bool _stopSpawning = false;
    private float _spawnTime = 5.0f;
    
    public void StartSpawning()
    {
        
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnDifficultyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
        //StartCoroutine(SpawnAsteroidsRoutine());
    }

    //Coroutine
    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3f);
        while (_stopSpawning == false)
        {
            Vector3 spawn_pos = new Vector3(Random.Range(-11f, 11f), 6, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, spawn_pos, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            Debug.Log("The spawn time =" + _spawnTime);
            yield return new WaitForSeconds(_spawnTime);
            

        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
        yield return new WaitForSeconds(3f);
        while (_stopSpawning == false)
        {
            Vector3 post2Spawn = new Vector3(Random.Range(-9f, 9f), 6, 0);
            Instantiate(_powerup[Random.Range(0,3)], post2Spawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(8, 15));
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
    IEnumerator SpawnDifficultyRoutine()
    {
        while (_stopSpawning == false)
        {
            if (_spawnTime > 1.0f)
            {
                _spawnTime -= 1.0f;
                Debug.Log("Difficulty1 :" + _spawnTime);
            }
            else if (_spawnTime <= 1.0f && _spawnTime > 0.1f)
            {
                _spawnTime -= 0.1f;
                Debug.Log("Difficulty2 :" + _spawnTime);
            }
            yield return new WaitForSeconds(10);
        }
    }

    //IEnumerator SpawnAsteroidsRoutine()
    //{
    //        Vector3 asteroidSpawn = new Vector3(0, 6, 0);
    //        GameObject asteroid = Instantiate(_asteroidPrefab, asteroidSpawn, Quaternion.identity);
    //        yield return new WaitForSeconds(5);   
    //}
}