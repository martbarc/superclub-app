using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Roster : MonoBehaviour
{
    [SerializeField] Team team;

    [SerializeField] GameObject prefabPlayer;
    [SerializeField] GameObject defaultGoalie;

    [SerializeField] Button button_AddPlayer;

    public List<GameObject> playerObjectList;


    public int totalPower = 0;
    
    // Start is called before the first frame update
    void Awake()
    {
        playerObjectList = new List<GameObject>();

        button_AddPlayer.onClick.AddListener(AddPlayerToRoster);
    }

    private void Start()
    {
        playerObjectList.Add(defaultGoalie);
        Player dGoalie = defaultGoalie.GetComponent<Player>();
        dGoalie.AssignToTeam(team);
        dGoalie.position = "G";
        dGoalie.positionAct = "Def";
        dGoalie.power = 1;
        dGoalie.UpdateText();

        Recalc();
    }

    public void Recalc()
    {
        totalPower = 0;
        foreach(GameObject pObj in playerObjectList)
        {
            Player p = pObj.GetComponent<Player>();

            totalPower += p.power;
        }
    }

    public void AddPlayerToRoster()
    {
        //string name = inputField_AddPlayer.text;

        //Add way to make player from database here

        GameObject newPlayerObject = Instantiate(prefabPlayer, transform.position, Quaternion.identity);
        newPlayerObject.transform.parent = this.transform;

        Player newPlayer = newPlayerObject.GetComponent<Player>();
        newPlayer.AssignToTeam(team);
        newPlayer.power = 1;
        //Player newPlayer = new Player();

        playerObjectList.Add(newPlayerObject);

        Recalc();

        Debug.Log("Added player to roster");
    }

    // ------ PRIVATE ------
    private GameObject SpawnPlayer(GameObject player, Vector3 location)
    {
        GameObject obj = Instantiate(player, location, Quaternion.identity);

        return obj;
    }
}
