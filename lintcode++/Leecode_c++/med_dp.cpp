#include "Interface.h"

using namespace SolutionSpace;
int MedianQuest::longestPalindromeSubseq(string &s) {
	if (s.length() == 0)
		return 0;

	int n = s.length();
	vector<vector<int>> dp(n, vector<int>(n, 0));
	for (int i = 0; i < n; ++i) {
		dp[i][i] = 1;
	}

	for (int i = n - 2; i >= 0; --i) {
		for (int j = i + 1; j < n; ++j) {
			if (s[i] == s[j])
				dp[i][j] = dp[i + 1][j - 1] + 2;
			else
				dp[i][j] = max(dp[i + 1][j], dp[i][j - 1]);
		}
	}

	return dp[0][n - 1];
}

int MedianQuest::numDecodings(string &s) {
	if (s.length() == 0)
		return 0;

	int n = s.length();
	vector<int> dp(n + 1, 0);
	dp[0] = 1;
	dp[1] = (s[0] == '0' ? 0 : 1);
	for (int i = 2; i <= n; ++i) {
		if (s[i] != '0')
			dp[i] = dp[i - 1];
		if (s[i - 1] != '0' && stoi(s.substr(i - 1, 2)) <= 26) {
			dp[i] += dp[i - 2];
		}

		if (dp[i] == 0)
			return 0;
	}

	return dp[n];
}


