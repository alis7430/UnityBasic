using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviourSingleton<Managers>
{
    public static InputManager input { get { return Instance._input; } }
    public static ResourceManager Resource { get { return Instance._resource; } }

    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();

    // Update is called once per frame
    void Update()
    {
        input?.OnUpdate();
    }
}
