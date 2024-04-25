using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedManCircle : MonoBehaviour
{
    public Transform RedManCircleTransform;
    private float speed = 1.0f; 
    public Rigidbody RedManCircleRigidbody;
    public float aceleration = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /**Vector3 position = RedManCircleTransform.position;

        position.x += Mathf.Cos(Time.time) * Time.deltaTime * speed * 2;
        position.z += Mathf.Sin(Time.time) * Time.deltaTime * speed * 2;

        RedManCircleTransform.position = position;**/
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with: " + collision.collider.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Trigger activated: " + other.name);
        }
    }

    private void FixedUpdate()
    {
        Vector3 direction = Vector3.zero;
        direction.z = 1;
        RedManCircleRigidbody.AddForce(direction * aceleration);
    }
}
