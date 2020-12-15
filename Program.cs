using System;
using System.Reflection;
using System.IO;

namespace oop_12
{

    public class Reflector
    {
        static StreamWriter sw = new StreamWriter("outputLog.txt", true);
        public static void GetAssemblyName(string str)
        {
            Type type = Type.GetType(str);
            Console.WriteLine(Assembly.GetAssembly(type).GetName().Name);
            Console.WriteLine();            
            sw.WriteLine(Assembly.GetAssembly(type).GetName().Name);
            sw.WriteLine();
        }

        public static void getPublicConstructor(string str)
        {
            var type = Type.GetType(str);
            ConstructorInfo[] c = type.GetConstructors();
            foreach (ConstructorInfo ctor in c)
                Console.WriteLine(ctor); ;
            Console.WriteLine();
            foreach (ConstructorInfo ctor in c)
                sw.WriteLine(ctor); ;
            sw.WriteLine();
        }

        public static void ClassPublicMethods(string str)
        {
            Type type = Type.GetType(str);
            MethodInfo[] c = type.GetMethods(); // BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public
            foreach (MethodInfo m in c)
                Console.WriteLine(m);
            Console.WriteLine();
            foreach (MethodInfo m in c)
                sw.WriteLine(m);
            sw.WriteLine();
        }

        public static void ClassFieldsAndProperties(string str)
        {
            Type type = Type.GetType(str);
            FieldInfo[] c = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (FieldInfo f in c)
                Console.WriteLine(f);
            Console.WriteLine();
            foreach (FieldInfo f in c)
                sw.WriteLine(f);
            sw.WriteLine();
            PropertyInfo[] cc = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (PropertyInfo p in cc)
                Console.WriteLine(p);
            Console.WriteLine();
            foreach (PropertyInfo p in cc)
                sw.WriteLine(p);
            sw.WriteLine();
        }

        public static void ClassInterfaces(string str)
        {
            Type type = Type.GetType(str);
            Type[] c = type.GetInterfaces();
            foreach (Type t in c)
                Console.WriteLine(t);
            Console.WriteLine();
            foreach (Type t in c)
                sw.WriteLine(t);
            sw.WriteLine();
        }

        public static void ClassMethodsWithType(string str, string st)
        {
            Type type = Type.GetType(str);
            MethodInfo[] c = type.GetMethods();
            foreach (MethodInfo m in c)
            {
                ParameterInfo[] cc = m.GetParameters();
                foreach (ParameterInfo p in cc)
                    if (p.ParameterType.ToString() == st)
                    {
                        Console.WriteLine(m);
                        sw.WriteLine(m);
                    }
            }
        }

        static public object Invoke(string str, string st, int p1, int p2)
        {
            Type type = Type.GetType(str);
            object o = Activator.CreateInstance(type);
            MethodInfo m = type.GetMethod(st);
            return m.Invoke(o, new object[] { p1, p2 });
        }

        static public T Create<T>()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
    }

    public class Mmath
    {
        public void Pow(double x, double y)
        {
            Console.WriteLine( Math.Pow(x, y));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var className = Console.ReadLine();
            Reflector.getPublicConstructor(className);
            Reflector.ClassPublicMethods(className);
            Reflector.ClassPublicMethods(className);
            Reflector.ClassFieldsAndProperties(className);
            Reflector.ClassInterfaces(className);
            Reflector.ClassMethodsWithType(className, "System.Int32");

            Reflector.Invoke("oop_12.Mmath", "Pow", 4, 5);

            object s = Reflector.Create<object>();
            Console.WriteLine(s);
        }
    }
}
