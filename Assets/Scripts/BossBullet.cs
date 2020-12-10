using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : Proyectile {

    public GameObject CylinderI;
    public GameObject CylinderII;
    public GameObject CylinderIII;
    public float RotationValue;

    public GameObject tank;

    public override void Start()
    {
        base.Start();
        //Instantiate(InitialExplosion);

        //InitialExplosion.transform.position = this.transform.position;
        tank = GameObject.FindGameObjectWithTag("Player");
        this.transform.LookAt(tank.transform);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        CylinderI.transform.Rotate(0, RotationValue * Time.deltaTime, 0);
        CylinderII.transform.Rotate(0, 0, RotationValue * Time.deltaTime);
        CylinderIII.transform.Rotate(0, 0, RotationValue * Time.deltaTime);
        rb.velocity += rb.transform.forward * Speed * Time.deltaTime;

    }
}
