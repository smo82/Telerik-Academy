using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;


[DataContract]
public class LoggedUserModel
{
    [DataMember(Name = "sessionKey")]
    public string SessionKey { get; set; }
    [DataMember(Name = "displayName")]
    public string DisplayName { get; set; }
}
