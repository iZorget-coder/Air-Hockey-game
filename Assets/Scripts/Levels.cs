using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource[] sources;
    public Slider slideMain, slideMusic;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < sources.Length; i++)
        {
            sources[i].volume = slideMain.value;


        }
        sources[4].volume = slideMusic.value;


    }
}
