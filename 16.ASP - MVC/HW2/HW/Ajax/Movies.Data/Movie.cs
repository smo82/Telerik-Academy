//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Movies.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public System.DateTime Year { get; set; }
        public string MaleActorName { get; set; }
        public int MaleActorAge { get; set; }
        public string FemaleActorName { get; set; }
        public int FemaleActorAge { get; set; }
        public string StudioName { get; set; }
        public string StudioAddress { get; set; }
    }
}
