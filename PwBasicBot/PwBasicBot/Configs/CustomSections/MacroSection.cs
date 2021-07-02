using System.Configuration;

namespace PwBasicBot.Configs
{
    public class MacroSection : ConfigurationSection
    {
        [ConfigurationProperty("Macros")]
        [ConfigurationCollection(typeof(MacrosCollection),
           AddItemName = "add",
           ClearItemsName = "clear",
           RemoveItemName = "remove")]
        public MacrosCollection Macros
        {
            get
            {
                return (MacrosCollection)base["Macros"];
            }
        }
    }

    public class MacrosCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Macro();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Macro)element);
        }

        public void Add(Macro Macro)
        {
            BaseAdd(Macro, false);
        }

        public void Clear()
        {
            BaseClear();
        }

        public Macro this[int index]
        {
            get { return (Macro)BaseGet(index); }
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

        public Macro Get(string type)
        {
            var objects = BaseGetAllKeys();
            for(int count = 0; count < objects.Length; count++)
            {
                if(((objects[count] as Macro).Type).Equals(type))
                {
                    return objects[count] as Macro;
                }
            }
            return null;
        }
    }

    public class Macro : ConfigurationElement
    {
        [ConfigurationProperty("Type", DefaultValue = "Default", IsRequired = true, IsKey = true)]
        public string Type
        {
            get
            {
                return (string)base["Type"];
            }
        }

        [ConfigurationProperty("Timeout", DefaultValue = (int)0, IsRequired = true, IsKey = false)]
        public int Timeout
        {
            get
            {
                return (int)base["Timeout"];
            }
        }

        [ConfigurationProperty("MinMP", DefaultValue = (int)0, IsRequired = true, IsKey = false)]
        public int MinMP
        {
            get
            {
                return (int)base["MinMP"];
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
