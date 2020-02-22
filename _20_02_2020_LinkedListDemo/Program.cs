using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_02_2020_LinkedListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ---===   Create Array String   ===---

            string[] words =
            {
                "Андрей",
                "Наталья",
                "Роман",
                "Катя"
            };

            #endregion

            #region ---===   Create Linked List   ===---

            // Создаем объект связанного списка и инициализируем его массивом строк.
            LinkedList<string> myLinkList = new LinkedList<string>(words);

            DisplayList(myLinkList, "Коллекция myLinkList:");

            #endregion
            Console.ReadKey();
            #region ---===   Add First Element   ===---

            // Добавляем в коллекцию строку “Евгения” на первую позицию.
            myLinkList.AddFirst("Евгения");

            DisplayList(myLinkList, "Добавляем строку 'Евгения' в начало списка:");

            #endregion
            Console.ReadKey();
            #region ---===   First Move To End   ===---

            // Переместим начальный элемент списка в его конец.
            LinkedListNode<string> tempList = myLinkList.First;

            myLinkList.RemoveFirst();
            myLinkList.AddLast(tempList);

            DisplayList(myLinkList, "Перемешаем первый элемент в конец списка:");

            #endregion
            Console.ReadKey();
            #region ---===   Update Last element   ===---

            // Изменяем последний элемент списка.
            myLinkList.RemoveLast();
            myLinkList.AddLast("Юлия");

            DisplayList(myLinkList, "Изменяем последний элемент списка на ‘Юлия’:");

            #endregion
            Console.ReadKey();
            #region ---===   Last Move To Start   ===---

            // Перемещаем последний элемент в начало.
            tempList = myLinkList.Last;

            myLinkList.RemoveLast();
            myLinkList.AddFirst(tempList);

            DisplayList(myLinkList, "Перемещаем последний элемент в начало списка:");

            #endregion
            Console.ReadKey();
            #region ---===   Search In Link List   ===---

            // Ищем строку ‘Юлия’.
            LinkedListNode<string> tempElement = myLinkList.FindLast("Юлия");

            IndicateNode(tempElement, "Ищем последнее вхождение в список строки 'Юлия':");

            #endregion
            Console.ReadKey();
            #region ---===   Add After Search   ===---

            // Добавляем строки 'Анна' и 'Илья' после строки 'Юлия'.
            myLinkList.AddAfter(tempElement, "Анна");
            myLinkList.AddAfter(tempElement, "Илья");

            IndicateNode(tempElement, "Добавляем строки 'Анна' и 'Илья' после строки 'Юлия':");

            #endregion
            Console.ReadKey();
            #region ---===   Add Before Search   ===---

            // Добавляем строки 'Иван' и 'Тарас' перед строкой 'Юлия':
            myLinkList.AddBefore(tempElement, "Иван");
            myLinkList.AddBefore(tempElement, "Тарас");

            IndicateNode(tempElement, "Добавляем строки 'Иван' и 'Тарас' перед строкой 'Юлия':");

            #endregion
            Console.ReadKey();
            #region ---===   Linked List To Array   ===---

            // создаем строковый массив и переносим туда все элементы из связанного списка.
            string[] newArray = new string[myLinkList.Count];
            myLinkList.CopyTo(newArray, 0);

            foreach (string s in newArray)
            {
                Console.WriteLine(s);
            }

            #endregion
            Console.ReadKey();
            #region ---===   Clear Link List  ==---

            // Очищаем все записи связанного списка.
            myLinkList.Clear();

            #endregion

        }

        private static void DisplayList(LinkedList<string> words, string message)
        {
            Console.WriteLine(message);

            foreach (string word in words)
            {
                Console.Write(word + "\t\t");
            }

            Console.WriteLine("\n");
        }

        // Метод сравнения строк. Используется для поиска строки внутри элемента.
        private static void IndicateNode(LinkedListNode<string> node, string message)
        {
            Console.WriteLine(message);

            if (node.List == null)
            {
                Console.WriteLine("строка '{0}' отсутствует в списке.\n",
                    node.Value);

                return;
            }

            StringBuilder result = new StringBuilder("(" + node.Value + ")");
            LinkedListNode<string> nodeP = node.Previous;

            while (nodeP != null)
            {
                result.Insert(0, nodeP.Value + " ");
                nodeP = nodeP.Previous;
            }

            node = node.Next;
            while (node != null)
            {
                result.Append(" " + node.Value);
                node = node.Next;
            }

            Console.WriteLine(result + "\n");
        }
    }
}
