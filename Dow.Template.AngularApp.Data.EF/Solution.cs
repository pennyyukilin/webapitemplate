//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dow.Template.AngularApp.Data.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Solution
    {
        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public string Name { get; set; }
    
        public virtual Application Application { get; set; }
    }
}
