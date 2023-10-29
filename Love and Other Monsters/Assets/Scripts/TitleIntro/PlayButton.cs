using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    string scene_name;

    // Start is called before the first frame update
    void Start()
    {
        scene_name = PlayerPrefs.GetString("currentScene");
        Debug.Log(scene_name);
    }

    public void OnButtonPress()
    {
        if (scene_name == "" || scene_name == "TitleScreen")
        {
            SceneManager.LoadScene("PrologueFlashback");
        }

        else
        {
            SceneManager.LoadScene(scene_name);
        }
    }
}
