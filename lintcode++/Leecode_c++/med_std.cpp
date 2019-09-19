#include "Interface.h"
using namespace SolutionSpace;

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