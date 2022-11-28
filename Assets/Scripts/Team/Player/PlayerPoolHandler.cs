using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPoolHandler : MonoBehaviour
{
    [SerializeField] public PlayerPool playerPool;

    public GameObject SearchBar;

    public int totalElements;

    // Start is called before the first frame update
    void Start()
    {
        totalElements = playerPool.transform.childCount;
    }

    public void Search()
    {
        string SearchText = SearchBar.GetComponent<TMP_InputField>().text;
        int searchTxtlength = SearchText.Length;

        int searchedElements = 0;

        foreach (GameObject e in playerPool.playerObjList)
        {
            searchedElements++;

            PlayerObj pObj = e.GetComponent<PlayerObj>();
            if (pObj.p.n.Length >= searchTxtlength)
            {
                if (pObj.p.n.Substring(0, searchTxtlength).ToLower().Contains(SearchText.ToLower()))
                {
                    e.SetActive(true);
                }
                else
                {
                    e.SetActive(false);
                }
            }
        }
    }
}
