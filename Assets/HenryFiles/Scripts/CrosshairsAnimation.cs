using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairsAnimation : MonoBehaviour
{
    public GameObject UpCurse;
    public GameObject DownCurse;
    public GameObject UpCurseRight;
    public GameObject DownCurseRight;
    private float firestart = 0f;
    private float firecooldown = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void PlayerWeaponCrosshairAnimation()
    {
        UpCurse.GetComponent<Animation>();
        UpCurse.GetComponent<Animation>().Play();
        DownCurse.GetComponent<Animation>();
        DownCurse.GetComponent<Animation>().Play();
        UpCurseRight.GetComponent<Animation>();
        UpCurseRight.GetComponent<Animation>().Play();
        DownCurseRight.GetComponent<Animation>();
        DownCurseRight.GetComponent<Animation>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetButtonDown("Fire1")) && (Time.time > firestart + firecooldown))
        {
            PlayerWeaponCrosshairAnimation();
            firestart = Time.time;
        }
    }
}
