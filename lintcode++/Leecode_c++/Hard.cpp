#include "Interface.h"
using namespace SolutionSpace;
//Union find
vector<int> parents;
int np;
int Find(int a) {
	int tmp = a;
	while (a != parents[a]) {
		a = parents[a];
	}

	while (tmp != parents[tmp]) {
		int tp = parents[tmp];
		parents[tmp] = a;
		tmp = tp;
	}

	return a;
}
bool Union(int a, int b) {
	int ap = Find(a);
	int bp = Find(b);

	if (ap != bp) {
		parents[ap] = bp;
		np--;
		return true;
	}

	return false;
}

//tritree
TrieNode* trie_root;
vector < vector<int>> dirs4 = { {0, 1},{0, -1},{1, 0},{-1, 0} };
vector < vector<int>> dirs8 = { {0, 1},{0, -1},{1, 0},{-1, 0},{1, -1},{-1, 1},{1, 1},{-1, -1} };

///
int HardQuest::maxCoins(vector<int> &nums) {
	if (nums.empty())
		return 0;

	vector<int> nnums;
	nnums.push_back(1);
	for (int v : nums)
		nnums.push_back(v);
	nnums.push_back(1);
	

	int n = nnums.size();
	vector<vector<int>> dp(n, vector<int>(n + 2, 0));
	
	//dp[i][j] means maximun coins get from i + 1 to j - 1
	for (int i = n - 3; i >= 0; --i) {
		for (int j = i + 2; j < n; ++j) {
			int maxv = INT_MIN;
			for (int k = i + 1; k < j; ++k) {
				maxv = max(maxv, dp[i][k] + dp[k][j] + nnums[i] * nnums[k] * nnums[j]);
			}

			dp[i][j] = maxv;
		}
	}

	return dp[0][n - 1];
}

///
int helper(vector<int> stones, int left, int right, int k, unordered_map<pair<int, int>, int> &ump) {
	//Incorrect solution as memorized searching
	if (left > right)
		return 0;

	//if (ump.count({left,right}))
	//	return ump[{left, right}];
	
	if (right - left + 1 <= k) {
		int sum = 0;
		for (int i = left; i <= right; ++i)
			sum += stones[i];
		
		//ump.insert({ {left, right}, sum });
		return sum;
	}

	int minv = INT_MAX;
	for (int s = right - left; s >= k; --s) {
		int start = left, end = start + s - 1;
		while (end <= right) {
			int tmp = helper(stones, left, start - 1, k, ump) +
				helper(stones, start, end, k, ump) +
				helper(stones, end + 1, right, k, ump);

			start++;
			end++;
			if (tmp != -1 && tmp < minv)
				minv = tmp;
		}
	}

	//ump.insert({ {left, right}, minv });
	return minv;
}
int HardQuest::mergeStones(vector<int> &stones, int K) {
	if (stones.empty() || K <= 1)
		return 0;

	//check if input valid to generate final 1 result
	int n = stones.size();
	if (n % (K - 1) != 1)
		return 0;

	vector<int> sums(n + 1, 0);
	for (int i = 1; i <= n; ++i) {
		sums[i] = sums[i - 1] + stones[i - 1];
	}

	vector<vector<int>> dp(n, vector<int>(n, 0));
	for (int len = K; len <= n; ++len) {
		for (int i = 0; i + len < n; ++i) {
			int j = i + len - 1;
			dp[i][j] = INT_MAX;
			for (int t = i; t < j; t += K - 1) {
				dp[i][j] = min(dp[i][j], dp[i][t] + dp[t + 1][j]);
			}

			if ((j - i) % (K - 1) == 0)
				dp[i][j] += sums[j + 1] - sums[i];
		}
	}

	return dp[0][n - 1];
}

///
int HardQuest::postOffice(vector<int> &A, int k) {
	if(A.empty() || k <= 0)
		return 0;

	int n = A.size();
	vector<vector<int>> dp(n, vector<int>(n, 0));

	return dp[0][n - 1];
}

///
vector<Connection> HardQuest::lowestCost(vector<Connection>& connections)
{
	//minimun spanning tree
	if (connections.empty())
		return {};
	
	vector<Connection> ans;
	int idx = 0;
	unordered_map<string, int> cities;
	map<int, set<vector<string>>> costs;
	unordered_map<string, Connection> mp;
	
	for (Connection con : connections) {
		if (con.city1 == con.city2)
			continue;

		if (!cities.count(con.city1)) {
			cities[con.city1] = idx++;
		}

		if (!cities.count(con.city2)) {
			cities[con.city2] = idx++;
		}

		vector<string> p = { con.city1, con.city2 };
		costs[con.cost].insert(p);
		
		string ns = con.city1 + "_" + con.city2;
		mp[ns] = con;
	}

	np = idx;
	for (int i = 0; i < np; ++i) {
		parents.push_back(i);
	}

	for (auto p : costs) {
		for (vector<string> con : p.second) {
			if (Union(cities[con[0]], cities[con[1]]))
				ans.push_back(mp[con[0] + "_" + con[1]]);
		}
	}

	if (np > 1)
		return {};

	return ans;
}

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
void insertToTrieTree(string str) {
	TrieNode* cp = trie_root;
	for (int i = 0; i < str.size(); ++i) {
		if (cp->child[str[i] - 'a'] == NULL)
			cp->child[str[i] - 'a'] = new TrieNode();

		cp = cp->child[str[i] - 'a'];
	}

	cp->isEnd = true;
	cp->str = str;
}
void searchTrieTree(vector<vector<char>> &board, vector<vector<bool>> &visited, vector<string> &ans, TrieNode* nn, int y, int x) {
	if (nn->str != "") {
		ans.push_back(nn->str);
		nn->str = "";
	}

	for (int i = 0; i < dirs4.size(); ++i) {
		int ny = y + dirs4[i][0], nx = x + dirs4[i][1];
		if (ny >= 0 && ny < board.size() && nx >= 0 && nx < board[0].size() && !visited[ny][nx] && nn->child[board[ny][nx] - 'a'] != NULL) {
			visited[ny][nx] = true;
			searchTrieTree(board, visited, ans, nn->child[board[ny][nx] - 'a'], ny, nx);
			visited[ny][nx] = false;
		}
	}
}
vector<string> HardQuest::wordSearchII(vector<vector<char>> &board, vector<string> &words) {
	trie_root = new TrieNode();
	vector<string> ans;
	vector<vector<bool>> visited(board.size(), vector<bool>(board[0].size(), false));
	
	for (int i = 0; i < board.size(); ++i) {
		for (int j = 0; j < board[0].size(); ++j) {
			if (trie_root->child[board[i][j] - 'a']) {
				searchTrieTree(board, visited, ans, trie_root->child[board[i][j] - 'a'], i, j);
			}
		}
	}

	return ans;
}

///