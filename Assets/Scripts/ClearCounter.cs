using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kichenObject;

    public Transform CounterTopPoint
    {
        get => counterTopPoint;
        private set => counterTopPoint = value;
    }

    public void Interact(Player player)
    {
        if (kichenObject == null)
        {
            // Spawn the kitchen object on top the counter
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().KitchenObjectParent = this;

            // Debugging
            Debug.Log("Spawned Kitchen Object: " + kitchenObjectTransform.GetComponent<KitchenObject>().KitchenObjectSO.objectName);
        }
        else
        {
            // Give the kitchen object to the player
            kichenObject.KitchenObjectParent = player;
        }
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
}
