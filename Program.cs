using System;
using System.Diagnostics;

namespace tras_log
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string filePath = "textfile.txt";
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.Listeners.Add(new TextWriterTraceListener(filePath));
            Trace.AutoFlush = true;

            Console.ForegroundColor = ConsoleColor.Yellow;
            bool isFileEmpty = !File.Exists(filePath) || new FileInfo(filePath).Length == 0;
            if (isFileEmpty)
            {
                Trace.TraceInformation($"| {DateTime.Now} | Файл логов пуст или не существует.");
            }
            else
            {
                Trace.TraceInformation($"| {DateTime.Now} | Файл логов уже содержит данные.");
            }
            Console.ForegroundColor= ConsoleColor.DarkGreen;

            Trace.TraceInformation($"| {DateTime.Now} | Программа запущена.");
            Console.WriteLine("Введите текст, сэр или мэм\n");
            string userInput = Console.ReadLine()!;
            
            Trace.WriteLine($"| {DateTime.Now} | Вы ввели: {userInput}");


            if (userInput.All(char.IsLetter) && userInput.Length >= 1)
            {
                Trace.WriteLine($"\n| {DateTime.Now} | Верно, в вашей строке онли буквы");
            }
            else if (userInput == "")
            {
                Trace.WriteLine($"\n| {DateTime.Now} | Зачем мне твоя пустая строка?");
            }
            else
            {
                Trace.WriteLine($"\n| {DateTime.Now} | Должны быть только буквы, инакомыслия не приемлем");
            }

            Console.ReadKey();
        }
    }
}
