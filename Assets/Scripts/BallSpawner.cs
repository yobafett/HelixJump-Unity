using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject BallPrefab;
    [SerializeField] private Transform SpawnPosition;

    private void Awake()
    {
        Instantiate(BallPrefab, SpawnPosition.position, Quaternion.identity);
    }
}
