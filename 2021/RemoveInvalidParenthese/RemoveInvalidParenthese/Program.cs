using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoveInvalidParenthese
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
        }
    }
}

public class Solution
{
    private HashSet<string> validExpressions = new HashSet<string>();
    private int minimumRemoved = int.MaxValue;

    public IList<string> RemoveInvalidParentheses(string s)
    {
        Helper(s, 0, 0, 0, new StringBuilder(), 0);
        return validExpressions.ToArray();
    }

    private void Helper(string s, int index, int leftCount, int rightCount, StringBuilder expression, int removedCount)
    {
        if (index == s.Length)
        {
            if (leftCount == rightCount)
            {
                if (removedCount <= minimumRemoved)
                {
                    var possibleAnswer = expression.ToString();

                    if (removedCount < minimumRemoved)
                    {
                        validExpressions.Clear();
                        minimumRemoved = removedCount;
                    }
                    
                    validExpressions.Add(possibleAnswer);
                }
            }
        }
        else
        {
            var currentCharacter = s[index];
            var length = expression.Length;

            if (currentCharacter != '(' && currentCharacter != ')')
            {
                expression.Append(currentCharacter);
                Helper(s, index + 1, leftCount, rightCount, expression, removedCount);
                expression.Remove(length, 1);
            }
            else
            {
                Helper(s, index + 1, leftCount, rightCount, expression, removedCount + 1);
                expression.Append(currentCharacter);

                if (currentCharacter == '(')
                {
                    Helper(s, index + 1, leftCount + 1, rightCount, expression, removedCount);
                }
                else if (rightCount < leftCount)
                {
                    Helper(s, index + 1, leftCount, rightCount + 1, expression, removedCount);
                }

                expression.Remove(length, 1);
            }
        }
    }
}