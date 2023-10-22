using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InventoryMgr
{
    public static List<string> m_List = new List<string>();
    public static float m_Dirty = 0;
    public static void Init()
    {
        m_List.Clear();
    }
    public static void AddItem(string key)
    {
        m_List.Add(key);
        m_Dirty++;
    }
    public static void RemoveItem(string key)
    {
        m_List.Remove(key);
        m_Dirty++;
    }
    public static bool ContainsItem(string key)
    {
        return m_List.Contains(key);
    }
}
