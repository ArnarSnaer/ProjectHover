using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Wave
{
    public GameObject [] EnemiesPerWave;
}

public class SpawnManager : MonoBehaviour
{
    public Wave[] Waves; // class to hold information per wave
    public Transform[] SpawnPoints;
    public float TimeBetweenEnemies = 2f;
    public AudioSource spawnEnemy;
    public AudioSource WaveDone;
    public GameObject ExitPortal;
    public TMPro.TextMeshProUGUI waveLabel;
    public TMPro.TextMeshProUGUI enemyLabel;
    private int _totalEnemiesInCurrentWave;
    private int _enemiesInWaveLeft;
    private int _spawnedEnemies;
    private int enemiesLeft = 0;
    private int _currentWave;
    private int _totalWaves;
    private int currWave = 1;

    public int turtle_switch = 0;

    int target_switch = 1;

	void Start ()
	{
	    _currentWave = -1; // avoid off by 1
	    _totalWaves = Waves.Length - 1; // adjust, because we're using 0 index
        waveLabel.text = "Wave: " + currWave + " / " + Waves.Length;
        StartNextWave();
	}

    void StartNextWave()
    {
        _currentWave++;

        // win
        if (_currentWave > _totalWaves)
        {
            Debug.Log("Next level!");
            waveLabel.text = "Level complete!";
            Instantiate(ExitPortal, new Vector3(0, 0, 0), Quaternion.identity);
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        _totalEnemiesInCurrentWave = Waves[_currentWave].EnemiesPerWave.Length;
        enemiesLeft = _totalEnemiesInCurrentWave;
        enemyLabel.text = "Enemies left: " + enemiesLeft;
        _enemiesInWaveLeft = 0;
        _spawnedEnemies = 0;

        StartCoroutine(SpawnEnemies());
    }

    // Coroutine to spawn all of our enemies
    IEnumerator SpawnEnemies()
    {
        GameObject enemy;
        yield return new WaitForSeconds(5);
        while (_spawnedEnemies < _totalEnemiesInCurrentWave)
        {
            enemy = Waves[_currentWave].EnemiesPerWave[_spawnedEnemies];

            int spawnPointIndex = Random.Range(0, SpawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            TankMovement[] players = FindObjectsOfType<TankMovement>();
            TankMovement player1 = players[0];
            TankMovement player2 = players[1];
            Transform direction1 = player1.transform;
            Transform direction2 = player2.transform;
            GameObject clone = Instantiate(enemy, SpawnPoints[spawnPointIndex].position, SpawnPoints[spawnPointIndex].rotation);
            spawnEnemy.Play();
            Pathfinding.AIDestinationSetter player_target = clone.GetComponent<Pathfinding.AIDestinationSetter>();
            if(target_switch == 1){
                player_target.target = direction1; 
                target_switch = 2; 
            }
            else{
                player_target.target = direction2; 
                target_switch = 1; 
            }
            _spawnedEnemies++;
            _enemiesInWaveLeft++;
            yield return new WaitForSeconds(TimeBetweenEnemies);
        }
        TimeBetweenEnemies /= 2;
        yield return null;
    }
    
    // called by an enemy when they're defeated
    public void EnemyDefeated()
    {
        Debug.Log("Enemy kill");
        _enemiesInWaveLeft--;
        enemiesLeft--;
        enemyLabel.text = "Enemies left: " + enemiesLeft;
        
        // We start the next wave once we have spawned and defeated them all
        if ((enemiesLeft <= 0) && (_spawnedEnemies >= _totalEnemiesInCurrentWave))
        {
            WaveDone.Play();
            GameManager.healPlayers(25);
            StartNextWave();
            currWave += 1;
            if(enemiesLeft < 0)
            {
                enemyLabel.text = "Enemies left: 0";
            }
            waveLabel.text = "Wave: " + currWave + " / " + Waves.Length;
        }
    }
}
