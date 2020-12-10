using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Boss {

    public GameObject boss2;

    public override void Start()
    {
        base.Start();
        allPHs = GameObject.FindGameObjectsWithTag("Boss 1 PHs");
        shootTimer = 2.5f;
    }

    public override void Update()
    {
        base.Update();
    }

    public override void GenerateDirection()
    {
        base.GenerateDirection();
    }

    public override void OnTriggerEnter(Collider c)
    {
        base.OnTriggerEnter(c);
        if (life <= 0)
        {
            boss2.transform.position = this.transform.position;
            boss2.SetActive(true);
        }
    }

    public override void OnTriggerStay(Collider c)
    {
        base.OnTriggerStay(c);
    }

    public override void OnTriggerExit(Collider c)
    {
        base.OnTriggerExit(c);
    }
}
