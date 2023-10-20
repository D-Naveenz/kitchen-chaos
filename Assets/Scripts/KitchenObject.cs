using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private IKitchenObjectParent kitchenObjectParent;

    public KitchenObjectSO KitchenObjectSO
    {
        get => kitchenObjectSO;
        set => kitchenObjectSO = value;
    }

    public IKitchenObjectParent KitchenObjectParent
    {
        get => kitchenObjectParent;
        set
        {
            // Clear the old counter if there is one
            if (kitchenObjectParent != null)
            {
                kitchenObjectParent.ClearKitchenObject();
            }

            kitchenObjectParent = value;
            // Safty check
            if (kitchenObjectParent.HasKitchenObject())
            {
                Debug.LogError("Counter already has a kitchen object!");
            }
            kitchenObjectParent.SetKitchenObject(this);

            // Change the visuals
            transform.SetParent(kitchenObjectParent.CounterTopPoint);
            transform.localPosition = Vector3.zero;
        }
    }
}
