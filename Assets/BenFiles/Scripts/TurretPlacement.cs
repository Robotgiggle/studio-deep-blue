using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacement : MonoBehaviour
{
    public GameObject turret;
    public float cooldown;
    public float range;
    RaycastHit placePoint;
    int mask = 1 << 3;
    float tbuffer;
    // Start is called before the first frame update
    void Start()
    {
        tbuffer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q)&&Time.time>=tbuffer){
            if(Physics.Raycast(transform.position,transform.forward,out placePoint,range,mask)){
                Instantiate(turret,placePoint.point,Quaternion.Euler(Vector3.zero));
                tbuffer = Time.time + cooldown;
            }
        }
    }
}
