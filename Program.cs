using System.Collections;

namespace CAGeneric
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbersList = new Any<int>();
            numbersList.Add(1);
            numbersList.Add(2);
            numbersList.Add(3);
            numbersList.DisplayList();

            Console.WriteLine($"Length: {numbersList.Count} Items");
            Console.WriteLine($"Empty: {numbersList.IsEmpty}");

            numbersList.RemoveAt(1);
            numbersList.DisplayList();
            Console.WriteLine($"Length: {numbersList.Count} Items");
            Console.WriteLine($"Empty: {numbersList.IsEmpty}");
            Console.WriteLine("\n---------------------------------");

            //var personslist = new Any<Person>();
            //personslist.Add(new Person { FName = "Rami", LName = "Saloum" });
            //personslist.Add(new Person { FName = "Ranim", LName = "Shtewe" });
            //personslist.DisplayList();
            //Console.WriteLine($"Length: {numbersList.Count} Items");
            //Console.WriteLine($"Empty: {numbersList.IsEmpty}");
            //Console.WriteLine("\n---------------------------------");

            var personlist1 = new List<Person>();
            personlist1.Add(new Person("Reem", "S"));
            personlist1.Add(new Person("Ali", "N"));

            foreach(var person in personlist1)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine($"Length: {personlist1.Count} items");
            Console.WriteLine($"Empty: {personlist1.Count == 0}");

            Console.WriteLine("-------------------");
            var arr = new ArrayList();
            arr.Add(1);
            arr.Add("Good Morning");
            arr.Add(new Person("Ali", "N"));
            arr.Add(new { FName = "Reem", LName = "S" });
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Length: {arr.Count} items");
            Console.WriteLine($"Empty: {arr.Count == 0}");

            Console.ReadKey();
        }
    }

    class Person
    {
        

        public string FName { get; set; }
        public string LName { get; set; }
        public Person(string fName, string lName)
        {
            FName = fName;
            LName = lName;
        }

        public override string ToString()
        {
            return $"{FName} {LName}";
        }

    }
    //class Any<T> where T : class, new() <=> we can use T class with conditions
    //(I want type of T is Class not string(new()) or int)
    class Any<T>
    {
        private T[] _items;

        public void Add(T item)
        {
            if (_items is null)
            {
                _items = new T[] { item };
            }
            else
            {
                var length = _items.Length;
                var dest = new T[length + 1];
                for (int i = 0; i < length; i++)
                {
                    dest[i] = _items[i];
                }
                dest[dest.Length - 1] = item;
                _items = dest;

            }
        }

        public void RemoveAt(int position)
        {
            if (position < 0 || position > _items.Length-1)
              return;

            var index = 0;
            var dest = new T[_items.Length -1];
            for (int i = 0; i < _items.Length; i++)
            {
                if (position == i)
                {
                    continue;
                }
                dest[index++] = _items[i];

            }
            _items = dest;
        }

        public bool IsEmpty => _items is null || _items.Length == 0;
        public int Count => (IsEmpty) ? 0 : _items.Length;

        public void DisplayList()
        {
            Console.Write("[");
            for (int i = 0; i < _items.Length; i++)
            {
                Console.Write(_items[i]);
                if (i <_items.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("]");
        }
    }
   
}