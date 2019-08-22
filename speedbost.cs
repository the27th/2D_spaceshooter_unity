using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedbost : MonoBehaviour
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="player")
        {
            other.GetComponent<player>().speedbostpowerup();
            Destroy(this.gameObject);
        }
    }
}
