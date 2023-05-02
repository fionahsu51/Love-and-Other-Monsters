using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

//Tutorial from here https://www.youtube.com/watch?v=8oTYabhj248&ab_channel=BMo
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextAsset inkFile;
    
    private Story currentStory;
    private string currentLine;
    
    //public string[] lines;
    public float textSpeed;
    //private int index;
    public bool dialoguePlaying;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue(inkFile);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == currentLine)
            {
                continueStory();
            }

            else
            {
                StopAllCoroutines();
                textComponent.text = currentLine;
            }
        }
    }

    public void StartDialogue(TextAsset inkJSON)
    {
        dialoguePlaying = true;
        currentStory = new Story(inkJSON.text);
        //StartCoroutine(TypeLine());
        continueStory();
        

        //StartCoroutine(TypeLine());
    }

    void continueStory(){
        if(currentStory.canContinue){
            textComponent.text = "";
            currentLine = currentStory.Continue();
            StartCoroutine(TypeLine());
        }else{
            endDialogue();
        }
    }

    void endDialogue(){
        dialoguePlaying = false;
        gameObject.SetActive(false);
        textComponent.text = "";
    }

    //Types each character out one by one
    IEnumerator TypeLine()
    {
        foreach(char c in currentLine.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    /*void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }*/
}
