//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ipek
{
    using System;
    using System.Collections.Generic;
    
    public partial class gosterim
    {
        public int gosterimID { get; set; }
        public int filmID { get; set; }
        public int seansID { get; set; }
        public int salonID { get; set; }
        public int sinemaID { get; set; }
    
        public virtual film film { get; set; }
        public virtual salon salon { get; set; }
        public virtual seans seans { get; set; }
        public virtual sinema sinema { get; set; }
    }
}
