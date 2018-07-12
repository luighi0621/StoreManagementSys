using System.Collections.Generic;

namespace Prototype
{
    public class ItemManager
    {
        private Dictionary<string, ItemPrototype> _items = new Dictionary<string, ItemPrototype>();
        public ItemPrototype this[string key]
        {
            get { return _items[key]; }
            set { _items.Add(key, value); }
        }
    }
}