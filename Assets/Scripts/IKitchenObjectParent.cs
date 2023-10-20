using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent
{
    Transform CounterTopPoint { get; }

    KitchenObject GetKitchenObject();

    void SetKitchenObject(KitchenObject kitchenObject);

    void ClearKitchenObject();

    bool HasKitchenObject();
}
