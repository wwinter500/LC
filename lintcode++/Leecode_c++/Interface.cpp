#include "Interface.h"
using namespace SolutionSpace;

Interface::Interface() {
	questions[978] = 21;
	questions[1045] = 22;
	questions[401] = 23;
	questions[363] = 24;
	questions[406] = 25;
	questions[384] = 26;
	questions[512] = 27;
	questions[386] = 28;
	questions[668] = 29;
	questions[431] = 30;

	questions[1798] = 31;
	questions[168] = 32;
	questions[435] = 33;
	questions[629] = 34;
	questions[465] = 35;
	questions[132] = 36;
	questions[635] = 37;
	questions[840] = 38;
	questions[634] = 39;

	questions[40001] = 41;
	questions[40002] = 42;
}

Interface::~Interface() {};

void Interface::call(int quest) {
	if (!questions.count(quest)) {
		cout << "Did not record this question" << endl;
		return;
	}

	int cp = questions[quest];
	int level = 1;
	while (cp > 0) {
		level = (cp % 10);
		cp /= 10;
	}

	//question information	
	cout << "Question: " << quest << endl;
	cout << "Description:" << getQuestionInformation(quest) << endl;

	if (level == 1)
		cout << "Level: " << "EASY" << endl;
	else if (level == 2)
		cout << "Level: " << "MEDIAN" << endl;
	else if (level == 3)
		cout << "Level: " << "HARD" << endl;
	else if (level == 4)
		cout << "Level: " << "CONTEST" << endl;

	//run solution
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
		vector<vector<int>> input = { {1 ,5 ,7 },{3 ,7 ,8},{4 ,8 ,9 } };
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
	else if (quest == 431) {
		cout << "check code, no test case" << endl;
	}
	else if (quest == 840) {
	}
	//Hard Section
	else if (quest == 1798) {
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
		vector<vector<char>> board = { {'a','b','c','d','e','f','g'},
									   {'h','u','y','u','y','w','w'},
									   {'g','h','i','h','j','u','i'},
									   {'w','u','i','i','u','w','w'} };
		vector<string> words = { "efg","defi","gh","iuw","ww","iw","ghih","dasf","aaa" };
		cout << HardQuest::boggleGame(board, words) << endl;
	}
	else if (quest == 634) {
		vector<string> input = { "area", "lead", "wall", "lady", "ball" };
		auto res = HardQuest::wordSquares(input);
	}
	//Contest section
	else if (quest == 40001) {
		vector<int> input = { 10,10,10,10,10,10,10,10,10,10,10,10 };
		cout << ContestQuest::playgames(input) << endl;
	}
	else if (quest == 40002) {
		vector<int> int_arr = { 137872,312786,640276,718243,995859,1188568,1229359,1549474,1843642,1931010,2242465,2430010,2549796,2902294,3396266,3521509,3961579,4297275,4613587,4614842,5074008,5094591,5327198,5860009,5945922,6341191,6655012,
							6816932,7084191,7109821,7640178,7936610,8026301,8054873,8545942,8989726,9224735,9244360,9331817,9406546,9898145,10239978,10764311,10962958,10972250,11128108,11319843,11515655,11818594,12283648,12403800,12631814,12885894,
							13202229,13229659,13362406,13446983,13639755,13783223,14210368,14292516,14787853,14808906,15269292,15393700,15607344,15858474,16279493,16281697,16551566,16646986,17129598,17270469,17599294,18119162,18371807,18492487,
							18611563,18843930,18927526,19164215,19465972,19637549,19973483,20262894,20600381,20736572,21174736,21475457,21824861,21986321,22213204,22705607,22708998,23140278,23212977,23378634,23677390,23708887,23728739 };

		int ans = ContestQuest::skipstones(int_arr, 100, 40, 53428902);//result = 238356
		cout << ans << endl;
	}
}

string Interface::getQuestionInformation(int id) {
	string res = "";
	switch (id) {
	case 132:
		res = "word search II"; break;
	case 978:
		res = "Calculation operator"; break;
	case 1045:
		res = "Partition Labels"; break;
	case 401:
		res = "kth smallest in sorted matrix"; break;
	case 363:
		res = "trap rainwater - 1D"; break;
	case 406:
		res = "Minimun size subarray sum"; break;
	case 384:
		res = "length of longest substring without duplicate character"; break;
	case 386:
		res = "length of longest substring with at most unique character"; break;
	case 512:
		res = "Decode ways"; break;
	case 431:
		res = "group of connection on Undirection Graph"; break;
	case 840:
		res = "range sum with mutable -- segment tree"; break;

	//hard section
	case 1798:
		res = "minimum cost to merge stones - dp"; break;
	case 168:
		res = "burst balloons - dp"; break;
	case 435:
		res = "post office problem - serials dp"; break;
	case 629:
		res = "minimun spanning tree"; break;
	case 465:
		res = "kth sum within two sorted array"; break;
	case 668:
		res = "longest subseq of palindron - range dp"; break;
	case 635:
		res = "boggle game -- trie tree"; break;
	case 634:
		res = "find all words squares"; break;

	//contest section
	case 40001:
		res = "play games"; break;
	case 40002:
		res = "skip stones"; break;
	default:
		res = "Unkown ID";
		break;
	}

	return res;
}
