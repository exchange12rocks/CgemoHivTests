//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CgemoHivTests.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Declarant
    {
        public Declarant()
        {
            this.ResponsesToDeclarants = new HashSet<ResponsesToDeclarant>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
    
        public virtual ICollection<ResponsesToDeclarant> ResponsesToDeclarants { get; set; }
    }
}
