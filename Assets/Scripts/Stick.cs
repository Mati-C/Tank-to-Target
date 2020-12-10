using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stick : MonoBehaviour, IDragHandler, IEndDragHandler  {

    public Vector3 startPosition;
    public static Vector2 stickValue;

	// Use this for initialization
	void Start () {
        startPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        stickValue = Vector2.ClampMagnitude(this.transform.position - startPosition, 100) / 100;
	}

    public void OnDrag(PointerEventData data)
    {
        this.transform.position = Vector3.ClampMagnitude((Vector3)data.position - startPosition, 100) + startPosition;
    }

    public void OnEndDrag(PointerEventData value)
    {
        this.transform.position = startPosition;
    }
}
