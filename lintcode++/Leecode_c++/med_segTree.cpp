#include "Interface.h"

using namespace SolutionSpace;

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
	while (i <= arr.size()) {
		sums[i] += diff;
		i += lowbit(i);
	}
}