using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviourSingleton<Managers>
{
    public static InputManager input { get { return Instance._input; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static UIManager UI { get { return Instance._ui; }}
    public static SceneManagerEX Scene { get { return Instance._scene; }}

    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();
    SceneManagerEX _scene = new SceneManagerEX();
    UIManager _ui = new UIManager();

    // Update is called once per frame
    void Update()
    {
        input?.OnUpdate();
    }
}
