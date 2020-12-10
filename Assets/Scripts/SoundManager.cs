using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public static SoundManager instancia;
    public AudioClip[] sonidos;
    public AudioSource[] canales;

	void Awake () {
        instancia = this;
        canales = new AudioSource[sonidos.Length];

        for (int i = 0; i < sonidos.Length; i++)
        {
            canales[i] = gameObject.AddComponent<AudioSource>();
            canales[i].clip = sonidos[i];
        }
	}
	
	public void Play (int soundID, float volume, bool loop)
    {
        canales[soundID].Play();
        canales[soundID].volume = volume;
        canales[soundID].loop = loop;
	}

    public void Stop (int soundID)
    {
        if (!canales[soundID].isPlaying) return;
        canales[soundID].Stop();
    }

    public void Mute (int soundID, bool mute)
    {
        if (!canales[soundID].isPlaying) return;
        canales[soundID].mute = mute;
    }

    public void UnPause (int soundID)
    {
        canales[soundID].UnPause();
    }

    public void PauseAll ()
    {
        for (int i = 0; i < canales.Length; i++) canales[i].Pause();
    }

    public void UnPauseAll()
    {
        for (int i = 0; i < canales.Length; i++) canales[i].UnPause();
    }

    public void Button1 ()
    {
        Play((int)SoundID.BUTTON_1, 1, false);
    }

    public void Button2 ()
    {
        Play((int)SoundID.BUTTON_2, 1, false);
    }
}

public enum SoundID
{
    EXPLOSION,
    SHOOT,
    BUTTON_1,
    BUTTON_2,
    T_5,
    T_4,
    T_3,
    T_2,
    T_1,
    SLOWMO
}