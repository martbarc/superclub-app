using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SearchScript : MonoBehaviour
{
    public GameObject ContentHolder;

    public GameObject[] Element;

    public GameObject SearchBar;

    public int totalElements;


    // Start is called before the first frame update
    void Start()
    {
        totalElements = ContentHolder.transform.childCount;

        Element = new GameObject[totalElements];

        for (int i = 0; i < totalElements; i++)
        {
            Element[i] = ContentHolder.transform.GetChild(i).gameObject;
        }
    }

    public void Search()
    {
        string SearchText = SearchBar.GetComponent<TMP_InputField>().text;
        int searchTxtlength = SearchText.Length;

        int searchedElements = 0;

        foreach (GameObject e in Element)
        {
            searchedElements++;

            if (e.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Length >= searchTxtlength)
            {
                if (e.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Substring(0, searchTxtlength).ToLower().Contains(SearchText.ToLower()))
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
