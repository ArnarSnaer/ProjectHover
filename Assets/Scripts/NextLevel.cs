using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public Image black;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D player){
        if(player.gameObject.tag == "Player"){
            StartCoroutine(Fading());
        }

    }

    IEnumerator Fading()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(()=>black.color.a==1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
