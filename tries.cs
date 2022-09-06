using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// https://youtu.be/LIrtBZRe0gE?list=PLzDfwQwcvDq7Il9dZgvsK_eL6ODJCwtaI
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
            public void PrintTrie(){
                bool last = false;
                int i = 0;
                foreach(char key in root.chliden.Keys){
                    Console.WriteLine("+- "+ key);
                    if(i == root.chliden.Count - 1) last = true;
                    PrintTries(root.chliden[key], "", last);
                    i++;
                }
            }
            private void PrintTries(Node dic, string indent, bool last){
                // Console.WriteLine(indent + "+- " + dic.Keys);
                // indent += last ? "  " : "|  ";
                // if (dic.Left != null && dic.Right != null)
                // {
                //     PrintTries(dic.Left, indent, false);
                //     PrintTries(dic.Right, indent, true);
                // }
                // else if (dic.Left != null) PrintTries(dic.Left, indent, true);
                // else if (dic.Right != null) PrintTries(dic.Right, indent, true);
            }
            public bool Contains(string word){
                Node current = root;
                foreach (char child in word){
                    if(current.chliden.ContainsKey(child)){
                        current = current.chliden[child];
                    }else{
                        return false;
                    }
                }
                return current.flag;
            }
            public void Inseart(string text){
                char[] s = text.ToCharArray();
                // if(dic.Conta)
                int i = 0;
                while (i != s.Length){
                    Console.WriteLine(s[i]);
                    i++;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Running");
            Tries tries = new Tries();
            tries.Inseart("Jouney");
        }
    }
}
