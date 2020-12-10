using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ducky : MonoBehaviour {

    public int force;
    public Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(this.transform.forward * force);
    }
}
