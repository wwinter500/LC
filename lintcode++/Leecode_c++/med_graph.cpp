#include "Interface.h"

using namespace SolutionSpace;
vector<vector<int>> connectedSet(vector<UndirectedGraphNode*>& nodes) {
	if (nodes.empty())
		return{};

	int idx = 0;
	unordered_map<UndirectedGraphNode*, int> match;
	for (UndirectedGraphNode* pt : nodes) {
		if (!match.count(pt)) {
			match[pt] = idx;
			parents.push_back(idx++);
		}
	}

	np = match.size();

	for (UndirectedGraphNode* pt : nodes) {
		for (UndirectedGraphNode* nei : pt->neighbors) {
			Union(match[pt], match[nei]);
		}
	}

	unordered_map<int, set<int>> reorg;
	for (auto p : match) {
		int ap = Find(match[p.first]);

		reorg[ap].insert(p.first->label);
	}

	vector<vector<int>> res;
	for (auto st : reorg) {
		vector<int> vec;
		for (int v : st.second) {
			vec.push_back(v);
		}

		res.push_back(vec);
	}
	return res;
}

vector<int> MedianQuest::findOrder(int numCourses, vector<pair<int, int>> &prerequisites){
	if(numCourses == 0 || prerequisites.empty())
		return {};
	
	unordered_map<int, unordered_set<int>> indegree;
	unordered_map<int, unordered_set<int>> outdegree;
	for (auto p : prerequisites) {
		indegree[p.first].insert(p.second);
		outdegree[p.second].insert(p.first);
	}

	vector<unordered_set<int>> seq;
	unordered_set<int> st;
	for (int i = 0; i < numCourses; ++i) {
		if (!indegree.count(i))
			st.insert(i);
	}
	seq.push_back(st);

	vector<int> ans;
	while (!seq.empty() && !seq.back().empty()) {
		unordered_set<int> tmp;
		for (auto cur : seq.back()) {
			for (auto nxt : outdegree[cur]) {
				indegree[nxt].erase(cur);
				if (indegree[nxt].empty()) {
					tmp.insert(nxt);
					indegree.erase(nxt);
				}
			}

			outdegree.erase(cur);
		}

		seq.push_back(tmp);
	}

	for (auto st : seq) {
		for (auto v : st)
			ans.push_back(v);
	}

	if (ans.size() != numCourses)
		return {};

	return ans;
}