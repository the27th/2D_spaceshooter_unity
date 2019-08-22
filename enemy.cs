using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
  
    private float speed = 3.0f;
    private float spawnrate=1f;
    private float generation=-1f;
    private player p1;
    private Animator an;
    [SerializeField]
    private GameObject enemylaser;
    // Start is called before the first frame update
    void Start()
    {
        p1 = GameObject.Find("player").GetComponent<player>();
        if (p1 == null)
        {
            Debug.Log(" in enemy player object not loded");
        }
        an = GetComponent<Animator>();

        StartCoroutine(enemylaserfire());
    }

    // Update is called once per frame
    void Update()
    {
       
           // Instantiate(_enemy, new Vector3(Random.Range(-8f, 8f), 4, 0), Quaternion.identity);
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        

        if(transform.position.y<-9f)
        {
            transform.position = new Vector3(Random.Range(-8f, 8f), 6, 0);
        }

    }

    IEnumerator enemylaserfire()
    {
        while (true)
        {
            
            Instantiate(enemylaser, transform.position + new Vector3(0f, -0.5f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(6f);
        }
    }

  private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            player pl = other.transform.GetComponent<player>();

            if(pl!= null)
            {
                pl.Damageplayer();
            }
            speed = 0;
            an.SetTrigger("ontrigger");

            Destroy(this.gameObject,2.4f);

        }
        else if (other.tag == "laser") 
        {
            Destroy(other.gameObject);
            p1.scoreadder();
            speed = 0;
            an.SetTrigger("ontrigger");
            Destroy(this.gameObject,2.4f);
        }
    }

}
