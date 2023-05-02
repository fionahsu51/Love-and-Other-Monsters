using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickforScene : MonoBehaviour
{
    public int SceneIndex;
    bool mouseHover = false;
    GameObject dialogueBox;
    //Dialogue dialogueScript;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox = GameObject.Find("/Canvas/Dialogue Box");
        //dialogueScript = dialogueBox.GetComponent<Dialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if there is a dialogue box in this scene
        if (dialogueBox == null)
        {
            if (Input.GetMouseButton(0) && mouseHover == true)
            {
                SceneManager.LoadScene(SceneIndex);
            }
        }

        // If there is a dialogue box in this scene
        else
        {
            // If dialogue is finished, start coroutine
            if (!dialogueBox.activeSelf)
            {
                StartCoroutine(ClickBuffer());
            }
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

    // QOL, prevents immediate/accidental clicking to a different scene when the dialogue is finished
    // Example: When someone is spam-clicking through dialogue
    IEnumerator ClickBuffer()
    {
        yield return new WaitForSeconds(0.4f);
        if (Input.GetMouseButton(0) && mouseHover == true)
        {
            SceneManager.LoadScene(SceneIndex);
        }
    }
}
