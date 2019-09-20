#include "Interface.h"

using namespace SolutionSpace;

int MedianQuest::trapRainWater(vector<int> &heights) {
	if (heights.empty())
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
		if (heights[i] > leftmax) {
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

vector<int> MedianQuest::partitionLabels(string &input) {
	if (input.length() == 0)
		return{};

	int len = input.length();
	vector<pair<int, int>> range(26, { len, len });
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
		else {
			tmp.second = max(tmp.second, p.second);
		}
	}

	if (tmp.first != -1) {
		ans.push_back(tmp.second - tmp.first + 1);
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

	if (ans == nums.size() + 1)
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