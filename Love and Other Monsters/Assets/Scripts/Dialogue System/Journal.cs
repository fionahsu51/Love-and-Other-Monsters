using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Journal : MonoBehaviour
{
    public Animator journalAnimator;
    public GameObject tabs;
    public GameObject affinityPage;
    public GameObject settingsPage;
    public Button [] tabList;
    bool open;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && open==false && Time.timeScale == 0){
            open = true;
            openAffinities();
            tabs.GetComponent<CanvasGroup>().interactable = true;
            tabs.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    public void openAffinities()
    {
        Debug.Log("open affinities");
        journalAnimator.Play("affinities");
        affinityPage.GetComponent<CanvasGroup>().alpha = 1;
        affinityPage.GetComponent<CanvasGroup>().interactable = true;
        affinityPage.GetComponent<CanvasGroup>().blocksRaycasts = true;

        //set all other pages to uninteractable
        settingsPage.GetComponent<CanvasGroup>().alpha = 0;
        settingsPage.GetComponent<CanvasGroup>().interactable = false;
        settingsPage.GetComponent<CanvasGroup>().blocksRaycasts = false;

        for(int i = 0; i < 3; i++){
            Vector2 pos = tabList[i].GetComponent<RectTransform>().anchoredPosition;
            tabList[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(1465f, pos.y);
            tabList[i].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    public void openSettings()
    {
        Debug.Log("open settings");
        journalAnimator.Play("settings");

        //set this page to interactable
        settingsPage.GetComponent<CanvasGroup>().alpha = 1;
        settingsPage.GetComponent<CanvasGroup>().interactable = true;
        settingsPage.GetComponent<CanvasGroup>().blocksRaycasts = true;

        //set all other pages to uninteractable
        affinityPage.GetComponent<CanvasGroup>().alpha = 0;
        affinityPage.GetComponent<CanvasGroup>().interactable = false;
        affinityPage.GetComponent<CanvasGroup>().blocksRaycasts = false;
        
        for(int i = 0; i < 3; i++){
            Vector2 pos = tabList[i].GetComponent<RectTransform>().anchoredPosition;
            tabList[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-1465, pos.y);
            tabList[i].GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 1);
        }

    }

}
