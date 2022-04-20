using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    [Header("Speed Variables")]
    public float minimumXSpeed;
    public float maximumXSpeed;
    public float minimumYSpeed;
    public float maximumYSpeed;

    [Header("Gameplay Variables")]
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        //throw the moveobject upwards
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
            Random.Range(minimumXSpeed, maximumXSpeed),
            Random.Range(minimumYSpeed,maximumYSpeed)
        );

        //wait and destroy
        Destroy(gameObject, lifetime);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
