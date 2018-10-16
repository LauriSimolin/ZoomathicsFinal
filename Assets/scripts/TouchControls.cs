using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TouchControls : MonoBehaviour {

    public static bool touchEnabled;
    

    // Use this for initialization
    void Start () {
        touchEnabled = true;
        
        
	}
	
	// Update is called once per frame
	void Update () {

        

        RaycastHit2D hit;
        GameObject hitObj;

        // checks if touch is enabled or not
        if (touchEnabled == true)
        {
            //if (Input.GetTouch(0).phase == TouchPhase.Began)     <--- detecting touch
            //{
            //    Debug.Log(Input.GetTouch(0).position);
            //}
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log(Input.mousePosition);

                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                // Testing if collider is not null and is hitting specific item
                if (hit.collider != null)
                {
                    // testing if we are hitting fruits on levels
                    if(hit.transform.gameObject.tag == "Fruit")
                    {
                        //Debug.Log("Hit");
                        hitObj = hit.transform.gameObject;
                        GameHandler.picks += 1;
                        Destroy(hitObj);
                    }
                    if (hit.transform.gameObject.tag == "Level1")
                    {
                        Debug.Log("selected level 1");
                        GetComponent<WorldMapHandler>().LoadLevel(1);

                    }
                    
                    if (hit.transform.gameObject.tag == "Level2")
                    {
                        Debug.Log("selected level 2");
                        GetComponent<WorldMapHandler>().LoadLevel(2);
                        
                    }
                    if (hit.transform.gameObject.tag == "Level3")
                    {
                        Debug.Log("selected level 3");
                        //GetComponent<WorldMapHandler>().LoadLevel(3);
                    }


                }
            }
        }



        
	}

    
    
}
