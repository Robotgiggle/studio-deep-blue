using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    public float speed = 10f;
    
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
        //if (other.gameObject.CompareTag("<wall>"))
        //{
        //    Destroy(this.gameObject);
        //}
    }
}
