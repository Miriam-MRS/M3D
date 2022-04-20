using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Target")]
    public GameObject prefab;

    [Header("Gameplay")]
    public float interval;
    public float minimumX;
    public float maximumX;
    public float y;

    [Header("Visuals")]
    public GameObject[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", interval, interval);
    }

    // Update is called once per frame
    private void Spawn()
    {
        //Instantiate and position the object
        GameObject instance = Instantiate(prefab);
        instance.transform.position = new Vector3(Random.Range(minimumX, maximumX), y);
        //add fruit clone in spawner hierarchy
        instance.transform.SetParent(transform);

        //Select a sprite for the object
        GameObject randomSprite = sprites[Random.Range(0, sprites.Length)];
        instance = randomSprite;
        prefab = randomSprite;
    }
}
