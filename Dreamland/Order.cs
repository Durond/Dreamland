//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dreamland
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.ToyInOrder = new HashSet<ToyInOrder>();
        }
    
        public int id { get; set; }
        public int idClent { get; set; }
        public System.DateTime date { get; set; }

        public string Dateorder { get => date.ToLongDateString(); }
        public int state { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual State State1 { get; set; }

        public string nameclient
        {
            get
            {
                if (idClent.ToString() == null)
                    return "";
                else return Client.name;

            }
            set
            {

            }
        }

        public string  titlestate {
            get
            {
                if (state.ToString() == null)
                    return "";
                else return State1.title;


            }
            set
            {

            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ToyInOrder> ToyInOrder { get; set; }
     
    }
}
