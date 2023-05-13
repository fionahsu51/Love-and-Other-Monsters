using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestTextDisplay : MonoBehaviour
{
    public TMP_Text textComponent;
    string text;
    GameObject dialogueBox;
    string old = "Your previous selection was ";
    string selection = "Your new selection is ";

    // Start is called before the first frame update
    void Start()
    {
        // Display the previous woman choice
        text = PlayerPrefs.GetString("womanSelection");
        textComponent.text = old + text;
        dialogueBox = GameObject.Find("/Canvas/Dialogue Box");
    }

    // Update is called once per frame
    void Update()
    {
        // Display the new woman choice!
        if (!dialogueBox.activeSelf)
        {
            text = PlayerPrefs.GetString("womanSelection");
            textComponent.text = selection + text + "!";
        }
    }
}
