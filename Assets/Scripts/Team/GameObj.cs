using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameObj : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textGame;
    [SerializeField] public Button buttonSelect;

    public Team team;
    public Game game;

    // Start is called before the first frame update
    void Awake()
    {
        //this.textGame = this.gameObject.GetComponent<TextMeshProUGUI>();
        //this.buttonSelect = this.gameObject.GetComponent<Button>();
        buttonSelect.onClick.AddListener(onGameSelected);

        game = new Game();
    }

    private void Start()
    {
        RefreshText();
    }

    public void initGame(int seasonNum, int gameNum, int teamNum)
    {
        game = new Game(seasonNum, gameNum, teamNum);
        RefreshText();
    }

    public void SetWinLoss(int wl)
    {
        game.SetWinLoss(wl);
        RefreshText();
    }

    public void onGameSelected()
    {
        game.SelectGame();
        RefreshText();
    }

    public void RefreshText()
    {
        textGame.text = game.GetString();
    }
}
