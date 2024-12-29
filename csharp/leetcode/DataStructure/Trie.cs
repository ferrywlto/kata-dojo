public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; } = new();
    public bool IsEndOfWord { get; set; }
}

public class Trie
{
    private readonly TrieNode _root = new();

    public void Insert(string word)
    {
        var node = _root;
        foreach (var ch in word)
        {
            if (!node.Children.ContainsKey(ch))
            {
                node.Children[ch] = new TrieNode();
            }
            node = node.Children[ch];
        }
        node.IsEndOfWord = true;
    }

    public bool Search(string word)
    {
        var node = _root;
        foreach (var ch in word)
        {
            if (!node.Children.TryGetValue(ch, out var value))
            {
                return false;
            }
            node = value;
        }
        return node.IsEndOfWord;
    }

    public bool SearchReverse(string word)
    {
        var node = _root;
        for(var i = word.Length - 1; i>=0; i--)
        {
            var ch = word[i];
            if (!node.Children.TryGetValue(ch, out var value))
            {
                return false;
            }
            node = value;
        }
        return node.IsEndOfWord;
    }
}
