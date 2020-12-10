using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour {

    public static GameObject skipMessage;
    public static GameObject finishMessage;
    public static bool isReady;

	void Start () {
        Advertisement.Initialize("1454152", true);
        skipMessage = GameObject.Find("You Monster!");
        skipMessage.SetActive(false);
        finishMessage = GameObject.Find("Thanks!");
        finishMessage.SetActive(false);
        StartCoroutine(Ad());
	}

    void Update () {
        isReady = !Advertisement.isShowing;
    }

    public static IEnumerator Ad ()
    {
        while (!Advertisement.IsReady())
            yield return new WaitForEndOfFrame();

        var options = new ShowOptions { resultCallback = AdResult };
        Advertisement.Show(options);
    }

    public static void AdResult(ShowResult result)
    {
        if (result == ShowResult.Skipped)
            skipMessage.SetActive(true);
        if (result == ShowResult.Finished)
        {
            finishMessage.SetActive(true);
            Main.remainingAttempts++;
        }
    }
}
