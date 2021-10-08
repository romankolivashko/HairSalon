using System.Collections.Generic;

namespace HairSalon
{
  public class Stylist
  {
    public Stylist()
    {
      this.Client = new HashSet<Client>();
    }

    public int StylistId { get; set; }
    public string Name { get; set; }
    public string Description { get; set;}
    public virtual ICollection<Client> Client { get; set; }
  }
}