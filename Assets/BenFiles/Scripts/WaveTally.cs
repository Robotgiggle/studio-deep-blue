using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTally : MonoBehaviour
{
    public bool endless;
    public Vector3[] waves;
    public int wave = 0;
    public bool waveDone;
    Vector3[] backup;
    // Start is called before the first frame update
    void Start()
    {
        backup = waves;
    }

    // Update is called once per frame
    void Update()
    {
        if(!endless){waveDone = (waves[wave].x==0&&waves[wave].y==0&&waves[wave].z==0);}
    }

    void reset(){
        waves = backup;
    }
}
