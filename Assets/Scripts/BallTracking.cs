using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracking : MonoBehaviour
{
    [SerializeField] private Vector3 Offset;
    [SerializeField] private float Length;

    private Ball _ball;
    private Beam _beam;
    private Vector3 _cameraPos;
    private Vector3 _minBallPos;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _beam = FindObjectOfType<Beam>();

        _cameraPos = _ball.transform.position;
        _minBallPos = _ball.transform.position;
        
        TrackBall();
    }

    private void Update()
    {
        if (_ball.transform.position.y < _minBallPos.y)
        {
            TrackBall();
            _minBallPos = _ball.transform.position;
        }
    }

    private void TrackBall()
    {
        Transform ballTransform = _ball.transform;
        Vector3 ballPos = ballTransform.position;
        Vector3 beamPos = _beam.transform.position; 
        _cameraPos = ballPos;
        beamPos.y = ballPos.y;
        Vector3 dir = (beamPos - ballPos).normalized + Offset;
        _cameraPos -= dir * Length;
        transform.position = _cameraPos;
        transform.LookAt(ballTransform);
    }
}
