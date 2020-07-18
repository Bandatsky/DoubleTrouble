﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObjects : MonoBehaviour
{
    [Tooltip("Ресурсы которые будут выпадать")] [SerializeField] private GameObject[] resources;
    [Tooltip("Время спустя которое будет спауниться предмет")] [SerializeField] private float timeRespawn = 12f;
    [Tooltip("Вуроятность с которой будут спауниться предметы")] [SerializeField] private float chance = 0.5f;
    [Tooltip("Радиус в котором будут спауниться предметы")] [SerializeField] private float radius = 5;

    void Start()
    {
        StartCoroutine(SpawnResources());
        transform.position = new Vector3(transform.position.x, 10.0f, transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    IEnumerator SpawnResources()
    {
        while (true)
        {
            Spawner();
            yield return new WaitForSeconds(timeRespawn);
        }
    }

    private void Spawner()
    {
        if (resources != null && resources.Length > 0)
        {
            var randomResources = Random.Range(0, resources.Length);
            if (Random.value <= chance)
            {
                Vector2 randomPoint = Random.insideUnitCircle * radius;
                Vector3 pos = transform.position + new Vector3(randomPoint.x, 0, randomPoint.y);
                Instantiate(resources[randomResources], pos, Quaternion.identity);
            }
        }

    }
}
