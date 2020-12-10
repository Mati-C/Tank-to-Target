using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementChecker : MonoBehaviour {

    public GameObject completed;
    public bool achieved;

	// Use this for initialization
	void Start () {
        if (gameObject.name == "Rambo") achieved = Achievements.rambo;
        if (gameObject.name == "One Tank Army") achieved = Achievements.oneTankArmy;
        if (gameObject.name == "Flawless") achieved = Achievements.flawless;
        if (gameObject.name == "A Relaxing Cup of Coffee") achieved = Achievements.aRelaxingCupOfCoffee;
        if (gameObject.name == "Sharpshooter") achieved = Achievements.sharpShooter;
    }
	
	// Update is called once per frame
	void Update () {
        completed.SetActive(achieved);
	}
}
