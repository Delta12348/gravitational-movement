using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public Transform pivot;
    public double period;
    public double speedScale;

    public int counter;

    public bool tancencialInitialSpeed;
    public double initialSpeed; 

    public Vector3 attractionVector;
    public Vector3 tangencialVector;
    public Vector3 currentVector;

    public float m_Timer;

    private UniversalAttractionBehaviour attraction;

    private void Start()
    {
        m_Timer = 0;
        attraction = GameObject.FindGameObjectWithTag("GameController").GetComponent<UniversalAttractionBehaviour>();
        CheckIfTangencialSpeed();
        Debug.Log(initialSpeed);
        tangencialVector = Vector3.right * ((float)initialSpeed / (float)speedScale);
    }
    // Update is called once per frame
    void Update()
    {
        GravitationalMovement();
        UpdateTimer();
    }
    private void OnTriggerEnter(Collider other)
    {
        counter++;
        if (counter > 0) period = m_Timer / speedScale * attraction.objectScale / 86400;
        RestartTimer();
    }
    private void GravitationalMovement()
    {
        transform.LookAt(pivot);
        currentVector = tangencialVector + attractionVector;
        transform.Translate(currentVector  * Time.deltaTime);
        tangencialVector = currentVector;
        UpdateCurrentDistance();
    }
    private void Rotate()
    {
        this.transform.RotateAround(pivot.position, Vector3.up, ((Mathf.PI * 2) / (float)(period / 10000)) * Mathf.Rad2Deg);
    }
    private void CheckIfTangencialSpeed()
    {
        if (tancencialInitialSpeed) initialSpeed = attraction.CalculateGravitationalSpeed();
    }
    private void UpdateCurrentDistance()
    {
        attraction.currentDistance = Vector3.Distance(this.transform.position, pivot.position) * attraction.objectScale;
    }
    private void RestartTimer()
    {
        m_Timer = 0;
    }
    private void UpdateTimer()
    {
        m_Timer += Time.deltaTime;
    }
}
