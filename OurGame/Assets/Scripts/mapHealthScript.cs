using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapHealthScript : MonoBehaviour
{

    public HealthBar healthBar;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(StateDataController.teamMaxHp[id]);
        if(StateDataController.teamHealthIsFull)
            healthBar.SetHealt(StateDataController.teamMaxHp[id]);
        else 
            healthBar.SetHealt(StateDataController.teamHp[id]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
