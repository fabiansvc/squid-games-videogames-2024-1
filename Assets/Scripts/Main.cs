using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private float totalTime;
    public float TimeRun;
    private Camera myCamera;
    public Light SpotLight;
    public Transform RedMen01;

    /** void Awake()
    {
        Debug.Log("Awake");
    }

    void OnEnable()
    {
        Debug.Log("OnEnable");
    } **/

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hello Word");
        myCamera = GetComponent<Camera> ();
        //myCamera.fieldOfView = 30f;
        
        //Light light = FindObjectOfType<Light>();
        
        if(SpotLight != null )
        {
            SpotLight.color = Color.blue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        
        /** if (totalTime > TimeRun)
        {
            Debug.Log("Los jugadores eliminados despues de haber pasado: " + totalTime);
        }**/
        if(myCamera.fieldOfView > 30f)
        {
            myCamera.fieldOfView -= Time.deltaTime * 2f;
        }

        Vector3 position = RedMen01.position;
        position.x += Time.deltaTime * 0.5f;
        RedMen01.position = position;
    }
    
    /** void OnDisable()
    {
        Debug.Log("OnDisable");
    }**/
}
