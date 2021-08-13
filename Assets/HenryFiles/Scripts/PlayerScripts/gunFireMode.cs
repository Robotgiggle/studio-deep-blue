using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunFireMode : MonoBehaviour
{
    private AudioSource m_AudioSource;
    [SerializeField] private AudioClip m_GunSound;

    private Animation m_Animation;
    [SerializeField] private Animation m_GunShot;

    private float fireStart = 0;
    private float fireCooldown = 2f;

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && (Time.time > fireStart + fireCooldown) && (GlobalAmmo.CurrentAmmo > 0) && (!MouseLockCursor.paused))
        {
            PlayGunSound();
            PlayGunShot();
            fireStart = Time.time;
            GlobalAmmo.CurrentAmmo -= 1;
        }
    }

    private void PlayGunSound()
    {
        m_AudioSource.clip = m_GunSound;
        m_AudioSource.Play();
    }

    private void PlayGunShot()
    {
        m_Animation = GetComponent<Animation>();
        m_Animation.Play();
    }
}
