using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEntityFramework
{
    public partial class Customer
    {
        public override string ToString()
        {
            var stringPropertyNamesAndValues = this.GetType()
                .GetProperties()
                .Where(pi => pi.PropertyType == typeof(string) && pi.GetGetMethod() != null)
                .Select(pi => new
                    {
                        Name = pi.Name,
                        Value = pi.GetGetMethod().Invoke(this, null)
                    });

            StringBuilder result = new StringBuilder();
            foreach (var propertyData in stringPropertyNamesAndValues)
            {
                result.Append(propertyData.Name + " = " + propertyData.Value + ",");
            }

            result.Length--;
            return result.ToString();
        }
    }
}
