using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.SceneManagement;

//Tutorial from here https://www.youtube.com/watch?v=8oTYabhj248&ab_channel=BMo
//https://www.youtube.com/watch?v=vY0Sk93YUhA&list=PL3viUl9h9k78KsDxXoAzgQ1yRjhm7p8kl&index=2
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextAsset inkFile;

    private Story currentStory;
    private string currentLine;
    private DialogueVariables dialogueVariables;
    public string nextScene;
    int canAdvance = 1;
    public Map map;

    //choices
    public GameObject[] choices;

    private TextMeshProUGUI[] choiceText;

    //public string[] lines;
    public float textSpeed;
    //private int index;
    public bool dialoguePlaying;

    //Speaker constants

    private const string SPEAKER_TAG = "speaker";
    private const string SPEAKER_LEFT_TAG = "speaker-l";
    private const string SPEAKER_C_LEFT_TAG = "speaker-cl";
    private const string SPEAKER_CENTER_TAG = "speaker-c";
    private const string SPEAKER_C_RIGHT_TAG = "speaker-cr";
    private const string SPEAKER_RIGHT_TAG = "speaker-r";
    private const string SPEAKER_TRANSITION_TAG = "speaker-transition";
    private const string SPEAKER_LEFT_TRANSITION_TAG = "speaker-l-transition";
    private const string SPEAKER_C_LEFT_TRANSITION_TAG = "speaker-cl-transition";
    private const string SPEAKER_CENTER_TRANSITION_TAG = "speaker-c-transition";
    private const string SPEAKER_C_RIGHT_TRANSITION_TAG = "speaker-cr-transition";
    private const string SPEAKER_RIGHT_TRANSITION_TAG = "speaker-r-transition";
    private const string PORTRAIT_TAG = "portrait";
    private const string FORMAT_TAG = "format";
    private const string BACKGROUND_TAG = "bg";
    private const string OPEN_MAP_TAG = "map";

    public Animator speakerAnimator;
    public Animator speakerLAnimator;
    public Animator speakerCLAnimator;
    public Animator speakerCRAnimator;
    public Animator speakerRAnimator;

    public SpriteTransition speakerCTransition;
    public SpriteTransition speakerLTransition;
    public SpriteTransition speakerCLTransition;
    public SpriteTransition speakerCRTransition;
    public SpriteTransition speakerRTransition;

    public SpriteRenderer[] renderers;

    public Animator portraitAnimator;
    public Animator bgAnimator;

    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.Find("Map of Castelonia").GetComponent<Map>();
        map.setInvisible();
        textComponent.text = string.Empty;
        //get choices if there are choices
        choiceText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choiceText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
        dialogueVariables = new DialogueVariables();
        StartDialogue(inkFile);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && canAdvance == 1 && Time.timeScale != 0.0)
        {
            if (currentStory.currentChoices.Count == 0 && textComponent.text == currentLine)
            {
                continueStory();

            }

            else
            {

                foreach (SpriteRenderer r in renderers)
                {
                    if (r.sprite.name != "none")
                    {
                        Color tmp = r.color;
                        tmp.a = 1;
                        r.color = tmp;
                    }
                }

                StopAllCoroutines();
                textComponent.text = currentLine;
            }
        }
    }

    public void StartDialogue(TextAsset inkJSON)
    {
        dialoguePlaying = true;
        currentStory = new Story(inkJSON.text);
        dialogueVariables.StartListening(currentStory);
        continueStory();
    }

    void continueStory()
    {
        if (currentStory.canContinue)
        {
            textComponent.text = "";
            currentLine = currentStory.Continue();
            StartCoroutine(TypeLine());
            DisplayChoices();
            HandleTags(currentStory.currentTags);
            HandleTags(currentStory.currentTags);
        }
        else
        {
            endDialogue();
        }
    }

    private void HandleTags(List<string> tags)
    {
        foreach (string tag in tags)
        {
            string[] tagSplit = tag.Split(':');

            string key = tagSplit[0].Trim();
            string val = tagSplit[1].Trim();

            switch (key)
            {
                //Speakers
                case SPEAKER_TAG:
                    speakerAnimator.Play(val);
                    break;
                case SPEAKER_CENTER_TAG:
                    speakerAnimator.Play(val);
                    break;
                case SPEAKER_LEFT_TAG:
                    speakerLAnimator.Play(val);
                    break;
                case SPEAKER_C_LEFT_TAG:
                    speakerCLAnimator.Play(val);
                    break;
                case SPEAKER_C_RIGHT_TAG:
                    speakerCRAnimator.Play(val);
                    break;
                case SPEAKER_RIGHT_TAG:
                    speakerRAnimator.Play(val);
                    break;

                // Transitions
                case SPEAKER_TRANSITION_TAG:
                    StartCoroutine(speakerCTransition.FadeIn());
                    break;
                case SPEAKER_CENTER_TRANSITION_TAG:
                    StartCoroutine(speakerCTransition.FadeIn());
                    break;
                case SPEAKER_LEFT_TRANSITION_TAG:
                    StartCoroutine(speakerLTransition.FadeIn());
                    break;
                case SPEAKER_C_LEFT_TRANSITION_TAG:
                    StartCoroutine(speakerCLTransition.FadeIn());
                    break;
                case SPEAKER_C_RIGHT_TRANSITION_TAG:
                    StartCoroutine(speakerCRTransition.FadeIn());
                    break;
                case SPEAKER_RIGHT_TRANSITION_TAG:
                    StartCoroutine(speakerRTransition.FadeIn());
                    break;

                //Portrait
                case PORTRAIT_TAG:
                    portraitAnimator.Play(val);
                    break;

                //Format
                case FORMAT_TAG:
                    if (val == "italic")
                    {
                        textComponent.fontStyle = FontStyles.Italic;
                    }
                    else if (val == "bold")
                    {
                        textComponent.fontStyle = FontStyles.Bold;
                    }
                    else if (val == "none")
                    {
                        textComponent.fontStyle &= ~FontStyles.Bold;
                        textComponent.fontStyle &= ~FontStyles.Italic;
                    }
                    break;

                //Background and Map
                case BACKGROUND_TAG:
                    bgAnimator.Play(val);
                    break;
                case OPEN_MAP_TAG:
                    map.setVisible();
                    gameObject.SetActive(false);
                    break;
                default:
                    Debug.Log("Tag not handled");
                    break;
            }
        }
    }

    void endDialogue()
    {
        dialogueVariables.StopListening(currentStory);
        dialoguePlaying = false;
        textComponent.text = "";
        SceneManager.LoadScene(nextScene);
    }

    //Types each character out one by one
    //Line overhang fix from here https://www.youtube.com/watch?v=8PMhFpGmsBA&ab_channel=AllenDevs 
    IEnumerator TypeLine()
    {
        textComponent.text = "";
        int alphaIndex = 0;
        string originalText = currentLine;
        string displayedText = "";

        foreach (char c in currentLine.ToCharArray())
        {
            //string stringCheck = Char.ToString(c);

            //if (stringCheck == "*")
            //{
                
            //    Debug.Log("Markup");
            //}

            alphaIndex++;
            textComponent.text = originalText;
            displayedText = textComponent.text.Insert(alphaIndex, "<color=#00000000>");
            textComponent.text = displayedText;
            yield return new WaitForSeconds(textSpeed);
        }

        textComponent.text = currentLine;
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.Log("Too many choices in ink story");
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choiceText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].SetActive(false);
        }

    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        //currentStory.Continue();
        continueStory();
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

    public void setCanAdvance()
    {
        canAdvance *= -1;
    }

    public void returnFromMap()
    {
        continueStory();
    }
}