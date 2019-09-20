#include "Interface.h"
using namespace SolutionSpace;
#define quest 36
int main() {
	Interface it;
	it.call(105);
#if quest == 28
	MedianQuest mq;
	vector<int> nums = { 1,2,3 };
	NumArray na(nums);
	na.update(0, 10);
	cout << na.sumRange(0, 2) << endl;
#endif
}