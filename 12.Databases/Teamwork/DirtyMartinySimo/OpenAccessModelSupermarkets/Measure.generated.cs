#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using OpenAccessModelSupermarkets;

namespace OpenAccessModelSupermarkets	
{
	public partial class Measure
	{
		private int _measureId;
		public virtual int MeasureId
		{
			get
			{
				return this._measureId;
			}
			set
			{
				this._measureId = value;
			}
		}
		
		private string _measureName;
		public virtual string MeasureName
		{
			get
			{
				return this._measureName;
			}
			set
			{
				this._measureName = value;
			}
		}
		
		private IList<Product> _products = new List<Product>();
		public virtual IList<Product> Products
		{
			get
			{
				return this._products;
			}
		}
		
	}
}
#pragma warning restore 1591
