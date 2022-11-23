using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Roster : MonoBehaviour
{
    [SerializeField] Team team;

    public List<GameObject> playerObjectList;

    public int totalPower = 0;
    
    // Start is called before the first frame update
    void Awake()
    {
        playerObjectList = new List<GameObject>();
    }

    private void Start()
    {
        //GameObject defaultGoalie = Instantiate(prefabPlayer, transform.position, Quaternion.identity);
        //Player dGoalie = defaultGoalie.GetComponent<Player>();
        //dGoalie.AssignToTeam(team);
        //dGoalie.position = "G";
        //dGoalie.positionAct = "Def";
        //dGoalie.power = 1;
        ////dGoalie.UpdateText();

        //defaultGoalie.transform.parent = this.transform;
        //playerObjectList.Add(defaultGoalie);

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

    // ------ PRIVATE ------
    private GameObject SpawnPlayer(GameObject player, Vector3 location)
    {
        GameObject obj = Instantiate(player, location, Quaternion.identity);

        return obj;
    }
}
