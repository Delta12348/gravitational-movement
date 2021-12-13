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

    public double period;

    public double distance;

    public double gravitationalConstant = 6.667E-11;

    public double gravitationalSpeed;

    public double userSpeed;

    public double centripetalAcceleration;
    public double gravitationalAcceleration;

    private Transform trigger;
    // Start is called before the first frame update
    void Start()
    {
        trigger = GameObject.FindGameObjectWithTag("Trigger").transform;
        gravitationalSpeed = CalculateGravitationalSpeed();
        gravitationalAcceleration = CalculateGravitationaAcceleration();
        centripetalAcceleration = CalculateCentripetalAcceleration(userSpeed);
        period = CalculatePeriod(gravitationalSpeed);
        SimulateDistance();
        Debug.Log(period / 86400);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SimulateDistance()
    {
        float simulatedDistance = ((float)distance / (float)objectScale);
        smallModel.position = new Vector3(simulatedDistance, 0, 0);
        trigger.position = new Vector3(simulatedDistance, 0, 0); 
    }
    private double CalculateGravitationalSpeed()
    {
        return Math.Sqrt((gravitationalConstant * bigObject.mass) / (distance));
    }
    private double CalculatePeriod(double speed)
    {
        return (Math.PI * 2 * distance) / (speed);
    }
    private double CalculateGravitationaAcceleration()
    {
        return (gravitationalConstant * bigObject.mass) / (distance * distance); 
    }
    private double CalculateCentripetalAcceleration(double speed)
    {
        return (speed * speed) / (distance);
    }
    
}
