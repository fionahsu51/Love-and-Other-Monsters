using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartTextBehavior : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public GameObject[] paragraphs;
    public GameObject indicator;
    public GameObject background;
    bool fadeout = false;
    bool fadein = false;
    public float fadeSpeed = 0.5f;
    int index = 0;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        indicator.GetComponent<CanvasGroup>().alpha = 0;
        fadein = true;
    }

    // Update is called once per frame
    void Update()
    {
        //WaitForStudio();
        if (fadein)
        {
            float objectAlpha = paragraphs[index].GetComponent<CanvasGroup>().alpha;
            paragraphs[index].GetComponent<CanvasGroup>().alpha = objectAlpha + (fadeSpeed * Time.deltaTime);
            indicator.GetComponent<CanvasGroup>().alpha = objectAlpha + (fadeSpeed * Time.deltaTime);
            //if (index < paragraphs.Length - 1)
            //{
            //    indicator.GetComponent<CanvasGroup>().alpha = objectAlpha + (fadeSpeed * Time.deltaTime);
            //}

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
            if (index <= paragraphs.Length - 1)
            {
                indicator.GetComponent<CanvasGroup>().alpha = objectAlpha - (fadeSpeed * Time.deltaTime);
            }

            if (objectAlpha == 0 && indicator.GetComponent<CanvasGroup>().alpha == 0)
            {

                if (index >= paragraphs.Length - 1)
                {
                    
                    fadein = false;
                    fadeout = false;
                    background.GetComponent<CanvasGroup>().alpha = objectAlpha - (0.2f * Time.deltaTime);
                    indicator.GetComponent<CanvasGroup>().blocksRaycasts = false;
                    foreach (GameObject item in paragraphs)
                    {
                        item.GetComponent<CanvasGroup>().blocksRaycasts = false;
                        item.GetComponent<CanvasGroup>().interactable = false;
                    }
                    this.GetComponent<CanvasGroup>().interactable = false;
                    this.GetComponent<CanvasGroup>().blocksRaycasts = false;

                    SceneManager.LoadScene("TitleScreen");
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
    //public IEnumerator WaitForStudio()
    //{
    //    yield return new WaitForSeconds(f);
    //}
}
