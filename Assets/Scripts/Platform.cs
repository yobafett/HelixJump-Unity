using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float BounceForce;
    [SerializeField] private float BounceRadius;

    public void Break()
    {
        var segments = GetComponentsInChildren<PlatformSegment>();
        foreach (PlatformSegment segment in segments)
        {
            segment.Bounce(BounceForce,transform.position,BounceRadius);
        }
    }
}
