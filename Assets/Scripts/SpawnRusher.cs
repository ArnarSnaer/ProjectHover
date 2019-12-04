using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRusher : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    public GameObject SpawnPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(myPrefab, SpawnPosition.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
