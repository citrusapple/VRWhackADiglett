using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour {
    public float VisibleHeight = 0.2f;
    public float HiddenHieght = -0.3f;
    public float speed = 2f;
    public float dissapearDuration = 2f;

    private Vector3 targetPosition;
    private float dissapearTimer = 0f;


	// Use this for initialization
	void Awake () {
        targetPosition = new Vector3(
            transform.localPosition.x,
            HiddenHieght,
            transform.localPosition.z
        );
        transform.localPosition = targetPosition;

    }

    //Update is called once per frame
    void Update()
    {
        dissapearTimer -= Time.deltaTime;
        if(dissapearTimer <= 0f)
        {
            Hide();
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime *speed);
    }
    public void Rise()
    {
        Debug.Log("Mole is rising");
        targetPosition = new Vector3(
            transform.localPosition.x,
            VisibleHeight,
            transform.localPosition.z
        );
        dissapearTimer = dissapearDuration;
    }
    public void Hide()
    {
        targetPosition = new Vector3(
            transform.localPosition.x,
            HiddenHieght,
            transform.localPosition.z
        );

    }
    public void OnHit ()
    {
        Hide();
    }
}
