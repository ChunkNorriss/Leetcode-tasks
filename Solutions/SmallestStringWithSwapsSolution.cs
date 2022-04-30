using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions
{
    public class SmallestStringWithSwapsSolution {
        public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
        {
            var connectedGroups = BuildConnectedGroups(s, pairs);

            var sb = new StringBuilder(s.Length);

            for (var i = 0; i < s.Length; i++)
            {
                var cg = connectedGroups.Find(x => x.Contains(i));

                var nextChar = cg?.GetNextChar() ?? s[i];
                sb.Append(nextChar);
            }
            
            
            return sb.ToString();
        }

        private static List<ConnectedGroup> BuildConnectedGroups(string s, IList<IList<int>> pairs)
        {
            var connectedGroups = new List<ConnectedGroup>();

            foreach (var pair in pairs)
            {
                var list = FindConnectedGroup(connectedGroups, pair);
                ConnectedGroup cg;
                if (list != null && list.Count > 1)
                {
                    cg = list[0];
                    for (var i = 1; i < list.Count; i++)
                    {
                        cg.Merge(list[i]);
                        connectedGroups.Remove(list[i]);
                    }
                }
                
                
                if (list.Count == 0)
                {
                    cg = new ConnectedGroup();
                    connectedGroups.Add(cg);
                }
                else
                {
                    cg = list[0];
                }

                cg.Add(pair);
            }

            foreach (var connectedGroup in connectedGroups)
                connectedGroup.BuildChars(s);

            return connectedGroups;
        }

        private static List<ConnectedGroup> FindConnectedGroup(List<ConnectedGroup> connectedGroups, IList<int> pair)
        {
            return connectedGroups.FindAll(cg => cg.Contains(pair));
        }
        
                
        private class ConnectedGroup
        {
            public ConnectedGroup()
            {
                Positions = new HashSet<int>();
            }

            private HashSet<int> Positions { get; set; }
            private char[] Chars { get; set; }
            private int Index { get; set; }

            public bool Contains(IList<int> positions)
            {
                foreach (var position in positions)
                {
                    if (Positions.Contains(position))
                        return true;
                }

                return false;
            }
            
            public void Merge(ConnectedGroup other)
            {
                Positions.UnionWith(other.Positions);
            }
            
            public bool Contains(int position)
            {
                return Positions.Contains(position);
            }
            
            public void Add(IList<int> pair)
            {
                Positions.Add(pair[0]);
                Positions.Add(pair[1]);
            }

            public char GetNextChar()
            {
                return Chars[Index++];
            }
            
            public void BuildChars(string s)
            {
                Chars = new char[Positions.Count];
                var charIdx = 0;
                foreach (var position in Positions) 
                    Chars[charIdx++] = s[position];
                
                Array.Sort(Chars);
            }
        }
    }
}