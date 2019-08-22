using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
   
    private bool isgameover = false;

    
    private void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire") && isgameover == true)
        {
            SceneManager.LoadScene(1);//current game scene index
        }
        //else if(isgameover==true && )
    }
    public void gameover()
    {
       
        isgameover = true;
    }
 
}
