using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] Button button_dec;
    [SerializeField] Button button_inc;

    [SerializeField] TextMeshProUGUI text_counter;
    [SerializeField] TMP_InputField inputfield_increment; //optional

    [SerializeField] Image background;

    public float counter = 0f;
    public float inc = 0.5f;

    public float counter_min = float.MinValue;
    public float counter_max = float.MaxValue;

    public string prepend = "";
    public string append = "";

    private void Awake()
    {
        button_inc.onClick.AddListener(IncCounter);
        button_dec.onClick.AddListener(DecCounter);
    }

    //private void Start()
    //{
    //    //UpdateText(); // Set default values
    //}

    public void AddListenerToCounterChange(UnityEngine.Events.UnityAction call)
    {
        button_inc.onClick.RemoveAllListeners();
        button_dec.onClick.RemoveAllListeners();

        button_inc.onClick.AddListener(IncCounter);
        button_dec.onClick.AddListener(DecCounter);

        button_inc.onClick.AddListener(call);
        button_dec.onClick.AddListener(call);
    }

    public void UpdateCounter(float newValue)
    {
        counter = newValue;
        UpdateText();
    }

    public void UpdateText()
    {
        if (text_counter != null) { text_counter.text = $"{prepend}{counter.ToString()}{append}"; }
        //if (inputfield_increment != null) inputfield_increment.text = inc.ToString();
    }

    private void IncCounter()
    {
        if (inputfield_increment != null) ChangeInc();

        if (counter + inc <= counter_max) counter += inc;

        UpdateText();
    }

    private void DecCounter()
    {
        if (inputfield_increment != null) ChangeInc();

        if (counter - inc >= counter_min) counter -= inc;

        UpdateText();
    }

    private void ChangeInc()
    {
        Debug.Log($"{inputfield_increment.text}");
        float.TryParse(inputfield_increment.text, out float incTemp);
        this.inc = incTemp;
    }
}
