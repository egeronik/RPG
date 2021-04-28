using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class battleSceneLoadingScript : MonoBehaviour
{
    // Start is called before the first frame update


    
    public void loadMenuScene()
    {
        SceneManager.LoadScene(0);
    }
    
    public void loadMapScene()
    {
        SceneManager.LoadScene(1);
    }
}
