﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public int EnemiesPerWave;
    public GameObject Enemy;
}

public class SpawnManager : MonoBehaviour
{
    public Wave[] Waves; // class to hold information per wave
    public Transform[] SpawnPoints;
    public float TimeBetweenEnemies = 2f;
    public AudioSource WaveDone;
    private int _totalEnemiesInCurrentWave;
    private int _enemiesInWaveLeft;
    private int _spawnedEnemies;

    private int _currentWave;
    private int _totalWaves;

    int target_switch = 1;

	void Start ()
	{
	    _currentWave = -1; // avoid off by 1
	    _totalWaves = Waves.Length - 1; // adjust, because we're using 0 index

	    StartNextWave();
	}

    void StartNextWave()
    {
        _currentWave++;

        // win
        if (_currentWave > _totalWaves)
        {
            return;
        }

        _totalEnemiesInCurrentWave = Waves[_currentWave].EnemiesPerWave;
        _enemiesInWaveLeft = 0;
        _spawnedEnemies = 0;

        StartCoroutine(SpawnEnemies());
    }

    // Coroutine to spawn all of our enemies
    IEnumerator SpawnEnemies()
    {
        GameObject enemy = Waves[_currentWave].Enemy;
        while (_spawnedEnemies < _totalEnemiesInCurrentWave)
        {
            _spawnedEnemies++;
            _enemiesInWaveLeft++;

            int spawnPointIndex = Random.Range(0, SpawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            TankMovement[] players = FindObjectsOfType<TankMovement>();
            TankMovement player1 = players[0];
            TankMovement player2 = players[1];
            Transform direction1 = player1.transform;
            Transform direction2 = player2.transform;
            GameObject clone = Instantiate(enemy, SpawnPoints[spawnPointIndex].position, SpawnPoints[spawnPointIndex].rotation);
            Pathfinding.AIDestinationSetter player_target = clone.GetComponent<Pathfinding.AIDestinationSetter>();
            if(target_switch == 1){
                player_target.target = direction1; 
                target_switch = 2; 
            }
            else{
                player_target.target = direction2; 
                target_switch = 1; 
            }
            Debug.Log(clone.GetComponent<Pathfinding.IAstarAI>().destination);
            yield return new WaitForSeconds(TimeBetweenEnemies);
        }
        yield return null;
    }
    
    // called by an enemy when they're defeated
    public void EnemyDefeated()
    {
        _enemiesInWaveLeft--;
        
        // We start the next wave once we have spawned and defeated them all
        if (_enemiesInWaveLeft == 0 && _spawnedEnemies == _totalEnemiesInCurrentWave)
        {
            WaveDone.Play();
            StartNextWave();
        }
    }
}
