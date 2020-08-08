using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dataBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public void spawn(GameObject graph, float x, float y, float z,string name)
    {
        GameObject bar = GameObject.CreatePrimitive(PrimitiveType.Cube);
        bar.transform.parent = graph.transform;
        bar.transform.localScale = new Vector3(1,y,1);
        bar.transform.localPosition = new Vector3((float)(x +(0.5*x)), y/2,(float)(z+(z*0.5)));//moves the bar into position
        bar.name = name;
    }
}
