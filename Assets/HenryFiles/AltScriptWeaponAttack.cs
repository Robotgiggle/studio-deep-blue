using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltScriptWeaponAttack : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject playerBullet;
    public float bulletForwardForce = 5f;
    public float timeBetweenShots = 3f;
    public bool canAnimate = false;
    private float fireStart = 0;
    private float fireCooldown = 2f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Fire1")) && (Time.time > fireStart + fireCooldown) && !(MouseLockCursor.paused))// && (GlobalAmmo.CurrentAmmo > 0))
        {
            fireStart = Time.time;
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(playerBullet, firePoint.transform.position, transform.rotation) as GameObject;
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 3);

            Rigidbody Temporary_Rigid_Body;
            Temporary_Rigid_Body = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
            Temporary_Rigid_Body.AddForce(transform.right * bulletForwardForce * -100);
        }
    }
}
