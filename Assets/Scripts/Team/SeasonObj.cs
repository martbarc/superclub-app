using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SeasonObj : MonoBehaviour
{
    [SerializeField] public GameObject prefab_game;

    [SerializeField] public TextMeshProUGUI text_season;
    [SerializeField] public TextMeshProUGUI text_seasonStats;
    [SerializeField] public Button button_lastSeason;
    [SerializeField] public Button button_nextSeason;

    [SerializeField] public Button button_gameLoss;
    [SerializeField] public Button button_gameWin;

    //
    [SerializeField] public GameObject seasonGrid;
    [SerializeField] public GameObject gameHistory;

    [SerializeField] Team team;

    public int maxGames = 5;
    public List<Game> currentGames;

    public int seasonSelected;
    public int maxSeason;

    private void Awake()
    {
        button_lastSeason.onClick.AddListener(LastSeason);
        button_nextSeason.onClick.AddListener(NextSeason);
        button_gameLoss.onClick.AddListener(GameSelectLoss);
        button_gameWin.onClick.AddListener(GameSelectWin);

        seasonSelected = 0;
        maxSeason = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        // clear place holders
        foreach (Transform child in seasonGrid.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        foreach (Transform child in gameHistory.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        NewSeason();
        UpdateText();
    }

    public void NewSeason()
    {
        maxSeason++;
        seasonSelected = maxSeason;

        // create new season
        for (int i = 0; i < maxGames; i++)
        {
            GameObject newGame = Instantiate(prefab_game, transform.position, Quaternion.identity);
            newGame.transform.SetParent(this.seasonGrid.transform);

            newGame.GetComponent<GameObj>().initGame(maxSeason, i + 1, i + 1);

            //Debug.Log("Loaded new game card");
        }

        UpdateText();
    }

    public void GameSelectWin()
    {
        foreach (Transform child in seasonGrid.transform)
        {
            GameObj g = child.gameObject.GetComponent<GameObj>();

            if (g != null)
            {
                if (g.game.selected) { g.SetWinLoss(6); }
            }
        }
    }

    public void GameSelectLoss()
    {
        foreach (Transform child in seasonGrid.transform)
        {
            GameObj g = child.gameObject.GetComponent<GameObj>();

            if (g != null)
            {
                if (g.game.selected) { g.SetWinLoss(0); }
            }
        }
    }

    public void NextSeason()
    {
        //move all games over to history
        MoveGamesToHistory();

        if (seasonSelected + 1 > maxSeason)
        {
            NewSeason();
        }
        else
        {
            seasonSelected++;
            SetSeasonGames(seasonSelected);
        }

        UpdateText();
    }

    public void LastSeason()
    {
        MoveGamesToHistory();

        seasonSelected--;
        if (seasonSelected <= 0)
        {
            seasonSelected = 1;
        }

        SetSeasonGames(seasonSelected);

        UpdateText();
    }

    public void UpdateText()
    {
        text_season.text = $"Season: {seasonSelected}";

        int wins = 0, loss = 0, draw = 0, total = 0;
        foreach (Transform child in seasonGrid.transform)
        {
            GameObj g = child.gameObject.GetComponent<GameObj>();

            if (g != null)
            {
                if (g.game.winLoss > 0)
                    total += g.game.winLoss;

                switch (g.game.winLoss)
                {
                    case 6:
                        wins++;
                        break;
                    case 2:
                        draw++;
                        break;
                    case 0:
                        loss++;
                        break;
                    
                }
            }
        }

        string sStats = "";
        sStats += $"{team.teamName}";
        sStats += $"W: {wins} - L: {loss} - D: {draw}\n";
        sStats += $"Season Total Points: {total}\n";
        sStats += $"Season + Team Roster: {total + team.totalPower}\n";

        text_seasonStats.text = sStats;
    }

    private void SetSeasonGames(int s)
    {
        int tries = 10;

        while (seasonGrid.transform.childCount < maxGames)
        {
            foreach (Transform child in gameHistory.transform)
            {
                GameObj g = child.gameObject.GetComponent<GameObj>();

                if (g != null)
                {
                    if (g.game.seasonNum == s)
                    {
                        child.transform.SetParent(seasonGrid.transform);
                    }
                }
            }

            tries--;
            if (tries <= 0)
            {
                Debug.Log("ERROR: Season games cannot be found!!!");
                break;
            }
        }
    }

    private void MoveGamesToHistory()
    {
        while (seasonGrid.transform.childCount > 0)
        {
            foreach (Transform child in seasonGrid.transform)
            {
                child.transform.SetParent(gameHistory.transform);
            }
        }
    }
}
