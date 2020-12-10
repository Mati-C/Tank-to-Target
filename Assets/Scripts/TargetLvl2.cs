using UnityEngine;
using System.Collections;

public class TargetLvl2 : MonoBehaviour
{

    float Timer = 0;
    Vector3 ThisPos = new Vector3(0, 0, 0);

    public Vector3 vOscilation;
    public Vector3 vMovement;

    public int Dice;
    public bool frontOsc;
    public bool verticalOsc;
    public bool horizontalOsc;
    // Use this for initialization
    void Start()
    {
        ThisPos = transform.position;
        Dice = Random.Range(1, 4);

        if (Dice == 1)
        {
            frontOsc = true;
            verticalOsc = false;
            horizontalOsc = true;
        }
        else if (Dice == 2)
        {
            frontOsc = false;
            verticalOsc = true;
            horizontalOsc = false;
        }
        else if (Dice == 3)
        {
            frontOsc = false;
            verticalOsc = false;
            horizontalOsc = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ThisPos = transform.position;

        Timer += Time.deltaTime;
        if (frontOsc) vOscilation = new Vector3(Mathf.Sin(Timer), 0, 0);
        else if (verticalOsc) vOscilation = new Vector3(0, Mathf.Sin(Timer), 0);
        else if (horizontalOsc) vOscilation = new Vector3(0, 0, Mathf.Sin(Timer));

        transform.position += (vOscilation * 2) * Time.deltaTime;

        if (ThisPos.x < 130)
        {
            vMovement = new Vector3(1, 0, 0);
            transform.position += (vMovement / 2) * Time.deltaTime;
        }
        else return;

        Debug.DrawLine(ThisPos, transform.position, Color.magenta, 100);
    }
}
