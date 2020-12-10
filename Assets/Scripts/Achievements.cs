using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Achievements : MonoBehaviour {

    public static bool rambo;                  //0
    public static bool oneTankArmy;            //1
    public static bool flawless;               //2
    public static bool aRelaxingCupOfCoffee;   //3
    public static bool sharpShooter;           //4

    public GameObject[] allNotifs;
    public static GameObject[] allNotifications;

    float timer;
    public static float notifTimer;

    // Use this for initialization
    void Start ()
    {
            allNotifications = allNotifs;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            timer += Time.deltaTime;
            if (timer >= 60)
            {
                aRelaxingCupOfCoffee = true;
                AchievementNotification(3);
            }
        }
    }

    public static void AchievementNotification (int index)
    {
        notifTimer += Time.deltaTime;
        if (notifTimer <= 8)
            allNotifications[index].SetActive(true);
        else
            allNotifications[index].SetActive(false);

        switch (index)
        {
            case 0:
                rambo = true;
                break;
            case 1:
                oneTankArmy = true;
                break;
            case 2:
                flawless = true;
                break;
            case 3:
                aRelaxingCupOfCoffee = true;
                break;
            case 4:
                sharpShooter = true;
                break;
        }
    }
}
