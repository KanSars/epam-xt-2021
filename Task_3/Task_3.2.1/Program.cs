using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task_3._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
public class DynamicArray<T> : IEnumerable<T>
{
    int sizeArray = 0; //по факту капасити
    T[] myArray;
    int length = 0;

    public DynamicArray()
    {
        this.sizeArray = 8;
        this.myArray = new T[sizeArray];
    }
    
    public DynamicArray(int length)
    {
        this.sizeArray = length;
        Array.Resize(ref myArray, sizeArray); //ref передать массив по ссылке (дает возможность изменять именно этот массив)
    }

    public void ChangeCapacity(int length) //вместо public какое лучше использовать, учитывая что он будет использоваться только внутри класса?
    {
        this.sizeArray = length;            
        Array.Resize(ref myArray, sizeArray);
    }

    public DynamicArray(IEnumerable<T> collectionOfT)
    {
        myArray = collectionOfT.ToArray<T>();
        sizeArray = length = myArray.Length;
    }
    public void Add(T value)
    {
        if (sizeArray == 0)
        {
            sizeArray = 1;
            myArray = new T[sizeArray];
            myArray[0] = value;
            this.length++;
        }
        if ( length == sizeArray )
        {
            sizeArray = sizeArray * 2;
            Array.Resize(ref myArray, sizeArray);
        }

        myArray[length + 1] = value;
        this.length++;
    }

    public void AddRange(IEnumerable<T> collectionOfT)
    { 
        int collectionOfTLength = collectionOfT.Count();
        if (sizeArray < length + collectionOfTLength)
        {
            sizeArray = length + collectionOfTLength;
            Array.Resize(ref myArray, sizeArray);
        }

        foreach (var item in collectionOfT)
        {
            myArray[length] = item;
        }

        length += collectionOfTLength;
    }

    public bool Remove(int indexToDelete)
    {
        if (sizeArray == 0 || indexToDelete < 1 || indexToDelete > sizeArray)
        {
            return false;
        }
        else
        {
            if (indexToDelete == sizeArray)
            {
                length--;
                return true;
            }
            else
            {
                for (int i = indexToDelete - 1; i < length - 1; i++)
                {
                    myArray[i] = myArray[i + 1];
                }
                // myArray[length - 1] = 0; -можно ли как-то обнулить элемент массива<T> этого не требуется но все же?
                length--;
                return true;
            }
        }
    }

    public bool Insert(int indexToInsert, T value)
    {
        
        if (sizeArray == 0)
            return false;

        if (indexToInsert < 1 || indexToInsert > sizeArray)
            throw new ArgumentOutOfRangeException();

        if (length == sizeArray)
        {
            sizeArray = sizeArray * 2;
            Array.Resize(ref myArray, sizeArray);
        }

        for (int i = length; i > indexToInsert-1 ; i--)
        {
            myArray[i] = myArray[i - 1];
        }

        myArray[indexToInsert - 1] = value;

        return true;
    }

    public int Length()
    {
        return this.length;
    }

    public int Capacity()
    {
        return this.sizeArray;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        for (int i = 0; i < this.length; i++)
        {
            yield return myArray[i];
        }
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        for (int i = 0; i < this.length; i++)
        {
            yield return myArray[i];
        }
    }

    public T this[int i]
    {
        get { return myArray[i]; }
        set { myArray[i] = value; }
    }
}

