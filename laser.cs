using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    [SerializeField]
    private float speed=6.0f;
    
 
    
    void Update()
    {

        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if(transform.position.y>9.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
