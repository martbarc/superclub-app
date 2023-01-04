using System.Collections;
using System.Collections.Generic;
using TMPro;
using UltimateClean;
using UnityEngine;

public class BonusSlider : MonoBehaviour
{
    [SerializeField] private FadeButton prevButton;
    [SerializeField] private FadeButton nextButton;

    [SerializeField] protected TextMeshProUGUI optionLabel;

    public float currentIndex;
    public float incrementStep = 0.5f;

    protected virtual void Awake()
    {
        currentIndex = 0f;
        prevButton.onClick.AddListener(DecreaseIndex);
        nextButton.onClick.AddListener(IncreaseIndex);
    }

    protected virtual void Start()
    {
        SetCurrentOptionLabel();
    }

    protected void SetCurrentOptionLabel()
    {
        optionLabel.text = $"Bonus: {currentIndex}";
    }

    public void IncreaseIndex()
    {
        currentIndex += incrementStep;
        SetCurrentOptionLabel();
    }

    public void DecreaseIndex()
    {
        currentIndex -= incrementStep;
        SetCurrentOptionLabel();
    }
}
