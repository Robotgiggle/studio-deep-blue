using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAmmo : MonoBehaviour
{
    public static int CurrentAmmo;
    public int InternalAmmo;
    public GameObject AmmoDisplay;

    // Start is called before the first frame update
    void Start()
    {
        CurrentAmmo = 0;
        CurrentAmmo += 10;
    }

    // Update is called once per frame
    void Update()
    {
        InternalAmmo = CurrentAmmo;
        //Text displaying ammo count to be added
        //AmmoDisplay.GetComponent<Text>().text = "Ammo: " + InternalAmmo;
    }
}