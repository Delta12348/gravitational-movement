using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class UniversalAttractionBehaviour : MonoBehaviour
{
    public SpaceObjectBehaviour bigObject;
    public Transform bigModel;

    public SpaceObjectBehaviour smallObject;
    public Transform smallModel;

    public double objectScale;

    public double initialDistance;
    public double currentDistance;

    public double gravitationalConstant = 6.667E-11;

    public double gravitationalAcceleration;
 
    private Transform trigger;
    private SphereCollider triggerCollider;
    // Start is called before the first frame update
    void Start()
    {
        trigger = GameObject.FindGameObjectWithTag("Trigger").transform;
        triggerCollider = trigger.GetComponent<SphereCollider>();
        triggerCollider.radius = (float)smallObject.radius / (float)objectScale;
        currentDistance = initialDistance + bigObject.radius + smallObject.radius;
        SimulateInitialDistance();
    }

    // Update is called once per frame
    void Update()
    {
        gravitationalAcceleration = CalculateGravitationaAcceleration();
    }

    private void SimulateInitialDistance()
    {
        float simulatedDistance = ((float)currentDistance / (float)objectScale);
        smallModel.position = new Vector3(simulatedDistance, 0, 0);
        trigger.position = new Vector3(simulatedDistance, 0, 0); 
    }
    public double CalculateGravitationalSpeed()
    {
        return Math.Sqrt((gravitationalConstant * bigObject.mass) / (currentDistance));
    }
    public double CalculatePeriod(double speed)
    {
        return (Math.PI * 2 * currentDistance) / (speed);
    }
    private double CalculateGravitationaAcceleration()
    {
        return (gravitationalConstant * bigObject.mass) / (currentDistance * currentDistance); 
    }
    private double CalculateCentripetalAcceleration(double speed)
    {
        return (speed * speed) / (currentDistance);
    }
    
}
