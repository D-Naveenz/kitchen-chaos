using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;

    private KitchenObject kichenObject;

    public Transform CounterTopPoint
    {
        get => counterTopPoint;
        private set => counterTopPoint = value;
    }

    public void Interact()
    {
        if (kichenObject == null)
        {
            // Spawn the kitchen object on top the counter
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().ClearCounter = this;

            // Debugging
            Debug.Log("Spawned Kitchen Object: " + kitchenObjectTransform.GetComponent<KitchenObject>().KitchenObjectSO.objectName);
        }
        else
        {
            // Destroy the kitchen object
            Destroy(kichenObject.gameObject);

            // Debugging
            Debug.Log("Destroyed Kitchen Object: " + kichenObject.KitchenObjectSO.objectName);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T))
        {
            if (kichenObject != null)
            {
                kichenObject.ClearCounter = secondClearCounter;
            }
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
