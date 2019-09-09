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

	class Lintcode {
	public:
		Lintcode(){}
		~Lintcode() {}
	};
	class EasyQuest:public Lintcode
	{
	public:
		//int getImportance(vector<Employee*> employees, int id);

		void runTest(int questid);
	};
	class MedianQuest :public Lintcode
	{
	public:
		int calculate(string& s);
		vector<int> partitionLabels(string &input);
		int kthSmallest(vector<vector<int>> &matrix, int k);
		int trapRainWater(vector<int> &heights);
		int minimumSize(vector<int> &nums, int s);
		int lengthOfLongestSubstring(string &s);
		int lengthOfLongestSubstringKDistinct(string &s, int k);
		
		//dp
		int numDecodings(string &s);
		int longestPalindromeSubseq(string &s);
	};
	class HardQuest :public Lintcode {
	public:

		//dp 
		int maxCoins(vector<int> &nums);
		int mergeStones(vector<int> &stones, int K);
		int postOffice(vector<int> &A, int k);
		vector<Connection> lowestCost(vector<Connection>& connections);
		int kthSmallestSum(vector<int> &A, vector<int> &B, int k);
	};
	class ContestQuest :public Lintcode{
	public:
		int skipstones(vector<int> stones, int n, int m, int target);
		long long playgames(vector<int> A);
	};
}

