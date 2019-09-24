#include "Interface.h"

using namespace SolutionSpace;
void helper(vector<string> &ans, string &basic, int idx) {
	if (idx == basic.length()) {
		ans.push_back(basic);
		return;
	}
	
	char tmp = basic[idx];
	basic[idx] = '1';
	helper(ans, basic, idx + 1);
	
	basic[idx] = tmp;
	helper(ans, basic, idx + 1);
}

void helper2(vector<string> &ans, string &basic, int idx) {

}

vector<string> MedianQuest::generateAbbreviations(string &word) {
	if (word.length() == 0)
		return {};

	vector<string> basics;
	helper(basics, word, 0);

	vector<string> ans;
	for (auto str : basics) {
		ans.push_back(str);
	}

	for (int i = 0; i < basics.size(); ++i) {
		helper2(ans, basics[i], 0);
	}

	return ans;
}
