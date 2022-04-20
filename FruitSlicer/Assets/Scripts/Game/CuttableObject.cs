using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableObject : MonoBehaviour
{
    public bool harmful;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //identify if the object is being cut
        if(collision.gameObject.tag == "Cut")
        {
            Destroy(gameObject);

            if (!harmful)
            {
                //we add 10 points when we destroy an object that is not harmful
                GameObject.Find("ScoreText").transform.GetComponent<ScoreText>().Score += 10;
            }
            else
            {
                GameObject.Find("LifeCounter").transform.GetComponent<LifeCounter>().LoseLife();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
