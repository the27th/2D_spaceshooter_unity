using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trippleshot : MonoBehaviour
{
    private float speed = 3f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y <-9f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "player")
        {
            other.GetComponent<player>().Trippleshot_power();
            Destroy(this.gameObject);
        }
    }
}
