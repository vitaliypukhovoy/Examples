using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    class Program
    {
        /**/

        public void method()
        {
            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += i;
            }
            // Console.WriteLine("Sum of " + i + " numbers is " + sum);
        }

        static void f(ref int a, out int bb)
        {
            //a = 10 + b;
            bb = 10 + a;
            Console.WriteLine(bb);
        }

        //В методе f переменная b должна быть инициализирована до ее использования 3566 / 9689
        //В методе f необходимо обязательно присвоить значение переменной b 5215 / 9689
        //Переменная b должна быть проинициализирована целочисленным значением или не инициализирована вовсе 5006 / 9689
        //Перед вызовом метода f переменная а должна быть проинициализирована

        static bool Method1()
        {
            Console.WriteLine("in Method1");
            return false;
        }
        static bool Method2()
        {
            Console.WriteLine("in Method2");
            return true;
        }


        int[] someArray1 = new int[4];
        int[] someArray2 = { 1, 2, 3, 4 };
        // int[4] someArray3; 
        int[] someArray4 = new int[4] { 1, 2, 3, 4 };
        // int someArray[] = new int[4]; 
        int[] someArray5 = new int[] { 1, 2, 3, 4 };

        public void Array()
        {
            ArrayList list = new ArrayList();
            list.Add(new Object());
            list.Add(new Exception());
            list.Add(new Random().Next(10));
            list.Add(new ArrayList());
        }
        internal sealed class SomeGenericClass<T> where T : struct  // or new()
        {
            public static T SomeMethod()
            {
                return new T();
            }
        }



        public void TestMethod()
        {
            int k = 1;
            Console.WriteLine(k++ + ++k);

            Console.ReadLine();
        }
        static void Main(string[] args)
        {


            int a;
            // int b = 5.0;
            //  f(ref a, out bb);

            if (Method1() & Method2()) // Оператор & всегда вычисляет значение обоих операндов
            {
                Console.WriteLine("inside if");
            }
            //TestMethod();
            //Array();

            Decimal x = Decimal.MaxValue;

            //unchecked
            //{
            //    x++;
            //}

            if (x == Decimal.MinValue)
                Console.WriteLine("MinValue");
            else if (x == Decimal.MaxValue)
                Console.WriteLine("MaxValue");
            else
                Console.WriteLine("Something else");



            string s;// need s=null or "kjkjkj"
            // s += "string";//unassigned local variable
            // Console.WriteLine(s); 


            System.Collections.ArrayList list =
    new System.Collections.ArrayList();  // list is a reference type
            int n = 777;                              // n is a value type
            list.Add(n);
            list.Add(444);
            list.Add(555);
            list.Add(66);// n is boxed
            n = (int)list[0];
            Console.WriteLine("{0}", n);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            List<int> list2 = new List<int>();
            list2.Add(1);
            list2.Add(2);
            list2.Add(3);
            list2.Add(4);
            list2.Add(5);

            var n2 = list2[0];
            Console.WriteLine("{0}", n2);

            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }


            var aa = new A();
            aa.Print();

            c c = new c();
            c.m1();

        }
    }


    abstract class B
    {
        public virtual void Print()
        {
            Console.WriteLine("This is B");
        }
    }

    class A : B
    {
        private new void Print()
        {
            Console.WriteLine("This is A");
        }
    }
}


class a
{
    public virtual void m1()
    {
        Console.WriteLine("This is a");
    }
}
class b : a
{
    public override void m1()
    {
        Console.WriteLine("This is b");
    }
}
class c : b
{
    public c()
    {
        base.m1();
    }
    public override void m1()
    {


        Console.WriteLine("This is c");
        /* програмный код */
    }

    public interface IUIControl
    {
        void Paint();
    }
    public interface IEditBox : IUIControl
    {
        new void Paint();
    }

    public interface IDropList : IUIControl
    {
        new void Paint();
    }
    //Из класса C невозможно обратиться к методу m1() класса A для одного и того же объекта 3629 / 7122
    //Из класса C можно получить доступ к методу m1() класса B используя вызов base.m1()




    interface A2
    {
        void f();
    }

    interface B2
    {
        void f();
    }

    class C2 : A2, B2
    {
        void A2.f() { }
        void B2.f() { }
    }
    //Это явная реализация интерфейсов.
    //Такой код позволит сделать разные реализации метода f для каждого из реализованных интерфейсов.

    interface IBase
    {
        void Print();
    }

    interface IDerived : IBase
    {
        void PrintFormatted();
    }

    class A : IDerived
    {
        public void PrintFormatted()
        {
            System.Console.WriteLine("A.PrintFormatted()");
        }

        void IBase.Print() { }
        void IDerived.PrintFormatted()
        {
            System.Console.WriteLine("IDerived.PrintFormatted()");
        }
        //Интерфейс IDerived наследует Print() из IBase. Поэтому класс A должен реализовать метод Print();
    }
}