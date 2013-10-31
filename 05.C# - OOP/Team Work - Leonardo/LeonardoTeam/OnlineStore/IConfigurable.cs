using System;
using System.Reflection;

namespace OnlineStore
{
    interface IConfigurable
    {
        PropertyInfo[] GetChangableProperties();
    }
}
