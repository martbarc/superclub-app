using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPool : MonoBehaviour
{
    [SerializeField] public GameObject prefabAddPlayer;

    [SerializeField] public TextAsset playerListJson;

    //Init in playerpoolgrid
    [SerializeField] public GameObject playerpoolgrid;

    [SerializeField] public Team team;

    public List<GameObject> pObjList;

    private void Awake()
    {
        pObjList = new List<GameObject>();
    }

    void Start()
    {
        LoadNewPool();
    }

    public void AddPlayerToPool(ushort id, string n, ushort position, float power, ushort chem, ushort tval, ushort sval)
    {
        GameObject addPlayerObject = Instantiate(prefabAddPlayer, transform.position, Quaternion.identity);
        addPlayerObject.name = n;
        addPlayerObject.GetComponent<Player_AddCard>().targetTeam = this.team;
        addPlayerObject.transform.SetParent(playerpoolgrid.transform);
        addPlayerObject.transform.localScale = new Vector3(1f, 1f, 1f);

        addPlayerObject.GetComponent<Player_AddCard>().InitPlayer(team, id, n, (Pos)position, power, (Chem)chem, tval, sval);

        pObjList.Add(addPlayerObject);
    }

    public void LoadNewPool()
    {
        PlayerList playersInJson = JsonUtility.FromJson<PlayerList>(playerListJson.text);

        foreach (Player p in playersInJson.playerlist)
        {
            AddPlayerToPool(p.id, p.n, p.pos, p.pow, p.chem, p.tval, p.sval);
            //p.transform.SetParent(playerpoolgrid.transform);
        }
    }
}