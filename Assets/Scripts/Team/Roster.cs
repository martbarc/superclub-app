using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Roster : MonoBehaviour
{
    public List<Player> roster; //11 + 12 = 23

    [SerializeField] GameObject prefabPlayer;
    //[SerializeField] TMP_InputField inputField_AddPlayer;

    public int totalPower = 0;
    

    // Start is called before the first frame update
    void Awake()
    {
        roster = new List<Player>(23);
    }

    public void AddPlayerToRoster()
    {
        //string name = inputField_AddPlayer.text;

        //Add way to make player from database here

        GameObject newPlayerObject = Instantiate(prefabPlayer, transform.position, Quaternion.identity);
        newPlayerObject.transform.parent = this.transform;
        Player newPlayer = newPlayerObject.GetComponent<Player>();
        //Player newPlayer = new Player();

        roster.Add(newPlayer);

        Debug.Log("Added player to roster");
    }

    // ------ PRIVATE ------
    private GameObject SpawnPlayer(GameObject player, Vector3 location)
    {
        GameObject obj = Instantiate(player, location, Quaternion.identity);

        return obj;
    }
}
