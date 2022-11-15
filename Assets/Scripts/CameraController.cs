using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI text_stage;
    [SerializeField] public Button button_next;
    [SerializeField] public Camera camera_main;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateText_Stage(string text)
    {
        text_stage.text = text;
    }
}
