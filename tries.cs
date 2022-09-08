using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Tries_namespace
{
    internal class Program
    {
        class Node {
            public bool flag { get; set; }
            public Dictionary<char, Node> chliden { get; set; }
            public Node(){
                chliden = new Dictionary<char, Node>();
                this.flag = false;
            }
        }

        class Tries {
            private Node root = new Node();


            public Node GetRoot(){
                return root;
            }

            public void PrintTries(){
                bool last = false;
                int i = 0;
                foreach(char key in root.chliden.Keys){
                    Console.WriteLine("+- "+key);
                    if(i == root.chliden.Count - 1){
                        last = true;
                    }
                    PrintTrie(root.chliden[key], "", last);
                    i++;
                }
            }
            private void PrintTrie(Node dic, string indent, bool last){
                int i = 0;
                bool tmp = false;
                indent += last ? "   " : "|  ";
                foreach (char key in dic.chliden.Keys)
                {
                    Console.WriteLine(indent + "+- " + key);
                    if (i == dic.chliden.Count - 1) tmp = true;
                    PrintTrie(dic.chliden[key], indent, tmp);
                    i++;
                }
            }

            public bool Contains(string word){
                Node current = root;
                foreach(char c in word){
                    if(!current.chliden.ContainsKey(c)) return false;
                    current = current.chliden[c];
                }
                return current.flag;
            }

            public void Inseart(string text){
                char[] s = text.ToCharArray();
                int i = 0;
                Node current = root;
                while(i < s.Length){
                    if(current.chliden.ContainsKey(s[i])){
                        current = current.chliden[s[i]];
                    }else{
                        Node node = new Node();
                        current.chliden.Add(s[i], node);
                        current = node;
                    }
                    i++;
                }
                current.flag = true;
            }
        }

        static void Main(string[] args)
        {
            Tries tries = new Tries();
            tries.Inseart("jame");
            tries.Inseart("jim");
            tries.Inseart("joy");
            tries.Inseart("jack");
            tries.Inseart("big");
            tries.Inseart("boy");
            tries.Inseart("java");
            if(tries.Contains("bi")){
                Console.WriteLine("Have");
            }else{
                Console.WriteLine("Dont");
            }
            tries.PrintTries();
        }
    }
}
// +-j
// |  +-a
// |  |  +-m
// |  |  |  +-e
// |  |  +-c
// |  |     +-k
// |  +-i
// |  |  +-m
// |  +-o
// |     +-y
// +-b
//    +-i
//       +-g