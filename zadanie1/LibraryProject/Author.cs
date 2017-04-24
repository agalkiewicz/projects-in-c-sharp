namespace Library
{
    public class Author
    {
        public string Name { get; }
        public string Surname { get; }

        public Author(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return Name + " " + Surname;
        }

        public static bool operator ==(Author a, Author b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }
            
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return (a.Name == b.Name) && (a.Surname == b.Surname);
        }

        public static bool operator !=(Author a, Author b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            Author author = obj as Author;

            if (author == null)
            {
                return false;
            }

            return (this == author);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Surname.GetHashCode();
        }

    }
}
