#include "Interface.h"
using namespace SolutionSpace;

///
int HardQuest::kthSmallestSum(vector<int> &A, vector<int> &B, int k) {
	if (A.empty() || B.empty() || k <= 0)
		return 0;

	int n = A.size(), m = B.size();
	priority_queue<vector<int>, vector<vector<int>>, greater<vector<int>>> pq;
	pq.push({ A[0] + B[0], 0, 0 });
	for (int i = 1; i < k; ++i) {
		int ax = pq.top()[1], bx = pq.top()[2];
		if (ax == 0 && bx < m - 1)
			pq.push({ A[ax] + B[bx + 1], ax, bx + 1 });
		if (ax < n - 1) {
			pq.push({ A[ax + 1] + B[bx], ax + 1, bx });
		}

		pq.pop();
	}

	return pq.top()[0];
}

///
vector<int> HardQuest::medianSlidingWindow(vector<int> &nums, int k) {
	vector<int> result;
	int n = nums.size();
	if (n == 0)
		return result;

	multiset<int> max, min;
	for (int i = 0; i < k; ++i)
		max.insert(nums[i]);

	for (int i = 0; i < k / 2; ++i) {
		min.insert(*max.rbegin());
		max.erase(max.lower_bound(*max.rbegin()));
	}

	for (int i = k; i < n; ++i) {
		result.push_back(*max.rbegin());
		if (max.find(nums[i - k]) != max.end()) {
			max.erase(max.find(nums[i - k]));
			max.insert(nums[i]);
		}
		else {
			min.erase(min.find(nums[i - k]));
			min.insert(nums[i]);
		}
		if (max.size() > 0 && min.size() > 0 && *max.rbegin() > *min.begin()) {
			int tmp = *max.rbegin();
			max.erase(max.lower_bound(*max.rbegin()));
			max.insert(*min.begin());
			min.erase(min.begin());
			min.insert(tmp);
		}
	}
	result.push_back(*max.rbegin());

	return result;
} 

///
int HardQuest::trapRainWater(vector<vector<int>> &heights) {
	//water flood to get diiference when first time flooded for each pixel
	if(heights.empty() || heights[0].empty())
		return 0;

	int ans = 0;
	int n = heights.size(), m = heights[0].size();
	vector<vector<bool>> vis(n, vector<bool>(m, false));
	priority_queue<vector<int>, vector<vector<int>>, greater<vector<int>>> pq;
	for (int i = 0; i < n; ++i) {
		for (int j = 0; j < m; ++j) {
			if (i == 0 || i == n - 1 || j == 0 || j == m - 1) {
				pq.push({ heights[i][j], i, j });
				vis[i][j] = true;
			}
		}
	}

	int level = 1;
	while (!pq.empty()) {
		auto hd = pq.top();
		pq.pop();
		while(hd[0] > level) {
			level++;
		}

		for (int i = 0; i < dirs4.size(); ++i) {
			int ny = hd[1] + dirs4[i][0];
			int nx = hd[2] + dirs4[i][1];

			if (ny >= 0 && ny < n && nx >= 0 && nx < m && vis[ny][nx] == false) {
				if (heights[ny][nx] < level)
					ans += level - heights[ny][nx];
				pq.push({ heights[ny][nx], ny, nx });
				vis[ny][nx] = true;
			}
		}
	}

	return ans;
}

///
int HardQuest::largestRectangleArea(vector<int> &height) {
	//version_1 
	if (height.empty())
		return 0;
	
	//monotonous stack
	int n = height.size();
	vector<int> lens(n, 1);
	stack<pair<int,int>> pre, post;

	for (int i = 0; i < n; ++i) {
		if (pre.empty() || height[i] > pre.top().first) {
			pre.push({ height[i], i});
			continue;
		}

		while (!pre.empty() && height[i] <= pre.top().first) {
			pre.pop();
		}

		if (pre.empty())
			lens[i] += i;
		else
			lens[i] += i - pre.top().second - 1;

		pre.push({ height[i], i });
	}

	for (int i = n - 1; i >= 0; --i) {
		if (post.empty() || height[i] > post.top().first) {
			post.push({ height[i], i });
			continue;
		}

		while (!post.empty() && height[i] <= post.top().first) {
			post.pop();
		}

		if (post.empty())
			lens[i] += n - 1 - i;
		else
			lens[i] += post.top().second - i - 1;

		post.push({ height[i], i});
	}


	int ans = 0;
	for (int i = 0; i < n; ++i) {
		ans = max(ans, height[i] * lens[i]);
	}

	return ans;
}

///
int largesthistRectangle(vector<int> &height) {
	int n = height.size();
	vector<int> lens(n, 1);
	stack<pair<int, int>> pre, post;

	for (int i = 0; i < n; ++i) {
		if (!pre.empty() && height[i] <= pre.top().first) {
			while (!pre.empty() && height[i] <= pre.top().first) {
				pre.pop();
			}

			if (pre.empty())
				lens[i] += i;
			else
				lens[i] += i - pre.top().second - 1;
		}

		pre.push({ height[i], i });
	}

	for (int i = n - 1; i >= 0; --i) {
		if (!post.empty() && height[i] <= post.top().first) {
			while (!post.empty() && height[i] <= post.top().first) {
				post.pop();
			}

			if (post.empty())
				lens[i] += n - 1 - i;
			else
				lens[i] += post.top().second - i - 1;
		}

		post.push({ height[i] , i });
	}

	int ans = 0;
	for (int i = 0; i < n; ++i) {
		ans = max(ans, lens[i] * height[i]);
	}

	return ans;
}
int HardQuest::maximalRectangle(vector<vector<bool>> &matrix) {
	if (matrix.empty() || matrix[0].empty())
		return 0;

	int n = matrix.size();
	int m = matrix[0].size();
	vector<vector<int>> sums(n, vector<int>(m, 0));
	for (int i = 0; i < n; ++i) {
		for (int j = 0; j < m; ++j) {
			if (i > 0 && matrix[i][j] == true && matrix[i - 1][j] == true) {
				sums[i][j] = sums[i - 1][j] + 1;
			}
			else
				sums[i][j] = matrix[i][j];
		}
	}

	for (int i = 0; i < n; ++i) {
		for (int j = 0; j < m; ++j) {
			cout << sums[i][j] << " ";
		}
		cout << endl;
	}

	int ans = 0;
	for (int i = n - 1; i >= 0; --i) {
		ans = max(ans, largesthistRectangle(sums[i]));
	}

	return ans;
}