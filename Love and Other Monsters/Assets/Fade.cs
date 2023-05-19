using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{

    public float timeToWaitIn = 2.0f;
    public float timeToWaitOut = 10.0f;
    bool fadeout = false;
    bool fadein = false;
    public float fadeSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToFade());
    }

    // Update is called once per frame
    void Update()
    {
        
        if(fadein){
            float objectAlpha = this.GetComponent<CanvasGroup>().alpha;

            this.GetComponent<CanvasGroup>().alpha = objectAlpha + (fadeSpeed * Time.deltaTime);

            if(objectAlpha == 1){
                fadein = false;
                StartCoroutine(WaitToFade());
            }

            
        }

        if(fadeout){
            float objectAlpha = this.GetComponent<CanvasGroup>().alpha;

            this.GetComponent<CanvasGroup>().alpha = objectAlpha - (fadeSpeed * Time.deltaTime);

            if(objectAlpha == 0){
                fadeout = false;
            }
        }
    }

    IEnumerator WaitToFade(){
        
        if(this.GetComponent<CanvasGroup>().alpha == 0){
            Debug.Log("waiting in");
            yield return new WaitForSeconds(timeToWaitIn);
            Debug.Log("done waiting");
            fadein = true;
        }else{
            Debug.Log("waiting out");
            yield return new WaitForSeconds(timeToWaitOut);
            Debug.Log("done waiting");
            fadeout = true;
        }

    }
}
