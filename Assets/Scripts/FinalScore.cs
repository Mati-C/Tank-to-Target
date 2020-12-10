using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

    public static float finalScore;
    public Text displayFinalScore;

	// Use this for initialization
	void Start () {
        displayFinalScore.text = "Final Score: " + finalScore + " seconds";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
