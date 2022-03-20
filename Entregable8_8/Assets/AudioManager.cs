using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] Audios;
    public GameObject[] Canciones;
    private AudioSource source;
    public bool audioispaused = false;
    private int CurrentSong;
    private bool SongisShuffled = false;
    
  


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        
    }

     public void Play()
    {
        if(!audioispaused)
        {
            source.PlayOneShot(Audios[0]);
            Canciones[0].SetActive(true);
        }
        else
        {
            source.UnPause();
        }
        
    }

    public  void Pause()
    {
      source.Pause();
      audioispaused = true;
    }

    public void Next()

    {
        if(SongisShuffled = true)
        {
            Shuffle();
            source.Stop();
            Canciones[CurrentSong].SetActive(false);
            source.PlayOneShot(Audios[CurrentSong + 1]);
            Canciones[CurrentSong + 1].SetActive(true);
        }
        else
        {
            source.Stop();
            Canciones[CurrentSong].SetActive(false);
            source.PlayOneShot(Audios[+1]);
            Canciones[+1].SetActive(true);
        }
  
       
    }

    public void Preview()
    {
        source.Stop();
        source.PlayOneShot(Audios[CurrentSong - 1]);
        Canciones[CurrentSong].SetActive(false);
        Canciones[CurrentSong - 1].SetActive(true);
    }

    public  void Shuffle()
    {
        CurrentSong = Random.Range(0, 5);
        SongisShuffled = true;

    }

    public  void Repeat()
    {

    }

}
