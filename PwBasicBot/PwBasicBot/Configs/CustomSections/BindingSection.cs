using System.Configuration;

namespace PwBasicBot.Configs
{
    public class BindingSection : ConfigurationSection
    {
        [ConfigurationProperty("Bindings")]
        [ConfigurationCollection(typeof(BindingCollection),
           AddItemName = "add",
           ClearItemsName = "clear",
           RemoveItemName = "remove")]
        public BindingCollection Bindings
        {
            get
            {
                return (BindingCollection)base["Bindings"];
            }
        }
    }

    public class BindingCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Binding();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Binding)element);
        }

        public void Add(Binding Binding)
        {
            BaseAdd(Binding, false);
        }

        public void Clear()
        {
            BaseClear();
        }

        public Binding this[int index]
        {
            get { return (Binding)BaseGet(index); }
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

        public Binding Get(string type)
        {
            var objects = BaseGetAllKeys();
            for(int count = 0; count < objects.Length; count++)
            {
                if(((objects[count] as Binding).Name).Equals(type))
                {
                    return objects[count] as Binding;
                }
            }
            return null;
        }
    }

    public class Binding : ConfigurationElement
    {
        [ConfigurationProperty("Name", DefaultValue = "Default", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return (string)base["Name"];
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
