#include "Interface.h"

using namespace SolutionSpace;

void MedianQuest::run(int quest) {
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
		vector<vector<int>> input = { { 1 ,5 ,7 },{ 3 ,7 ,8 },{ 4 ,8 ,9 } };
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
		cout << "check code, no test case" << endl;
	}
	else if (quest == 477) {
		vector<vector<char>> board = { {'X','X','X','X'},
									   {'X','O','O','X'},
									   {'X','X','O','X'},
									   {'X','O','X','X'} };

		MedianQuest::surroundedRegions(board);

		for (auto vec : board) {
			for (auto ch : vec)
				cout << ch << " ";
			cout << endl;
		}
	}
	else if (quest == 575) {
		string s = "abs2[s]";
		cout << MedianQuest::expressionExpand(s) << endl;
	}
}

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

int MedianQuest::kthSmallest(vector<vector<int>> &matrix, int k) {
	//binary search max / min
	if (matrix.empty() || k <= 0)
		return 0;
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