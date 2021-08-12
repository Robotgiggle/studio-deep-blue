using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLauncher : MonoBehaviour
{
    public GameObject Weapon;
    public GameObject BulletInstantiate;
    public GameObject PlayerBullet;
    public GameObject BulletRotator;
    public float BulletForwardForce = 5;
    public float timeBetweenShots = 3;
    public float timeUntilNextShot;
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
        if ((Input.GetButtonDown("Fire1")) && (Time.time > fireStart + fireCooldown) && (GlobalAmmo.CurrentAmmo > 0) && !(MouseLockCursor.paused))
        {
            fireStart = Time.time;

        }

        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(PlayerBullet, BulletInstantiate.transform.position, transform.rotation) as GameObject;

        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
        Temporary_RigidBody.AddForce(transform.forward * BulletForwardForce * -50);
    }
}
