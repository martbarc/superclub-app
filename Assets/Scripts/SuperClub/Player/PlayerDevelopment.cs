using System.Collections;
using System.Collections.Generic;
using TMPro;
using UltimateClean;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDevelopment : MonoBehaviour
{
    [SerializeField] public Counter counter_pow;

    [SerializeField] public TMP_Dropdown dropdown_pos;
    [SerializeField] public TMP_Dropdown dropdown_chem;

    [SerializeField] public CleanButton save;

    public PlayerCard playerCard;

    public bool changesMade;

    public void SetupPanel(PlayerCard newPlayerCard)
    {
        changesMade = false;
        playerCard = newPlayerCard;

        counter_pow.counter = playerCard.p.pow;

        dropdown_pos.AddOptions(playerCard.p.GetPosList());
        dropdown_pos.value = playerCard.p.pos;

        dropdown_chem.AddOptions(playerCard.p.GetChemList());
        dropdown_chem.value = playerCard.p.chem;

        RefreshPanel();
    }

    public void RefreshPanel()
    {
        counter_pow.UpdateText();
    }
}
