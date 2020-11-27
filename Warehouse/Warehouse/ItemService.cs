using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    public class ItemService
    {
        public List<Item> Items { get; set; }
        public ItemService()
        {
            Items = new List<Item>();
        }

        public ConsoleKeyInfo AddNewItemView(MenuActionService actionService)
        {
            var addNewItemMenu = actionService.GetMenuActionsByMenuName("AddNewItemMenu");
            Console.WriteLine("Please select item type: ");
            for (int i = 0; i < addNewItemMenu.Count; i++)
            {
                Console.WriteLine($"{addNewItemMenu[i].Id}. {addNewItemMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            return operation;
        }

        public int AddNewItem(char itemType)
        {
            int itemTypeId;
            Int32.TryParse(itemType.ToString(), out itemTypeId);
            Item item = new Item();
            item.TypeId = itemTypeId;

            Console.WriteLine("Please enter id for new item: ");
            var id = Console.ReadLine();
            int itemId;
            Int32.TryParse(id, out itemId);
            item.Id = itemId;

            Console.WriteLine("Please enter name for new item: ");
            var name = Console.ReadLine();
            item.Name = name;

            Items.Add(item);
            return itemId;
        }

        public int RemoveItemView()
        {
            Console.WriteLine("Please enter id for item you want to remove: ");
            var itemId = Console.ReadKey();

            int id;
            Int32.TryParse(itemId.KeyChar.ToString(), out id);

            return id;
        }

        public void RemoveItem(int removeId)
        {
            Item productToRemove = new Item();

            foreach (var item in Items)
            {
                if (item.Id == removeId)
                {
                    productToRemove = item;
                    break;
                }
            }
            Items.Remove(productToRemove);     
        }
    }
}
