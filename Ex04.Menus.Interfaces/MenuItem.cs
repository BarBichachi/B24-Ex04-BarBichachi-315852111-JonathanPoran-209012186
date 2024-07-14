// using System;
// using System.Collections.Generic;

// namespace Ex04.Menus.Interfaces
// {
//     public class MenuItem
//     {
//         private readonly string r_Title;
//         private bool? m_IsSubMenu;
//         private List<MenuItem> SubItems;
//         public event Action<MenuItem> m_MenuNoitifier;
//         public event Action<string> m_MethodNoitifier
//         {
//             add
//             {
//                 SetIsSubMenu(false);
//                 if(m_IsSubMenu == true)
//                 {
//                     throw new ArgumentException("Cannot add sub-items to an executable item.");
//                 }
//                 else
//                 {
//                     m_MethodNoitifier += value;
//                 }
//             }
//             remove
//             {
//                 m_MethodNoitifier -= value;
//             }
//         }
//         public MenuItem(string i_Title)
//         {
//             r_Title = i_Title;
//         }

//         public void AddMenuItem(MenuItem i_MenuItem)
//         {
//             SetIsSubMenu(true);

//             if(m_IsSubMenu == true)
//             {
//                 if (SubItems == null)
//                 {
//                     SubItems = new List<MenuItem>();
//                 }

//                 SubItems.Add(i_MenuItem);
//                 i_MenuItem.m_MenuNoitifier += new Action<MenuItem>(this.DoChooseItem);
//             }
            
//             else
//             {
//                 throw new ArgumentException("Cannot add sub-items to an executable item.");
//             }
//         }

//         public void RemoveMenuItem(MenuItem i_MenuItem)
//         {
//             if (SubItems == null)
//             {
//                 throw new ArgumentException("Cannot remove from an executable item.");
//             }

//             if (SubItems.Count == 0)
//             {
//                 throw new ArgumentException("No items to remove in the SubItems list.");
//             }

//             if (!SubItems.Contains(i_MenuItem))
//             {
//                 throw new ArgumentException("Menu item to remove does not exist in SubItems.");
//             }

//             SubItems.Remove(i_MenuItem);
//         }

//         public override string ToString()
//         {
//             return r_Title;
//         }

//         public void DoChooseItem()
//         {
//             m_MethodNoitifier?.Invoke(r_Title);
//         }

//         private void SetIsSubMenu(bool value)
//         {
//             if (m_IsSubMenu == null)
//             {
//                 m_IsSubMenu = value;
//             }
//         }
//     }
// }