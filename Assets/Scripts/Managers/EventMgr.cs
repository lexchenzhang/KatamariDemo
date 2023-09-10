using UnityEngine;
using System;

public class EventMgr : MonoBehaviour
{
    public static EventMgr current;
    public event Action<ICollectable> OnItemPickedUpTriggerEnter;
    private void Awake()
    {
        current = this;
    }

    public void ItemPickedUpTriggerEnter(ICollectable item)
    {
        OnItemPickedUpTriggerEnter?.Invoke(item);
    }
}
