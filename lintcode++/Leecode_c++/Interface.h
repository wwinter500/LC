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

static unordered_map<int, int> questions;
namespace SolutionSpace
{	
	/*comman function*/
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
		vector<int> nn;
		NumArray(vector<int> nums) {
			nn = nums;
		}
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
		//int getImportance(vector<Employee*> employees, int id);
		void runTest(int questid);
	};

	class MedianQuest
	{
	public:
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
		static vector<Connection> lowestCost(vector<Connection>& connections);
		static int kthSmallestSum(vector<int> &A, vector<int> &B, int k);
		static vector<string> wordSearchII(vector<vector<char>> &board, vector<string> &words);

		//dp 
		static int maxCoins(vector<int> &nums);
		static int mergeStones(vector<int> &stones, int K);
		static int postOffice(vector<int> &A, int k);
	};
	class ContestQuest{
	public:
		static int skipstones(vector<int> stones, int n, int m, int target);
		static long long playgames(vector<int> A);
	};
}

