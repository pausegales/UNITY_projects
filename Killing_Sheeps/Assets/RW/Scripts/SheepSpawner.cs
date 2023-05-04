using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    
    public bool canSpawn = true; // 1
    public GameObject sheepPrefab; // 2
    public List<Transform> sheepSpawnPositions = new List<Transform>(); // 3
    public float timeBetweenSpawns ;
    private List<GameObject> sheepList = new List<GameObject>(); // 5
    
    private IEnumerator SpawnRoutine(){
        while (canSpawn){
            SpawnSheep(); // 3
            yield return new WaitForSeconds(timeBetweenSpawns); // 4
        }
    }
    
    public void DestroyAllSheep()
    {
        foreach (GameObject sheep in sheepList) // 1
        {
            Destroy(sheep); // 2
        }

        sheepList.Clear();
    }

    
    public void RemoveSheepFromList (GameObject sheep){
        sheepList.Remove(sheep);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (SpawnRoutine());
    }
    
    private void SpawnSheep(){
        Vector3 randomPosition = sheepSpawnPositions [Random.Range(0, sheepSpawnPositions.Count)].position;
        GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation); // 2
        sheepList.Add(sheep); // 3
        sheep.GetComponent<Sheep>().SetSpawner(this); // 4
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
