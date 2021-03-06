using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject bladeTrailPrefab;
    public float minCuttingVelocity = .001f;

    bool isCutting = false;
    Vector2 previousPosition;

   GameObject currentBladeTrail;

   Rigidbody2D rb;
   Camera cam;
   CircleCollider2D circleCollider;
    
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        } else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }
        if (isCutting)
        {
            UpdateCut();
        }
    }

    void UpdateCut()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition); //set to the current mouse position in world points
        rb.position = newPosition;

        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime; //the speed at which we are travelling is the length of newPosition - previousPosition
        if(velocity > minCuttingVelocity) //we enable circleCollider only if the velocity is greater than  minCuttingVelocity
        {
            circleCollider.enabled = true;
        } else
        {
            circleCollider.enabled = false;
        }

        previousPosition = newPosition;

    }

    void StartCutting()
    {
        isCutting = true;
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        circleCollider.enabled = false; //not enabled on the frist frame
        //Destroy(this.gameObject);
    }

    void StopCutting()
    {
        isCutting = false;
       currentBladeTrail.transform.SetParent(null);
       Destroy(currentBladeTrail, 2f); //destroy the trail after 2 sec
       circleCollider.enabled = false;
    }

}
