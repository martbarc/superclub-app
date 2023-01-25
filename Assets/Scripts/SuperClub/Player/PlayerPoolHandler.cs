using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; // Required when Using UI elements.

public class PlayerPoolHandler : MonoBehaviour
{
    [SerializeField] public PlayerPool playerPool;

    [SerializeField] public Button button_loadPlayers;

    [SerializeField] public GameObject searchContent;
    [SerializeField] public TMP_InputField SearchBar;

    public string lastSearch;

    void Awake()
    {
        //SearchBar.onValueChanged.AddListener(delegate {Search(); });
        button_loadPlayers.onClick.AddListener(playerPool.LoadNewPool);
    }

    // Start is called before the first frame update
    void Start()
    {
        // clear place holders
        // foreach (Transform child in playerPool.transform)
        // {
        //     GameObject.Destroy(child.gameObject);
        // }

        //playerPool.LoadNewPool();
    }

    public void Search()
    {
        string SearchText = SearchBar.text;
        lastSearch = SearchText;
        int searchTxtlength = SearchText.Length;

        if (SearchText.Length < 2)
        {
            return;
        }

        int searchedElements = 0;
        int totalElements = playerPool.transform.childCount;

        foreach (Transform c in searchContent.transform)
        {
            Player_AddCard pObj = c.gameObject.GetComponent<Player_AddCard>();
            if (pObj == null)
            {
                continue;
            }

            searchedElements++;
            if (pObj.p.n.Length >= searchTxtlength)
            {
                if (pObj.p.n.Substring(0, searchTxtlength).ToLower().Contains(SearchText.ToLower()))
                {
                    c.gameObject.SetActive(true);
                }
                else
                {
                    c.gameObject.SetActive(false);
                }
            }
        }
    }
}
