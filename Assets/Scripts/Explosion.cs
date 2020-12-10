using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float timer;
    public float currentTimer;
    public GameObject tank;
    public float loudness;

	// Use this for initialization
	void Start () {
        tank = GameObject.Find("Tank 00");
        currentTimer = 0;
        if (Vector3.Distance(this.transform.position, tank.transform.position) < 1)
            loudness = 1;
        else
            loudness = 10 / Vector3.Distance(this.transform.position, tank.transform.position);
        SoundManager.instancia.Play((int)SoundID.EXPLOSION, loudness, false);
	}
	
	// Update is called once per frame
	void Update () {
        currentTimer += Time.deltaTime * Time.timeScale;

        if (currentTimer >= timer)
            Destroy(this.gameObject);
	}
}
