using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class GetItem : MonoBehaviour
{
    public InventoryBearer inventory;
    public List<GameObject> slots = new List<GameObject>();
    public GameObject slot;
    public GameObject list;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //list = GameObject.Find("Slots");
        for (int i = 0; i < list.transform.childCount; i++)
        {
            slots.Add(list.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Eat()
    {
        GameObject clickedSlot = EventSystem.current.currentSelectedGameObject;
        Debug.Log(clickedSlot.transform.parent.name.ToString());
        int index = Convert.ToInt32(clickedSlot.transform.parent.name);
        slot = slots[index];

        bool didEat = inventory.EatFood(index);

        if (didEat)
        {
            player.GetComponent<Health>().Eat();
        }
    }
}
