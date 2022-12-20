using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPool : MonoBehaviour
{
    [SerializeField] public GameObject prefabPlayer;
    [SerializeField] public TextAsset playerListJson;
    [SerializeField] public Canvas canvas_root;

    //Init in playerpoolgrid
    [SerializeField] public GameObject playerpoolgrid;

    public List<GameObject> pObjList;

    [SerializeField] public Team team;

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
        GameObject newPlayerObject = Instantiate(prefabPlayer, transform.position, Quaternion.identity);
        newPlayerObject.name = n;
        newPlayerObject.transform.SetParent(this.transform);

        newPlayerObject.GetComponent<PlayerObj>().InitPlayer(team, id, n, (Pos)position, power, (Chem)chem, tval, sval);

        pObjList.Add(newPlayerObject);

        //Debug.Log("Loaded player: " + n + " " + position);
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