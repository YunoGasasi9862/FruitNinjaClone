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
    public GameObject BladeTrail;
    GameObject CurrentTrail;
    void Start()
    {
       
        cam = Camera.main;
        col = GetComponent<Collider2D>();
        prevPosition = cam.ScreenToWorldPoint(Input.mousePosition); //this is for the first one: prevposition

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

       CurrentTrail = Instantiate(BladeTrail, transform);
       
    }

    void StopCutting()
    {
        isCutting = false;
        col.enabled = false;
        CurrentTrail.transform.SetParent(null);
        Destroy(CurrentTrail, 2f);
    }
}
