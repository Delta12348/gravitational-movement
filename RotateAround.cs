using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public Transform pivot;
    public double period;
    public double speedScale;

    public int counter = -1;

    public double gravitationalSpeed;
    public double tangencialSpeed;
    private double currentSpeed;
    private double acceleration;

    public Vector3 attractionVector;
    public Vector3 tangencialVector;
    public Vector3 currentVector;

    private UniversalAttractionBehaviour attraction;

    private void Start()
    {
        attraction = GameObject.FindGameObjectWithTag("GameController").GetComponent<UniversalAttractionBehaviour>();
        gravitationalSpeed = attraction.gravitationalSpeed / speedScale;
        tangencialSpeed = attraction.gravitationalSpeed / speedScale;
        acceleration = attraction.gravitationalAcceleration / speedScale;

        currentSpeed = 0;
    }
    // Update is called once per frame
    void Update()
    {
        CentripetalMovement();

    }
    private void OnTriggerEnter(Collider other)
    {
        counter++;
    }
    private void CentripetalMovement()
    {
        this.transform.LookAt(pivot);
        this.transform.Translate((float)tangencialSpeed * new Vector3(1, 0, 0)* Time.deltaTime);
    }
    private void Rotate()
    {
        this.transform.RotateAround(pivot.position, Vector3.up, ((Mathf.PI * 2) / (float)(period / 10000)) * Mathf.Rad2Deg);
    }
}
