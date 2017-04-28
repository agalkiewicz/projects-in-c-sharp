namespace Library
{
    public class Reader : Person
    {
        public uint IdNumber { get; private set; }

        public Reader(string name, string surname, uint idNumber) : base(name, surname)
        {
            IdNumber = idNumber;
        }

        public override string ToString()
        {
            return Name + " " + Surname + " " + IdNumber;
        }
    }
}
