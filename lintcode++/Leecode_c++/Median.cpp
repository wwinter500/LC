#include "Interface.h"

using namespace SolutionSpace;

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

int MedianQuest::numDecodings(string &s) {
	if(s.length() == 0)
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

vector<vector<int>> connectedSet(vector<UndirectedGraphNode*>& nodes) {
	if (nodes.empty())
		return {};

	int idx = 0;
	unordered_map<UndirectedGraphNode*, int> match;
	for (UndirectedGraphNode* pt : nodes) {
		if (!match.count(pt)) {
			match[pt] = idx;
			parents.push_back(idx++);
		}
	}

	np = match.size();

	for (UndirectedGraphNode* pt : nodes) {
		for (UndirectedGraphNode* nei : pt->neighbors) {
			Union(match[pt], match[nei]);
		}
	}

	unordered_map<int, set<int>> reorg;
	for (auto p : match) {
		int ap = Find(match[p.first]);

		reorg[ap].insert(p.first->label);
	}

	vector<vector<int>> res;
	for (auto st : reorg) {
		vector<int> vec;
		for (int v : st.second) {
			vec.push_back(v);
		}

		res.push_back(vec);
	}
	return res;
}

NumArray::NumArray(vector<int> nums) {
	arr = vector<int>(nums.size());
	for (int i = 0; i < nums.size(); ++i)
		arr[i] = nums[i];

	sums = vector<int>(nums.size() + 1, 0);
	for (int i = 0; i < nums.size(); ++i)
		update(i, nums[i]);
}
int NumArray::sum(int idx) {
	idx++;
	int res = 0;
	while (idx <= arr.size()) {
		res += sums[idx];
		idx -= lowbit(idx);
	}

	return res;
}
int NumArray::sumRange(int i, int j) {
	return sum(i) - sum(j - 1);
}
void NumArray::update(int i, int val) {
	int diff = val - arr[i];
	arr[i] = val;
	i += 1;
	while(i <= arr.size()){
		sums[i] += diff;
		i += lowbit(i);
	}
}