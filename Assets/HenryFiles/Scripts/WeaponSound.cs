using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSound : MonoBehaviour
{
    private AudioSource m_AudioSource;
    [SerializeField] private AudioClip m_WeaponSound_1;

    private Animation m_Animation;
    [SerializeField] private Animation m_GunShot;

    private float fireCooldown = 2f;
    private float fireStart = 0;
    //public bool canAnimate = true;
    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && (Time.time > fireStart + fireCooldown) && (!MouseLockCursor.paused))
        {
            PlayWeaponSound();
            PlayWeaponFire();
            //canAnimate = true;
            fireStart = Time.time;
        }
    }

    private void PlayWeaponSound()
    {
        if (m_WeaponSound_1 != null)
        {
            m_AudioSource.clip = m_WeaponSound_1;
            m_AudioSource.Play();
        }
    }

    private void PlayWeaponFire()
    {
        if (m_GunShot)
        {
            m_Animation = GetComponent<Animation>();
            m_Animation.Play();
            //canAnimate = false;
        }
    }
}
