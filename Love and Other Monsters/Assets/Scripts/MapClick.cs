using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapClick : MonoBehaviour
{
    public int SceneIndex;
    bool mouseHover = false;
    public bool clickable = false;
    GameObject dialogueBox;
    Dialogue dialogue;
    public GameObject enlarged;
    public Map map;

    // Start is called before the first frame update
    void Start()
    {
        enlarged.SetActive(false);
        map = GameObject.Find("Map of Castelonia").GetComponent<Map>();;
        dialogueBox = GameObject.Find("/Canvas/Dialogue Box");
        dialogue = dialogueBox.GetComponent<Dialogue>();
        //dialogueScript = dialogueBox.GetComponent<Dialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Check if there is a dialogue box in this scene
        if (dialogueBox == null)
        {
            if (Input.GetMouseButton(0) && mouseHover == true && clickable == true)
            {
                //SceneManager.LoadScene(SceneIndex);
                map.setInvisible();
                dialogueBox.SetActive(true);
                dialogue.returnFromMap();
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
        if (!dialogueBox.activeSelf)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            enlarged.SetActive(true);
            mouseHover = true;
        }
    }

    void OnMouseExit()
    {
        if (!dialogueBox.activeSelf)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            enlarged.SetActive(false);
            mouseHover = false;
        }
    }

    // QOL, prevents immediate/accidental clicking to a different scene when the dialogue is finished
    // Example: When someone is spam-clicking through dialogue
    IEnumerator ClickBuffer()
    {
        yield return new WaitForSeconds(0.4f);
        if (Input.GetMouseButton(0) && mouseHover == true && clickable == true)
        {
            map.setInvisible();
            dialogueBox.SetActive(true);
            dialogue.returnFromMap();
        }
    }
}

