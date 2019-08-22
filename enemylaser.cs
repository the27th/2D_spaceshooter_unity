using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemylaser : MonoBehaviour
{
    private float speed = 4f;
    private player p1;
   
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y<-10f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="player")
        {
            p1 = GameObject.Find("player").GetComponent<player>();
            if(p1 != null)
            {
                Debug.Log("player hit by laser");
                p1.Damageplayer();
            }
            Destroy(this.gameObject);
        }
    }
}
