using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GlobalPlayerHealth : MonoBehaviour
{
    public static double CurrentHealth;
    public double InternalHealth;
    public GameObject HealthDisplay;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = 0;
        CurrentHealth += 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (InternalHealth < 0)
        {
            InternalHealth = 0;
            CurrentHealth = 0;
        }
        InternalHealth = CurrentHealth;
        HealthDisplay.GetComponent<Text>().text = "Health: " + InternalHealth;
    }
}