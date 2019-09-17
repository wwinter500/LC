#include "Interface.h"
using namespace SolutionSpace;

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
bool search(vector<vector<char>> &board, vector<vector<bool>> &visited, TrieNode* nn, int y, int x) {
	visited[y][x] = true;
	if (nn->str != "") {
		return true;
	}

	for (auto dir : dirs4) {
		int ny = y + dir[0], nx = x + dir[1];
		if (ny >= 0 && ny < board.size() && nx >= 0 && nx < board[0].size() && visited[ny][nx] == false && nn->child[board[ny][nx] - 'a']) {
			if (search(board, visited, nn->child[board[ny][nx] - 'a'], ny, nx)) {
				return true;
			}
		}
	}

	visited[y][x] = false;
	return false;
}
int HardQuest::boggleGame(vector<vector<char>> &board, vector<string> &words) {
	int n = board.size();
	int m = board[0].size();

	trie_root = new TrieNode();
	vector<vector<bool>> visited(n, vector<bool>(m, false));
	for (string str : words) {
		insertToTrieTree(str);
	}

	int ans = 0;
	for (int i = 0; i < n; ++i) {
		for (int j = 0; j < m; ++j) {
			if (trie_root->child[board[i][j] - 'a']) {
				if (search(board, visited, trie_root->child[board[i][j] - 'a'], i, j))
					ans += 1;
			}
		}
	}

	return ans;
}

///
vector<vector<string>> HardQuest::wordSquares(vector<string> &words) {
	return{};
}