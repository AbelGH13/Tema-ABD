//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoWash
{
    using System;
    using System.Collections.Generic;
    
    public partial class Muncitori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Muncitori()
        {
            this.IstoricProgramari = new HashSet<IstoricProgramari>();
            this.Programari = new HashSet<Programari>();
        }
    
        public int MuncitorID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string AdresaEMAIL { get; set; }
        public string Parola { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IstoricProgramari> IstoricProgramari { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Programari> Programari { get; set; }
    }
}
