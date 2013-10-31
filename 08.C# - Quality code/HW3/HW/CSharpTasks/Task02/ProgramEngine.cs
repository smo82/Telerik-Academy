using System;

namespace Task02
{
    class ProgramEngine
    {
        static void Main(string[] args)
        {
            PersonEngine testEngine = new PersonEngine();
            testEngine.CreatePerson(1);
            testEngine.CreatePerson(2);
        }
    }
}
