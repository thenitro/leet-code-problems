using System;

namespace AddAndSearchWord
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var dict = new WordDictionary();

            dict.AddWord("bad");
            dict.AddWord("dad");
            dict.AddWord("mad");
            
            Console.WriteLine(false == dict.Search("pad"));
            Console.WriteLine(true == dict.Search("bad"));
            Console.WriteLine(true == dict.Search(".ad"));
            Console.WriteLine(true == dict.Search("b.."));
        }
    }
}

public class WordDictionary
{
    private class TrieNode
    {
        public TrieNode[] Children = new TrieNode[26];
        public string Item = String.Empty;
    }

    private TrieNode Root;
    
    /** Initialize your data structure here. */
    public WordDictionary() {
        Root = new TrieNode();
    }
    
    /** Adds a word into the data structure. */
    public void AddWord(string word)
    {
        TrieNode node = Root;

        foreach (var c in word)
        {
            var index = c - 'a';
            
            if (node.Children[index] == null)
            {
                node.Children[index] = new TrieNode();
            }

            node = node.Children[index];
        }

        node.Item = word;
    }
    
    /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
    public bool Search(string word)
    {
        return Match(word.ToCharArray(), 0, Root);
    }

    private bool Match(char[] chars, int k, TrieNode node)
    {
        if (k == chars.Length)
        {
            return !node.Item.Equals(string.Empty);
        }

        if (chars[k] != '.')
        {
            var index = chars[k] - 'a';

            return node.Children[index] != null && Match(chars, k + 1, node.Children[index]);
        }
        else
        {
            for (var i = 0; i < node.Children.Length; i++)
            {
                if (node.Children[i] != null)
                {
                    if (Match(chars, k + 1, node.Children[i]))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */