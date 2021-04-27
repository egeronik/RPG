using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightStarter : MonoBehaviour
{
   
    public float evadeChance = 10;
    public GameObject dialogWindow;
    public GameObject constationWidnow;

    public void startFight()
    {
        constationWidnow.SetActive(false);
        StateDataController.dialogWindowAlive = false;

        SceneManager.LoadScene(1); 
    }

    public void tryToEscape()
    {
        if (Random.Range(0, 100) > evadeChance)
        {
            for (int i = 0; i < StateDataController.teamHP.Length; ++i)
            {
                StateDataController.teamHP[i] *= 9 / 10;
            }
            dialogWindow.SetActive(false);
            constationWidnow.SetActive(true);
        }
        else
        {
            dialogWindow.SetActive(false);
            
            StateDataController.dialogWindowAlive = false;
        }
    }
}
