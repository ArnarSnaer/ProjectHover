using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private HealthSystem health;
    // Start is called before the first frame update
    public void Setup(HealthSystem health){
        this.health = health;
        
        health.OnHealthChanged += HealthSystem_OnHealthChanged;
    }
    private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e){
        transform.Find("Bar").localScale = new Vector3(health.GetHealthPercent(), 1);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
