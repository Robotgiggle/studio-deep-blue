using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenManager : MonoBehaviour
{
    public GameObject turret;
    public float cooldown;
    public float range;
    public int coreHealCost;
    public int turretPlaceCost;
    public int turretUpgradeCost;
    public int waveClearReward;
    public int tokens;
    RaycastHit target;
    Transform buttons;
    int turretBonus;
    int maskA = 1 << 3;
    int maskB = 1 << 4;
    int maskC = 1 << 6;
    Vector3 tBuffer;
    // Start is called before the first frame update
    void Start()
    {
        buttons = GameObject.Find("PanelT").transform;
        tBuffer = Vector3.one * cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        turretBonus = GameObject.FindGameObjectsWithTag("turret").Length;
        //ui integration
        buttons.GetChild(1).gameObject.GetComponent<Text>().text = tokens.ToString().PadLeft(2,'0');
        buttons.GetChild(2).GetChild(0).gameObject.GetComponent<Text>().text = (turretPlaceCost+turretBonus).ToString();
        buttons.GetChild(3).GetChild(0).gameObject.GetComponent<Text>().text = turretUpgradeCost.ToString();
        buttons.GetChild(4).GetChild(0).gameObject.GetComponent<Text>().text = coreHealCost.ToString();
        //token abilities
        if(Input.GetKey(KeyCode.E)||Input.GetMouseButton(1)){
            Vector3 source = transform.position;
            source += transform.forward * 0.5f;
            if(Physics.Raycast(source,transform.forward,out target,range,maskC)){
                CoreController core = target.transform.gameObject.GetComponent<CoreController>();
                if(target.transform.gameObject.name=="core"&&tokens>=coreHealCost&&Time.time>=tBuffer.z&&core.health<200){
                    tokens -= coreHealCost;
                    core.health += 20;
                    if(core.health>200){core.health = 200;}
                    tBuffer.z = Time.time + cooldown;
                    StartCoroutine(buttonBlink(3));
                }else if(target.transform.gameObject.name=="head_lv1"&&tokens>=turretUpgradeCost&&Time.time>=tBuffer.y){
                    tokens -= turretUpgradeCost;
                    target.transform.gameObject.GetComponent<TurretController>().levelUp();
                    tBuffer.y = Time.time + cooldown;
                    StartCoroutine(buttonBlink(2));
                }
            }
        }
        if(Input.GetKey(KeyCode.Q)&&Time.time>=tBuffer.x){
            if(Physics.Raycast(transform.position,transform.forward,out target,range,maskA)){
                if(Physics.Raycast(transform.position,transform.forward,range,maskB)){
                    Debug.Log("can't place a turret on an existing object");
                }else if(tokens>=turretPlaceCost + turretBonus){
                    Instantiate(turret,target.point,Quaternion.Euler(Vector3.zero));
                    tokens -= turretPlaceCost + turretBonus;
                    tBuffer.x = Time.time + cooldown;
                    StartCoroutine(buttonBlink(1));
                }
            }
        }
    }

    public void reward(){
        tokens += waveClearReward;
        waveClearReward += 5;
    }

    IEnumerator buttonBlink(int button){
        buttons.GetChild(button+1).gameObject.GetComponent<Image>().color = new Color(0.1322372f,0.06488074f,0.509434f,0.6666667f);
        yield return new WaitForSeconds(cooldown);
        buttons.GetChild(button+1).gameObject.GetComponent<Image>().color = new Color(0.02745098f,0.007843138f,0.1333333f,0.6666667f);
    }
}
