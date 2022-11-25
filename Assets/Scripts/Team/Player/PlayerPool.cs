using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPool : MonoBehaviour
{
    [SerializeField] public GameObject prefabPlayer;
    [SerializeField] public TextAsset playerListJson;

    public List<GameObject> playerObjList;

    public Team team;

    private void Awake()
    {
        playerObjList = new List<GameObject>();
    }

    void Start()
    {
        PlayerList playersInJson = JsonUtility.FromJson<PlayerList>(playerListJson.text);

        foreach (Player p in playersInJson.playerlist)
        {
            AddPlayerToPool(p.id, p.pos, p.pow, p.chem);
        }
    }

    public void AddPlayerToPool(string firstName, string position, float power, string chem)
    {
        GameObject newPlayerObject = Instantiate(prefabPlayer, transform.position, Quaternion.identity);
        newPlayerObject.transform.parent = this.transform;

        newPlayerObject.GetComponent<PlayerObj>().InitPlayer(team, firstName, position, power, chem);

        playerObjList.Add(newPlayerObject);

        Debug.Log("Loaded player: " + firstName + " " + position);
    }
}