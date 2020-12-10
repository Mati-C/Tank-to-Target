using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : Boss {

    public override void Start()
    {
        base.Start();
        allPHs = GameObject.FindGameObjectsWithTag("Boss 2 PHs");
        shootTimer = 1.5f;
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
