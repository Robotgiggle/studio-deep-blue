using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossHairsAnimation : MonoBehaviour
{
    private Animation m_Animation;
    [SerializeField] private Animation m_GunShot;
    public GameObject weaponToTrack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponToTrack.GetComponent<BulletSpawner>().isFiring)
        PlayWeaponFire();
    }

    private void PlayWeaponFire()
    {
        if (m_GunShot)
        {
            m_Animation = GetComponent<Animation>();
            m_Animation.Play();
        }
    }
}
