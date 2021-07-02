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
            BaseAdd(keyBinding, false);
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
                Add(value);
                //BaseAdd(index, value);
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

        [ConfigurationProperty("Name", DefaultValue = (string)"Default", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return (String)base["Name"];
            }
        }
        [ConfigurationProperty("Key", DefaultValue = (int)0, IsRequired = true)]
        public int Key
        {
            get
            {
                return (int)base["Key"];
            }
        }
    }
}
