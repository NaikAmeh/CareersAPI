namespace Model.Core.Models.Entities
{
    public class Location
    {
        public virtual int LocationID { get; set; }
        public virtual string LocationName { get; set; }
        public virtual string LocationCity { get; set; }
        public virtual string LocationState { get; set; }
        public virtual string LocationCountry { get; set; }
        public virtual int LocationZip { get; set; }
    }
}