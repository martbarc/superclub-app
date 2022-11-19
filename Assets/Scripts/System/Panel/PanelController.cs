using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    [SerializeField] public Button button_close;
    [SerializeField] public Button button_open;

    private void Awake()
    {
        button_close.onClick.AddListener(HidePanel);
        button_open.onClick.AddListener(ShowPanel);
    }
    private void Start()
    {
        HidePanel();
    }

    public void HidePanel()
    {
        this.gameObject.SetActive(false);
    }

    public void ShowPanel()
    {
        this.gameObject.SetActive(true);
    }
}
