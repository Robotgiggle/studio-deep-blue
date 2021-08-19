using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenManager : MonoBehaviour
{
    public GameObject turret;
    public float cooldown;
    public float range;
    public int coreHealCost;
    public int turretPlaceCost;
    public int turretUpgradeCost;
    public int wepUpgradeCost;
    public int waveClearReward;
    public int tokens;
    RaycastHit target;
    int maskA = 1 << 3;
    int maskB = 1 << 4;
    int maskC = 1 << 6;
    float tbuffer;
    // Start is called before the first frame update
    void Start()
    {
        tbuffer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            Vector3 source = transform.position;
            source += transform.forward * 0.5f;
            if(Physics.Raycast(source,transform.forward,out target,range,maskC)){
                if(target.transform.gameObject.name=="core"&&tokens>=coreHealCost){
                    tokens -= coreHealCost;
                    CoreController core = target.transform.gameObject.GetComponent<CoreController>();
                    core.health += 10;
                    if(core.health>200){core.health = 200;}
                }else if(target.transform.gameObject.name=="head_lv1"&&tokens>=turretUpgradeCost){
                    tokens -= turretUpgradeCost;
                    target.transform.gameObject.GetComponent<TurretController>().levelUp();
                }
            }
        }
        if(Input.GetKey(KeyCode.Q)&&Time.time>=tbuffer){
            if(Physics.Raycast(transform.position,transform.forward,out target,range,maskA)){
                if(Physics.Raycast(transform.position,transform.forward,range,maskB)){
                    Debug.Log("can't place a turret on an existing object");
                }else if(tokens>=turretPlaceCost){
                    Instantiate(turret,target.point,Quaternion.Euler(Vector3.zero));
                    tokens -= turretPlaceCost;
                    turretPlaceCost++;
                    tbuffer = Time.time + cooldown;
                }
            }
        }
        if(Input.GetKey(KeyCode.E)){
            if(tokens>=wepUpgradeCost){
                tokens -= wepUpgradeCost;
                //upgrade weapon
            }
        }
    }

    public void reward(){
        tokens += waveClearReward;
    }
}
