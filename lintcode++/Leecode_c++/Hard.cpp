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
}

///
int HardQuest::kthSmallestSum(vector<int> &A, vector<int> &B, int k) {
	if (A.empty() || B.empty() || k <= 0)
		return 0;
	
	int n = A.size(), m = B.size();
	priority_queue<vector<int>, vector<vector<int>>, greater<vector<int>>> pq;
	pq.push({ A[0] + B[0], 0, 0 });
	for (int i = 1; i < k; ++i) {
		int ax = pq.top()[1], bx = pq.top()[2];
		if (ax == 0 && bx < m - 1)
			pq.push({ A[ax] + B[bx + 1], ax, bx + 1 });
		if (ax < n - 1) {
			pq.push({ A[ax + 1] + B[bx], ax + 1, bx });
		}

		pq.pop();
	}

	return pq.top()[0];
}

vector<string> HardQuest::wordsAbbreviation(vector<string> &dict) {
	return {};
}