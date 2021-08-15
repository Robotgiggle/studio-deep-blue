using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject[] spawnables;
    public float spawnRate;
    public float moveSpeed;
    public float moveDist;
    public bool zAxis;
    RaycastHit spawnPoint;
    bool left = false;
    int mask = 1 << 3;
    int selected;
    float lBound;
    float rBound;
    float tbuffer;

    // Start is called before the first frame update
    void Start()
    {
        if(zAxis){
            lBound = transform.position.z;
            rBound = transform.position.z + moveDist;
        }else{
            lBound = transform.position.x;
            rBound = transform.position.x + moveDist;
        }
        tbuffer = spawnRate;   
        moveSpeed += Random.Range(-4f,4f);
        spawnRate += Random.Range(-0.4f,0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        if(zAxis){
            if(moveDist>=0){
                if(transform.position.z<=rBound&&!left){
                    transform.Translate(Vector3.right*moveSpeed*Time.deltaTime);
                }else if(!left){
                    left = true;
                }else if(transform.position.z>=lBound&&left){
                    transform.Translate(Vector3.left*moveSpeed*Time.deltaTime);
                }else if(left){
                    left = false;
                }else{
                    Debug.Log("motion error");
                }
            }else{
                if(transform.position.z>=rBound&&!left){
                    transform.Translate(Vector3.right*moveSpeed*Time.deltaTime);
                }else if(!left){
                    left = true;
                }else if(transform.position.z<=lBound&&left){
                    transform.Translate(Vector3.left*moveSpeed*Time.deltaTime);
                }else if(left){
                    left = false;
                }else{
                    Debug.Log("motion error");
                }
            }            
        }else{
            if(moveDist>=0){
                if(transform.position.x<=rBound&&!left){
                    transform.Translate(Vector3.right*moveSpeed*Time.deltaTime);
                }else if(!left){
                    left = true;
                }else if(transform.position.x>=lBound&&left){
                    transform.Translate(Vector3.left*moveSpeed*Time.deltaTime);
                }else if(left){
                    left = false;
                }else{
                    Debug.Log("motion error");
                }
            }else{
                if(transform.position.x>=rBound&&!left){
                    transform.Translate(Vector3.right*moveSpeed*Time.deltaTime);
                }else if(!left){
                    left = true;
                }else if(transform.position.x<=lBound&&left){
                    transform.Translate(Vector3.left*moveSpeed*Time.deltaTime);
                }else if(left){
                    left = false;
                }else{
                    Debug.Log("motion error");
                }
            }
        }
        if(Time.time>=tbuffer){
            selected = Random.Range(1,101);
            if(selected<=50){
                selected = 0;
            }else if(selected<=80){
                selected = 1;
            }else{
                selected = 2;
            }
            Physics.Raycast(transform.position,Vector3.down,out spawnPoint,100,mask);
            Instantiate(spawnables[selected],spawnPoint.point,transform.rotation);
            tbuffer = Time.time + spawnRate;
        }
    }
}
