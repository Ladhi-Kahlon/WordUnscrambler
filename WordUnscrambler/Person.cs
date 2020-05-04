namespace WordUnscrambler
{
    public class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public void ChangePerson()
        {
            FirstName = "Jane";
            LastName = "Doe";
        }
    }
}