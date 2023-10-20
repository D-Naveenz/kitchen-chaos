using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kichenObject;

    public Transform CounterTopPoint
    {
        get => counterTopPoint;
        private set => counterTopPoint = value;
    }

    public KitchenObject GetKitchenObject()
    {
        return kichenObject;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        kichenObject = kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kichenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kichenObject != null;
    }

    public virtual void Interact(Player player)
    {
        // This method is meant to be overriden
        Debug.LogError("Interact method in BaseCounter is not meant to be called!");
    }

    public virtual void InteractAlternate(Player player)
    {
        // This method is meant to be overriden
        Debug.LogError("Interact Alternate method in BaseCounter is not meant to be called!");
    }
}
