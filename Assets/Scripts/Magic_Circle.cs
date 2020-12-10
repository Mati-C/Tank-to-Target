using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Circle : MonoBehaviour {

    public Vector3 MaxScale =  new Vector3 (10, 0.005f, 10);

    public float Speed;
    public bool EnlargeDone = false;
    Vector3 torque = new Vector3 (0,1,0);
    float TorqueSpeed = 50;

    public float TimeON;
    // Use this for initialization
    void Start () {
        //Time.timeScale = 0.1f;
        this.transform.localScale = new Vector3(0.001f, 0.005f, 0.001f);
        
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.localScale.x < MaxScale.x && this.transform.localScale.z < MaxScale.z && EnlargeDone == false) Enlarge();
        else if (this.transform.localScale.x >= MaxScale.x && this.transform.localScale.z >= MaxScale.z || EnlargeDone) Shorten();

        if (this.transform.localScale.x < 1 && this.transform.localScale.z < 1 && EnlargeDone) Destroy(this.gameObject);

        TimeON += 1 * Time.deltaTime;
        print(TimeON);
    }
    public void FixedUpdate()
    {
        this.transform.position = Magic_Trigger.Magic_PH_Position;
    }

    public void Enlarge()
    {
        this.transform.localScale += new Vector3(0.01f, 0, 0.01f) * Time.deltaTime * Speed / 3;
        this.transform.Rotate (torque * TorqueSpeed * Time.deltaTime);
    }

    public void Shorten()
    {
        print("Se acooooorta");
        
        EnlargeDone = true;

        this.transform.localScale -= new Vector3(0.01f, 0, 0.01f) * Time.deltaTime * Speed * 2;
        this.transform.Rotate(-torque * TorqueSpeed * Time.deltaTime);


    }

}
