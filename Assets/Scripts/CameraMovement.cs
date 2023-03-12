using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newTarget = new Vector3(target.position.x, transform.position.y, target.position.z + offset.z);
        
        transform.position = Vector3.Lerp(transform.position, newTarget,10*Time.deltaTime);
    }
}
