#include "Interface.h"
using namespace SolutionSpace;

Interface::Interface() {
	questions[638] = 11;
	questions[626] = 12;

	questions[978] = 21;
	questions[1045] = 22;
	questions[401] = 23;
	questions[363] = 24;
	questions[406] = 25;
	questions[384] = 26;
	questions[512] = 27;
	questions[386] = 28;
	questions[668] = 29;
	questions[431] = 210;
	questions[840] = 211;
	
	questions[1798] = 31;
	questions[168] = 32;
	questions[435] = 33;
	questions[629] = 34;
	questions[465] = 35;
	questions[132] = 36;
	questions[635] = 37;
	questions[634] = 39;
	
	questions[40001] = 41;
	questions[40002] = 42;
}

Interface::~Interface() {};

void Interface::call(int quest) {
	if (!questions.count(quest)) {
		cout << "Did not record this question" << endl;
		return;
	}

	int cp = questions[quest];
	int level = 1;
	while (cp > 0) {
		level = (cp % 10);
		cp /= 10;
	}

	//question information	
	cout << "Question: " << quest << endl;
	cout << "Description:" << getQuestionInformation(quest) << endl;

	if (level == 1)
		cout << "Level: " << "EASY" << endl;
	else if (level == 2)
		cout << "Level: " << "MEDIAN" << endl;
	else if (level == 3)
		cout << "Level: " << "HARD" << endl;
	else if (level == 4)
		cout << "Level: " << "CONTEST" << endl;

	//run solution
	if (level == 1) {
		EasyQuest::run(quest);
	}
	else if (level == 2) {
		MedianQuest::run(quest);
	}
	else if (level == 3) {
		HardQuest::run(quest);
	}
	else if (level == 4)
		ContestQuest::run(quest);
}

string Interface::getQuestionInformation(int id) {
	string res = "";
	switch (id) {
	case 638:
		res = "check if string a can be replaced by b -- HIGH FREQ - LINKEDIN"; break;
	case 626:
		res = "check if rectange overlapped or not -- HIGH FREQ - AMAZON"; break;
	//median section
	case 132:
		res = "word search II"; break;
	case 978:
		res = "Calculation operator"; break;
	case 1045:
		res = "Partition Labels"; break;
	case 401:
		res = "kth smallest in sorted matrix"; break;
	case 363:
		res = "trap rainwater - 1D"; break;
	case 406:
		res = "Minimun size subarray sum"; break;
	case 384:
		res = "length of longest substring without duplicate character"; break;
	case 386:
		res = "length of longest substring with at most unique character"; break;
	case 512:
		res = "Decode ways"; break;
	case 431:
		res = "group of connection on Undirection Graph"; break;
	case 840:
		res = "range sum with mutable -- segment tree"; break;
	
	//hard section
	case 1798:
		res = "minimum cost to merge stones - dp"; break;
	case 168:
		res = "burst balloons - dp"; break;
	case 435:
		res = "post office problem - serials dp"; break;
	case 629:
		res = "minimun spanning tree"; break;
	case 465:
		res = "kth sum within two sorted array"; break;
	case 668:
		res = "longest subseq of palindron - range dp"; break;
	case 635:
		res = "boggle game -- trie tree"; break;
	case 634:
		res = "find all words squares"; break;

	//contest section
	case 40001:
		res = "play games"; break;
	case 40002:
		res = "skip stones"; break;
	default:
		res = "Unkown ID";
		break;
	}

	return res;
}
