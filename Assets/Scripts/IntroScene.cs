using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScene : MonoBehaviour {

    public GameObject PressEnter;

    public bool ShowCommand;
    public float MaxTimer = 0.4f;
    public float Timer;

    void Start () {
        StartCoroutine(Video());
        Timer = MaxTimer;
        ShowCommand = true;
        Achievements.rambo = false;
        Achievements.oneTankArmy = false;
        Achievements.flawless = false;
        Achievements.aRelaxingCupOfCoffee = false;
        Achievements.sharpShooter = false;
	}

	void Update () {
        Timer -= Time.deltaTime;
        
        if (Timer <= 0)
        {
            Timer = MaxTimer;
            ShowCommand = !ShowCommand;
        }
        PressEnter.SetActive(ShowCommand);

    }

    protected IEnumerator Video ()
    {
        Handheld.PlayFullScreenMovie("intro.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
        yield return new WaitForSeconds(2);
    }
}
