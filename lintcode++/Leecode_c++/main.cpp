#include "Interface.h"
using namespace SolutionSpace;
#define quest 28
int main() {
#pragma region  easy 
#if quest == 11
	string input = "2-4-(8+2-6+(8+4-(1)+8-10)) + 6";
	cout << "Result:" << mq.calculate(input) << endl;
#pragma endregion

#pragma region  median
#elif quest == 21
	vector<int> int_arr = { 137872,312786,640276,718243,995859,1188568,1229359,1549474,1843642,
							1931010,2242465,2430010,2549796,2902294,3396266,3521509,3961579,4297275,
							4613587,4614842,5074008,5094591,5327198,5860009,5945922,6341191,6655012,
							6816932,7084191,7109821,7640178,7936610,8026301,8054873,8545942,8989726,
							9224735,9244360,9331817,9406546,9898145,10239978,10764311,10962958,10972250,
							11128108,11319843,11515655,11818594,12283648,12403800,12631814,12885894,
							13202229,13229659,13362406,13446983,13639755,13783223,14210368,14292516,
							14787853,14808906,15269292,15393700,15607344,15858474,16279493,16281697,
							16551566,16646986,17129598,17270469,17599294,18119162,18371807,18492487,
							18611563,18843930,18927526,19164215,19465972,19637549,19973483,20262894,
							20600381,20736572,21174736,21475457,21824861,21986321,22213204,22705607,
							22708998,23140278,23212977,23378634,23677390,23708887,23728739 };

	int ans = cq.skipstones(int_arr, 100, 40, 53428902);//238356
#elif quest == 22
	string input = "abcab";
	vector<int> ans = mq.partitionLabels(input);
	for (int v : ans)
		cout << v << " ";
	cout << endl;
#elif quest == 23
	vector<vector<int>> input = { {1 ,5 ,7 },
									{3 ,7 ,8},
									{4 ,8 ,9 } };
	int ans = qu.kthSmallest(input, 2);
#elif quest == 24
	MedianQuest mq;
	vector<int> input = { 3,1,2,4,0,1,0,3,0,2 };// result = 6
	cout << "Result: " << mq.trapRainWater(input) << endl;
#elif quest == 25
	MedianQuest mq;
	vector<int> in = { 2, 3,1 ,2,4,3 }; //result = 2
	cout << mq.minimumSize(in, 7) << endl;
#elif quest == 26
	MedianQuest mq;
	string s = "WORLD";//result = 4
	cout<<"longest length with at most k: "<< mq.lengthOfLongestSubstringKDistinct(s, 4)<<endl;
#elif quest == 27
	MedianQuest mq;
	string str = "12";
	cout << mq.numDecodings(str) << endl;
#elif quest == 28
	MedianQuest mq;
	vector<int> nums = { 1,2,3 };
	NumArray na(nums);
	na.update(0, 10);
	cout << na.sumRange(0, 2) << endl;
#pragma endregion

#pragma region hard
#elif quest == 31
	HardQuest qu;
	vector<int> input = { 3,2, 4,1 };
	int k = 2;
	cout<<qu.mergeStones(input, k)<<endl;
#elif quest == 32
	HardQuest hq;//result = 270
	vector<int> input = { 4, 1, 5, 10 };
	cout << hq.maxCoins(input) << endl;
#elif quest == 33
	HardQuest hq;
	vector<int> input = { 1, 2, 3,4, 5 };
	int k = 2;
	cout << "Minimum Distance: " << hq.postOffice(input, k) << endl;
#elif quest == 34
	HardQuest hq;
	Connection c1("Acity", "Bcity", 1);
	Connection c2("Acity", "Ccity", 2);
	Connection c3("Bcity", "Ccity", 2);
	vector<Connection> input = { c1, c3 ,c2 };
	vector<Connection> output = hq.lowestCost(input);
	for (Connection con : output)
		cout << con.city1 << " " << con.city2 << " " << con.cost << endl;
#elif quest == 35
	HardQuest hq;
	vector<int> A = {1, 7, 11};
	vector<int> B = { 2, 4, 6 };
	cout << hq.kthSmallestSum(A, B, 3) << endl;
#pragma endregion

#pragma region contest
#elif quest == 41
	ContestQuest cq;
	vector<int> input = { 10,10,10,10,10,10,10,10,10,10,10,10 };
	cout << "PlayGames Results: " << cq.playgames(input) << endl;
#elif quest == 42
#pragma endregion
#endif
}