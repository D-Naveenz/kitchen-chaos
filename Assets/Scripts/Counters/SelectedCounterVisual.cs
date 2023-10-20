using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter counter;

    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.SelectedCounter == counter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        foreach (Transform childTrasform in gameObject.transform)
        {
            childTrasform.gameObject.SetActive(true);
        }
    }

    private void Hide()
    {
        foreach (Transform childTrasform in gameObject.transform)
        {
            childTrasform.gameObject.SetActive(false);
        }
    }
}
