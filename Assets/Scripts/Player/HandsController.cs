using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsController : MonoBehaviour
{
    [SerializeField] private Transform followTarget;
    [SerializeField] private float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = followTarget.rotation;
        transform.position = Vector3.Lerp(transform.position, followTarget.position, Time.fixedDeltaTime * speed);
    }
}
