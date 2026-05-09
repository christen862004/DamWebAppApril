using DamWebAppApril.Controllers;
using DamWebAppApril.Repository;
using System.Runtime.InteropServices;

namespace DamWebAppApril.Models
{
    //SRP - OCP
    public interface ISort
    {
        void Sort(int[] arr);
    }
    public class BubbleSort:ISort
    {
        public void Sort(int[] arr)
        {

        }
    }
    public class SelectSort:ISort//extend
    {
        public void Sort(int[] arr) { }
    }

    public class ChirsSort : ISort
    {
        public void Sort(int[] arr)
        {
           
        }
    }
    //IOC MyList==>Bubble
    //DIP high (myList) depend on low level(bubble sort) ,interface
    public class MyList
    {
        int[] arr;
        ISort sortAl=null;// lossly
        public MyList(ISort _sortAl)//Depdency inject (dont create but ask about it (consurutr - method) 
        {
            arr = new int[10];
            sortAl = _sortAl;//inialize with specifc type
        }
        public void SortList()
        {
            sortAl.Sort(arr);
        }
    }
    public class TestClass
    {
        void Fun()
        {
            MyList l1 = new MyList(new BubbleSort());
            l1.SortList();//using bubble

            MyList l2 = new MyList(new SelectSort());
            l2.SortList();//using Selection

            MyList l3 = new MyList(new ChirsSort());
            l3.SortList();//using Selection
            //EmployeeController emp = new EmployeeController(new EmployeeRepository());
            //EmployeeController emp = new EmployeeController(new EmpMemoryRepo());




            //MyController c = new MyController();
            //c.ViewData = "sdfhajf";//boxing
            //string cc = c.ViewData.ToString();


            //Child<dynamic> c = new ();//Stop
            //c.Model.Name = "ahmed";//unboxing

            //Child2 c2=new Child2 ();
            //c2.Model=new Student();


            //dynamic no = 10;//int runtime detect type
            //dynamic   name = "ahmed";
            //dynamic std = new Student();
            //name= no + name;//exception
        }
    }





















    public class MyController
    {
        object _viewData;
        public object ViewData
        {
            get { return _viewData; }
            set { _viewData = value; }
        }
        public dynamic ViewBag
        {
            get { return _viewData; }
            set { _viewData = value; }
        }
    }

    class Parent<T>//open type
    {
        public T Model { get; set; }
    }
    class Child<T>: Parent<T> 
    {
        public int xyz { get; set; }
    }
    class Child2 : Parent<dynamic>
    {

    }
}
