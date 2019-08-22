using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private GameObject _bulet;
    private int _life = 3;
    private Spawnmanager sp;
    [SerializeField]
    private bool istripple = false;
    [SerializeField]
    private GameObject _triplelaser;
    private bool shieldpower = false;

    [SerializeField]
    private GameObject shieldplayer;

    [SerializeField]
    private int score=0;

    private uimanager ui;
    [SerializeField]
    private AudioClip laseraudio;
  
    private AudioSource laseraudiosource;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        sp = GameObject.Find("spawn").GetComponent<Spawnmanager>();
        if(sp!= null)
        {
            Debug.Log("success");
        }
        shieldplayer.SetActive(false);
        ui = GameObject.Find("Canvas").GetComponent<uimanager>();

        ui.updatelives(_life);

        laseraudiosource = GetComponent<AudioSource>();
        if(laseraudiosource==null)
        {
            Debug.Log("audio source componenet not found");
        }
        else
        {
            laseraudiosource.clip = laseraudio;
        }
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMovements();
        if (Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("Fire"))
        {
            bullet();
        }
        
       
    }

    void bullet()
    {

        if (istripple==true)
        {
            Instantiate(_triplelaser, transform.position + new Vector3(0, 0.7f, 0), Quaternion.identity);
            StartCoroutine(powerupcooldown());
        }
        else
        {
            Instantiate(_bulet, transform.position + new Vector3(0, 0.7f, 0), Quaternion.identity);
        }

        laseraudiosource.Play();

    }
    void PlayerMovements()
    {
        float horizontalinput = CrossPlatformInputManager.GetAxis("Horizontal");// Input.GetAxis("Horizontal");
        float verticalinput = CrossPlatformInputManager.GetAxis("Vertical");// Input.GetAxis("Vertical");

        if (transform.position.x > 10.1f)
        {
            transform.position = new Vector3(-10.1f, transform.position.y, 0);
        }
        else if (transform.position.x < -10.1f)
        {
            transform.position = new Vector3(10.1f, transform.position.y, 0);
        }
        else if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);

        }
        else if (transform.position.y < -3.9f)
        {
            transform.position = new Vector3(transform.position.x, -3.9f, 0);
        }
        transform.Translate(new Vector3(horizontalinput, verticalinput, 0) * _speed * Time.deltaTime);
        // transform.Translate(Vector3.right * horizontalinput * speed * Time.deltaTime);
        // transform.Translate(Vector3.up * verticalinput * speed * Time.deltaTime);
    }

     IEnumerator powerupcooldown()
    {
        yield return new WaitForSeconds(10.0f);
        istripple = false;
    }

    IEnumerator shieldcooldown()
    {
        yield return new WaitForSeconds(20.0f);
        shieldplayer.SetActive(false);
        shieldpower = false;
    }

    IEnumerator speedbostcooldown()
    {
        yield return new WaitForSeconds(10.0f);
        _speed = 5.0f;
    }

   
    public void Damageplayer()
    {
        if (shieldpower == false)
        {
            _life--;
            ui.updatelives(_life);
            if (_life < 1)
            {
                sp.Playerdeath();
                Destroy(this.gameObject);
            }
        }

       
    }
    
    public void Trippleshot_power()
    {

        istripple = true;
    }

    public void speedbostpowerup()
    {
        _speed = 10.0f;
        StartCoroutine(speedbostcooldown());
    }

    public void shieldpowerup()
    {
        shieldpower = true;
        shieldplayer.SetActive(true);
        StartCoroutine(shieldcooldown());
    }

    public void scoreadder()
    {
        score += 10;
        ui.updatescore(score);
    }
}