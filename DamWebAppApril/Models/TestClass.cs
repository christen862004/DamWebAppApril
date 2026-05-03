using System.Runtime.InteropServices;

namespace DamWebAppApril.Models
{

    public class TestClass
    {
        void Fun()
        {
            MyController c = new MyController();
            c.ViewData = "sdfhajf";//boxing
            string cc = c.ViewData.ToString();
            

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
