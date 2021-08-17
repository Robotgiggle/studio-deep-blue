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

    void OnTriggerEnter(Collider col)
    {
        //if (other.gameObject.CompareTag("enemy"))
        //{
        //    Destroy(this.gameObject);
        //}
        //if (other.gameObject.CompareTag("<wall>"))
        //{
        //    Destroy(this.gameObject);
        //}
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("NeverMind");
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
