namespace School_Exam_System
{
    class Person
    {
        public string Name { get; private set; }
        public string Id { get; private set; }
        public Person(string name, string id)
        {
            Name = name;
            Id = id;
        }
    }

}

