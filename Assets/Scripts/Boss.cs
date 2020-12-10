using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float Speed;
    public Vector3 NextPosition;
    float timer = 3;
    float currentTimer = 0;
    public BoxCollider movementArea;
    public bool isInsideArea;
    public float lerpValue;
    public bool returnFinished;
    public int life = 5;
    public static int totalLife;

    public GameObject[] allPHs;
    public GameObject prefabBullet;
    public float shootTimer;
    float currentShootTimer = 0;

    public Camera camera;

    virtual public void Start()
    {
        GenerateDirection();
        lerpValue = 0;
        isInsideArea = true;
        if (LV3.bossPhasesDestroyed == 0)
            totalLife = 5 + life;
        else
            totalLife = life;
    }

    virtual public void Update()
    {
        this.transform.LookAt(camera.transform);
        if (isInsideArea)
        {
            currentTimer += Time.deltaTime;
            if (currentTimer >= timer)
            {
                currentTimer = 0;
                GenerateDirection();
            }

            this.transform.position += NextPosition * Time.deltaTime * Speed;
        }
        else
        {
            lerpValue += 0.1f * Time.deltaTime * Speed;
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(0, 0, 0), lerpValue);
            if (lerpValue > 0.01f)
            {
                lerpValue = 0;
                returnFinished = true;
            }
        }

        currentShootTimer += Time.deltaTime;
        if (currentShootTimer >= shootTimer && prefabBullet != null && !LV3.isPaused)
        {
            GameObject b = Instantiate(prefabBullet);
            for (int i = 0; i < allPHs.Length; i++)
            {
                if (allPHs[i] != null && b != null)
                {
                    b.transform.position = allPHs[Random.Range(0, allPHs.Length)].transform.position;
                    currentShootTimer = 0;
                }
            }
        }
    }

    virtual public void GenerateDirection()
    {
        NextPosition.x = Random.Range(movementArea.bounds.min.x, movementArea.bounds.max.x);
        NextPosition.y = Random.Range(movementArea.bounds.min.y, movementArea.bounds.max.y);
        NextPosition.z = Random.Range(movementArea.bounds.min.z, movementArea.bounds.max.z);
    }

    virtual public void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.layer == 10)
            life--;

        if (life <= 0)
        {
            Destroy(this.gameObject);
            LV3.bossPhasesDestroyed++;
        }
    }

    virtual public void OnTriggerStay(Collider c)
    {
        if (returnFinished)
            isInsideArea = true;
    }

    virtual public void OnTriggerExit(Collider c)
    {
        isInsideArea = false;
        returnFinished = false;
    }
}
