using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    bool isCutting=false;
   public Rigidbody2D rb;
    Camera cam;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
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

        }
    }

    void StartCutting()
    {
        isCutting = true;
    }

    void StopCutting()
    {
        isCutting = false;
    }
}
