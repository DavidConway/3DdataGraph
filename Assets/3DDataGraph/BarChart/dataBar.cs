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

    public void dateBar(GameObject graph, float x, float y, float z)
    {
        GameObject bar = GameObject.CreatePrimitive(PrimitiveType.Cube);
        bar.transform.parent = graph.transform;
        bar.transform.position.Set(x, bar.transform.position.y, z);
        bar.transform.localScale.Set(1,y,1);
    }
}
