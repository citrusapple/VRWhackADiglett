using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokeball : MonoBehaviour
{
    private Vector3 initialPosition;

    // Use this for initialization
    void Start()
    {
        initialPosition = transform.position;
    }

    public void Hit(Vector3 targetPosition)
    {
        Debug.Log("Hit on pokeball is executed");
        transform.position = targetPosition;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime);
    }
}
