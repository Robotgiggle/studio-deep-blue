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
        CurrentHealth += 100;
    }

    // Update is called once per frame
    void Update()
    {
        InternalHealth = CurrentHealth;
        HealthDisplay.GetComponent<Text>().text = "Health: " + InternalHealth;
    }
}