using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (GetComponent<AudioSource>().isPlaying == true)
            {
                GetComponent<AudioSource>().Stop();
            }
            else
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
