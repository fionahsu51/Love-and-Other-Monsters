using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownMusic : MonoBehaviour
{
    public AudioSource townIntro;
    public AudioSource townLoop;
    // Start is called before the first frame update
    void Start()
    {
        playTownMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playTownMusic()
    {
        StartCoroutine(waitToPlayLoop());
        townIntro.Play();
    }

    IEnumerator waitToPlayLoop()
    {
        townLoop.loop = true;
        Debug.Log("play loop");
        yield return new WaitForSeconds(32.513f);
        townLoop.Play();
    }
}
