using System.Collections.Generic;

namespace Library.Models
{
  public class Author
  {
    public Author()
    {
      this.JoinEntities = new HashSet<AuthorBook>();
    }

    public int BookId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<AuthorBook> JoinEntities { get; }
  }
}