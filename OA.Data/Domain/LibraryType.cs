using System.Collections.Generic;

namespace OA.Data.Domain
{
    public class LibraryType : BaseEntity
    {
        public LibraryType()
        {
            Libraries = new HashSet<Library>();
        }

        public string Category { get; set; }
        public ICollection<Library> Libraries { get; set; }
    }
}
