using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class uimanager : MonoBehaviour
{
    [SerializeField]
    private Text score;
    [SerializeField]
    private Sprite[] lives;
    [SerializeField]
    private Image img;
    [SerializeField]
    private Text gameover;
    [SerializeField]
    private Text returnkey;
    private gamemanager gm;
    [SerializeField]
    private Button exitbutton;
  
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + 27;
        gameover.gameObject.SetActive(false);
        returnkey.gameObject.SetActive(false);
        exitbutton.gameObject.SetActive(false);
        gm = GameObject.Find("gamemanager").GetComponent<gamemanager>();

        if(gm==null)
        {
            Debug.Log("game manager not loaded");
        }
    }

    // Update is called once per frame
    public void updatescore(int playerscore)
    {
        score.text = " Score: " + playerscore.ToString();

    }

    public void updatelives(int currentlives)
    {
        img.sprite = lives[currentlives];
        if(currentlives==0)
        {
            gameover.gameObject.SetActive(true);
            returnkey.gameObject.SetActive(true);
            exitbutton.gameObject.SetActive(true);
            gm.gameover();

        }
    }
    public void exittomenu()
    {
        SceneManager.LoadScene(0);//back to main menue.
    }

  
}
