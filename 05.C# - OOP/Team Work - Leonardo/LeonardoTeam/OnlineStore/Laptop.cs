using System;
using System.Collections.Generic;
using System.Reflection;

namespace OnlineStore
{
    public class Laptop :Configuration,IStorable, IConfigurable
    {
        private string description;

        public string Description
        {
            get { return this.description; }
            set { description = value; }
        }

        private HDD hdd;

        public HDD Hdd
        {
            get { return this.hdd; }
            set { hdd = value; }
        }
        
        private RAM ram;

        public RAM Ram
        {
            get { return this.ram; }
            set { ram = value; }
        }
        
        private CPU cpu;

        public CPU Cpu
        {
            get { return this.cpu; }
            set { cpu = value; }
        }

        public Laptop(string model, Brand brand, decimal price, string description )
            :base(model, brand, price)
        {
            this.Description = description;
        }

        public Laptop(string model, Brand brand, decimal price, string description, CPU cpu = null, RAM ram = null, HDD hdd = null)
            : this (model, brand, price, description)
        { 
            this.Cpu = cpu;
            this.Ram = ram;
            this.Hdd = hdd;            
        }

        public PropertyInfo [] GetChangableProperties ()
        {
            List<string> propertiesStringNames = new List<string> { "Cpu", "Ram", "Hdd" };
            List<PropertyInfo> propertiesNames = new List<PropertyInfo>();

            Type classType = this.GetType();

            foreach (PropertyInfo property in classType.GetProperties())
            {
                if ((property.GetValue(this, null) is Product) && (propertiesStringNames.IndexOf(property.Name) >= 0))
                {
                    propertiesNames.Add(property);
                }
            }
            return propertiesNames.ToArray();
        }

        public override decimal GetPrice()
        {
            decimal totalPrice = this.Price;

            PropertyInfo[] changebleProperties = GetChangableProperties();

            foreach (PropertyInfo property in changebleProperties)
            {
                Product currentPropertyValue = property.GetValue(this, null) as Product;
                if (currentPropertyValue != null)
                    totalPrice += currentPropertyValue.GetPrice();
            }

            return totalPrice;
        }
    }
}
