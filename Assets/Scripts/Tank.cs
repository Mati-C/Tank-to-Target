using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {

    public GameObject Rotor;
    public GameObject UpperBody;
    public GameObject Cannon;
    public GameObject lowerBody;
    public float speed;
    public float rSpeed;
    public static float life;
    public static int shootCount;
    public Vector3 bodyDirection;

    #region PHs
    public GameObject BulletPH;
    public GameObject ExposionPH;
    //public GameObject MagicPH;

    public GameObject VisualPH00;
    public GameObject VisualPH01;
    public GameObject VisualPH02;
    public GameObject VisualPH03;

    #endregion

    public GameObject PrefabBala;
    public GameObject PrefabExplosion;

    public GameObject Camera;
    public bool Cam00;
    public bool Cam01;
    public bool Cam02;
    public bool Cam03;

    public float timeToShoot;
    public float currentTimeToShoot;

    public static Vector3 TankPosition;

    // Use this for initialization
    void Awake()
    {
        #region PlacingCamera

        Camera.transform.position = VisualPH00.transform.position;
        Camera.transform.rotation = VisualPH00.transform.rotation;
        Cam00 = true;

        #endregion

    }
    void Start() {
        currentTimeToShoot = 99;
        life = 10;
        shootCount = 0;
    }

    // Update is called once per frame
    void Update() {

        print(life);

        if (Stick.stickValue != Vector2.zero)
        {
            bodyDirection = new Vector3(Stick.stickValue.x, 0, Stick.stickValue.y);
            lowerBody.transform.rotation = Quaternion.LookRotation(bodyDirection);
        }

        TankPosition = this.transform.position;
        currentTimeToShoot += Time.deltaTime;

        if (!Console.ConsoleOpen && !Main.isPaused && !LV3.isPaused)
        {
            this.transform.position += -(this.transform.right) * speed * Time.deltaTime * Stick.stickValue.y;
            this.transform.position += this.transform.forward * speed * Time.deltaTime * Stick.stickValue.x;
            //this.transform.Rotate(0, Stick.stickValue.x * Time.deltaTime * rSpeed, 0);

            if (Stick.stickValue == Vector2.zero)
            {
                Rotor.transform.Rotate(0, GetDirection(0).y * rSpeed * Time.deltaTime, 0);
                UpperBody.transform.Rotate(0, 0, GetDirection(0).x);
            } else
            {
                Rotor.transform.Rotate(0, GetDirection(1).y * rSpeed * Time.deltaTime, 0);
                UpperBody.transform.Rotate(0, 0, GetDirection(1).x);
            }



            Rotor.transform.localRotation = new Quaternion(Rotor.transform.localRotation.x,
                                               Mathf.Clamp(Rotor.transform.localRotation.y, -0.2f, 0.2f),
                                               Rotor.transform.localRotation.z,
                                               Rotor.transform.localRotation.w);

            if (Input.GetKeyDown(KeyCode.F8))
            {
                if (Cam00) ChangeVision01();
                else if (Cam01) ChangeVision02();
                else if (Cam02) ChangeVision03();
                else if (Cam03) ChangeVision00();
            }
        }
    }

	public void Shoot()
	{
        if (Console.unlimitedFireRate == true || currentTimeToShoot > timeToShoot)
        {
            shootCount++;
            currentTimeToShoot = 0;
            SoundManager.instancia.Play((int)SoundID.SHOOT, 1, false);

            if (Console.shotgunMode == true)
            {
                for (int i = 0; i < 14; i++)
                {
                    GameObject b = Instantiate(PrefabBala);
                    b.transform.position = BulletPH.transform.position;
                    b.transform.forward = BulletPH.transform.forward;

                    Quaternion bulletRotation = Quaternion.Euler(Random.Range(b.transform.eulerAngles.x - 15, b.transform.eulerAngles.x + 15), Random.Range(b.transform.eulerAngles.y - 15, b.transform.eulerAngles.y + 15), BulletPH.transform.rotation.z);
                    b.transform.rotation = bulletRotation;
                }
            }
            else
            {
                GameObject b = Instantiate(PrefabBala);
                b.transform.position = BulletPH.transform.position;
                b.transform.forward = Rotor.transform.forward;
                b.transform.rotation = BulletPH.transform.rotation;
            }

            GameObject E = Instantiate(PrefabExplosion);
            E.transform.position = ExposionPH.transform.position;
        }
    }

    public void OnTriggerEnter (Collider c)
    {
        if (c.gameObject.layer == 14)
        {
            life--;
            Achievements.flawless = false;
        }
    }

	#region Camera Position

	public void ChangeVision00()
	{

		Camera.transform.position = VisualPH00.transform.position;
		Camera.transform.rotation = VisualPH00.transform.rotation;

		Cam00 = true; Cam01 = false; Cam02 = false; Cam03 = false;
	}

	public void ChangeVision01()
	{

		Camera.transform.position = VisualPH01.transform.position;
		Camera.transform.rotation = VisualPH01.transform.rotation;

		Cam00 = false; Cam01 = true; Cam02 = false; Cam03 = false;
	}
	public void ChangeVision02()
	{

		Camera.transform.position = VisualPH02.transform.position;
		Camera.transform.rotation = VisualPH02.transform.rotation;

		Cam00 = false; Cam01 = false; Cam02 = true; Cam03 = false;
	}
	public void ChangeVision03()
	{

		Camera.transform.position = VisualPH03.transform.position;
		Camera.transform.rotation = VisualPH03.transform.rotation;

		Cam00 = false; Cam01 = false; Cam02 = false; Cam03 = true;
	}
	#endregion

    public bool GetTouch(int ID)
    {
        if (Input.touchCount > ID && (Input.GetTouch(ID).phase == TouchPhase.Began || Input.GetTouch(ID).phase == TouchPhase.Moved) || Input.GetMouseButton(ID))
            return true;
        else
            return false;
    }

    public bool GetTouchUp (int ID)
    {
        if (Input.touchCount > ID && Input.GetTouch(ID).phase == TouchPhase.Ended || Input.GetMouseButtonUp(ID))
            return true;
        else
            return false;
    }

    public Vector2 GetDirection (int ID)
    {
        if (GetTouch(ID))
            return Input.GetTouch(ID).deltaPosition / 2;
        else
            return Vector2.zero;
    }
}
