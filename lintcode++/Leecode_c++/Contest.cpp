#include "Interface.h"
using namespace SolutionSpace;

void ContestQuest::run(int quest) {
	if (quest == 40001) {
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

int ContestQuest::skipstones(vector<int> stones, int n, int m, int target) {
	//serials dp or divident dp??
	if (stones.empty() || m >= n)
		return target;

	vector<int> nn;
	nn.push_back(0);
	for (int v : stones)
		nn.push_back(v);
	nn.push_back(target);

	vector<vector<int>> dp(n + 2, vector<int>(n + 2, 0));
	for (int len = m; len <= n; ++len) {
		for (int i = 0; i <= n + 2 - len; ++i) {
						
		}
	}

	return dp[0][n + 1];
}
long long ContestQuest::playgames(vector<int> A) {
	//binary search
	if (A.empty())
		return 0;
	
	int maxv = 0;
	for (int v : A) {
		maxv = max(maxv, v);
	}

	long long left = 0, right = 2 * maxv;
	
	while (left < right) {
		long long med = left + (right - left) / 2;
		long long cnt = 0;//round of plays when one finish his rounds
		for (long long a : A) {
			cnt += max(med - a, (long long)0);
		}

		if (cnt >= med)
			right = med;
		else
			left = med + 1;
	}

	return max(left, (long long)maxv);
}