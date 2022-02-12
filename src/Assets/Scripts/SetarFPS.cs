using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetarFPS : MonoBehaviour
{
    [Range(-1, 200)]
    public int fps;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = fps;
    }
}
