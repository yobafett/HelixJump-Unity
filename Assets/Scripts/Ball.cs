using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlatformSegment platformSegment))
        {
            platformSegment.GetComponentInParent<Platform>().Break();
        }
    }
}
