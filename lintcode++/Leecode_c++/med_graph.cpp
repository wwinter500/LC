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
	return {};
}