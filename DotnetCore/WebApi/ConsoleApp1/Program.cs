using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("li");
            //p.LastName = "ge";
            Console.WriteLine(p.ToString());
            Console.WriteLine("Hello, World!");
        }
    }

    record class Person(string FirstName, string LastName)
    {
        //public string FirstName { get; set; }  // 这里就不要写 ,否则就没效果了
        //public string LastName { get; set; }  // 这里就不要写 ,否则就没效果了

        public Person(string FirstName) : this(FirstName, null) { } //此时 LastName 不能被再次赋值了
    }

}