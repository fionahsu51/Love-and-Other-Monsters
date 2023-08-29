using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHighlight : MonoBehaviour
{
    public int sceneIndex;
    public GameObject unhovered, hovered;
    bool mouseHover = false;

    // Start is called before the first frame update
    void Start()
    {
        unhovered.SetActive(true);
        hovered.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && mouseHover == true)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        mouseHover = true;
        unhovered.SetActive(false);
        hovered.SetActive(true);
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        mouseHover = false;
        unhovered.SetActive(true);
        hovered.SetActive(false);
        Debug.Log("Mouse is no longer on GameObject.");
    }
}