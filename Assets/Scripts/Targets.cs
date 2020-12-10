using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour {
    public float life;

	// Use this for initialization
	void Start () {
        life = 1;
        this.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
    }
	
	// Update is called once per frame
	void Update () {
        if (life <= 0)
        {
            Main.destroyedTargets++;
            Destroy(this.gameObject);
        }
        if (this.transform.localScale.x < 0.1f)
            this.transform.localScale += new Vector3(0.08f, 0.08f, 0.08f) * Time.deltaTime;
    }

    public void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.layer == 9)
            life -= 5;
        if (c.gameObject.layer == 10)
            life--;
    }
}
