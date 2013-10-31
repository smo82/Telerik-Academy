using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShapesSpace;

namespace EngineSpace
{
    public class InvalidRangeException<T> : ApplicationException
    {
		public T RangeStart {get; private set;}
		public T RangeEnd {get; private set;}
		
		public InvalidRangeException(string msg, T pRangeStart, T pRangeEnd)
			: base (msg)
		{
			this.RangeStart = pRangeStart;
			this.RangeEnd = pRangeEnd;
		}
		
       	public InvalidRangeException(T pRangeStart, T pRangeEnd)
			: this (string.Format("Your value is out of the range: [{0}, {1}]", pRangeStart, pRangeEnd), pRangeStart, pRangeEnd)
		{}
    }
}