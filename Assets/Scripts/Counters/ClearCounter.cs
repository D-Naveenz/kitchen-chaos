using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        // Chack the clear counter is empty and the player has a kitchen object
        if (!HasKitchenObject() && player.HasKitchenObject())
        {
            player.GetKitchenObject().KitchenObjectParent = this;

            // Debugging
            Debug.Log($"Placed Kitchen Object: \'{GetKitchenObject().KitchenObjectSO.objectName} on the \'{gameObject.name}");
        }
        else if (HasKitchenObject() && !player.HasKitchenObject())
        {
            // Give the kitchen object to the player
            GetKitchenObject().KitchenObjectParent = player;
        }
    }
}
