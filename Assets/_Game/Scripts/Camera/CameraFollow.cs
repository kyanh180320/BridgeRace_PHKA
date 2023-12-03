using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 offset;
    public Transform target;
    public float speedFollow;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position , target.position + offset, speedFollow * Time.deltaTime);
    }
}
