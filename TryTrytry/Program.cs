using System;
public class MyCollection
{
    int[] items;
    public MyCollection()
    {
        items = new int[5] { 12, 44, 33, 2, 50 };
    }

    // Delete the following line to resolve.  
    MyEnumerator GetEnumerator()

    // Uncomment the following line to resolve:  
    // public MyEnumerator GetEnumerator()
    {
        return new MyEnumerator(this);
    }

    // Declare the enumerator class:  
    public class MyEnumerator
    {
        int nIndex;
        MyCollection collection;
        public MyEnumerator(MyCollection coll)
        {
            collection = coll;
            nIndex = -1;
        }

        public bool MoveNext()
        {
            nIndex++;
            return (nIndex < collection.items.Length);
        }

        public int Current => collection.items[nIndex];
    }

    public static void Main()
    {
        MyCollection col = new MyCollection();
        Console.WriteLine("Values in the collection are:");
        foreach (int i in col)   // CS1579  
        {
            Console.WriteLine(i);
        }
    }
}