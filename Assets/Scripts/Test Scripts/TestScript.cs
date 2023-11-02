using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [HideInInspector]
    public string displayNewText;

    [SerializeField]
    public string displayText = "Hello World";

    public Transform testCube;

    public float rotateSpeed;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(displayText);

        int i = 5;

        // double equals sign means that it is a comparison (is i equal to 5?)
        // && means "and"
        // || means "or"
        if (i == 5  || i == 3)
        {
            Debug.Log("Value of i is 5 and 3");
        }
        else
        {
            Debug.Log("i is not equal to 5");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 is a point that has 3 dimentions (y,x, and z values)
        // Vector2 is a point that has 2 dimentions (y and x values)

        // transform.Translate(Vector3.up);

        //testCube.Rotate(new Vector3(0,1,0) * rotateSpeed * Time.deltaTime);
        testCube.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        testCube.Rotate(Vector3.up * rotateSpeed * Input.GetAxis("Mouse X"));

        //testCube.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // GetKey (or Get anything) is called as long as the key is pressed (pressed or held down)
        // GetKey down or up us used when you want the button to be pressed once or over and over to call and action
        // GetKey down is when it is pressed, GetKey up is when it is released 
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A is being presssed");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("B is pressed once");
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            Debug.Log("C is pressed once");
        }

    }


}
