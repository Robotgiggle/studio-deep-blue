using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleExpire : MonoBehaviour
{
    public float partExpireTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ParticleDestroy());
    }

    IEnumerator ParticleDestroy()
    {
        yield return new WaitForSeconds(partExpireTime);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
