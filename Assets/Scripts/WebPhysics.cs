using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebPhysics : MonoBehaviour
{

    public float webCountdown;
    public string player_index;
    private TankMovement main_tank; 
    // Start is called before the first frame update
    void Start()
    {
        TankMovement[] players = FindObjectsOfType<TankMovement>();
        TankMovement player1 = players[0];
        TankMovement player2 = players[1];
        if(player1.playerIndex == player_index){
            main_tank = player1;
        }
        else{
            main_tank = player2;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if(main_tank.moveSpeed != 0f){
            Destroy (this.gameObject);
        }
        webCountdown -= Time.deltaTime;
        if (webCountdown < 0){
                Destroy (this.gameObject);
                 main_tank.moveSpeed = 10f;
            }
    }
    
}
