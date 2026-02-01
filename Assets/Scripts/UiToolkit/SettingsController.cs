using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;



public class SettingsController : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    private UIDocument SetDoc;
    private VisualElement m_root;
    private bool m_IsOpen = false;
    private void Awake()
    {
        SetDoc = gameObject.GetComponent<UIDocument>();
        m_root = SetDoc.rootVisualElement.Q<VisualElement>("Panel");

        //Instance = this;
    }

    public void OnMenuButton()
    {
        if(m_IsOpen)
        {
            CloseMenu();
        }
        else
        {
            OpenMenu();
        }
        //m_IsOpen = !m_isOpen;
    }

    public void OpenMenu()
    {
        Time.timeScale = 0;
        m_root.RemoveFromClassList("hidden");
        m_IsOpen = true;
    }
    public void CloseMenu()
    {
        Time.timeScale = 1;
        m_root.AddToClassList("hidden");
        m_IsOpen = false;
    }
}
