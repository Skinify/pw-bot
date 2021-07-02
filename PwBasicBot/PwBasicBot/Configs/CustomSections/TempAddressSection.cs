﻿using System;
using System.Configuration;

namespace PwBasicBot.Configs
{
    public class TempAddressSection : ConfigurationSection
    {
        [ConfigurationProperty("Addresses")]
        [ConfigurationCollection(typeof(TempAddressCollection),
           AddItemName = "add",
           ClearItemsName = "clear",
           RemoveItemName = "remove")]
        public TempAddressCollection Addresses
        {
            get
            {
                return (TempAddressCollection)base["Addresses"];
            }
        }
    }

    public class TempAddressCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new TempAddress();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TempAddress)element).Address;
        }

        public void Add(TempAddress TempAddress)
        {
            BaseAdd(TempAddress, false);
        }

        public void Clear()
        {
            BaseClear();
        }

        public TempAddress this[int index]
        {
            get { return (TempAddress)BaseGet(index); }
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

        public TempAddress Get(string name)
        {
            var objects = BaseGetAllKeys();
            for(int count = 0; count < objects.Length; count++)
            {
                if(((objects[count] as TempAddress).Name).Equals(name))
                {
                    return objects[count] as TempAddress;
                }
            }
            return null;
        }
    }

    public class TempAddress : ConfigurationElement
    {
        [ConfigurationProperty("Name", DefaultValue = (string)"Default", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return (string)base["Name"];
            }
        }

        [ConfigurationProperty("Address", DefaultValue = (int)0)]
        public int Address
        {
            get
            {
                return (int)base["Address"];
            }
        }

    }
}
