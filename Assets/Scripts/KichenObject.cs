using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KichenObject : MonoBehaviour
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
        set => clearCounter = value;
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
