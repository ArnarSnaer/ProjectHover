using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownLogic : MonoBehaviour
{
    public GameObject player;

    private string playerIndex;
    public Image skill1;
    public Image skill2;
    private  float skill1Cooldown;
    private float skill2Cooldown;
    private float skill1Countdown;
    private float skill2Countdown;
    private Image skill1Image;
    private Image skill2Image;

    private bool skill1OnCooldown = false;
    private bool skill2OnCooldown = false;
  

    void Start()
    {
        playerIndex = player.GetComponent<TankMovement>().playerIndex;
        skill1Cooldown = player.GetComponent<GuardianAbilities>().pushCooldown;
        skill2Cooldown = player.GetComponent<GuardianAbilities>().wallCooldown;
        skill1Countdown = player.GetComponent<GuardianAbilities>().pushCountdown;
        skill2Countdown = player.GetComponent<GuardianAbilities>().wallCountdown;
        skill1Image = skill1.GetComponentsInChildren<Image>()[1];
        skill2Image = skill2.GetComponentsInChildren<Image>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        // Push
        if (skill1Countdown > 0.0f)
        {
            skill1Image.fillAmount = 1;
            skill1OnCooldown = true;
        }

        if (skill1OnCooldown)
        {
            skill1Image.fillAmount -= 1 / skill1Cooldown * Time.deltaTime;
            float timer = skill1Image.fillAmount * 10;
            GetComponentsInChildren<Text>()[0].text = timer.ToString("F0");

            if (skill1Image.fillAmount >= 1)
            {
                skill1Cooldown = 0;
                skill1Image.fillAmount = 0;
                skill1OnCooldown = false;
            }
        }
        
        // Wall
        if (skill2Countdown > 0.0f)
        {
            skill2Image.fillAmount = 1;
            skill2OnCooldown = true;
        }

        if (skill2OnCooldown)
        {
            skill2Image.fillAmount -= 1 / skill2Cooldown * Time.deltaTime;
            float timer = skill2Image.fillAmount * 10;
            GetComponentsInChildren<Text>()[1].text = timer.ToString("F0");

            if (skill2Image.fillAmount >= 1)
            {
                skill2Cooldown = 0;
                skill2Image.fillAmount = 0;
                skill2OnCooldown = false;
            }
        }
    }
}
