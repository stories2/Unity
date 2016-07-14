using UnityEngine;
using System.Collections;

public class ItemNode : MonoBehaviour {

    int data = 0;
    ItemNode next_link = null;

    public ItemNode get_link()
    {
        return next_link;
    }

    public void set_link(ItemNode node)
    {
        this.next_link = node;
    }

    public int get_data()
    {
        return data;
    }

    public void set_data(int data)
    {
        this.data = data;
    }
}
