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
    WaveTally tally;
    int mask = 1 << 3;
    int selected;
    float lBound;
    float rBound;
    float tbuffer;
    bool left;

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
        tally = GameObject.Find("manager").GetComponent<WaveTally>();
    }

    // Update is called once per frame
    void Update()
    {
        if(zAxis){
            slideZ();           
        }else{
            slideX();
        }
        if(Time.time>=tbuffer){
            selectSpawnable();
            if(Physics.Raycast(transform.position,Vector3.down,out spawnPoint,100,mask)){
                if(selected!=3){Instantiate(spawnables[selected],spawnPoint.point,transform.rotation);}
            }
            tbuffer = Time.time + spawnRate;
        }
        if(tally.waveDone){
            this.gameObject.SetActive(false);
        }
    }

    void slideX(){
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

    void slideZ(){
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
    }

    void selectSpawnable(){
        selected = 3;
        if(!tally.waveDone){
            bool empty = true;
            while(empty&&!tally.waveDone){
                selected = Random.Range(0,3);
                switch(selected){
                    case 0:
                        if(tally.waves[tally.wave].x!=0){
                            empty = false;
                            tally.waves[tally.wave].x--;
                        }
                        break;
                    case 1:
                        if(tally.waves[tally.wave].y!=0){
                            empty = false;
                            tally.waves[tally.wave].y--;
                        }
                        break;
                    case 2:
                        if(tally.waves[tally.wave].z!=0){
                            empty = false;
                            tally.waves[tally.wave].z--;
                        }
                        break;
                    default:
                        Debug.Log("enemy selection error");
                        break;
                }
                tally.waveDone = (tally.waves[tally.wave].x==0&&tally.waves[tally.wave].y==0&&tally.waves[tally.wave].z==0);
            }
        }
    }
}
