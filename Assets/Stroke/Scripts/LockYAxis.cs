using Meta.Voice;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class LockYAxis : MonoBehaviour
{
    private Rigidbody rb;
    private bool grabbed = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbed)
        {
            Vector3 position = transform.position;
            position.y = 0;
            transform.position = position;

            Quaternion rotation = transform.rotation;
            rotation.x = 0;
            rotation.z = 0;
            rotation .y = 0;
            transform.rotation = rotation;
        }
    }

    
    
}
