using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] Button button_dec;
    [SerializeField] Button button_inc;

    [SerializeField] TextMeshProUGUI text_counter;
    [SerializeField] TMP_InputField inputfield_increment; //optional

    public float counter = 0f;
    public float inc = 0.5f;

    public string prepend = "";
    public string append = "";

    private void Awake()
    {
        button_inc.onClick.AddListener(IncCounter);
        button_dec.onClick.AddListener(DecCounter);
    }

    private void Start()
    {
        UpdateText(); // Set default values
    }

    public void UpdateCounter(float newValue)
    {
        counter = newValue;
        UpdateText();
    }

    public void UpdateText()
    {
        text_counter.text = $"{prepend}{counter.ToString()}{append}";
        //if (inputfield_increment != null) inputfield_increment.text = inc.ToString();
    }

    private void IncCounter()
    {
        if (inputfield_increment != null) ChangeInc();
        counter += inc;
        UpdateText();
    }

    private void DecCounter()
    {
        if (inputfield_increment != null) ChangeInc();
        counter -= inc;
        UpdateText();
    }

    private void ChangeInc()
    {
        Debug.Log($"{inputfield_increment.text}");
        float.TryParse(inputfield_increment.text, out float incTemp);
        this.inc = incTemp;
    }
}
