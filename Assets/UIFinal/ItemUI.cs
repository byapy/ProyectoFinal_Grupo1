using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Name Item", menuName = "Item/Create New Item")]
public class ItemUI : ScriptableObject 
{
    public int id;
    public string ItemName;
    public int value;
    public Sprite icon;
}
