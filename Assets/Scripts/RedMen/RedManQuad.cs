using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedManQuad : MonoBehaviour
{
    public Transform RedManQuadTransform;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = RedManQuadTransform.position;
        position.x += Mathf.Cos(Time.time) * Time.deltaTime * 2;
        RedManQuadTransform.position = position;
    }
}
