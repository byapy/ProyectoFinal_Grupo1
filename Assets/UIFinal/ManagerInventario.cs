using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerInventario : MonoBehaviour
{
    public static ManagerInventario Instance;
    public List<ItemUI> Items = new List<ItemUI> ();

    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance = this;
    }
    public void Add(ItemUI item)
    {
        Items.Add(item);
    }
    public void Remove(ItemUI item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }


        foreach (var item in Items ) 
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);

            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemName").GetComponent<Image>();

            itemName.text = item.ItemName;
            itemIcon.sprite = item.icon;
        }
    }
}
