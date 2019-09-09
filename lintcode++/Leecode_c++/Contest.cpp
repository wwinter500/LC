#include "Interface.h"
using namespace SolutionSpace;

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