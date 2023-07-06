using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;

    private KichenObject kichenObject;

    public void Interact()
    {
        if (kichenObject == null)
        {
            // Spawn the kitchen object on top the counter
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectTransform.localPosition = Vector3.zero;

            // Let the kitchen object know about this counter, and vice versa
            kichenObject = kitchenObjectTransform.GetComponent<KichenObject>();
            kichenObject.ClearCounter = this;

            // Debugging
            Debug.Log("Spawned Kitchen Object: " + kitchenObjectTransform.GetComponent<KichenObject>().KitchenObjectSO.objectName);
        }
    }
}
