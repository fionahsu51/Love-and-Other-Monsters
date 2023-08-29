using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed;
    public bool isRotating = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(isRotating){
            transform.Rotate(0, 0, rotationSpeed);
        }
        
    }

    public void setRotating(){
        if(isRotating){
            isRotating = false;
        }else{
            isRotating = true;
        }
    }
}
