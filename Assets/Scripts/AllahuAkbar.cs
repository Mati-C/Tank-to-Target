using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AllahuAkbar : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Video());
    }

    protected IEnumerator Video()
    {
        Handheld.PlayFullScreenMovie("Allahu Akbar.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
        SceneManager.LoadScene(5);
        yield return new WaitForSeconds(1);
    }
}
