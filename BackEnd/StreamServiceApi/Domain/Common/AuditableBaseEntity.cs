namespace Domain.Common
{
    public abstract class AuditableBaseEntity
    {
        public virtual int Id { get; set; }  // se crea virtual para que adalis no mande esa propiedad a la BD

     
    }
}
