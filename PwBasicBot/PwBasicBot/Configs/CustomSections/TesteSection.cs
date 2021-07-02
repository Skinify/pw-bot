using System.Configuration;

namespace PwBasicBot.Configs
{
    public class TmpAdressSection : ConfigurationSection
    {
        [ConfigurationProperty("Addresses")]
        [ConfigurationCollection(typeof(AddressCollection),
           AddItemName = "add",
           ClearItemsName = "clear",
           RemoveItemName = "remove")]
        public AddressCollection Addresses
        {
            get
            {
                return (AddressCollection)base["Addresses"];
            }
        }
    }

    public class AddressCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new TmpAddress();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TmpAddress)element);
        }

        public void Add(TmpAddress Macro)
        {
            BaseAdd(Macro, false);
        }

        public void Clear()
        {
            BaseClear();
        }

        public TmpAddress this[int index]
        {
            get { return (TmpAddress)BaseGet(index); }
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

        public TmpAddress Get(string type)
        {
            var objects = BaseGetAllKeys();
            for(int count = 0; count < objects.Length; count++)
            {
                if(((objects[count] as TmpAddress).Name).Equals(type))
                {
                    return objects[count] as TmpAddress;
                }
            }
            return null;
        }
    }

    public class TmpAddress : ConfigurationElement
    {
        [ConfigurationProperty("Name", DefaultValue = "Default", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return (string)base["Name"];
            }
        }

        [ConfigurationProperty("Address", DefaultValue = (int)0, IsRequired = true, IsKey = false)]
        public int Address
        {
            get
            {
                return (int)base["Address"];
            }
        }
    }
}
