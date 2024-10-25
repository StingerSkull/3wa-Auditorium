using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent myEvent;
    public UnityEvent unityEvent;

    private void OnEnable()
    {
        myEvent.Register(this);
    }

    private void OnDisable()
    {
        myEvent.Unregister(this);
    }
}
