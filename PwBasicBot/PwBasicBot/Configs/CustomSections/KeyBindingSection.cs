using System;
using System.Configuration;

namespace PwBasicBot.Configs
{
    public class KeyBindingSection : ConfigurationSection
    {
        [ConfigurationProperty("Bindings")]
        [ConfigurationCollection(typeof(KeyBindingCollection),
           AddItemName = "add",
           ClearItemsName = "clear",
           RemoveItemName = "remove")]
        public KeyBindingCollection Bindings
        {
            get
            {
                return (KeyBindingCollection)base["Bindings"];
            }
        }
    }

    public class KeyBindingCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new KeyBinding();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((KeyBinding)element).Key;
        }

        public void Add(KeyBinding keyBinding)
        {
            BaseAdd(keyBinding);
        }

        public void Clear()
        {
            BaseClear();
        }

        public KeyBinding this[int index]
        {
            get { return (KeyBinding)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public KeyBinding Get(string name)
        {
            var objects = BaseGetAllKeys();
            for(int count = 0; count < objects.Length; count++)
            {
                if(((objects[count] as KeyBinding).Name).Equals(name))
                {
                    return objects[count] as KeyBinding;
                }
            }
            return null;
        }
    }

    public class KeyBinding : ConfigurationElement
    {
        [ConfigurationProperty("Key")]
        public int Key
        {
            get
            {
                return (int)base["Key"];
            }
        }

        [ConfigurationProperty("Name")]
        public string Name
        {
            get
            {
                return (String)base["Name"];
            }
        }
    }
}
