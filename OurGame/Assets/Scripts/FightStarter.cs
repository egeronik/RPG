using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightStarter : MonoBehaviour
{
   
    public float evadeChance = 10;
    public GameObject dialogWindow;


    public void startFight()
    {
        Debug.Log("KEK");
        //SceneManager.LoadScene("OtherSceneName"); Добавить сдесь сцену
    }

    public void tryToEscape()
    {
        if (Random.Range(0, 100) > evadeChance)
        {
            startFight();
            for (int i = 0; i < StateDataController.teamHP.Length; ++i)
            {
                StateDataController.teamHP[i] *= 9 / 10;
            }
        }
        else
        {
            dialogWindow.SetActive(false);
            StateDataController.dialogWindowAlive = false;
        }
    }
}
