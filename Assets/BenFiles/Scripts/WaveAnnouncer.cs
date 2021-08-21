using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveAnnouncer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator print(string message,float lifetime){
        Text printout = gameObject.GetComponent<Text>();
        printout.text = message;
        //fade in
        gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        printout.color = new Color(1f,1f,1f,0.2f);
        yield return new WaitForSeconds(0.1f);
        printout.color = new Color(1f,1f,1f,0.4f);
        yield return new WaitForSeconds(0.1f);
        printout.color = new Color(1f,1f,1f,0.6f);
        yield return new WaitForSeconds(0.1f);
        printout.color = new Color(1f,1f,1f,0.8f);
        yield return new WaitForSeconds(0.1f);
        printout.color = new Color(1f,1f,1f,1f);
        //stay rendered for [lifetime]
        yield return new WaitForSeconds(lifetime);
        //fade out
        yield return new WaitForSeconds(0.1f);
        printout.color = new Color(1f,1f,1f,0.8f);
        yield return new WaitForSeconds(0.1f);
        printout.color = new Color(1f,1f,1f,0.6f);
        yield return new WaitForSeconds(0.1f);
        printout.color = new Color(1f,1f,1f,0.4f);
        yield return new WaitForSeconds(0.1f);
        printout.color = new Color(1f,1f,1f,0.2f);
        yield return new WaitForSeconds(0.1f);
        printout.color = new Color(1f,1f,1f,0f);
        gameObject.SetActive(false);
    }
}
