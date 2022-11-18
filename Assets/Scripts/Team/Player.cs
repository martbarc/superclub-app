
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public int power;
    public string myName;
    public string position;

    public bool selected;

    [SerializeField] public Button select;

    [SerializeField] public TextMeshProUGUI text_stats;

    void Awake()
    {
        power = 0;
        myName = "Default";
        selected = false;
        position = "Att";
    }

    void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        text_stats.text = $"\n\nName: {myName}\nStars: {power}\nPosition: {position}\nSelected: {selected}";
    }

    public void onButtonClicked()
    {
        selected = !selected;
        UpdateText();
    }
}
