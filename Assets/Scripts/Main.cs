using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

    public static int remainingAttempts = 2;
    public static float remainingTime;
    public static GameObject[] remainingTargets;
    public Text displayRemainingAttempts;
    public Text displayRemainingTime;
    public Text displayRemainingTargets;
    public static int destroyedTargets;
    public GameObject pauseMenu;
    public static bool isPaused;
    public GameObject completeMenu;
    public GameObject video;
    public static bool playVideo;
    public static bool failed;
    public static AudioSource audio;
    public static bool checkpointLv1Reached;
    public static bool checkpointLv2Reached;
    public static bool flawlessFailed;

    public bool canSpawn;
    public GameObject spawnBox;
    public BoxCollider spawnArea;
    public Vector3 targetPosition;
    public float spawnCooldown;
    public float currentSpawnCooldown;
    public GameObject prefabTarget;
    public Transform[] targetChild;
    public Camera camera;
    public int maxTargetAmount;

    public static int currentScene;

	// Use this for initialization
	void Start () {
        spawnArea = spawnBox.GetComponent<BoxCollider>();
        currentSpawnCooldown = 0;
        destroyedTargets = 0;
        canSpawn = true;
        currentScene = SceneManager.GetActiveScene().buildIndex;
        playVideo = false;
        failed = false;
        audio = GetComponent<AudioSource>();

        if (currentScene == 10)
        {
            if (checkpointLv1Reached && CheckpointManager.checkpointActive)
            {
                remainingTime = 40;
                maxTargetAmount = 5;
            } else
            {
                remainingTime = 60;
                maxTargetAmount = 10;
            }
        }

        if (currentScene == 11)
        {
            if (checkpointLv2Reached && CheckpointManager.checkpointActive)
            {
                remainingTime = 60;
                maxTargetAmount = 10;
            }
            else
            {
                remainingTime = 100;
                maxTargetAmount = 20;
            }

        }

        if (currentScene == 14)
        {
            remainingTime = 120;
            maxTargetAmount = 50;
            Console.unlimitedAttempts = true;
        }

        SetPosition();
        GameObject t = Instantiate(prefabTarget);
        t.transform.position = targetPosition;
        currentSpawnCooldown = 0;
    }
	
	// Update is called once per frame
	void Update () {
        video.SetActive(playVideo);

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

        currentSpawnCooldown += Time.deltaTime;
        if (!completeMenu.activeSelf) remainingTime -= Time.deltaTime * Time.timeScale;
        displayRemainingTime.text = "Time Remaining: " + (Mathf.Round(remainingTime * 100) / 100).ToString();

        remainingTargets = GameObject.FindGameObjectsWithTag("Target");
        displayRemainingTargets.text = "Targets Remaining: " + remainingTargets.Length.ToString();

        if (Console.unlimitedAttempts == true)
            displayRemainingAttempts.text = "Spare Tanks: ∞";
        else
            displayRemainingAttempts.text = "Spare Tanks: " + remainingAttempts.ToString();

        if (remainingTime <= 0)
            Fail();

        if (currentSpawnCooldown >= spawnCooldown && remainingTargets.Length < maxTargetAmount && canSpawn)
        {
            SetPosition();
            GameObject t = Instantiate(prefabTarget);
            t.transform.position = targetPosition;
            currentSpawnCooldown = 0;
        } else
            if (remainingTargets.Length + destroyedTargets >= maxTargetAmount)
              canSpawn = false;

        remainingTargets = GameObject.FindGameObjectsWithTag("Target");
        targetChild = new Transform[remainingTargets.Length];

        for (int i = 0; i < remainingTargets.Length; i++)
        {
            targetChild[i] = remainingTargets[i].transform.Find("Diana Visible");
            targetChild[i].LookAt(camera.transform);
        }

        if (destroyedTargets >= maxTargetAmount)
            if (!completeMenu.activeSelf)
            {
                CustomEvents.Complete();
                completeMenu.SetActive(true);
            }

        if (destroyedTargets >= maxTargetAmount / 2 && CheckpointManager.checkpointActive)
        {
            if (currentScene == 10)
                checkpointLv1Reached = true;
            if (currentScene == 11)
                checkpointLv2Reached = true;
        }


        if (remainingTime <= 6 && remainingTime > 5)
            SoundManager.instancia.Play((int)SoundID.T_5, 1, false);
        if (remainingTime <= 5 && remainingTime > 4)
            SoundManager.instancia.Play((int)SoundID.T_4, 1, false);
        if (remainingTime <= 4 && remainingTime > 3)
            SoundManager.instancia.Play((int)SoundID.T_3, 1, false);
        if (remainingTime <= 3 && remainingTime > 2)
            SoundManager.instancia.Play((int)SoundID.T_2, 1, false);
        if (remainingTime <= 2 && remainingTime > 1)
            SoundManager.instancia.Play((int)SoundID.T_1, 1, false);
    }

    public void SetPosition ()
    {
        targetPosition.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
        targetPosition.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
        targetPosition.z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);
    }

    public void Completed()
    {
        SceneManager.LoadScene(8);
    }

    public void PauseMenu()
    {
        pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);
        isPaused = pauseMenu.gameObject.activeSelf;
    }

    public static void Fail ()
    {
        if (failed == false)
        {
            flawlessFailed = true;
            failed = true;
            if (!Console.unlimitedAttempts)
                remainingAttempts--;

            if (remainingAttempts < 0)
                SceneManager.LoadScene(7);
            else
            {
                if (SceneManager.GetActiveScene().buildIndex == 12)
                    SceneManager.LoadScene(6);
                else
                {
                    if (!Console.allahuAkbar)
                    {
                        SceneManager.LoadScene(5);
                        CustomEvents.Fail();
                    }
                    else
                    {
                        audio.Stop();
                        SoundManager.instancia.PauseAll();
                        playVideo = true;
                    }
                }
            }
        }           
    }
}
