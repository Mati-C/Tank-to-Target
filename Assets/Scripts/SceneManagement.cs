using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour {

    public int currentScene;
    public float timeToChange;

    // Use this for initialization
    void Start() {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update() {
        if (currentScene == 5 && Ads.isReady)
        {
            timeToChange += Time.deltaTime;
            if (timeToChange >= 5)
                ChangeSceneTo(Main.currentScene);
        }
        if (currentScene == 6 && Ads.isReady)
        {
            timeToChange += Time.deltaTime;
            if (timeToChange >= 5)
                ChangeSceneTo(12);
        }
        if (currentScene == 8)
        {
            timeToChange += Time.deltaTime;
            if (timeToChange >= 5)
                if (Main.currentScene == 14)
                    ChangeSceneTo(9);
                else
                    ChangeSceneTo(Main.currentScene + 1);
        }
    }

    public void Intro ()
    {
        SoundManager.instancia.Play((int)SoundID.BUTTON_2, 1, false);
        AddChangeSceneTo(1);
    }

    public void ChangeSceneTo(int value)
    {
        Main.isPaused = false;
        LV3.isPaused = false;
        SceneManager.LoadScene(value);
    }

    public void AddChangeSceneTo (int value)
    {
        SceneManager.LoadScene(value, LoadSceneMode.Additive);
    }
    public void ResetLevel()
    {
        Main.isPaused = false;
        LV3.isPaused = false;
        if (currentScene == 12)
            SceneManager.LoadScene(currentScene);
        else
            SceneManager.LoadScene(Main.currentScene);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ResetAttempts()
    {
        Main.remainingAttempts = 2;
    }
}
