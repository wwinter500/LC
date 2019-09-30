#include "Interface.h"
using namespace SolutionSpace;

///
string MedianQuest::expressionExpand(string &s) {
	stack<char> stk_ch;
	
	for (char ch : s) {
		if (stk_ch.empty()) {
			stk_ch.push(ch);
			continue;
		}
			
		if ((ch >= 'a' && ch <= 'z') || 
			(ch >= 'A' && ch <= 'Z') || 
			(ch >= '0' && ch <= '9') ||
			(ch == '[')) {
			stk_ch.push(ch);
			continue;
		}

		string base = "", str = "";
		while (!stk_ch.empty() && stk_ch.top() != '[') {
			base += stk_ch.top();
			stk_ch.pop();
		}

		reverse(base.begin(), base.end());
		if (!stk_ch.empty()) {
			stk_ch.pop();
			string num = "";
			while (!stk_ch.empty() && (stk_ch.top() >= '0' && stk_ch.top() <= '9')) {
				num += stk_ch.top();
				stk_ch.pop();
			}

			int rep = 1;
			if (num != "") {
				reverse(num.begin(), num.end());
				rep = stoi(num);
			}


			for (int i = 0; i < rep; ++i) {
				str += base;
			}
		}
		else
			str = base;
		

		for (char c : str) {
			stk_ch.push(c);
		}
	}

	string ans = "";
	while (!stk_ch.empty()) {
		ans += stk_ch.top();
		stk_ch.pop();
	}

	reverse(ans.begin(), ans.end());
	return ans;
}

///
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

///
void adjustHeap(vector<int> &heap, int val) {
	heap.push_back(val);
	if (heap.size() == 1)
		return;

	int last = heap.size() - 1;
	while (last > 0) {
		int pare = (last - (last % 2 == 0 ? 2 : 1)) / 2;
		if (heap[last] >= heap[pare])
			break;

		int tmp = heap[pare];
		heap[pare] = heap[last];
		heap[last] = tmp;

		last = pare;
	}
}
void MedianQuest::heapify(vector<int> &A) {
	//O(n) solution
	if (A.empty())
		return;

	vector<int> tmp;
	for (int i = 0; i < A.size(); ++i) {
		adjustHeap(tmp, A[i]);
	}

	for (int i = 0; i < A.size(); ++i){
		A[i] = tmp[i];
	}
}

///
int MedianQuest::maxPathSum2(TreeNode * root) {
	if (root == NULL)
		return 0;

	int lefts = maxPathSum2(root->left);
	int rights = maxPathSum2(root->right);
	if (max(lefts, rights) < 0)
		return root->val;
	else
		return root->val + max(lefts, rights);
}