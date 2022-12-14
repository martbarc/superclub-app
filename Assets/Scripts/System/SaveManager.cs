using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] public Team t;
    private string savePath;

    // Start is called before the first frame update
    void Awake()
    {
        savePath = Application.persistentDataPath + "/team.yeet";
        DontDestroyOnLoad(gameObject);
        //Load();
    }

    public void Save()
    {
        Debug.Log("NOTE: Starting team save...");
        ES3.Save("TeamName", t.teamName);
    }

    public void Load()
    {
        if (!ES3.FileExists())
        {
            Debug.Log("NOTE: Team save file doesn't exist...");
            return;
        }
        Debug.Log("NOTE: Loading team save...");
        t.teamName = (string)ES3.Load("TeamName");
    }
}
