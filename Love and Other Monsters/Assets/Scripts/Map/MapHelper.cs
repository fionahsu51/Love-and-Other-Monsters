using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHelper : MonoBehaviour
{

    GameObject dialogueBox;
    Dialogue dialogue;
    // Start is called before the first frame update
    void Start()
    {
        dialogueBox = GameObject.Find("/Canvas/Dialogue Box");
        dialogue = dialogueBox.GetComponent<Dialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateDialogueBox(){
        dialogueBox.SetActive(true);
        dialogue.returnFromMap();
    }
}
