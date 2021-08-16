using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenManager : MonoBehaviour
{
    public float range;
    public int coreHealing;
    public int coreHealCost;
    public int turretUpgradeCost;
    public int wepUpgradeCost;
    public int waveClearReward;
    public int tokens;
    RaycastHit target;
    int mask = 1 << 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            if(Physics.Raycast(transform.position,transform.forward,out target,range,mask)){
                if(target.transform.gameObject.name=="core"&&tokens>=coreHealCost){
                    tokens -= coreHealCost;
                    CoreController core = target.transform.gameObject.GetComponent<CoreController>();
                    core.health += coreHealing;
                    if(core.health>100){core.health = 100;}
                }else if(target.transform.gameObject.name=="head_lv1"&&tokens>=turretUpgradeCost){
                    tokens -= turretUpgradeCost;
                    target.transform.gameObject.GetComponent<TurretController>().levelUp();
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
