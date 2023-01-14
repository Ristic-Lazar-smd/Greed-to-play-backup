using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour
{
    public SpriteRenderer sr;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            sr.flipX = true;
            
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) ||Input.GetKey(KeyCode.D))
        {
            sr.flipX = false;
        }
        
    }
}
