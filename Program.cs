using System.Reflection;
using System;
using LogDLL;

double perem = 512;
double osnov = 8;
//////////ДИНАМИЧЕСКОЕ ПОДКЛЮЧЕНИЕ//////////
Assembly asm = Assembly.LoadFrom("LogDLL.dll");
Type? program = asm.GetType("LogDLL.Class1", true,true);
object obj = Activator.CreateInstance(program);
if (program is not null)
{
    // получаем метод Main
    MethodInfo? getlog = program.GetMethod("GetLog");

    // вызываем метод Main
    object result = getlog.Invoke(obj, new object[] {perem, osnov});   
    Console.WriteLine("Логарифм '" + perem + "' по основанию '" + osnov + "' равен: '"+result+"'");
}




//////////СТАТИЧЕСКОЕ ПОДКЛЮЧЕНИЕ//////////
//Class1 LogDLL = new Class1();
//LogDLL.GetLog2(perem, osnov);