using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMotion : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.forward*speed*Time.deltaTime);
        }else if(Input.GetKey(KeyCode.S)){
            transform.Translate(Vector3.back*speed*Time.deltaTime);
        }else if(Input.GetKey(KeyCode.A)){
            transform.Translate(Vector3.left*speed*Time.deltaTime);
        }else if(Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.right*speed*Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("token")){
            Destroy(other.gameObject);
            transform.GetChild(0).gameObject.GetComponent<TokenManager>().tokens++;
        }
    }
}
