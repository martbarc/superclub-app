using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LineupSlot : MonoBehaviour
{

}

/*
    public Team team;
    public GameObject slotPlayer;

    public string formation;
    public int slot;

    void Awake()
    {
        select.onClick.AddListener(selected_click);

        slot = 0;
    }

    public void selected_click()
    {
        GameObject g = team.GetFirstSelectedPlayer();
        if (g == null)
        {
            BenchPlayer();
        }
        else
        {
            SlotPlayer(g);
        }
    }

    public void UpdateText()
    {
        string newText = $"Fill\n({slot})";
        if (slotPlayer != null)
        {
            newText = $"Filled\n({slot})";
        }

        text_stats.text = newText;
    }

    public void SlotPlayer(GameObject g)
    {
        BenchPlayer();

        PlayerObj pObj = g.GetComponent<PlayerObj>();
        pObj.AssignToFormation(formation, slot);

        g.transform.SetParent(this.transform);
        g.transform.position = this.transform.position;

        slotPlayer = g;

        select.transform.SetAsLastSibling();
        UpdateText();
    }

    public void BenchPlayer()
    {
        if (slotPlayer != null)
        {
            slotPlayer.GetComponent<PlayerObj>().MoveToBench();
            slotPlayer = null;
        }
    }
*/