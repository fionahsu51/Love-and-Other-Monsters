using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickforScene : MonoBehaviour
{
    public int SceneIndex;
    bool mouseHover = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && mouseHover == true)
        {
            SceneManager.LoadScene(SceneIndex);
        }
    }

    void OnMouseOver()
    {
        
        mouseHover = true;
 
    }

    void OnMouseExit()
    {
        mouseHover = false;
    }
}
