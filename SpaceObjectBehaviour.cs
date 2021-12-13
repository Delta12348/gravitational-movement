using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObjectBehaviour : MonoBehaviour
{
    public double mass;
    public double radius;

    private UniversalAttractionBehaviour attraction;

    // Start is called before the first frame update
    void Start()
    {
        attraction = GameObject.FindGameObjectWithTag("GameController").GetComponent<UniversalAttractionBehaviour>();
        SimulateScale();    
    }
    void SimulateScale()
    {
        double diameter = (radius/attraction.objectScale) * 2;
        float simulatedScale = (float)diameter;

        this.transform.localScale = new Vector3(simulatedScale, simulatedScale, simulatedScale);
    }
}
