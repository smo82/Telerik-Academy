using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

[DataContract]
public class UserModel
{
    [DataMember(Name="displayName")]
    public string DisplayName { get; set; }

    [DataMember(Name = "authCode")]
    public string AuthCode { get; set; }
}
