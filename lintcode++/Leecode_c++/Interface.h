#pragma once
#include <iostream>
#include <vector>
#include <map>
#include <stack>
#include <string>
#include <unordered_set>
#include <queue>
#include <set>
#include <algorithm>
#include <functional>
#include <unordered_map>
using namespace std;

namespace SolutionSpace
{
	/*comman function*/
	struct UndirectedGraphNode {
		int label;
		vector<UndirectedGraphNode *> neighbors;
		UndirectedGraphNode(int x) : label(x) {};
	};
	struct Employee
	{
		int id, importance;
		vector<int> subordinates;
	};
	class Connection {
	public:
		string city1, city2;
		int cost;
		Connection() {}
		Connection(string city1, string city2, int cost) {
			this->city1 = city1;
			this->city2 = city2;
			this->cost = cost;
		}
	};
	class NumArray {
	public:
		//format of segment tree
		// 1 ~ n | 1 ~ n / 2 | n / 2 + 1 ~ n | 1 ~ n / 4 | ....... | 1 | 2 | 3
		vector<int> arr;
		vector<int> sums;
		NumArray(vector<int> nums);
		int sum(int idx);
		void update(int i, int val);
		int sumRange(int i, int j);
	};
	class TrieNode {
	public:
		TrieNode* child[26];
		bool isEnd;
		string str;
		set<int> fre;

		TrieNode(): isEnd(false), str(""){
			for (int i = 0; i < 26; ++i) {
				child[i] = NULL;
			}
		}
	};
	class Interface {
	public:
		Interface();
		~Interface();
		static void call(int quest);
		
	private:
		static string getQuestionInformation(int id);
	};

	class EasyQuest
	{
	public:
		static void run(int quest);
		static bool isIsomorphic(string &s, string &t);
	};

	class MedianQuest
	{
	public:
		static void run(int quest);
		static int calculate(string& s);
		static vector<int> partitionLabels(string &input);
		static int kthSmallest(vector<vector<int>> &matrix, int k);
		static int trapRainWater(vector<int> &heights);
		static int minimumSize(vector<int> &nums, int s);
		static int lengthOfLongestSubstring(string &s);
		static int lengthOfLongestSubstringKDistinct(string &s, int k);
		
		//dp
		static int numDecodings(string &s);
		static int longestPalindromeSubseq(string &s);
	};
	class HardQuest{
	public:
		static void run(int quest);

		static vector<Connection> lowestCost(vector<Connection>& connections);
		static int kthSmallestSum(vector<int> &A, vector<int> &B, int k);
		static vector<string> wordSearchII(vector<vector<char>> &board, vector<string> &words);
		static int boggleGame(vector<vector<char>> &board, vector<string> &words);
		static vector<vector<string>> wordSquares(vector<string> &words);

		//dp 
		static int maxCoins(vector<int> &nums);
		static int mergeStones(vector<int> &stones, int K);
		static int postOffice(vector<int> &A, int k);
	};
	class ContestQuest{
	public:
		static void run(int quest);

		static int skipstones(vector<int> stones, int n, int m, int target);
		static long long playgames(vector<int> A);
	};

	//Union find
	static vector<int> parents;
	static int np;
	static int Find(int a) {
		int tmp = a;
		while (a != parents[a]) {
			a = parents[a];
		}

		while (tmp != parents[tmp]) {
			int tp = parents[tmp];
			parents[tmp] = a;
			tmp = tp;
		}

		return a;
	}
	static inline bool Union(int a, int b) {
		int ap = Find(a);
		int bp = Find(b);

		if (ap != bp) {
			parents[ap] = bp;
			np--;
			return true;
		}

		return false;
	}
	

	static TrieNode* trie_root;
	static vector < vector<int>> dirs4 = { {0, 1},{0, -1},{1, 0},{-1, 0} };
	static vector < vector<int>> dirs8 = { {0, 1},{0, -1},{1, 0},{-1, 0},{1, -1},{-1, 1},{1, 1},{-1, -1} };

	static inline int lowbit(int x) { return x & (-x + 1); }
	static unordered_map<int, int> questions;
}

