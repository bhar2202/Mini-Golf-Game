using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public float waitTime;
    // Update is called once per frame

    private void Start()
    {
        StartCoroutine(moveObject());
    }

    IEnumerator moveObject()
    {
        while (true)
        {
            for(int i = 0; i < 10; i++)
            {
                gameObject.transform.position += (new Vector3(horizontalSpeed, verticalSpeed, 0));
                yield return new WaitForSeconds(waitTime);
            }
            
            for (int i = 0; i < 10; i++)
            {
                gameObject.transform.position -= (new Vector3(horizontalSpeed, verticalSpeed, 0));
                yield return new WaitForSeconds(waitTime);
            }
            
        }
        
    }
}
