using Hotel.Api.Data.Common;
using Hotel.Api.Data.Enums;

namespace Hotel.Api.Data.Entities
{
    public class Contact : BaseEntity
    {
        public Guid PersonId { get; set; }
        public ContactInfoType InfoType { get; set; }
        public string Info { get; set; }
        public virtual Person Person { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}
