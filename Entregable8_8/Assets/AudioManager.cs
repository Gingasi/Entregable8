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
   




    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

    }

    public void Play() //Decimos que si no est� pausado se empiece de cero la canci�n y que s� est� pausado, la canci�n continue. 
    {
        if (!audioispaused)
        {
            source.PlayOneShot(Audios[CurrentSong]);
            Canciones[CurrentSong].SetActive(true);
        }
        else
        {
            source.UnPause();
        }

    }

    public void Pause()
    {
        source.Pause();
        audioispaused = true;
    }

    public void Next()

    {
        source.Stop(); //Paramos la canci�n.
        Canciones[CurrentSong].SetActive(false); //Desactivamos el game object con el texto y la imagen de la canci�n actual. 
        CurrentSong++;//Sumamos a la canci�n actual para pasar a la siguiente. 

        if (CurrentSong >= 6) //Indicamos que si llega a la �ltima canci�n repita la primera. 
        {
            CurrentSong = 0;
        }

        source.PlayOneShot(Audios[CurrentSong]);
        Canciones[CurrentSong].SetActive(true);
    }

    public void Preview() //Hacemos lo mismo que en Next() pero a la inversa para poder ir hacia atr�s.
    {
        source.Stop();
        Canciones[CurrentSong].SetActive(false);
        CurrentSong--;

        if (CurrentSong <= -1)
        {
            CurrentSong = 5;
        }

        source.PlayOneShot(Audios[CurrentSong]);
        Canciones[CurrentSong].SetActive(true);
    }

    public void Shuffle()
    {
        Canciones[CurrentSong].SetActive(false);
        CurrentSong = Random.Range(0, 5); //Que se reproduzca de forma random entre el track 1 y el 6.
        CurrentSong++;
        source.PlayOneShot(Audios[CurrentSong]);
        Canciones[CurrentSong].SetActive(true);
    }

    public void Repeat()
    {
        source.loop = true; //Activamos el loop de la canci�n actual. 
    }
}
