#include "Interface.h"
using namespace SolutionSpace;

int HardQuest::maxCoins(vector<int> &nums) {
	if (nums.empty())
		return 0;

	vector<int> nnums;
	nnums.push_back(1);
	for (int v : nums)
		nnums.push_back(v);
	nnums.push_back(1);


	int n = nnums.size();
	vector<vector<int>> dp(n, vector<int>(n + 2, 0));

	//dp[i][j] means maximun coins get from i + 1 to j - 1
	for (int i = n - 3; i >= 0; --i) {
		for (int j = i + 2; j < n; ++j) {
			int maxv = INT_MIN;
			for (int k = i + 1; k < j; ++k) {
				maxv = max(maxv, dp[i][k] + dp[k][j] + nnums[i] * nnums[k] * nnums[j]);
			}

			dp[i][j] = maxv;
		}
	}

	return dp[0][n - 1];
}

///
int helper(vector<int> stones, int left, int right, int k, unordered_map<pair<int, int>, int> &ump) {
	//Incorrect solution as memorized searching
	if (left > right)
		return 0;

	//if (ump.count({left,right}))
	//	return ump[{left, right}];

	if (right - left + 1 <= k) {
		int sum = 0;
		for (int i = left; i <= right; ++i)
			sum += stones[i];

		//ump.insert({ {left, right}, sum });
		return sum;
	}

	int minv = INT_MAX;
	for (int s = right - left; s >= k; --s) {
		int start = left, end = start + s - 1;
		while (end <= right) {
			int tmp = helper(stones, left, start - 1, k, ump) +
				helper(stones, start, end, k, ump) +
				helper(stones, end + 1, right, k, ump);

			start++;
			end++;
			if (tmp != -1 && tmp < minv)
				minv = tmp;
		}
	}

	//ump.insert({ {left, right}, minv });
	return minv;
}
int HardQuest::mergeStones(vector<int> &stones, int K) {
	if (stones.empty() || K <= 1)
		return 0;

	//check if input valid to generate final 1 result
	int n = stones.size();
	if (n % (K - 1) != 1)
		return 0;

	vector<int> sums(n + 1, 0);
	for (int i = 1; i <= n; ++i) {
		sums[i] = sums[i - 1] + stones[i - 1];
	}

	vector<vector<int>> dp(n, vector<int>(n, 0));
	for (int len = K; len <= n; ++len) {
		for (int i = 0; i + len < n; ++i) {
			int j = i + len - 1;
			dp[i][j] = INT_MAX;
			for (int t = i; t < j; t += K - 1) {
				dp[i][j] = min(dp[i][j], dp[i][t] + dp[t + 1][j]);
			}

			if ((j - i) % (K - 1) == 0)
				dp[i][j] += sums[j + 1] - sums[i];
		}
	}

	return dp[0][n - 1];
}

///TODO
int HardQuest::postOffice(vector<int> &A, int k) {
	if (A.empty() || k <= 0)
		return 0;

	int n = A.size();
	vector<vector<int>> dp(n, vector<int>(n, 0));

	return dp[0][n - 1];
}

///
vector<Connection> HardQuest::lowestCost(vector<Connection>& connections)
{
	//minimun spanning tree
	if (connections.empty())
		return{};

	vector<Connection> ans;
	int idx = 0;
	unordered_map<string, int> cities;
	map<int, set<vector<string>>> costs;//sort
	unordered_map<string, Connection> mp;

	for (Connection con : connections) {
		if (con.city1 == con.city2)
			continue;

		if (!cities.count(con.city1)) {
			cities[con.city1] = idx++;
		}

		if (!cities.count(con.city2)) {
			cities[con.city2] = idx++;
		}

		vector<string> p = { con.city1, con.city2 };
		costs[con.cost].insert(p);

		string ns = con.city1 + "_" + con.city2;
		mp[ns] = con;
	}

	np = idx;
	for (int i = 0; i < np; ++i) {
		parents.push_back(i);
	}

	for (auto p : costs) {
		for (vector<string> con : p.second) {
			if (Union(cities[con[0]], cities[con[1]]))
				ans.push_back(mp[con[0] + "_" + con[1]]);
		}
	}

	if (np > 1)
		return{};

	return ans;
}
