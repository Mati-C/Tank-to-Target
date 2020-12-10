using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMadness : MonoBehaviour {

    public int Speed;
    public GameObject explosion;
    public bool TankBullet;
    public bool BossBullet;
    public Rigidbody rb;

    virtual public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    virtual public void Update()
    {

        rb.transform.position += -this.transform.right * Speed * Time.deltaTime;

    }
    public void OnTriggerEnter(Collider c)
    {
        #region Tank Bullet
        if (TankBullet)
        {
            if (c.gameObject.layer != 10)
            {
                Instantiate(explosion, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
            }
        }
        #endregion

        #region Boss Bullet
        if (BossBullet)
        {
            if (c.gameObject.layer != 14)
            {
                Instantiate(explosion, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
            }
        }
        #endregion
    }
}
