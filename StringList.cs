/*==========================================================
 * 
 * Currently contained classes:
 * StringList -- Encapsulates an ArrayList to deal specificaly with strings and string[]
 * 
 * 
 * 
 *///==========================================================

using System;
using System.Collections;

//Helper classes meant to speed up development 
namespace StudyPlan
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	/// 

	public class StringList
	{
		ArrayList m_alMain;
		//constructor
		public StringList()
		{
			m_alMain = new ArrayList();
		}
		//destructor
		~ StringList()
		{
			m_alMain.Clear();
		}
		//add an item to the end of the list
		//returns the number of items in the list
		public int Add(string s)
		{
			m_alMain.Add(s);
			return m_alMain.Count;
		}
		public StringList AddRange(StringList sl)
		{
			m_alMain.AddRange(sl.m_alMain);
			return null;
		}
		//insert a string into the list only if the same string hasn't been added yet
		public int AddNoDuplicate(string s)
		{
			if(m_alMain.IndexOf(s) == -1)
				m_alMain.Add(s);
			return m_alMain.Count;
		}
		//insert an item at the desired position
		//will throw an error if index is out of range
		//returns the number of items in the list
		public int Insert(int index, string s)
		{
			m_alMain.Insert(index, s);
			return m_alMain.Count;
		}
		//remove an item from the list
		//returns the number of items in the list
		public int Remove(String s)
		{
			m_alMain.Remove(s);
			return m_alMain.Count;
		}
		public int Replace(string sFind, string sReplace)
		{
			int index = m_alMain.IndexOf(sFind);
			if(index > -1)
			{
				m_alMain.RemoveAt(index);
				m_alMain.Insert(index, sReplace);
			}
			return m_alMain.Count;
		}
		//remove all items from the list
		public void Clear()
		{
			m_alMain.Clear();
		}
		//indexer
		public String this[int index]
		{
			get
			{
				return (string)m_alMain[index];
			}
			set
			{
				if(index >= m_alMain.Count)
					m_alMain.Add(value);
				else
					m_alMain[index] = value;
			}
		}
		//ToString() override
		//Return the contents of the list with the items seperated by a new line
		public override string ToString()
		{
			string sRHS = "";
			int index = 0;
			while(index < m_alMain.Count)
			{
				sRHS += (string)m_alMain[index++] + "\n";
			}
			return sRHS;
		}
		//return the contents of the list seperated by the given seperator string
		public String ToString(string sSeperator)
		{
			string sRHS = "";
			int index = 0;
			while(index < m_alMain.Count)
			{
				sRHS += (string)m_alMain[index++];
				if(index < m_alMain.Count)
					sRHS += sSeperator;
			}
			return sRHS;
		}
		//Sort the string in the array
		public void Sort()
		{
			m_alMain.Sort();
		}
		//Properties
		//Count
		//returns the number of items in the list
		public int Count
		{
			get
			{
				return m_alMain.Count;
			}
		}
		/// <summary>
		/// Finds the index of a given string.
		/// </summary>
		/// <param name="sFind">String to find the index of.</param>
		/// <returns>The index of sFind or -1 if it doesn't exist.</returns>
		public int IndexOf(string sFind)
		{
			return m_alMain.IndexOf(sFind);
		}
		//conversion operators
		//convert a StringList to a string[]
		public static implicit operator string[](StringList sl)
		{
			string[] sLHS = new string[sl.m_alMain.Count];
			int index = 0;
			while(index < sl.m_alMain.Count)
			{
				sLHS[index] = (string)sl.m_alMain[index];
				index++;
			}
			return sLHS;
		}
		//convert a string[] to a StringList
		public static implicit operator StringList(string[] sa)
		{
			StringList sl = new StringList();
			for(int index = 0; index < sa.Length; index++)
			{
				sl.Add(sa[index]);
			}
			return sl;
		}
		//convert a string[] to a StringList
		public static implicit operator StringList(object[] sa)
		{
			StringList sl = new StringList();
			for(int index = 0; index < sa.Length; index++)
			{
				sl.Add(sa[index].ToString());
			}
			return sl;
		}
	}
}
