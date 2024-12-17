using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositionOnFall : MonoBehaviour
{
    private Vector3 positionOnStart = Vector3.zero;
    private Quaternion rotationOnStart = Quaternion.identity;
    private float FallThreshold = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        positionOnStart = transform.position;
        rotationOnStart = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < FallThreshold)
        {
            transform.position = positionOnStart;
            transform.rotation = rotationOnStart;
        }

    }
}
