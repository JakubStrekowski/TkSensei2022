using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalLines : MonoBehaviour
{
    public float val;
    
    private void LateUpdate()
    {
        if (transform.position.x < -val * 2f)
        {
            var pos = transform.position;
            pos.x += val;
            transform.position = pos;
        }
    }
}
