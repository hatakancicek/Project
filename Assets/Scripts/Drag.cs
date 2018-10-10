using System.Collections;
using UnityEngine;

public class Drag : MonoBehaviour {
    public SpringJoint2D spring;
    void Awake()
    {
        spring = this.gameObject.GetComponent<SpringJoint2D>(); 
        spring.connectedAnchor = gameObject.transform.position;
    }

    void OnMouseDown()
    {

        spring.enabled = true;

    }
    void OnMouseDrag()
    {

        if (spring.enabled == true)
        {

            Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//getting cursor position

            spring.connectedAnchor = cursorPosition;//the anchor get's cursor's position


        }
    }


    void OnMouseUp()
    {
        spring.enabled = false;//disabling the spring component
        
    }
}

