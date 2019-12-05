using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRusher : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    public GameObject SpawnPosition;
    public GameObject clone;
    
    // Start is called before the first frame update
    void Start()
    {
        TankMovement[] players = FindObjectsOfType<TankMovement>();
        TankMovement player1 = players[0];
        TankMovement player2 = players[1];
        Transform direction1 = player1.transform;
        Transform direction2 = player1.transform;
        // Instantiate at position (0, 0, 0) and zero rotation.
        clone = Instantiate(myPrefab, SpawnPosition.transform.position, Quaternion.identity);
        Pathfinding.AIDestinationSetter player_target = clone.GetComponent<Pathfinding.AIDestinationSetter>();
        player_target.target = direction2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
