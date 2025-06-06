using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviourSingleton<Managers>
{
    public static InputManager input { get { return Instance._input; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static UIManager UI { get { return Instance._ui; }}

    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();
    UIManager _ui = new UIManager();

    // Update is called once per frame
    void Update()
    {
        input?.OnUpdate();
    }
}
