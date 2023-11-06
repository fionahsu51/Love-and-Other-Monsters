using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    string scene_name;
    public Canvas popup;
    // Start is called before the first frame update
    void Start()
    {
        popup.enabled = false;
        scene_name = PlayerPrefs.GetString("currentScene");
        Debug.Log(scene_name);
    }

    public void OnButtonPress()
    {
        
        if (scene_name == "" || scene_name == "TitleScreen" || scene_name == "PrologueFlashback")
        {
            SceneManager.LoadScene("PrologueFlashback");
        }

        else
        {
            popup.enabled = true;
        }
    }

    public void OnYesButtonPress()
    {
        SceneManager.LoadScene(scene_name);
    }

    public void OnNoButtonPress()
    {
        SceneManager.LoadScene("PrologueFlashback");
    }
}
