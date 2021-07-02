using System.Configuration;

namespace PwBasicBot.Configs
{
    public class ItemSection : ConfigurationSection
    {
        [ConfigurationProperty("Items")]
        [ConfigurationCollection(typeof(ItemsCollection),
           AddItemName = "add",
           ClearItemsName = "clear",
           RemoveItemName = "remove")]
        public ItemsCollection Items
        {
            get
            {
                return (ItemsCollection)base["Items"];
            }
        }
    }

    public class ItemsCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Item();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Item)element);
        }

        public void Add(Item Item)
        {
            BaseAdd(Item, false);
        }

        public void Clear()
        {
            BaseClear();
        }

        public Item this[int index]
        {
            get { return (Item)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                Add(value);
                //BaseAdd(index, value);
            }
        }

        public Item Get(string type)
        {
            var objects = BaseGetAllKeys();
            for(int count = 0; count < objects.Length; count++)
            {
                if(((objects[count] as Item).Type).Equals(type))
                {
                    return objects[count] as Item;
                }
            }
            return null;
        }
    }

    public class Item : ConfigurationElement
    {
        [ConfigurationProperty("Type", DefaultValue = "Default", IsRequired = true, IsKey = true)]
        public string Type
        {
            get
            {
                return (string)base["Type"];
            }
        }

        [ConfigurationProperty("CoolDown", DefaultValue = (int)0, IsRequired = true, IsKey = false)]
        public int CoolDown
        {
            get
            {
                return (int)base["CoolDown"];
            }
        }


        [ConfigurationProperty("Key", DefaultValue = (int)0, IsRequired = true, IsKey = false)]
        public int Key
        {
            get
            {
                return (int)base["Key"];
            }
        }
    }
}
