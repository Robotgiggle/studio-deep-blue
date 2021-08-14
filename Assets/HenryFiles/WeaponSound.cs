using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSound : MonoBehaviour
{
    private AudioSource m_AudioSource;
    [SerializeField] private AudioClip m_WeaponSound_1;

    private float fireCooldown = 2f;
    private float fireStart = 0;

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
            fireStart = Time.time;
        }
    }

    private void PlayWeaponSound()
    {
        m_AudioSource.clip = m_WeaponSound_1;
        m_AudioSource.Play();
    }
}
