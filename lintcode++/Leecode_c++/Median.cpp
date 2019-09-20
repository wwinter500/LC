#include "Interface.h"

using namespace SolutionSpace;

void MedianQuest::run(int quest) {
	if (quest == 978) {
		string input = "2-4-(8+2-6+(8+4-(1)+8-10)) + 6";
		cout << "Result:" << MedianQuest::calculate(input) << endl;
	}
	else if (quest == 1045) {
		string input = "abcab";
		vector<int> ans = MedianQuest::partitionLabels(input);
		for (int v : ans)
			cout << v << " ";
		cout << endl;
	}
	else if (quest == 401) {
		vector<vector<int>> input = { { 1 ,5 ,7 },{ 3 ,7 ,8 },{ 4 ,8 ,9 } };
		int ans = MedianQuest::kthSmallest(input, 2);
		cout << ans << endl;
	}
	else if (quest == 363) {
		vector<int> input = { 3,1,2,4,0,1,0,3,0,2 };// result = 6
		cout << "Result: " << MedianQuest::trapRainWater(input) << endl;
	}
	else if (quest == 406) {
		vector<int> in = { 2, 3,1 ,2,4,3 }; //result = 2
		cout << MedianQuest::minimumSize(in, 7) << endl;
	}
	else if (quest == 384) {
		string s = "WORLD";//result = 4
		cout << "longest length with at most k: " << MedianQuest::lengthOfLongestSubstringKDistinct(s, 4) << endl;
	}
	else if (quest == 512) {
		string str = "12";
		cout << MedianQuest::numDecodings(str) << endl;
	}
	else if (quest == 386) {
		string str = "abesxswas";
		int k = 3;
		cout << MedianQuest::lengthOfLongestSubstringKDistinct(str, k) << endl;
	}
	else if (quest == 668) {
		string str = "fnwofnaobmaowmofwo";
		cout << MedianQuest::longestPalindromeSubseq(str) << endl;
	}
	else if (quest == 477) {
		vector<vector<char>> board = { {'X','X','X','X'},
									   {'X','O','O','X'},
									   {'X','X','O','X'},
									   {'X','O','X','X'} };

		MedianQuest::surroundedRegions(board);

		for (auto vec : board) {
			for (auto ch : vec)
				cout << ch << " ";
			cout << endl;
		}
	}
	else if (quest == 575) {
		string s = "abs2[s]";
		cout << MedianQuest::expressionExpand(s) << endl;
	}
	else if (quest == 779) {
		string str = "word";
		auto re = MedianQuest::generateAbbreviations(str);
		for (string st : re)
			cout << st << " ";
		cout << endl;
	}
	else if (quest == 431 || quest == 840 || quest == 105 || quest == 616) {
		cout << "check code, no test case" << endl;
	}
}


int MedianQuest::kthSmallest(vector<vector<int>> &matrix, int k) {
	//binary search max / min
	if (matrix.empty() || k <= 0)
		return 0;
}
