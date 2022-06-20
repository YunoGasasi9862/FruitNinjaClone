using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    bool isCutting=false;
 
    Camera cam;
    Collider2D col;
    Vector3 prevPosition;
   public float minVelocity = 0.02f;
    void Start()
    {
       
        cam = Camera.main;
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }else if(Input.GetMouseButtonUp(0))
        {

            StopCutting();
        }

        if(isCutting)
        {
            Vector3 position = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position= position;
            float velocity = (position - prevPosition).magnitude / Time.deltaTime;

            if(velocity > minVelocity)
            {
                col.enabled = true;
            }
            else
            {
                col.enabled = false;
            }

            prevPosition = position;
        }
    }

    void StartCutting()
    {
        isCutting = true;
        col.enabled = true;
        prevPosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void StopCutting()
    {
        isCutting = false;
        col.enabled = false;
    }
}
