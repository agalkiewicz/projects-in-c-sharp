namespace Library
{
    public class Reader
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public uint IdNumber { get; private set; }

        public Reader(string name, string surname, uint idNumber)
        {
            Name = name;
            Surname = surname;
            IdNumber = idNumber;
        }

        public override string ToString()
        {
            return Name + " " + Surname + " " + IdNumber;
        }
    }
}
