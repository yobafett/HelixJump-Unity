using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int LevelCount;
    [SerializeField] private float AdditionalScale;
    [SerializeField] private GameObject BeamPrefab;
    [SerializeField] private StartPlatform StartPlatform;
    [SerializeField] private Platform[] Platforms;
    [SerializeField] private FinishPlatform FinishPlatform;

    private const float START_AND_FINISH_ADDITIONAL_SCALE = 0.5f;
    private float BeamScaleY => LevelCount / 2f + START_AND_FINISH_ADDITIONAL_SCALE + AdditionalScale / 2f;
    
    private void Awake()
    {
        Build();
    }

    private void Build()
    {
        GameObject beam = Instantiate(BeamPrefab, transform);
        beam.transform.localScale = new Vector3(1f,BeamScaleY,1f);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - AdditionalScale;

        SpawnPlatform(StartPlatform, ref spawnPosition, beam.transform);
        
        for (var i = 0; i < LevelCount; i++)
            SpawnPlatform(Platforms[Random.Range(0,Platforms.Length)], ref spawnPosition, beam.transform);
        
        SpawnPlatform(FinishPlatform, ref spawnPosition, beam.transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 position, Transform parent)
    {
        Quaternion rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
        Instantiate(platform, position, rotation, parent);
        position.y -= 1;
    }
}
