using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider.name == "Play")
            {
                PlayStats.gameHasStarted = false;
                SceneManager.LoadScene(1);
            }
            
            if (hit.collider.name == "Exit")
            {
                Debug.Log("Exit Program");
            }
        }
    }
}
