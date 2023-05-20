using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingNewScene : MonoBehaviour
{
    public int SceneIndex;
    public AudioSource carriageSFX;

    // Start is called before the first frame update
    void Start()
    {
        carriageSFX.Play();
        StartCoroutine(AudioBuffer());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator AudioBuffer()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneIndex);
    }
}