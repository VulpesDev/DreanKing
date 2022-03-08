using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLinesWayne : MonoBehaviour
{
    // line [0,4] - tutorial
    int lineCount = 0;
    AudioSource asource;
    public AudioClip[] clipsDir;
    void Start()
    {
        asource = GetComponent<AudioSource>();
        lineCount = 0;
        StartCoroutine(CheckSentences());
    }

    IEnumerator CheckSentences()
    {
        float distance = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position);
        if(!asource.isPlaying && lineCount < clipsDir.Length && distance < 7f)
        {
            if (lineCount >= 0 && lineCount <= 4)
            {
                StartCoroutine(PlayLine());
            }
            else if (Zone.maxZoneID >= 6 && lineCount <= 5)
            {
                StartCoroutine(PlayLine());
            }
            else if (Zone.maxZoneID >= 6 && lineCount <= 6)
            {
                StartCoroutine(PlayLine());
            }
            else if (Zone.maxZoneID >= 8 && lineCount <= 7)
            {
                StartCoroutine(PlayLine());
            }
            else if (Zone.maxZoneID >= 8 && lineCount <= 8)
            {
                StartCoroutine(PlayLine());
            }
        }
        yield return new WaitForSeconds(1.1f);
        yield return new WaitForFixedUpdate();
        StartCoroutine(CheckSentences());
    }
    IEnumerator PlayLine()
    {
        asource.clip = clipsDir[lineCount];
        yield return new WaitForSeconds(1f);
        asource.Play();
        lineCount++;
    }
}

