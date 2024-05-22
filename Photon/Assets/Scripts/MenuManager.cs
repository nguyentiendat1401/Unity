using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public Menu[] menus;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    
    public void OpenMenu(string name)
    {
        for(int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName == name)
            {
                menus[i].Open();
            }
            else
            {
                menus[i].Close();
            }
        }
    }
    public void CloseMenu(Menu menu)
    {
        //for (int i = 0; i < menus.Length; i++)
        //{
        //   if (menus[i].isOpen)
        //    {
        //        menus[i].Close();
        //    }
        //}

        menu.Close();
    }
}
