using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    private bool DEBUG = false;
    private int uniqueId;

    //GridTileObject Properties
    [SerializeField] public int id; 
    [SerializeField] public string tileName;
    public string GetTileName() { return this.tileName; }

    [SerializeField] public GameObject spawnedObj;

    private SpriteRenderer sprite;

    private Vector3 away = new Vector3(0f,0f,0f);
    private Vector3 assemble = new Vector3(0f, 0f, 0f);

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public GridTile()
    {
        uniqueId = -1;

        this.id = -1;
        this.tileName = "Null";
    }

    public int GetUniqueID()
    {
        return uniqueId;
    }

    public void SetUniqueID(int uniqueId)
    {
        this.uniqueId = uniqueId;
    }

    public List<string> GetTilePropertiesString()
    {
        List<string> unitProperties = new List<string>();

        unitProperties.Add("ID: " + this.GetUniqueID().ToString());
        unitProperties.Add("Name: " + this.GetTileName());
        unitProperties.Add("Pos: " + this.transform.position);

        return unitProperties;
    }

    public void DebugTileProperties()
    {
        string log = "";
        List<string> tileString = this.GetTilePropertiesString();
        foreach (string strProp in tileString)
        {
            log += strProp + " | ";
        }
        Debug.Log("NOTE: " + log);
    }

    public void FlyAway(Vector3 direction)
    {
        float speed = 8f;

        if (away == new Vector3(0f,0f,0f))
        {
            away = direction;
            
        }
        else
        {
            if (id != 60)
                transform.position = Vector2.MoveTowards(transform.position, away, speed * Time.deltaTime);
        }            
    }

    public void FlyIn()
    {
        float speed = 20f;

        if (assemble == new Vector3(0f, 0f, 0f))
        {
            assemble = transform.position; //SAVE CURENT POSITION
            Vector3 away = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f));
            transform.position = away;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, assemble, speed * Time.deltaTime);
        }
    }

    //public void SetObjectActive(bool active)
    //{
    //    //this.gameObject.SetActive(false);
    //}

    // PRIVATE

    //private void OnMouseDown()
    //{
    //    if (enableDragging)
    //    {
    //        isDragged = true;
    //        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        spriteDragStartPosition = transform.localPosition;
    //    }
    //}

    //private void OnMouseDrag()
    //{
    //    if (enableDragging && isDragged)
    //    {
    //        transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
    //    }
    //}

    //private void OnMouseUp()
    //{
    //    if (enableDragging)
    //    {
    //        isDragged = false;
    //        dragEndedCallback(this);
    //    }
    //}
}
