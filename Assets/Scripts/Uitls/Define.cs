using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
    }

    public enum Sound
    {
        BGM,
        SFX,
        MaxCount,
    }

    public enum UIEvent
    {
        Click,
        Drag,
    }
    public enum MouseEvent
    {
        Press,
        Click
    }

    public enum CameraMode
    {
        QuaterView
    }
}
