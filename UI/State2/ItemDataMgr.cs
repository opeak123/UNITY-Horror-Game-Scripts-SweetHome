using System.Collections.Generic;
using UnityEngine;
public class ItemDataMgr : MonoBehaviour
{
    public List<Data_Item> m_List = new List<Data_Item>();
    Dictionary<string, Data_Item> m_Dic = new Dictionary<string, Data_Item>();
    static ItemDataMgr m_Inst;
    public static ItemDataMgr GetInst()
    {
        if (m_Inst == null)
            m_Inst = FindObjectOfType<ItemDataMgr>();
        return m_Inst;
    }

    void Awake()
    {
        m_List.ForEach(v =>{m_Dic.Add(v.m_Key, v);});
    }
    public static Data_Item GetData(string key)
    {
        Data_Item value;
        GetInst().m_Dic.TryGetValue(key, out value);
        return value;
    }
}
