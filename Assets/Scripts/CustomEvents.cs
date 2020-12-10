using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class CustomEvents : MonoBehaviour {

    public static void Fail()
    {
        if (Main.currentScene == 10)
        {
            Analytics.CustomEvent("Level 1 Failed", new Dictionary<string, object>
            {{"Targets Remaining", Main.remainingTargets.Length}});
            print("1 Failure OK!");
        }

        if (Main.currentScene == 11)
        {
            Analytics.CustomEvent("Level 2 Failed", new Dictionary<string, object>
            {{"Targets Remaining", Main.remainingTargets.Length}});
            print("2 Failure OK!");
        }

        if (Main.currentScene == 14)
        {
            Analytics.CustomEvent("Level Madness Failed", new Dictionary<string, object>
            {{"Targets Remaining", Main.remainingTargets.Length}});
            print("Madness Failure OK!");
        }

        Analytics.FlushEvents();
    }


    public static void Complete()
    {
        if (Main.currentScene == 10)
        {
            Analytics.CustomEvent("Level 1 Completed", new Dictionary<string, object>
                {
                    {"Time Remaining", Main.remainingTime},
                    {"Shots Fired", Tank.shootCount},
                    {"Attempts Remaining", Main.remainingAttempts}
                });
            print("1 Completion OK!");
        }

        if (Main.currentScene == 11)
        {
            Analytics.CustomEvent("Level 2 Completed", new Dictionary<string, object>
                {
                    {"Time Remaining", Main.remainingTime},
                    {"Shots Fired", Tank.shootCount},
                    {"Attempts Remaining", Main.remainingAttempts}
                });
            print("2 Completion OK!");
        }

        if (Main.currentScene == 14)
        {
            Analytics.CustomEvent("Level Madness Completed", new Dictionary<string, object>
                {
                    {"Time Remaining", Main.remainingTime},
                    {"Shots Fired", Tank.shootCount}
                });
            print("Madness Completion OK!");
        }

        Analytics.FlushEvents();
    }

    public static void GameCompleted()
    {
        Analytics.CustomEvent("Game Completed", new Dictionary<string, object>
            {
                {"Final Score", FinalScore.finalScore},
                {"Shots Fired", Tank.shootCount},
                {"Attempts Remaining", Main.remainingAttempts}
            });
        print("Game Completion OK!");

        Analytics.FlushEvents();
    }

    public static void BossFail()
    {
        Analytics.CustomEvent("Level 3 Failed", new Dictionary<string, object>
        {{ "Remaining Boss Life", Boss.totalLife }});
        print("Game Failure OK!");

        Analytics.FlushEvents();
    }
}
