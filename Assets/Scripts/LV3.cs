using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LV3 : MonoBehaviour {

    public static float currentTime = 0;
    public Text displayRemainingAttempts;
    public Text displayCurrentTime;
    public static int bossPhasesDestroyed;
    public Image lifeMeter;
    public GameObject pauseMenu;
    public static bool isPaused;
    public GameObject explosion;
    float endTimer = 0;
    public GameObject boss;
    Vector3 bossPosition;
    Quaternion bossRotation;
    public static bool victory = false;
    public GameObject audioContainer;
    AudioSource audio;
    public static bool checkpointLv3Reached;
    public GameObject rambo;
    public GameObject flawless;
    public GameObject sharpShooter;

    public static int currentScene;

    // Use this for initialization
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        bossPhasesDestroyed = 0;
        audio = audioContainer.GetComponent<AudioSource>();
        if (checkpointLv3Reached && CheckpointManager.checkpointActive)
            Destroy(boss);
    }

    // Update is called once per frame
    void Update()
    {
        FinalScore.finalScore = Mathf.Round(currentTime * 100) / 100;

        if (bossPhasesDestroyed != 2 && boss != null)
        {
            bossPosition = boss.transform.position;
            bossRotation = boss.transform.rotation;
        }

        if (Console.slowMo && !Console.ConsoleOpen)
            Time.timeScale *= 0.25f;
        if (Console.fastmo && !Console.ConsoleOpen)
            Time.timeScale *= 3;

        if (Input.GetKeyDown(KeyCode.Escape))
            PauseMenu();
        if (pauseMenu.gameObject.activeSelf)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

        if (!victory)
            currentTime += Time.deltaTime;
        displayCurrentTime.text = "Current Time: " + (Mathf.Round(currentTime * 100 ) / 100).ToString();
        lifeMeter.fillAmount = Tank.life / 10;

        if (Console.unlimitedAttempts == true)
            displayRemainingAttempts.text = "Spare Tanks: ∞";
        else
            displayRemainingAttempts.text = "Spare Tanks: " + Main.remainingAttempts.ToString();

        if (Tank.life <= 0)
        {
            CustomEvents.BossFail();
            Main.Fail();
        }

        if (bossPhasesDestroyed == 2)
        {
            if (!victory)
            {
                Vector3 achievementSpace = new Vector3(0, -400, 0);

                Achievements.AchievementNotification(1);

                if (Tank.life == 1)
                    Achievements.AchievementNotification(0);

                if (!Main.flawlessFailed && Tank.life >= 10)
                    Achievements.AchievementNotification(2);

                if (40 / Tank.shootCount >= 0.75f)
                    Achievements.AchievementNotification(4);

                CustomEvents.GameCompleted();
                victory = true;
                Instantiate(explosion, bossPosition, bossRotation);
                SoundManager.instancia.PauseAll();
                SoundManager.instancia.Play((int)SoundID.SLOWMO, 1, false);
                audio.mute = true;

        }
        if (victory)
        {
            Time.timeScale = 0.2f;
            endTimer += Time.deltaTime;
        }

        if (endTimer >= 1)
            SceneManager.LoadScene(13);
        }
}

    public void PauseMenu ()
    {
        pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);
        isPaused = pauseMenu.gameObject.activeSelf;
    }
}
