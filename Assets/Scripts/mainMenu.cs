﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.UI;
using UnityEngine.EventSystems;
public class mainMenu : MonoBehaviour
{
    private EventSystem ES;
    private GameObject StoreSelected;
    
    public void Start()
    {
        ES = EventSystem.current;
        StoreSelected = ES.firstSelectedGameObject;
    }
    
    public void Update()
    {
        if (ES.currentSelectedGameObject != StoreSelected)
        {
            if (ES.currentSelectedGameObject == null)
            {
                ES.SetSelectedGameObject(StoreSelected);
            }
            else
            {
                StoreSelected = ES.currentSelectedGameObject;
            }
        }
    }
    public void PlayGame()
    {
        // Loads the next scene in the queue.
        // File -> Build Settings -> Scenes
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
