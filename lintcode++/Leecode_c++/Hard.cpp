#include "Interface.h"
using namespace SolutionSpace;

void HardQuest::run(int quest) {
	if (quest == 1798) {
		vector<int> input = { 3,2, 4,1 };
		int k = 2;
		cout << HardQuest::mergeStones(input, k) << endl;
	}
	else if (quest == 168) {//result = 270
		vector<int> input = { 4, 1, 5, 10 };
		cout << HardQuest::maxCoins(input) << endl;
	}
	else if (quest == 435) {
		vector<int> input = { 1, 2, 3,4, 5 };
		int k = 2;
		cout << "Minimum Distance: " << HardQuest::postOffice(input, k) << endl;
	}
	else if (quest == 629) {
		Connection c1("Acity", "Bcity", 1);
		Connection c2("Acity", "Ccity", 2);
		Connection c3("Bcity", "Ccity", 2);
		vector<Connection> input = { c1, c3 ,c2 };
		vector<Connection> output = HardQuest::lowestCost(input);
		for (Connection con : output)
			cout << con.city1 << " " << con.city2 << " " << con.cost << endl;
	}
	else if (quest == 465) {
		vector<int> A = { 1, 7, 11 };
		vector<int> B = { 2, 4, 6 };
		cout << HardQuest::kthSmallestSum(A, B, 3) << endl;
	}
	else if (quest == 132) {
		cout << "check code, no test case" << endl;
	}
	else if (quest == 635) {
		vector<vector<char>> board = { { 'a','b','c','d','e','f','g' },
		{ 'h','u','y','u','y','w','w' },
		{ 'g','h','i','h','j','u','i' },
		{ 'w','u','i','i','u','w','w' } };
		vector<string> words = { "efg","defi","gh","iuw","ww","iw","ghih","dasf","aaa" };
		cout << HardQuest::boggleGame(board, words) << endl;
	}
	else if (quest == 634) {
		vector<string> input = { "area", "lead", "wall", "lady", "ball" };
		auto res = HardQuest::wordSquares(input);
	}
	else if (quest == 639) {
		//TODO
	}
	else if (quest == 360) {
		int k = 3;
		vector<int> input = { 1,2,7,8,5 };
		auto ans = HardQuest::medianSlidingWindow(input, k);
		for (int v : ans)
			cout << v << " ";
		cout << endl;
	}
	else if (quest == 364) {
		vector<vector<int>> input = {{12,13,0,12},
									{13,4,13,12},
									{13,8,10,12},
									{12,13,12,12},
									{13,13,13,13}};
		cout << "Result: " << HardQuest::trapRainWater(input) << endl;
	}
	else if (quest == 122) {
		vector<int> input = { 2,1,5,6,5,3,5,7,6,2 };
		cout << "Result: " << HardQuest::largestRectangleArea(input) << endl;
	}
}


vector<string> HardQuest::wordsAbbreviation(vector<string> &dict) {
	return {};
}