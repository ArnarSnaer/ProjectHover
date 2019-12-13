using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("P1 PS4 X") || Input.GetButton("P2 PS4 Circle"))
        {
            SceneManager.LoadScene("MainMenu");        
        }
    }
}
