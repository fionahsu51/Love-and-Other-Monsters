using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSequence : MonoBehaviour
{
    public GameObject[] paragraphs;
    public GameObject indicator;
    bool fadeout = false;
    bool fadein = false;
    public float fadeSpeed = 0.5f;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        indicator.GetComponent<CanvasGroup>().alpha = 0;
        fadein = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (fadein)
        {
            float objectAlpha = paragraphs[index].GetComponent<CanvasGroup>().alpha;
            paragraphs[index].GetComponent<CanvasGroup>().alpha = objectAlpha + (fadeSpeed * Time.deltaTime);

            if (index < paragraphs.Length - 1)
            {
                indicator.GetComponent<CanvasGroup>().alpha = objectAlpha + (fadeSpeed * Time.deltaTime);
            }

            if (objectAlpha == 1)
            {
                fadein = false;
            }
        }

        else
        {
            if (Input.GetMouseButton(0) && fadein == false)
            {
                fadeout = true;
            }
        }

        if (fadeout)
        {
            float objectAlpha = paragraphs[index].GetComponent<CanvasGroup>().alpha;
            paragraphs[index].GetComponent<CanvasGroup>().alpha = objectAlpha - (fadeSpeed * Time.deltaTime);
            if (index < paragraphs.Length - 1)
            {
                indicator.GetComponent<CanvasGroup>().alpha = objectAlpha - (fadeSpeed * Time.deltaTime);
            }

            if (objectAlpha == 0 && indicator.GetComponent<CanvasGroup>().alpha == 0)
            {

                if (index >= paragraphs.Length - 1)
                {
                    fadein = false;
                    fadeout = false;
                    SceneManager.LoadScene("Title Screen");
                }

                else
                {
                    fadein = true;
                    fadeout = false;
                    index += 1;
                }
            }
        }
    }
}
