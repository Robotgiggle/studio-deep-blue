using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSound : MonoBehaviour
{
    public AudioSource m_AudioSource;

    //private AudioSource m_AudioSource;
    [SerializeField] private AudioClip m_WeaponSound_1;

    private Animation m_Animation;
    [SerializeField] private Animation m_GunShot;

    public bool canAnimate = true;
    public GameObject weaponToTrack;

    public float shotCooldown = 1f;
    private float fireStart = 0;
    // Start is called before the first frame update
    void Start()
    {
        //m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponToTrack.GetComponent<BulletSpawner>().isFiring)
        {
            PlayWeaponSound();
            PlayWeaponFire();
            fireStart = Time.time;
        }

        if (Input.GetButtonDown("Fire1") && (Time.time > fireStart + shotCooldown) && Time.timeScale != 0)
        {
            PlayWeaponSound();
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
        }
    }
}
