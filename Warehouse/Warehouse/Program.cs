﻿using System;

namespace Warehouse
{
    class Program
    {
        static void Main(string[] args)
        {


            ////d. Zwrócenie listy przedmiotów o zadanym filtrze (nazwa kategorii)

            //// d1 Zostanę poproszony o wprowadzenie nazwy albo id kategorii produktów
            //// d2 Wyświetlę listę produktów

            MenuActionService actionService = new MenuActionService();
            actionService = Initialize(actionService);
            ItemService itemService = new ItemService();
            Console.WriteLine("Welcome to warehouse app!");

            while (true)
            {        
                Console.WriteLine("Please let me know what you want to do: ");
                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
                for(int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }

                var operation = Console.ReadKey();
                Console.WriteLine("------------------------------------");
                switch(operation.KeyChar)
                {
                    case '1':
                        var keyInfo = itemService.AddNewItemView(actionService);
                        var id = itemService.AddNewItem(keyInfo.KeyChar);
                        break;

                    case '2':
                        var removeId = itemService.RemoveItemView();
                        itemService.RemoveItem(removeId);
                        break;

                    case '3':
                        var detailId = itemService.ItemDetailSelectionView();
                        itemService.ItemDetailViem(detailId);
                        break;

                    case '4':
                        var typeId = itemService.ItemTypeSelectionView();
                        itemService.ItemsByTypeIdView(typeId);
                        break;

                    default:
                        Console.WriteLine("Action you entered does not exist");
                        break;
                }
            }
        }

        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Add item", "Main");
            actionService.AddNewAction(2, "Remove item", "Main");
            actionService.AddNewAction(3, "Show details", "Main");
            actionService.AddNewAction(4, "List of Items", "Main");

            actionService.AddNewAction(1, "Clothing", "AddNewItemMenu");
            actionService.AddNewAction(2, "Electronics", "AddNewItemMenu");
            actionService.AddNewAction(3, "Grocery", "AddNewItemMenu");

            return actionService;
        }
    }
}
