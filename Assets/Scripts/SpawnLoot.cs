using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLoot : MonoBehaviour
{
    [SerializeField] private List<GameObject> _lootItems;
    [SerializeField][Range(1, 19)] private int _minLootCount = 1;
    [SerializeField][Range(2, 20)] private int _maxLootCount = 5;
    [SerializeField] private Transform _spawnPoint;
    private bool _isCollected = false;
    public bool isSpawned = false;

    private void Update()
    {
        if(isSpawned && !_isCollected)
        {
            isSpawned = false;
            Loot();
        }
    }

    private void Loot()
    {
        Debug.Log("Spawn loot");
        _isCollected = true;
        int numberOfItemsToSpawn = UnityEngine.Random.Range(_minLootCount, _maxLootCount);

        StartCoroutine(CreateLootRoutine(numberOfItemsToSpawn));
    }

    IEnumerator CreateLootRoutine(int itemsToSpawn)
    {
        yield return new WaitForSeconds(0.5f);

        

        for (int i = 0; i < itemsToSpawn; i++)
        {
            //Spawn item
            int lootIndex = UnityEngine.Random.Range(0, _lootItems.Count);
            GameObject loot = Instantiate(_lootItems[lootIndex], _spawnPoint.position, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
        }
    }
}
