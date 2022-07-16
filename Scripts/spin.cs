using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    
    public float speed;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, speed));
    }
}
