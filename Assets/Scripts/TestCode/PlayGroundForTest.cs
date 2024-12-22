using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGroundForTest : MonoBehaviour
{
    void Start()
    {
        int x = (1 << 8);
        int y = (1 << 7);
        int a =  x | y;

        Debug.Log(x);
        Debug.Log(y);
        Debug.Log(a);
    }

    void Update()
    {
        
    }
}
