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
	return true;
}