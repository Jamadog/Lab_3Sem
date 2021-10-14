using System;
using System.Collections.Generic;
using System.Linq;
// using System.IO;
 
internal static class Program{

    public static void Main(){
        MyList<char> a = new MyList<char> { 'f', 'g', 's'};
        MyList<char> b = new MyList<char> { 'l' };
        int x = 1;
        MyList<char> y = new MyList<char> { 'f', 'g', 't'};

        MyList<char> c = (a + b);//оперант добавления в конец
        MyList<char> d = (a - x);//оперант удаления последнего элемента

        if (a != y){
            Console.WriteLine("a не равен y");//оперант сравнения
        }
        Console.WriteLine("------------------------------");
        foreach (var item in c)
            Console.WriteLine(item);
        Console.WriteLine("------------------------------");
        foreach (var item in d)
            Console.WriteLine(item);
        Console.WriteLine("------------------------------");
    }
}
 
public class MyList<T> : List<T>{
    public static MyList<T> operator +(MyList<T> a, MyList<T> b){
        MyList<T> result = new MyList<T>();
        foreach (T item in a) result.Add(item);
        foreach (T item in b) result.Add(item);
        return result;
    }

    public static MyList<T> operator -(MyList<T> a, int x){
        MyList<T> result = new MyList<T>();
        foreach (T item in a) result.Add(item);
        result.RemoveAt(result.Count - x);
        return result;
    }

// Convert.ToInt32(a[])
// bool isEqual = list1.SequenceEqual(list2);

    public static bool operator ==(MyList<T> a, MyList<T> y){

        // bool result = a.SequenceEqual(y);
        // return result;

        if ((Convert.ToInt32(a[0]) == Convert.ToInt32(y[0])) && (Convert.ToInt32(a[1]) == Convert.ToInt32(y[1])) && (Convert.ToInt32(a[2]) == Convert.ToInt32(y[2])))
            return true;
        return false;
    }

    public static bool operator !=(MyList<T> a, MyList<T> y){
        
        // bool result = a.SequenceEqual(y);
        // if (result) {
        //     return false;
        // } else { 
        //     return true;
        // }
        
        if ((Convert.ToInt32(a[0])!= Convert.ToInt32(y[0])) || (Convert.ToInt32(a[1]) != Convert.ToInt32(y[1])) || (Convert.ToInt32(a[2]) != Convert.ToInt32(y[2])))
            return true;
        return false;
    }
    
}