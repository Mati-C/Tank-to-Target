using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingBossLife : MonoBehaviour {

    public Text bossLife;

	void Start () {
        bossLife.text = "The Boss only had " + Boss.totalLife + " HP left!";
    }
}
