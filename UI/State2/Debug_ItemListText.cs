using UnityEngine;
using UnityEngine.UI;
public class Debug_ItemListText : MonoBehaviour
{
    Text m_Text;
    float m_Dirty = float.MinValue;
    void Start()
    {
        m_Text = GetComponent<Text>();
    }
    void Update()
    {
        if (m_Dirty != InventoryMgr.m_Dirty)
        {
            m_Dirty = InventoryMgr.m_Dirty;
            m_Text.text = "ItemList:";
            InventoryMgr.m_List.ForEach(v =>
            {
                m_Text.text += string.Format("\n{0}", v);
            });
        }
    }
}
