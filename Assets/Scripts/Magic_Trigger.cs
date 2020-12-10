using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Trigger : MonoBehaviour {

    public GameObject Prefab_Magic_Circle;
    public static bool Explosion_Magic = false;
    public bool CanExplode = true;

    public float Clock;
    public int Min_Time_Limit = 9;

	public static Vector3 Magic_PH_Position;
	public bool canUseMagic;
	// Update is called once per frame
    void Awake()
    {
        Clock = 0;



    }
	void Update () {
		//canUseMagic = Console.canUseMagic;

		if (Input.GetMouseButtonDown(2) && CanExplode && canUseMagic == true)
        {
            CanExplode = false;

            Explosion_Magic = true;

            GameObject M = Instantiate(Prefab_Magic_Circle);

            M.transform.position = this.transform.position;
        }


        if (Explosion_Magic)
        {
            Clock += Time.deltaTime;
            if (Clock > Min_Time_Limit)
            {
                Explosion_Magic = false;
                Clock = 0;
                CanExplode = true;
            }
                
        }

	}
    void FixedUpdate()
    {
        Magic_PH_Position = this.transform.position;
    }
}
