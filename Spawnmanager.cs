using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnmanager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject _containerenemy;

    [SerializeField]
    private GameObject trippleshotpower;

    [SerializeField]
    private GameObject speedbost;

    [SerializeField]
    private GameObject shieldobject;

    private bool isdead = false;
    
    void Start()
    {
        StartCoroutine(Spawnenemy());
        StartCoroutine(Spawnpowerups());
    }

    
    void Update()
    {
        
    }

    IEnumerator Spawnpowerups() //this coroutin is used to generate various powerups at random.
    {
        
        while(isdead == false)
        {
            int choice = Random.Range(0, 3);
            switch (choice)
            {
                case 0:
                    speedbostpower();
                    break;

                case 1:
                    trippleshotpowerup();
                    break;

                case 2:
                    shieldspawn();
                    break;

            

            }
            yield return new WaitForSeconds(10f);
        }
        
    }
    IEnumerator Spawnenemy()
    {
        while (isdead == false)
        {

            int i, no = Random.Range(1, 4);
            for (i = no; i < 5; i++)
            {
                Vector3 pos = new Vector3(Random.Range(-8f, 8f), 7, 0);
                GameObject newenemy = Instantiate(_enemy, pos, Quaternion.identity);
                newenemy.transform.parent = _containerenemy.transform;
            }
            yield return new WaitForSeconds(10f);
        }
        
        
    }

    private void trippleshotpowerup()
    {
       
        
         Vector3 pos = new Vector3(Random.Range(-8f, 8f), 9, 0);
         Instantiate(trippleshotpower, pos, Quaternion.identity);
        
        
    }

    private void speedbostpower()
    {
        
        
            Vector3 pos = new Vector3(Random.Range(-8f, 8f), 9, 0);
            Instantiate(speedbost, pos, Quaternion.identity);
           
        
    }

    private void shieldspawn()
    {
        
            Vector3 pos = new Vector3(Random.Range(-8f, 8f), 9, 0);
            Instantiate(shieldobject, pos, Quaternion.identity);
           
        
    }
    public void Playerdeath()
    {
        isdead = true;
    }
}
