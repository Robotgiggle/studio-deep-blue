using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEnemies : MonoBehaviour
{
    public static int CurrentEnemies;
    public int InternalEnemies;
    public GameObject EnemiesDisplay;

    // Start is called before the first frame update
    void Start()
    {
        CurrentEnemies = 0;
        CurrentEnemies += 5;
    }

    // Update is called once per frame
    void Update()
    {

        InternalEnemies = CurrentEnemies;
        //EnemiesDisplay.GetComponent<Text>().text = "Enemies: " + InternalEnemies;

        if (CurrentEnemies == 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
