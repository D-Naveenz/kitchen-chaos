using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;

    private KichenObject kichenObject;

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
            kitchenObjectTransform.localPosition = Vector3.zero;

            // Let the kitchen object know about this counter, and vice versa
            kichenObject = kitchenObjectTransform.GetComponent<KichenObject>();
            kichenObject.ClearCounter = this;

            // Debugging
            Debug.Log("Spawned Kitchen Object: " + kitchenObjectTransform.GetComponent<KichenObject>().KitchenObjectSO.objectName);
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
                Debug.Log("Moved Kitchen Object: " + kichenObject.KitchenObjectSO.objectName);
            }
        }
    }
}
