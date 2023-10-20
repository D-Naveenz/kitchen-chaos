using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public event EventHandler OnPlayerGrabbedObject;

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            // Spawn the kitchen object and give it to the player
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().KitchenObjectParent = player;

            // fire off the event
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);

            // Debugging
            Debug.Log($"Player took {kitchenObjectTransform.GetComponent<KitchenObject>().KitchenObjectSO.objectName} from {gameObject.name}");
        }
    }
}
