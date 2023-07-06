using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private ClearCounter clearCounter;

    public KitchenObjectSO KitchenObjectSO
    {
        get => kitchenObjectSO;
        set => kitchenObjectSO = value;
    }

    public ClearCounter ClearCounter
    {
        get => clearCounter;
        set
        {
            // Clear the old counter if there is one
            if (clearCounter != null)
            {
                clearCounter.ClearKitchenObject();
            }

            clearCounter = value;
            // Safty check
            if (clearCounter.HasKitchenObject())
            {
                Debug.LogError("Counter already has a kitchen object!");
            }
            clearCounter.SetKitchenObject(this);

            // Change the visuals
            transform.SetParent(clearCounter.CounterTopPoint);
            transform.localPosition = Vector3.zero;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
