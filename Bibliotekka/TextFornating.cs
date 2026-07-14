using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekka
{
   
    public partial class Books
    {
        public override string ToString()
        {
            return NameBook;
        }
    }
    public partial class Author
    {
        public override string ToString()
        {
            return $"{Name} {LastName} {FirstName}";
        }
    }

    public partial class Readers
    {
        public override string ToString()
        {
            return $"{Name} {FirstName} :  {Phone}";
        }
    }

    public partial class AuthorBooks 
    {
        public override string ToString()
        {
            return $"{Author.Name} {Author.FirstName} - {Books.NameBook} ";
        }
    }
    public partial class Loans
    {
        public override string ToString()
        {
            return $"{Readers.Name} {Readers.FirstName} - {Books.NameBook} ";
        }
    }
}
