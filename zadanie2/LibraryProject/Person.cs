namespace Library
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public Person(Person person)
        {
            Name = person.Name;
            Surname = person.Surname;
        }
    }
}
