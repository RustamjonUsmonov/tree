using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Tree
    {
        private string value;
        private int count;
        private Tree left;
        private Tree right;

        // вставка
        public void Add(string value)
        
        {
            if (this.value == null)
                this.value = value;
            else
            {
                if (this.value.CompareTo(value) == 1)
                {
                    if (left == null)
                        this.left = new Tree();
                    left.Add(value);
                }
                else if (this.value.CompareTo(value) == -1)
                {
                    if (right == null)
                        this.right = new Tree();
                    right.Add(value);
                }
                else
                    throw new Exception("Узел уже существует");
            }

            this.count = Recount(this);
        }
        // поиск
        public Tree Search(string value)
        {
            if (this.value == value)
                return this;
            else if (this.value.CompareTo(value) == 1)
            {
                if (left != null)
                    return this.left.Search(value);
                else
                    throw new Exception("Искомого узла в дереве нет");
            }
            else
            {
                if (right != null)
                    return this.right.Search(value);
                else
                    throw new Exception("Искомого узла в дереве нет");
            }
        }
        // отображение в строку
        public string Display(Tree tr)
        {
            string result = "";
            if (tr.left != null)
                result += Display(tr.left);

            result += tr.value + " ";

            if (tr.right != null)
                result += Display(tr.right);

            return result;
        }
        // подсчет
        private int Recount(Tree t)
        {
            int count = 0;

            if (t.left != null)
                count += Recount(t.left);

            count++;

            if (t.right != null)
                count += Recount(t.right);

            return count;
        }
        // очистка
        public void Clear()
        {
            this.value = null;
            this.left = null;
            this.right = null;
        }
        // проверка пустоты
        public bool IsEmpty()
        {
            if (this.value == null)
                return true;
            else
                return false;
        }
        public void Remove(string value)
        {
            Tree tr = Search(value);
            string[] str1 = Display(tr).TrimEnd().Split(' ');
            string[] str2 = new string[str1.Length - 1];

            int i = 0;
            foreach (string s in str1)
            {
                if (s != value)
                    str2[i++] = s;
            }

            tr.Clear();
            foreach (string s in str2)
                tr.Add(s);

            this.count = Recount(this);
        }
        class Program
        {
            static void Main(string[] args)
            {
                Tree tr = new Tree();
                tr.Add("0");
                tr.Add("1");
                tr.Add("2");
                tr.Add("3");
                tr.Add("4");
                tr.Add("5");

                Console.WriteLine(tr.Display(tr));
                Tree s = tr.Search("2");
                Console.WriteLine(s.Display(s));
                Console.Read();
            }
        }
    }

}
