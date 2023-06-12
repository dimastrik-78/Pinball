using System;
using System.Collections;
using UnityEngine;
using Random = System.Random;

namespace _Source.BonusSystem
{
    public class SpawnBonus : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private GameObject prefBonus;
        [SerializeField] private int countBonus;
        [SerializeField] private float waitTime;
        
        private readonly Random _random = new();

        private BonusPool _pool;

        private void Awake()
        {
            _pool = new BonusPool(prefBonus);
            _pool.InitObject(countBonus);
            StartCoroutine(Spawn());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(waitTime);
            (GameObject, bool) bonusObject = _pool.GetObject();
            
            if (!bonusObject.Item2)
            {
                StartCoroutine(Spawn());
                yield break;
            }

            bool canSpawn = false;
            int index = 0;
            while (!canSpawn)
            {
                index = _random.Next(0, spawnPoints.Length);
                if (spawnPoints[index].childCount == 0)
                {
                    canSpawn = true;
                }
            }
            
            bonusObject.Item1.transform.position = spawnPoints[index].position;
            bonusObject.Item1.transform.parent = spawnPoints[index];
            StartCoroutine(Spawn());
        }
    }
}