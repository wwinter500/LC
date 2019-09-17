#include "Interface.h"
using namespace std;
using namespace SolutionSpace;

void EasyQuest::run(int quest) {
	if (quest == 638) {
		string a = "egg", b = "add";
		cout << (EasyQuest::isIsomorphic(a, b) ? "True" : "False") << endl;
	}
}

bool EasyQuest::isIsomorphic(string &s, string &t) {
	if (s.length() == 0 || t.length() == 0)
		return false;

	unordered_map<char, char> st;
	unordered_map<char, char> ts;
	for (int i = 0; i < s.length(); ++i) {
		if (i >= t.length())
			return true;

		if (ts.count(t[i]) && ts[t[i]] != s[i])
			return false;

		if (st.count(s[i]) && st[s[i]] != t[i])
			return false;

		ts[t[i]] = s[i];
		st[s[i]] = t[i];
	}

	return true;
}

bool EasyQuest::doOverlap(Point &l1, Point &r1, Point &l2, Point &r2) {
	int x11 = l1.x, x12 = r1.x, x21 = l2.x, x22 = r2.x;
	int y11 = l1.x, y12 = r1.x, y21 = l2.y, y22 = r2.y;

	if (((x11 >= x21 && x11 < x22) || (x12 > x21 && x12 <= x22)) &&
		((y11 >= y21 && y11 < y22) || (y12 > y21 && y12 <= y22)))
		return true;

	return false;
}