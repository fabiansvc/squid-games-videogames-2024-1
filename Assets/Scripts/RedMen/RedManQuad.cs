using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedManQuad : MonoBehaviour
{
    public Transform RedManQuadTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = RedManQuadTransform.position;
        position.x += Mathf.Cos(Time.time) * Time.deltaTime * 2;
        RedManQuadTransform.position = position;
    }
}
