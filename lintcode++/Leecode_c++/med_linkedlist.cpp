#include "Interface.h"
using namespace SolutionSpace;

RandomListNode* MedianQuest::copyRandomList(RandomListNode *head){
	//O(1) space version
	RandomListNode* dummy = new RandomListNode(0);
	RandomListNode* cp = head;
	while (cp != NULL) {
		RandomListNode* ncp = new RandomListNode(cp->label);
		RandomListNode* tmp = cp->next;
		cp->next = ncp;
		ncp->next = tmp;

		cp = cp->next->next;
	}

	cp = head;
	while (cp != NULL) {
		if(cp->random)
			cp->next->random = cp->random->next;

		cp = cp->next->next;
	}

	cp = head;
	RandomListNode* ncp = dummy;
	while (cp != NULL) {
		RandomListNode* tmp = cp->next->next;
		ncp->next = cp->next;
		cp->next = tmp;

		cp = cp->next;
		ncp = ncp->next;
		ncp->next = NULL;
	}

	return dummy->next;
}
