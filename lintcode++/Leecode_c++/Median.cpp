#include "Interface.h"

using namespace SolutionSpace;
/*Lintcode 978*/
void updateStacks(stack<char> &ops, stack<int> &vals, int newv) {
	int target = newv;
	while (!vals.empty() && !ops.empty()) {
		if (ops.top() == '(')
			break;

		int tv = vals.top();
		vals.pop();

		if (ops.top() == '+')
			target += tv;
		else if (ops.top() == '-')
			target = tv - target;
		ops.pop();
	}

	vals.push(target);
}
int MedianQuest::calculate(string &s) {
	if (s.length() == 0)
		return 0;

	int idx = 0;
	stack<char> ops;
	stack<int> vals;
	while (idx < s.length()) {
		while (s[idx] == ' ')
			idx++;

		if (idx == s.length())
			break;

		//a. meet operator
		if (s[idx] == '(' || s[idx] == '+' || s[idx] == '-') {
			ops.push(s[idx++]);
			continue;
		}

		if (s[idx] == ')' && !vals.empty()) {
			if (!ops.empty() && ops.top() == '(')
				ops.pop();

			int tp = vals.top();
			vals.pop();

			updateStacks(ops, vals, tp);
			idx++;
			continue;
		}

		//b. meet values
		string str = "";
		while (idx < s.length() && s[idx] >= '0' && s[idx] <= '9')
			str += s[idx++];

		if (str != "")
			updateStacks(ops, vals, stoi(str));
	}

	if (vals.size() > 1) {
		int tp = vals.top();
		vals.pop();

		updateStacks(ops, vals, tp);
	}

	return vals.top();
}

/*Lintcode 1045*/
vector<int> MedianQuest::partitionLabels(string &input) {
	if (input.length() == 0)
		return {};
	
	int len = input.length();
	vector<pair<int, int>> range(26, {len, len});
	for (int i = 0; i < input.length(); ++i) {
		int idx = input[i] - 'a';
		if (range[idx].first == len) {
			range[idx].first = i;
			range[idx].second = i;
		}
		else {
			range[idx].second = i;
		}
	}

	sort(range.begin(), range.end());

	vector<int> ans;
	pair<int, int> tmp(-1, -1);
	for (auto p : range) {
		if (p.first == len)
			break;

		if (tmp.first == -1) {
			tmp.first = p.first;
			tmp.second = p.second;
			continue;
		}

		if (tmp.second < p.first) {
			ans.push_back(tmp.second - tmp.first + 1);
			tmp.first = p.first;
			tmp.second = p.second;
		}
		else{
			tmp.second = max(tmp.second, p.second);
		}
	}

	if (tmp.first != -1) {
		ans.push_back(tmp.second - tmp.first + 1);
	}
	return ans;
}
/*Lintcode 401 - kth smallest in sorted matrix*/
int MedianQuest::kthSmallest(vector<vector<int>> &matrix, int k) {
	//binary search max / min
	if (matrix.empty() || k <= 0)
		return 0;
}
int MedianQuest::trapRainWater(vector<int> &heights) {
	if(heights.empty())
		return 0;
	
	int ans = 0, leftmax = 0, rightmax = 0;
	int maxid = 0, maxv = 0;
	for (int i = 0; i < heights.size(); ++i) {
		if (heights[i] > maxv) {
			maxv = heights[i];
			maxid = i;
		}
	}

	for (int i = 0; i < maxid; ++i) {
		if (heights[i] > leftmax){
			leftmax = heights[i];
			continue;
		}

		ans += leftmax - heights[i];
	}

	for (int i = heights.size() - 1; i > maxid; --i) {
		if (heights[i] > rightmax) {
			rightmax = heights[i];
			continue;
		}

		ans += rightmax - heights[i];
	}

	return ans;
}
int MedianQuest::minimumSize(vector<int> &nums, int s) {
	if (nums.empty())
		return -1;

	int ans = nums.size() + 1;
	int left = 0, right = 0;
	int sum = 0;
	while (left < nums.size()) {
		while (right < nums.size() && sum < s) {
			sum += nums[right++];
		}
		
		while (left < right && sum >= s) {
			ans = min(ans, right - left);
			sum -= nums[left++];
		}

		if (right == nums.size())
			break;
	}

	if(ans == nums.size() + 1)
		return -1;

	return ans;
}
int MedianQuest::lengthOfLongestSubstring(string &s) {
	//length of longest substring without duplicate character
	if (s.length() == 0)
		return 0;

	unordered_map<char, int> mp;
	int left = 0, right = 0;
	int ans = 0;
	while (right < s.length()) {
		while (right < s.length()) {
			mp[s[right]]++;
			right++;
			if (mp[s[right - 1]] > 1)
				break;

			ans = max(ans, right - left);
		}

		while (left < right) {
			mp[s[left]]--;
			left++;

			if (mp[s[left - 1]] == 1)
				break;

			if (mp[s[left - 1]] == 0)
				mp.erase(s[left - 1]);
		}
	}

	return ans;
}
int MedianQuest::lengthOfLongestSubstringKDistinct(string &s, int k) {
	if (s.length() == 0)
		return 0;

	unordered_map<char, int> mp;
	int left = 0, right = 0;
	int ans = 0;
	while (right < s.length()) {
		while (right < s.length()) {
			mp[s[right]]++;
			right++;
			if (mp.size() > k)
				break;

			ans = max(ans, right - left);
		}

		while (left < right) {
			mp[s[left]]--;
			left++;

			if (mp[s[left - 1]] == 0)
				mp.erase(s[left - 1]);

			if (mp.size() == k)
				break;
		}
	}

	return ans;
}
/*Lintcode 668 - range dp*/
int MedianQuest::longestPalindromeSubseq(string &s){
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
/*Lintcode 512 - Decode ways*/
int MedianQuest::numDecodings(string &s) {
	if(s.length() == 0)
		return 0;

	int n = s.length();
	vector<int> dp(n, 0);
	dp[0] = (s[0] == '0' ? 0 : 1);
	for (int i = 1; i < n; ++i) {
		if (s[i] != '0')
			dp[i] = dp[i - 1];
		if (s[i - 1] != '0' && stoi(s.substr(i - 1, 2)) <= 26) {
			dp[i] += dp[i - 2];
		}

		if (dp[i] == 0)
			return 0;
	}
	
	return dp[n - 1];
}
/*Lintcode 840 - range sum query*/
void NumArray::update(int i, int val) {
	//update value of index i to val

}

int NumArray::sumRange(int i, int j) {
	//return sum of index from i to j
	return 0;
}