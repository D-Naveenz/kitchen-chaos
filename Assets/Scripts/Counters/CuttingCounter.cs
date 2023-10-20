using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;

    public override void Interact(Player player)
    {
        // Chack the cutting counter is empty and the player has a kitchen object
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

    public override void InteractAlternate(Player player)
    {
        // Chack the cutting counter has a kitchen object
        if (HasKitchenObject())
        {
            // Despawn the uncut kitchen object
            GetKitchenObject().DestroySelf();
            // Spawn the cut kitchen object and give it to the player
            Transform kitchenObjectTransform = Instantiate(cutKitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().KitchenObjectParent = this;
        }
        else if (HasKitchenObject() && !player.HasKitchenObject())
        {
            // Give the kitchen object to the player
            GetKitchenObject().KitchenObjectParent = player;
        }
    }
}
