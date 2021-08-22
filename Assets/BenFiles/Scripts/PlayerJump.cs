using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpTime;
    Controller mainMotion;
    Vector3 aboveGround;
    Vector3 belowGround;
    public GameObject jumpEffect;
    public GameObject partPoint;
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        mainMotion = GetComponent<Controller>();
        aboveGround = transform.GetChild(1).position;
        belowGround = aboveGround;
        belowGround.y -= 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")&&Physics.Linecast(aboveGround,belowGround,8)){
            StartCoroutine(jump());
            if (jumpEffect != null)
            {
                effect = Instantiate(jumpEffect, partPoint.transform.position, partPoint.transform.rotation);
                effect.transform.parent = this.transform;
            }
        }
    }

    IEnumerator jump(){
        mainMotion.gravity = -9.81f;
        yield return new WaitForSeconds(jumpTime*0.8f);
        mainMotion.gravity = -4.9f;
        yield return new WaitForSeconds(jumpTime*0.2f);
        mainMotion.gravity = 4.9f;
        yield return new WaitForSeconds(jumpTime*0.2f);
        mainMotion.gravity = 9.81f;
    }
}
