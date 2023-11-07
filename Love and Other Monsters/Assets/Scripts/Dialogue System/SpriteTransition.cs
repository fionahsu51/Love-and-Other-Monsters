using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTransition : MonoBehaviour
{
    public SpriteRenderer yourSpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Fades sprite in and moves them in very slightly from the left
    public IEnumerator FadeIn()
    {
        //Vector3 initpos = transform.position;
        //Vector3 move = new Vector3(0.05f, 0, 0);
        //Vector3 start = new Vector3(0.5f, 0, 0);
        //transform.position -= start;
        Color tmp = yourSpriteRenderer.color;
        tmp.a = 0;
        yourSpriteRenderer.color = tmp;
        float alphaVal = yourSpriteRenderer.color.a;

        while (yourSpriteRenderer.color.a < 1)
        {
            alphaVal += 0.1f;
            tmp.a = alphaVal;
            yourSpriteRenderer.color = tmp;
            //transform.position += move;
            yield return new WaitForSeconds(0.01f); // update interval
        }

    }
}
